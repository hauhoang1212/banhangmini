using Quanlibanhang.Data;
using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class FormCategory : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();
        private bool isAdding = false;                 // true = Thêm, false = Sửa
        private readonly ErrorProvider ep = new ErrorProvider();

        public FormCategory()
        {
            InitializeComponent();

            // ErrorProvider
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.ContainerControl = this;

            // DataGridView: chỉ cho tick checkbox
            dgvCategories.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvCategories.Columns)
            {
                if (col.Name != "cchoose") col.ReadOnly = true;
            }
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;

            // Ban đầu: khóa input (màu xám)
            SetEditingState(false);

            // Load dữ liệu
            LoadCategories();

            // Khi mới vào form: nếu có data thì đổ dòng đầu lên input (nhưng vẫn khóa)
            if (dgvCategories.Rows.Count > 0 && !dgvCategories.Rows[0].IsNewRow)
            {
                dgvCategories.Rows[0].Selected = true;
                FillInputsFromRow(dgvCategories.Rows[0]);
            }

            // (Nếu bạn có nút export CSV trong UI thì hãy gán Click gọi ExportCsv())
            // btnExportCsv.Click += (s, e) => ExportCsv();
        }

        // =========================
        // LOAD
        // =========================
        private void LoadCategories(string keyword = "")
        {
            try
            {
                dgvCategories.Rows.Clear();

                string sql = @"SELECT CategoryId, Name, IFNULL(Description,'') AS Description
                               FROM Categories
                               WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim().Replace("'", "''");
                    sql += $" AND (Name LIKE '%{keyword}%' OR Description LIKE '%{keyword}%')";
                }

                sql += " ORDER BY CategoryId";

                DataTable dt = db.ExecuteQuery(sql);

                int stt = 1;
                foreach (DataRow r in dt.Rows)
                {
                    dgvCategories.Rows.Add(
                        false,                 // cchoose
                        stt++,                 // sSTT
                        r["CategoryId"],       // cCategoryId
                        r["Name"],             // cName
                        r["Description"]       // cDescription
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadCategories: " + ex.Message);
                Utils.LogDB("LoadCategories", ex);
            }
        }

        // =========================
        // UI STATE (khóa/mở + màu xám)
        // =========================
        private void SetEditingState(bool editing)
        {
            // Input
            txtCategoryId.Enabled = editing;
            txtCategoryName.Enabled = editing;
            txtDescription.Enabled = editing;

            // Màu xám khi disabled (Sunny.UI vẫn nhìn rõ)
            ApplyTextBoxStyle(txtCategoryId, editing);
            ApplyTextBoxStyle(txtCategoryName, editing);
            ApplyTextBoxStyle(txtDescription, editing);

            // Buttons
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing;
            btnDelete.Enabled = !editing;

            // Search vẫn dùng được
            txtSearch.Enabled = !editing;
            btnFilter.Enabled = !editing;
        }

        private void ApplyTextBoxStyle(dynamic tb, bool enabled)
        {
            try
            {
                // Sunny.UI UITextBox có FillColor
                tb.FillColor = enabled ? Color.White : Color.Gainsboro;
            }
            catch
            {
                // fallback nếu control khác
                try { tb.BackColor = enabled ? Color.White : SystemColors.Control; } catch { }
            }
        }

        private void ClearInput()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
            ep.SetError(txtCategoryId, "");
            ep.SetError(txtCategoryName, "");
        }

        private void FillInputsFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            txtCategoryId.Text = row.Cells["cCategoryId"].Value?.ToString() ?? "";
            txtCategoryName.Text = row.Cells["cName"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["cDescription"].Value?.ToString() ?? "";
        }

        // =========================
        // VALIDATE (ErrorProvider)
        // =========================
        private bool ValidateInput()
        {
            bool ok = true;
            ep.SetError(txtCategoryId, "");
            ep.SetError(txtCategoryName, "");

            string id = txtCategoryId.Text.Trim();
            string name = txtCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                ep.SetError(txtCategoryId, "Vui lòng nhập ID loại (vd: D01)");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                ep.SetError(txtCategoryName, "Vui lòng nhập Tên loại");
                ok = false;
            }

            if (!ok) MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
            return ok;
        }

        // =========================
        // EVENTS
        // =========================
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // không cần code, tick checkbox để chọn dòng
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvCategories.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            FillInputsFromRow(row);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lọc realtime
            LoadCategories(txtSearch.Text.Trim());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadCategories(txtSearch.Text.Trim());
        }

        // =========================
        // ADD / EDIT / CANCEL
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetEditingState(true);
            txtCategoryId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetFirstCheckedRow();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng tích chọn (v) 1 dòng để sửa!");
                return;
            }

            FillInputsFromRow(selectedRow);

            isAdding = false;
            SetEditingState(true);

            // Không cho sửa khóa chính khi sửa (đúng chuẩn)
            txtCategoryId.Enabled = false;
            ApplyTextBoxStyle(txtCategoryId, false);

            txtCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearInput();

            // bỏ tick checkbox
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (!row.IsNewRow) row.Cells["cchoose"].Value = false;
            }

            SetEditingState(false);

            // đổ lại dòng đang select (nếu có)
            if (dgvCategories.CurrentRow != null && !dgvCategories.CurrentRow.IsNewRow)
            {
                FillInputsFromRow(dgvCategories.CurrentRow);
            }
        }

        // =========================
        // SAVE (THÊM / SỬA)
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string id = txtCategoryId.Text.Trim().Replace("'", "''");
            string name = txtCategoryName.Text.Trim().Replace("'", "''");
            string desc = txtDescription.Text.Trim().Replace("'", "''");

            try
            {
                string sql;

                if (isAdding)
                {
                    // check trùng ID
                    DataTable dtCheck = db.ExecuteQuery($"SELECT COUNT(*) FROM Categories WHERE CategoryId='{id}'");
                    if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                    {
                        MessageBox.Show("ID loại đã tồn tại!");
                        return;
                    }

                    sql = $@"
                        INSERT INTO Categories(CategoryId, Name, Description)
                        VALUES('{id}', '{name}', '{desc}')
                    ";
                }
                else
                {
                    // Sửa theo ID
                    sql = $@"
                        UPDATE Categories
                        SET Name='{name}', Description='{desc}'
                        WHERE CategoryId='{id}'
                    ";
                }

                if (db.ExecuteNonQuery(sql))
                {
                    MessageBox.Show(isAdding ? "Thêm loại thành công!" : "Cập nhật loại thành công!");

                    LoadCategories(txtSearch.Text.Trim());

                    // reset trạng thái
                    isAdding = false;
                    SetEditingState(false);

                    // bỏ tick
                    foreach (DataGridViewRow row in dgvCategories.Rows)
                    {
                        if (!row.IsNewRow) row.Cells["cchoose"].Value = false;
                    }

                    // chọn lại dòng vừa lưu
                    SelectRowByCategoryId(id);
                }
                else
                {
                    MessageBox.Show("Lưu thất bại! Vui lòng xem log DB.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                Utils.LogDB("Category_Save", ex);
            }
        }

        private void SelectRowByCategoryId(string id)
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;
                if ((row.Cells["cCategoryId"].Value?.ToString() ?? "") == id)
                {
                    row.Selected = true;
                    dgvCategories.CurrentCell = row.Cells["cName"];
                    FillInputsFromRow(row);
                    return;
                }
            }

            // nếu không thấy (ví dụ đang lọc) thì clear input
            FillInputsFromRow(dgvCategories.CurrentRow);
        }

        // =========================
        // DELETE (không xóa nếu còn Product)
        // =========================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> ids = GetCheckedCategoryIds();
            if (ids.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất 1 loại để xóa!");
                return;
            }

            // kiểm tra ràng buộc Product thuộc Category
            foreach (var idRaw in ids)
            {
                string id = idRaw.Replace("'", "''");
                DataTable dt = db.ExecuteQuery($"SELECT COUNT(*) FROM Products WHERE CategoryID='{id}'");
                int cnt = (dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0][0]) : 0;
                if (cnt > 0)
                {
                    MessageBox.Show($"Không thể xóa loại {id} vì đang có {cnt} sản phẩm thuộc loại này!");
                    return;
                }
            }

            string msg = ids.Count == 1
                ? $"Bạn có chắc muốn xóa loại {ids[0]} không?"
                : $"Bạn có chắc muốn xóa {ids.Count} loại đã chọn không?";

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                int success = 0;
                foreach (var idRaw in ids)
                {
                    string id = idRaw.Replace("'", "''");
                    if (db.ExecuteNonQuery($"DELETE FROM Categories WHERE CategoryId='{id}'"))
                        success++;
                }

                MessageBox.Show($"Đã xóa {success} loại!");
                LoadCategories(txtSearch.Text.Trim());
                btnCancel_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
                Utils.LogDB("Category_Delete", ex);
            }
        }

        // =========================
        // EXPORT CSV (Advanced)
        // =========================
        private void ExportCsv()
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.FileName = $"Categories_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    sb.AppendLine("CategoryId,Name,Description");

                    foreach (DataGridViewRow row in dgvCategories.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string id = (row.Cells["cCategoryId"].Value?.ToString() ?? "").Replace("\"", "\"\"");
                        string name = (row.Cells["cName"].Value?.ToString() ?? "").Replace("\"", "\"\"");
                        string desc = (row.Cells["cDescription"].Value?.ToString() ?? "").Replace("\"", "\"\"");

                        sb.AppendLine($"\"{id}\",\"{name}\",\"{desc}\"");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất CSV thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi export CSV: " + ex.Message);
                Utils.LogDB("Category_ExportCSV", ex);
            }
        }

        // =========================
        // HELPERS: checkbox selection
        // =========================
        private DataGridViewRow GetFirstCheckedRow()
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cchoose"].Value != null
                                 && Convert.ToBoolean(row.Cells["cchoose"].Value);

                if (isChecked) return row;
            }
            return null;
        }

        private List<string> GetCheckedCategoryIds()
        {
            var ids = new List<string>();

            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cchoose"].Value != null
                                 && Convert.ToBoolean(row.Cells["cchoose"].Value);

                if (isChecked)
                {
                    string id = row.Cells["cCategoryId"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(id))
                        ids.Add(id.Trim());
                }
            }
            return ids;
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
<<<<<<< Updated upstream
=======
        private void LoadCategories()
        {
            try
            {
                dgvCategories.Rows.Clear();
                string query = "SELECT * FROM Categories";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null)
                {
                    int stt = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvCategories.Rows.Add(
                          false,
                                        stt++,
                                        dr["CategoryID"],
                                        dr["Name"],
                                        dr["Description"]
                                    );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
        }


        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
                txtCategoryName.Focus();
                return false;
            }
            return true;
        }
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra người dùng có click vào hàng dữ liệu không
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                // Đưa ID vào TextBox ẩn hoặc biến tạm để dùng cho nút Xóa
                txtCategoryId.Text = row.Cells["CategoryId"].Value?.ToString();
                txtCategoryName.Text = row.Cells["Name"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
            }
        }

        private void ControlButtons(bool isEditing)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra bắt buộc nhập (Validation)
                if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã ID loại sản phẩm!", "Thông báo");
                    txtCategoryId.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên loại sản phẩm!", "Thông báo");
                    txtCategoryName.Focus();
                    return;
                }

                string id = txtCategoryId.Text.Trim();
                string name = txtCategoryName.Text.Trim();
                string description = txtDescription.Text.Trim();

                SQLiteUtils db = new SQLiteUtils();

                // 2. Kiểm tra trùng mã ID (Vì bạn đã đổi sang ID chữ)
                string checkIdQuery = $"SELECT * FROM Categories WHERE CategoryId = '{id}'";
                DataTable dtCheckId = db.ExecuteQuery(checkIdQuery);

                if (dtCheckId != null && dtCheckId.Rows.Count > 0)
                {
                    MessageBox.Show("Mã ID loại này đã tồn tại, vui lòng nhập mã khác!");
                    txtCategoryId.Focus();
                    return;
                }

                // 3. Thực hiện Thêm vào Database
                // Sử dụng ExecuteNonQuery thay vì ExecuteQuery cho lệnh INSERT
                string query = $"INSERT INTO Categories (CategoryId, Name, Description) " +
                               $"VALUES ('{id}', '{name}', '{description}')";

                if (db.ExecuteNonQuery(query)) // Hàm này sẽ tự động mở kết nối
                {
                    MessageBox.Show("Đã thêm danh mục thành công!");

                    // 4. Xóa trắng form sau khi thêm
                    txtCategoryId.Clear();
                    txtCategoryName.Clear();
                    txtDescription.Clear();

                    // 5. Tải lại danh sách
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Tìm dòng được tích chọn (Checkbox)
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cchoose"].Value) == true)
                {
                    selectedRow = row;
                    break; // Lấy dòng đầu tiên được tích
                }
            }

            if (selectedRow != null)
            {
                // Đưa dữ liệu từ dòng tích chọn lên các ô nhập liệu
                txtCategoryId.Text = selectedRow.Cells["cCategoryId"].Value?.ToString();
                txtCategoryName.Text = selectedRow.Cells["cName"].Value?.ToString();
                txtDescription.Text = selectedRow.Cells["cDescription"].Value?.ToString();

                // Thiết lập trạng thái
                isAdding = false; // Đang ở chế độ Sửa
                txtCategoryId.Enabled = false;
                txtCategoryName.Enabled = false;// Không cho sửa ID (khóa chính)
                txtDescription.Enabled = true;
                txtCategoryName.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng tích chọn (v) vào một dòng để sửa!", "Thông báo");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa sạch nội dung trong các ô nhập dữ liệu
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();

            // Reset lại trạng thái ban đầu
            txtCategoryId.Enabled = true;
            txtCategoryName.Enabled = true;
            isAdding = false;

            // Bỏ tích tất cả trên bảng (nếu muốn)
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                row.Cells["cchoose"].Value = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtCategoryId.Text.Trim();
            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên loại!");
                return;
            }

            try
            {
                string sql = "";
                if (isAdding) // Nếu là chế độ Thêm mới
                {
                    // Kiểm tra trùng ID trước khi chèn
                    string checkSql = $"SELECT COUNT(*) FROM Categories WHERE CategoryId = '{id}'";
                    DataTable dt = db.ExecuteQuery(checkSql);
                    if (dt != null && Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        MessageBox.Show("Mã loại này đã tồn tại!");
                        return;
                    }
                    sql = $"INSERT INTO Categories (CategoryId, Name, Description) VALUES ('{id}', '{name}', '{desc}')";
                }
                else // Nếu là chế độ Sửa
                {
                    sql = $"UPDATE Categories SET Name = '{name}', Description = '{desc}' WHERE CategoryId = '{id}'";
                }

                if (db.ExecuteNonQuery(sql))
                {
                    MessageBox.Show(isAdding ? "Thêm mới thành công!" : "Cập nhật thành công!");
                    LoadCategories(); // Load lại bảng để thấy dữ liệu mới
                    btnCancel_Click(null, null); // Xóa trắng form sau khi lưu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Thu thập danh sách các ID đã được tích chọn
            List<string> selectedIds = new List<string>();

            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                // Kiểm tra giá trị của cột checkbox (cchoose)
                bool isChecked = Convert.ToBoolean(row.Cells["cchoose"].Value);
                if (isChecked)
                {
                    string id = row.Cells["cCategoryId"].Value?.ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        selectedIds.Add(id);
                    }
                }
            }

            // 2. Kiểm tra nếu chưa tích dòng nào
            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một loại sản phẩm để xoá!");
                return;
            }

            // 3. Xác nhận và thực hiện xoá
            string message = selectedIds.Count == 1
                ? $"Bạn có chắc muốn xoá mã {selectedIds[0]} không?"
                : $"Bạn có chắc muốn xoá {selectedIds.Count} dòng đã chọn không?";

            if (MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int successCount = 0;
                    foreach (string idXoa in selectedIds)
                    {
                        string sql = $"DELETE FROM Categories WHERE CategoryId = '{idXoa}'";
                        if (db.ExecuteNonQuery(sql)) // Sử dụng hàm từ SQLiteUtils
                        {
                            successCount++;
                        }
                    }

                    if (successCount > 0)
                    {
                        MessageBox.Show($"Đã xoá thành công {successCount} dòng!");
                        LoadCategories(); // Tải lại bảng 

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thực thi: " + ex.Message);
                }
            }
        }
        private void SearchCategory()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                dgvCategories.Rows.Clear();

                // Truy vấn tìm kiếm theo Tên hoặc Mô tả
                string query = $@"SELECT * FROM Categories 
                          WHERE Name LIKE '%{keyword}%' 
                          OR Description LIKE '%{keyword}%'";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null)
                {
                    int stt = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvCategories.Rows.Add(
                            false,
                            stt++,
                            dr["CategoryID"],
                            dr["Name"],
                            dr["Description"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                Utils.LogDB("SearchCategory", ex); // Ghi log lỗi vào DB log
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

       
>>>>>>> Stashed changes
    }
}
