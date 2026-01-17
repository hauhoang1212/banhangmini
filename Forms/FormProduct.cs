using Quanlibanhang.Data;
using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Quanlibanhang.Forms
{
    public partial class FormProduct : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();
        private DataTable dtCategories = null;
        private bool isAdding = false;

        public FormProduct()
        {
            InitializeComponent();

            LoadCategories();   // ComboBox
            LoadProducts();     // DataGridView

            // Cho phép tick checkbox cChose (giống FormCategory)
            dgvProduct.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                if (col.Name != "cChose")
                    col.ReadOnly = true;
            }

            // Gắn sự kiện (nếu bạn chưa gắn trong Designer)
            txtSearchh.TextChanged += txtSearchh_TextChanged;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            dgvProduct.CellClick += dgvProduct_CellClick;

            // Mặc định: chưa bấm Thêm/Sửa => khóa + màu xám
            SetEditMode(false);
        }

        // =========================
        // UI STATE: khóa/mở + đổi màu xám/trắng
        // =========================
        private void SetEditMode(bool isEdit)
        {
            // Input
            txtProductID.Enabled = isEdit;
            txtNameProduct.Enabled = isEdit;
            txtPrice.Enabled = isEdit;
            txtStock.Enabled = isEdit;
            txtDescription.Enabled = isEdit;

            // Selectors
            cboCategory.Enabled = isEdit;
            chkIsActive.Enabled = isEdit;

            // BackColor
            Color bg = isEdit ? Color.White : Color.Gainsboro;

            txtProductID.BackColor = bg;
            txtNameProduct.BackColor = bg;
            txtPrice.BackColor = bg;
            txtStock.BackColor = bg;
            txtDescription.BackColor = bg;

            // ComboBox cũng đổi nền cho dễ nhìn
            cboCategory.BackColor = bg;
        }

        // =========================
        // LOAD CATEGORIES
        // =========================
        private void LoadCategories()
        {
            try
            {
                string sql = "SELECT CategoryId, Name, IFNULL(Description,'') AS Description FROM Categories";
                dtCategories = db.ExecuteQuery(sql);

                cboCategory.DataSource = dtCategories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "CategoryId";
                if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadCategories: " + ex.Message);
                Utils.LogDB("LoadCategories", ex);
            }
        }

        // =========================
        // AUTO DESCRIPTION BY CATEGORY (FIX: KHÔNG DÙNG SelectedIndex)
        // =========================
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtCategories == null || cboCategory.SelectedValue == null) return;

                string catId = cboCategory.SelectedValue.ToString().Replace("'", "''");
                DataRow[] rows = dtCategories.Select($"CategoryId = '{catId}'");
                if (rows.Length > 0)
                    txtDescription.Text = rows[0]["Description"].ToString();
            }
            catch
            {
                // bỏ qua lỗi binding thời điểm load
            }
        }

        // =========================
        // LOAD PRODUCTS (JOIN Categories để lấy CategoryName)
        // =========================
        private void LoadProducts(string keyword = "")
        {
            try
            {
                dgvProduct.Rows.Clear();

                // --- CÂU SQL GIỮ NGUYÊN LEFT JOIN ---
                // Lấy p.CategoryID để xử lý logic (nếu cần)
                // Lấy c.Name và đặt tên giả (Alias) là CategoryName để hiển thị lên lưới
                string sql = @"
                    SELECT 
                        p.ProductId,
                        p.Name,
                        p.Price,
                        p.CategoryID, 
                        c.Name AS CategoryName, 
                        p.Description,
                        p.Stock,
                        p.IsActive
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    WHERE 1=1
                    ";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Tìm kiếm theo tên sản phẩm hoặc mã sản phẩm
                    keyword = keyword.Replace("'", "''");
                    sql += $" AND (p.Name LIKE '%{keyword}%' OR p.ProductId LIKE '%{keyword}%')";
                }

                // Sắp xếp
                sql += " ORDER BY p.ProductId ASC";

                DataTable dt = db.ExecuteQuery(sql);

                int stt = 1;
                foreach (DataRow r in dt.Rows)
                {
                    int stock = 0;
                    int.TryParse(r["Stock"]?.ToString(), out stock);

                    // Kiểm tra null cho CategoryName (đề phòng trường hợp ID không khớp hoặc null)
                    string catName = r["CategoryName"] != DBNull.Value ? r["CategoryName"].ToString() : "Chưa phân loại";

                    int rowIndex = dgvProduct.Rows.Add(
                        false,                               // cChose
                        stt++,                               // cSTT
                        r["ProductId"]?.ToString(),          // cProductID
                        r["Name"]?.ToString(),               // cName
                        r["Price"]?.ToString(),              // cPrice
                        catName,                             // cCategory (Lấy từ bảng Categories)
                        r["Description"]?.ToString(),        // cDSC
                        r["Stock"]?.ToString(),              // cStock
                        Convert.ToInt32(r["IsActive"]) == 1  // cIsActive
                    );

                    // ADVANCED: đổi màu dòng Stock < 5
                    if (stock < 5)
                    {
                        dgvProduct.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadProducts: " + ex.Message);
                Utils.LogDB("LoadProducts", ex);
            }
        }

        // =========================
        // CLICK DGV -> ĐỔ DỮ LIỆU LÊN FORM
        // =========================
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProduct.Rows[e.RowIndex];

            txtProductID.Text = row.Cells["cProductID"].Value?.ToString() ?? "";
            txtNameProduct.Text = row.Cells["cName"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["cPrice"].Value?.ToString() ?? "";
            txtStock.Text = row.Cells["cStock"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["cDSC"].Value?.ToString() ?? "";
            chkIsActive.Checked = row.Cells["cIsActive"].Value != null && Convert.ToBoolean(row.Cells["cIsActive"].Value);

            // set combo theo tên loại
            string catName = row.Cells["cCategory"].Value?.ToString() ?? "";
            if (!string.IsNullOrWhiteSpace(catName))
                cboCategory.Text = catName;
        }

        // =========================
        // ADD
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;

            ClearInput();
            SetEditMode(true);

            txtProductID.Enabled = true;
            txtProductID.BackColor = Color.White;
            txtProductID.Focus();
        }

        // =========================
        // EDIT (tick checkbox)
        // =========================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;
                bool isChecked = row.Cells["cChose"].Value != null && Convert.ToBoolean(row.Cells["cChose"].Value);
                if (isChecked)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng tích chọn 1 dòng để sửa!");
                return;
            }

            // Mở form để sửa
            SetEditMode(true);

            txtProductID.Text = selectedRow.Cells["cProductID"].Value?.ToString() ?? "";
            txtNameProduct.Text = selectedRow.Cells["cName"].Value?.ToString() ?? "";
            txtPrice.Text = selectedRow.Cells["cPrice"].Value?.ToString() ?? "";
            txtStock.Text = selectedRow.Cells["cStock"].Value?.ToString() ?? "";
            txtDescription.Text = selectedRow.Cells["cDSC"].Value?.ToString() ?? "";
            chkIsActive.Checked = selectedRow.Cells["cIsActive"].Value != null && Convert.ToBoolean(selectedRow.Cells["cIsActive"].Value);

            cboCategory.Text = selectedRow.Cells["cCategory"].Value?.ToString() ?? "";

            // Không cho sửa ID
            txtProductID.Enabled = false;
            txtProductID.BackColor = Color.Gainsboro;

            isAdding = false;
        }

        // =========================
        // SAVE (THÊM / SỬA)
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. VALIDATE DỮ LIỆU ĐẦU VÀO
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Vui lòng nhập ID sản phẩm!");
                txtProductID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameProduct.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                txtNameProduct.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                txtPrice.Focus();
                return;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out int stock))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!");
                txtStock.Focus();
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!");
                return;
            }

            // 2. CHUẨN BỊ DỮ LIỆU
            string productId = txtProductID.Text.Trim().Replace("'", "''");
            string name = txtNameProduct.Text.Trim().Replace("'", "''");
            string categoryId = cboCategory.SelectedValue.ToString().Replace("'", "''");
            string categoryName = cboCategory.Text; // Lấy tên loại để ghi Log
            string desc = txtDescription.Text.Trim().Replace("'", "''");
            int isActive = chkIsActive.Checked ? 1 : 0;
            string priceSql = price.ToString(System.Globalization.CultureInfo.InvariantCulture);

            try
            {
                string sql;
                if (isAdding)
                {
                    // KIỂM TRA TRÙNG ID TRƯỚC KHI THÊM
                    string checkSql = $"SELECT COUNT(*) FROM Products WHERE ProductId='{productId}'";
                    DataTable dtCheck = db.ExecuteQuery(checkSql);
                    if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                    {
                        MessageBox.Show("ID sản phẩm đã tồn tại!");
                        return;
                    }

                    sql = $@"INSERT INTO Products (ProductId, Name, Price, CategoryID, Description, Stock, IsActive)
                     VALUES ('{productId}', '{name}', {priceSql}, '{categoryId}', '{desc}', {stock}, {isActive});";
                }
                else
                {
                    sql = $@"UPDATE Products SET Name='{name}', Price={priceSql}, Stock={stock}, 
                     CategoryID='{categoryId}', Description='{desc}', IsActive={isActive}
                     WHERE ProductId='{productId}';";
                }

                // 3. THỰC THI VÀ GHI NHẬT KÝ (LOG)
                if (db.ExecuteNonQuery(sql))
                {
                    string action = isAdding ? "THÊM MỚI" : "CẬP NHẬT";
                    string logDetail = isAdding
                        ? $"Thêm SP mới: {name} (Mã: {productId}), Giá: {price:N0}, Kho: {stock}, Loại: {categoryName}"
                        : $"Sửa SP: {name} (Mã: {productId}), Giá mới: {price:N0}, Kho mới: {stock}";

                    // Gọi hàm ghi Log chung
                    Utils.WriteLog(action, "Sản phẩm", logDetail);

                    MessageBox.Show(isAdding ? "Thêm sản phẩm thành công!" : "Cập nhật sản phẩm thành công!");

                    LoadProducts(txtSearchh.Text.Trim());
                    ClearInput();
                    SetEditMode(false);
                    isAdding = false;
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể lưu dữ liệu vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                Utils.LogDB("btnSave_Click_Product", ex);
            }
        }

        // =========================
        // DELETE (tick checkbox)
        // =========================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> selectedIds = new List<string>();
            List<string> selectedNames = new List<string>(); // Danh sách để lưu tên sản phẩm phục vụ ghi Log

            // BƯỚC 1: Duyệt Grid để lấy thông tin sản phẩm đã chọn
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cChose"].Value != null && Convert.ToBoolean(row.Cells["cChose"].Value);
                if (isChecked)
                {
                    string productId = row.Cells["cProductID"].Value?.ToString();
                    string productName = row.Cells["cName"].Value?.ToString(); // Lấy tên sản phẩm từ cột cName

                    if (!string.IsNullOrWhiteSpace(productId))
                    {
                        selectedIds.Add(productId.Replace("'", "''"));
                        selectedNames.Add($"{productName} ({productId})"); // Lưu vào danh sách tạm
                    }
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một sản phẩm để xoá!");
                return;
            }

            // BƯỚC 2: Xác nhận xóa
            string message = selectedIds.Count == 1
                ? $"Bạn có chắc muốn xoá sản phẩm {selectedNames[0]} không?"
                : $"Bạn có chắc muốn xoá {selectedIds.Count} sản phẩm đã chọn không?";

            if (MessageBox.Show(message, "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // BƯỚC 3: Thực hiện xóa trong Database
            try
            {
                int successCount = 0;
                foreach (string id in selectedIds)
                {
                    string sql = $"DELETE FROM Products WHERE ProductId='{id}'";
                    if (db.ExecuteNonQuery(sql))
                        successCount++;
                }

                if (successCount > 0)
                {
                    // BƯỚC 4: Ghi nhật ký chi tiết
                    // Tạo chuỗi danh sách tên sản phẩm ngăn cách bởi dấu phẩy
                    string details = "Danh sách xóa: " + string.Join(", ", selectedNames);
                    Utils.WriteLog("XÓA", "Sản phẩm", details);

                    MessageBox.Show($"Đã xoá thành công {successCount} sản phẩm!");
                }

                LoadProducts(txtSearchh.Text.Trim());
                ClearInput();
                SetEditMode(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá sản phẩm: " + ex.Message);
                Utils.LogDB("DeleteProduct", ex);
            }

        }

        // =========================
        // CANCEL
        // =========================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;

            ClearInput();
            txtProductID.Enabled = true;

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (!row.IsNewRow)
                    row.Cells["cChose"].Value = false;
            }

            // Thoát chế độ sửa/thêm -> khóa + xám
            SetEditMode(false);
        }

        // =========================
        // SEARCH
        // =========================
        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearchh.Text.Trim());
        }

        private void txtSearchh_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearchh.Text.Trim());
        }

        // =========================
        // CLEAR INPUT
        // =========================
        private void ClearInput()
        {
            txtProductID.Clear();
            txtNameProduct.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = false;

            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        // =========================
        // ADVANCED: IMPORT CSV (khung hàm)
        // CSV: ProductId,Name,Price,CategoryID,Description,Stock,IsActive
        // =========================
        private void ImportProductsFromCsv(string filePath)
        {
            // 1. Kiểm tra xem file có đang bị mở không
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File Excel đang mở. Vui lòng tắt đi rồi thử lại!", "Lỗi");
                return;
            }

            if (!File.Exists(filePath)) return;

            try
            {
                var lines = File.ReadAllLines(filePath, Encoding.UTF8);
                if (lines.Length <= 1)
                {
                    MessageBox.Show("File rỗng!");
                    return;
                }

                int ok = 0;
                // Bắt đầu từ dòng 1 (bỏ header)
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    if (parts.Length < 7) continue;

                    // --- ĐỌC DỮ LIỆU ---
                    string pid = parts[0].Trim().Replace("'", "''");
                    string name = parts[1].Trim().Replace("'", "''");
                    string priceStr = parts[2].Trim();

                    // Lấy "Tên Loại" từ file CSV (Ví dụ: "Thực phẩm")
                    string catNameFromCSV = parts[3].Trim().Replace("'", "''");

                    string desc = parts[4].Trim().Replace("'", "''");
                    string stockStr = parts[5].Trim();
                    string activeStr = parts[6].Trim();

                    // Validate số
                    if (!decimal.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price)) continue;
                    if (!int.TryParse(stockStr, out int stock)) stock = 0;
                    int isActive = (activeStr == "1" || activeStr.ToLower() == "true") ? 1 : 0;

                    // Kiểm tra trùng Mã SP
                    string checkSql = $"SELECT COUNT(*) FROM Products WHERE ProductId='{pid}'";
                    if (Convert.ToInt32(db.ExecuteQuery(checkSql).Rows[0][0]) > 0) continue;

                    // ============================================================
                    // XỬ LÝ CATEGORIES (QUAN TRỌNG)
                    // ============================================================
                    string finalCatId = "";

                    // Kiểm tra xem trong bảng Categories đã có Tên Loại này chưa?
                    // (Lấy cột Name trong bảng Categories ra so sánh với file CSV)
                    string sqlFindCat = $"SELECT CategoryID FROM Categories WHERE Name = '{catNameFromCSV}'";
                    var dtCat = db.ExecuteQuery(sqlFindCat);

                    if (dtCat.Rows.Count > 0)
                    {
                        // NẾU CÓ RỒI: Lấy cái ID của nó ra (Ví dụ: L01)
                        finalCatId = dtCat.Rows[0]["CategoryID"].ToString();
                    }
                    else
                    {
                        // NẾU CHƯA CÓ: Tạo dòng mới trong bảng Categories
                        // Lưu "Thực phẩm" vào cột Name
                        finalCatId = "CAT_" + DateTime.Now.Ticks.ToString().Substring(10); // Tự sinh ID

                        string sqlInsertCat = $@"
                    INSERT INTO Categories(CategoryID, Name, Description) 
                    VALUES('{finalCatId}', '{catNameFromCSV}', 'Imported')";

                        db.ExecuteNonQuery(sqlInsertCat);
                    }

                    // ============================================================
                    // INSERT VÀO PRODUCTS (Lưu ID để liên kết)
                    // ============================================================
                    string insertSql = $@"
                INSERT INTO Products(ProductId, Name, Price, CategoryID, Description, Stock, IsActive)
                VALUES('{pid}','{name}',{price.ToString(CultureInfo.InvariantCulture)},'{finalCatId}','{desc}',{stock},{isActive});
            ";

                    if (db.ExecuteNonQuery(insertSql)) ok++;
                }

                MessageBox.Show($"Đã import thành công {ok} sản phẩm!");
                LoadProducts(txtSearchh.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Utils.LogDB("ImportProductsFromCsv", ex);
            }
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv";
                ofd.Title = "Chọn file CSV sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImportProductsFromCsv(ofd.FileName);
                }
            }
        }
    }
}
