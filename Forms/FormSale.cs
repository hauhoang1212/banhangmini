using Quanlibanhang.Data;
using Quanlibanhang.Forms;
using Quanlibanhang.Helpers;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class FormSale : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();

        // Cache sản phẩm active
        private DataTable dtProducts = null;

        // Giỏ hàng (memory)
        private class CartLine
        {
            public string ProductId { get; set; }     // TEXT: SP01...
            public string ProductName { get; set; }
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal LineTotal => UnitPrice * Qty;
        }

        private readonly List<CartLine> cart = new List<CartLine>();

        public FormSale()
        {
            InitializeComponent();

            SetupUI();
            InitGrid();
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            LoadActiveProductsToCombo();
            LoadCustomerAutoComplete();

            nudQuantity.Minimum = 1;
            nudQuantity.Value = 1;

            RefreshCartGrid();
            UpdateTotalUI();
        }

        // =========================
        // UI INIT
        // =========================
        private void SetupUI()
        {
            txtTotal.Enabled = false;

            // 1. Cho phép gõ văn bản vào ComboBox
            cboProduct.DropDownStyle = UIDropDownStyle.DropDown;

            // 2. Bật chế độ tự động gợi ý và hoàn thiện từ của SunnyUI
            cboProduct.ShowFilter = true;
            cboProduct.FilterMaxCount = 50;

            // === MỚI: Cấu hình tìm kiếm không phân biệt hoa thường ===
            cboProduct.FilterIgnoreCase = true;
        }

        private void InitGrid()
        {
            // Cho tick checkbox cChose giống FormProduct/FormCategory
            uiDataGridView1.ReadOnly = false;
            foreach (DataGridViewColumn col in uiDataGridView1.Columns)
            {
                if (col.Name != "cChose") col.ReadOnly = true;
            }

            // Format hiển thị tiền
            uiDataGridView1.Columns["cUnitPrice"].DefaultCellStyle.Format = "N0";
            uiDataGridView1.Columns["cLineTotal"].DefaultCellStyle.Format = "N0";
            uiDataGridView1.Columns["cQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        // =========================
        // LOAD PRODUCTS (IsActive=1)
        // =========================
        private void LoadActiveProductsToCombo()
        {
            try
            {
                // Đúng cột theo DB bạn gửi
                string sql = @"
SELECT ProductId, Name, Price, Stock
FROM Products
WHERE IFNULL(IsActive,1)=1
ORDER BY Name;
";
                dtProducts = db.ExecuteQuery(sql);

                // Designer có Items.AddRange -> ta set DataSource để dùng DB
                cboProduct.DataSource = null;
                cboProduct.Items.Clear();

                cboProduct.DataSource = dtProducts;
                cboProduct.DisplayMember = "Name";      // tên SP
                cboProduct.ValueMember = "ProductId";   // TEXT PK

                cboProduct.SelectedIndex = dtProducts.Rows.Count > 0 ? 0 : -1;
                btnAddToCart.Enabled = dtProducts.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm: " + ex.Message);
                Utils.LogDB("LoadActiveProductsToCombo", ex);
            }
        }

        // =========================
        // AUTOCOMPLETE CUSTOMER
        // =========================
        private void LoadCustomerAutoComplete()
        {
            try
            {
                string sql = @"
                                SELECT DISTINCT IFNULL(CustomerName,'') AS CustomerName
                                FROM Orders
                                WHERE TRIM(IFNULL(CustomerName,'')) <> ''
                                ORDER BY CustomerName;
                                ";
                DataTable dt = db.ExecuteQuery(sql);

                var ac = new AutoCompleteStringCollection();
                foreach (DataRow r in dt.Rows)
                {
                    ac.Add(r["CustomerName"].ToString());
                }

                txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomer.AutoCompleteCustomSource = ac;
            }
            catch (Exception ex)
            {
                Utils.LogDB("LoadCustomerAutoComplete", ex);
            }
        }

        // =========================
        // ADD TO CART (check stock)
        // =========================
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedValue == null || dtProducts == null || dtProducts.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            string productId = cboProduct.SelectedValue.ToString(); // TEXT
            int qtyAdd = (int)nudQuantity.Value;

            // Tìm row trong dtProducts
            string filter = $"ProductId = '{productId.Replace("'", "''")}'";
            DataRow[] rows = dtProducts.Select(filter);
            if (rows.Length == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                return;
            }

            string productName = rows[0]["Name"].ToString();
            decimal unitPrice = Convert.ToDecimal(rows[0]["Price"]);
            int stockDb = Convert.ToInt32(rows[0]["Stock"]);

            // Tổng số lượng của sản phẩm này hiện có trong giỏ
            int qtyInCart = cart.Where(x => x.ProductId == productId).Sum(x => x.Qty);

            // Check tồn kho trước khi add
            if (qtyInCart + qtyAdd > stockDb)
            {
                MessageBox.Show(
                    $"Không đủ tồn kho!\n" +
                    $"Tồn kho: {stockDb}\n" +
                    $"Đang có trong giỏ: {qtyInCart}\n" +
                    $"Bạn muốn thêm: {qtyAdd}"
                );
                return;
            }

            // Nếu đã có trong giỏ -> cộng số lượng
            var line = cart.FirstOrDefault(x => x.ProductId == productId);
            if (line == null)
            {
                cart.Add(new CartLine
                {
                    ProductId = productId,
                    ProductName = productName,
                    Qty = qtyAdd,
                    UnitPrice = unitPrice
                });
            }
            else
            {
                line.Qty += qtyAdd;
            }

            RefreshCartGrid();
            UpdateTotalUI();
            // === MỚI: Reset ComboBox về trạng thái rỗng ===
            cboProduct.SelectedIndex = -1;  // Bỏ chọn item hiện tại
            cboProduct.Text = string.Empty; // Xóa chữ trên ô nhập
            nudQuantity.Value = 1;          // Reset số lượng về 1
            cboProduct.Focus();             // Đưa con trỏ chuột về ô tìm kiếm để nhập tiếp
        }

        // =========================
        // REMOVE FROM CART (tick checkbox)
        // =========================
        private void btnCart_Click(object sender, EventArgs e)
        {
            var removeIds = new List<string>();

            foreach (DataGridViewRow row in uiDataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cChose"].Value != null
                                 && Convert.ToBoolean(row.Cells["cChose"].Value);

                if (!isChecked) continue;

                // ProductId ta lưu trong Tag
                string pid = row.Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(pid))
                    removeIds.Add(pid);
            }

            if (removeIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tick chọn dòng muốn xóa khỏi giỏ!");
                return;
            }

            foreach (var pid in removeIds.Distinct())
            {
                cart.RemoveAll(x => x.ProductId == pid);
            }

            RefreshCartGrid();
            UpdateTotalUI();
        }

        // =========================
        // CHECKOUT: Orders + OrderDetails, minus Stock (TRANSACTION)
        // =========================
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customer = (txtCustomer.Text ?? "").Trim();
            string phone = (txtPhone.Text ?? "").Trim();
            decimal total = cart.Sum(x => x.LineTotal);

            if (string.IsNullOrWhiteSpace(customer))
            {
                MessageBox.Show("Vui lòng nhập tên khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomer.Focus();
                return;
            }

            // 1. Mở kết nối ngoài cùng
            db.CloseConnection();
            db.OpenConnection();
            var conn = db.GetConnection();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // 2. Sử dụng Transaction để đảm bảo an toàn dữ liệu
            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    // Bước 1: Lưu đơn hàng tổng (Orders)
                    long orderId;
                    string sqlOrder = @"
                INSERT INTO Orders(CustomerName, Phone, TotalAmount, OrderDate) 
                VALUES(@CustomerName, @Phone, @TotalAmount, @Date);
                SELECT last_insert_rowid();";

                    using (var cmd = new SQLiteCommand(sqlOrder, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customer);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@TotalAmount", (double)total);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        orderId = Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    // Bước 2: Lưu chi tiết và trừ tồn kho cho từng sản phẩm
                    foreach (var line in cart)
                    {
                        // Cập nhật tồn kho (Chỉ trừ nếu đủ hàng)
                        string sqlStock = "UPDATE Products SET Stock = Stock - @Qty WHERE ProductId = @Pid AND Stock >= @Qty";
                        using (var cmdStock = new SQLiteCommand(sqlStock, conn, tran))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", line.Qty);
                            cmdStock.Parameters.AddWithValue("@Pid", line.ProductId);

                            int affected = cmdStock.ExecuteNonQuery();
                            if (affected == 0)
                                throw new Exception($"Sản phẩm '{line.ProductName}' không đủ tồn kho!");
                        }

                        // Lưu chi tiết đơn hàng
                        string sqlDetail = @"
                    INSERT INTO OrderDetails(OrderId, ProductId, Quantity, UnitPrice, LineTotal) 
                    VALUES(@OrderId, @ProductId, @Quantity, @UnitPrice, @LineTotal)";

                        using (var cmdDetail = new SQLiteCommand(sqlDetail, conn, tran))
                        {
                            cmdDetail.Parameters.AddWithValue("@OrderId", orderId);
                            cmdDetail.Parameters.AddWithValue("@ProductId", line.ProductId);
                            cmdDetail.Parameters.AddWithValue("@Quantity", line.Qty);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", (double)line.UnitPrice);
                            cmdDetail.Parameters.AddWithValue("@LineTotal", (double)line.LineTotal);

                            cmdDetail.ExecuteNonQuery();
                        }
                    }

                    // Hoàn tất giao dịch
                    tran.Commit();
                    // GỌI HÀM LƯU EXCEL NGAY TẠI ĐÂY
                    SaveToExcel(orderId, customer, phone, total);
                    MessageBox.Show($"Thanh toán thành công!\nMã đơn: {orderId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Cập nhật UI sau khi thành công
                    cart.Clear();
                    RefreshCartGrid();
                    UpdateTotalUI();
                    txtCustomer.Clear();
                    txtPhone.Clear();

                    // Reload dữ liệu mới nhất (để cập nhật Stock mới trên màn hình)
                    LoadActiveProductsToCombo();
                    LoadCustomerAutoComplete();
                }
                catch (Exception ex)
                {
                    // Hủy bỏ mọi thay đổi nếu có lỗi
                    tran.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utils.LogDB("btnCheckout_Click", ex);
                }
                finally
                {
                    // LUÔN LUÔN đóng kết nối ở đây
                    db.CloseConnection();
                }
            }
        }
        // =========================
        // EXPORT TXT (giỏ hiện tại)
        // =========================
        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống, không có gì để xuất!");
                return;
            }

            try
            {
                string customer = (txtCustomer.Text ?? "").Trim();
                string phone = (txtPhone.Text ?? "").Trim();
                decimal total = cart.Sum(x => x.LineTotal);

                // Lấy tên nhân viên từ Session
                string staffName = !string.IsNullOrEmpty(Session.FullName) ? Session.FullName : "Chưa xác định";

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    sfd.FileName = $"HoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    sb.AppendLine("=========== HOA DON BAN HANG ===========");
                    sb.AppendLine($"Ngay: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine($"Nhan vien: {staffName}");
                    sb.AppendLine($"Ten khach: {customer}");
                    sb.AppendLine($"SDT: {phone}");
                    sb.AppendLine("----------------------------------------");
                    sb.AppendLine($"{"San pham",-28} {"SL",4} {"Don gia",12} {"Thanh tien",14}");
                    sb.AppendLine("----------------------------------------");

                    foreach (var line in cart)
                    {
                        sb.AppendLine($"{Cut(line.ProductName, 28),-28} {line.Qty,4} {line.UnitPrice,12:N0} {line.LineTotal,14:N0}");
                    }

                    sb.AppendLine("----------------------------------------");
                    sb.AppendLine($"TONG TIEN: {total:N0}");
                    sb.AppendLine("========================================");

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                }

                MessageBox.Show("Xuất hóa đơn TXT thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất TXT: " + ex.Message);
                Utils.LogDB("btnExportTxt_Click", ex);
            }
        }

        private static string Cut(string s, int maxLen)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Length <= maxLen ? s : s.Substring(0, maxLen - 1) + "…";
        }

        // =========================
        // GRID RENDER + TOTAL UI
        // =========================
        private void RefreshCartGrid()
        {
            uiDataGridView1.Rows.Clear();

            int stt = 1;
            foreach (var line in cart)
            {
                int idx = uiDataGridView1.Rows.Add(
                    false,                 // cChose
                    stt++,                 // cSTT
                    line.ProductName,      // cProductName
                    line.Qty,              // cQty
                    line.UnitPrice,        // cUnitPrice
                    line.LineTotal         // cLineTotal
                );

                // lưu ProductId để xóa theo tick checkbox
                uiDataGridView1.Rows[idx].Tag = line.ProductId;
            }
        }

        private void UpdateTotalUI()
        {
            decimal total = cart.Sum(x => x.LineTotal);
            txtTotal.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudQuantity.Value = 1;
        }
        private void SaveToExcel(long orderId, string customer, string phone, decimal total)
        {
            try
            {
                // 1. Xác định thư mục và tên file theo ngày (ví dụ: Orders_2026_01_07.csv)
                string folderPath = Path.Combine(Application.StartupPath, "HistoryOrders");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string fileName = $"Orders_{DateTime.Now:yyyy_MM_dd}.csv";
                string filePath = Path.Combine(folderPath, fileName);

                bool isNewFile = !File.Exists(filePath);

                // 2. Chuẩn bị dữ liệu: Gộp tất cả sản phẩm thành 1 chuỗi để lưu trên 1 hàng
                string productDetails = string.Join(" | ", cart.Select(x => $"{x.ProductName}(x{x.Qty})"));

                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    // Nếu là file mới, tạo dòng tiêu đề (Header)
                    if (isNewFile)
                    {
                        sw.WriteLine("Mã Đơn,Thời Gian,Nhân Viên,Khách Hàng,SĐT,Danh Sách Sản Phẩm,Tổng Tiền");
                    }

                    // Ghi dữ liệu đơn hàng trên 1 dòng duy nhất
                    // Dùng dấu phẩy để ngăn cách các cột cho Excel
                    sw.WriteLine($"{orderId},{DateTime.Now:HH:mm:ss},\"{Session.FullName}\",\"{customer}\",\"{phone}\",\"{productDetails}\",{total.ToString("0")}");
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("SaveToExcel_Error", ex);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím nhấn có phải là số không, và không phải phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ phím vừa nhấn (không cho nhập vào ô)
            }
        }
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem phím nhấn có phải là số không, và không phải phím điều khiển (như Backspace)
            // 1. Đặt giới hạn chỉ được nhập 10 ký tự (nếu chưa chỉnh trong Properties)
            txtPhone.MaxLength = 10;

            // 2. (Tùy chọn) Kiểm tra nếu người dùng Paste chữ vào thì xóa đi
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                // Xóa các ký tự không phải số
                txtPhone.Text = System.Text.RegularExpressions.Regex.Replace(txtPhone.Text, "[^0-9]", "");
                // Đưa con trỏ về cuối dòng
                txtPhone.SelectionStart = txtPhone.Text.Length;
            }

            // 3. Logic kiểm tra hợp lệ (Ví dụ: Đổi màu nền nếu chưa đủ 10 số)
            if (txtPhone.Text.Length != 10)
            {
                // Chưa đủ 10 số -> Hiện màu đỏ hoặc báo lỗi nhẹ
                txtPhone.BackColor = Color.MistyRose;
            }
            else
            {
                // Đã đủ 10 số -> Màu trắng bình thường
                txtPhone.BackColor = Color.White;
            }
        }
    }
}
