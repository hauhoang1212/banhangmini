using Quanlibanhang.Data;
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
            // Tổng tiền chỉ hiển thị, không cho nhập
            txtTotal.Enabled = false;

            // Combo không cho nhập tay (chỉ chọn)
            cboProduct.DropDownStyle = UIDropDownStyle.DropDownList;
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
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            string customer = (txtCustomer.Text ?? "").Trim();
            string phone = (txtPhone.Text ?? "").Trim();
            decimal total = cart.Sum(x => x.LineTotal);

            // Validate đơn giản
            if (string.IsNullOrWhiteSpace(customer))
            {
                MessageBox.Show("Vui lòng nhập tên khách!");
                txtCustomer.Focus();
                return;
            }

            // Mở kết nối để dùng transaction
            db.OpenConnection();
            var conn = db.GetConnection();

            using (var tran = conn.BeginTransaction())
            {
                try
                {
                    // 1) Insert Orders -> lấy OrderId
                    long orderId;
                    using (var cmd = new SQLiteCommand(@"
INSERT INTO Orders(CustomerName, Phone, TotalAmount)
VALUES(@CustomerName, @Phone, @TotalAmount);
SELECT last_insert_rowid();
", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customer);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@TotalAmount", (double)total);

                        object scalar = cmd.ExecuteScalar();
                        orderId = Convert.ToInt64(scalar);
                    }

                    // 2) Với từng dòng giỏ: check&trừ tồn + insert OrderDetails
                    foreach (var line in cart)
                    {
                        // 2.1) Trừ tồn kho có điều kiện Stock >= Qty
                        using (var cmdStock = new SQLiteCommand(@"
UPDATE Products
SET Stock = Stock - @Qty
WHERE ProductId = @ProductId AND Stock >= @Qty;
", conn, tran))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", line.Qty);
                            cmdStock.Parameters.AddWithValue("@ProductId", line.ProductId);

                            int affected = cmdStock.ExecuteNonQuery();
                            if (affected == 0)
                                throw new Exception($"Không đủ tồn kho khi thanh toán: {line.ProductName} ({line.ProductId})");
                        }

                        // 2.2) Insert OrderDetails (ProductId TEXT)
                        using (var cmdDetail = new SQLiteCommand(@"
INSERT INTO OrderDetails(OrderId, ProductId, Quantity, UnitPrice, LineTotal)
VALUES(@OrderId, @ProductId, @Quantity, @UnitPrice, @LineTotal);
", conn, tran))
                        {
                            cmdDetail.Parameters.AddWithValue("@OrderId", orderId);
                            cmdDetail.Parameters.AddWithValue("@ProductId", line.ProductId); // TEXT
                            cmdDetail.Parameters.AddWithValue("@Quantity", line.Qty);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", (double)line.UnitPrice);
                            cmdDetail.Parameters.AddWithValue("@LineTotal", (double)line.LineTotal);

                            cmdDetail.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();

                    MessageBox.Show($"Thanh toán thành công!\nMã đơn: {orderId}");

                    // Clear giỏ + UI
                    cart.Clear();
                    RefreshCartGrid();
                    UpdateTotalUI();

                    // Reload product list + autocomplete
                    LoadActiveProductsToCombo();
                    LoadCustomerAutoComplete();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                    Utils.LogDB("btnCheckout_Click", ex);
                }
                finally
                {
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

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    sfd.FileName = $"HoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    sb.AppendLine("=========== HOA DON BAN HANG ===========");
                    sb.AppendLine($"Ngay: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
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
    }
}
