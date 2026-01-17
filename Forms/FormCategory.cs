using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
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
<<<<<<< Updated upstream
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
=======
                ep.SetError(txtCategoryName, "Vui lòng nhập Tên loại!");
                ok = false;
            }

            if (!ok) MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc!");
            return ok;
        }
        // =========================
        // XỬ LÝ SỰ KIỆN NÚT BẤM
        // =========================
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

        // =========================
        // ADD / EDIT / CANCEL
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
            SetEditingState(true);
            txtCategoryId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lấy dòng đang được tích checkbox
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cchoose"].Value))
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng tích chọn (v) một dòng để sửa!");
                return;
            }

            FillInputsFromRow(selectedRow);
            isAdding = false;
            SetEditingState(true);

            // Không cho sửa Mã (Khóa chính) khi đang Edit
            txtCategoryId.Enabled = false;
            txtCategoryId.FillColor = Color.Gainsboro;
            txtCategoryName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Thu thập các ID đã chọn
            List<string> selectedIds = new List<string>();
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cchoose"].Value))
                {
                    selectedIds.Add(row.Cells["cCategoryId"].Value?.ToString());
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một loại để xoá!");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xoá {selectedIds.Count} dòng đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int count = 0;
                    foreach (string id in selectedIds)
                    {
                        // Kiểm tra ràng buộc (nếu có bảng Sản phẩm tham chiếu tới)
                        DataTable dtCheck = db.ExecuteQuery($"SELECT 1 FROM Products WHERE CategoryId='{id}' LIMIT 1");
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                        {
                            MessageBox.Show($"Không thể xóa mã {id} vì đang có sản phẩm thuộc loại này!");
                            continue;
                        }

                        if (db.ExecuteNonQuery($"DELETE FROM Categories WHERE CategoryId='{id}'")) count++;
                    }

                    if (count > 0) MessageBox.Show($"Đã xoá thành công {count} dòng!");
                    LoadCategories();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xoá: " + ex.Message); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ep.Clear();
            SetEditingState(false);
            if (dgvCategories.CurrentRow != null) FillInputsFromRow(dgvCategories.CurrentRow);
        }

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
                    // Check trùng ID trước khi thêm
                    DataTable dt = db.ExecuteQuery($"SELECT 1 FROM Categories WHERE CategoryId='{id}'");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã loại này đã tồn tại trong hệ thống!");
                        return;
                    }
                    sql = $"INSERT INTO Categories(CategoryId, Name, Description) VALUES('{id}', '{name}', '{desc}')";
                }
                else
                {
                    sql = $"UPDATE Categories SET Name='{name}', Description='{desc}' WHERE CategoryId='{id}'";
                }

                if (db.ExecuteNonQuery(sql))
                {
                    MessageBox.Show("Lưu thành công!");
                    SetEditingState(false);
                    LoadCategories(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
                Utils.LogDB("Category_Save", ex);
            }
        }
        // =========================
        // SỰ KIỆN DATAGRIDVIEW
        // =========================

        private void btnFilter_Click(object sender, EventArgs e)
>>>>>>> Stashed changes
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
