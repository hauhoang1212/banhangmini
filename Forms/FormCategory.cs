using Quanlibanhang.Data;
using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quanlibanhang
{
    public partial class FormCategory : Form
    {
        SQLiteUtils db = new SQLiteUtils();
        private bool isAdding = false; // Để biết đang Thêm hay đang Sửa
        public FormCategory()
        {
            InitializeComponent();
            LoadCategories();
            dgvCategories.ReadOnly = false; // Phải để false để tích được Checkbox
            foreach (DataGridViewColumn col in dgvCategories.Columns)
            {
                if (col.Name != "cchoose") // Chỉ cho phép cột tích chọn (Checkbox) được sửa
                {
                    col.ReadOnly = true;
                }
            }
            ControlButtons(false); // Ban đầu khóa các ô nhập liệu
        }
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
                if (!ValidateInput()) return;
                string id = txtCategoryId.Text.Trim();
                string name = txtCategoryName.Text.Trim();
                string description = txtDescription.Text.Trim();

                // 1. Kiểm tra trùng tên (Sửa lỗi thiếu dấu nháy đơn '{name}')
                string checkIdQuery = $"SELECT * FROM Categories WHERE CategoryId = '{id}'";
                DataTable dtCheckId = db.ExecuteQuery(checkIdQuery);

                if (dtCheckId != null && dtCheckId.Rows.Count > 0)
                {
                    MessageBox.Show("Mã ID loại này đã tồn tại, vui lòng nhập mã khác!");
                    return;
                }

                // 2. Thêm vào Database (ID loại sẽ tự động tăng trong DB nếu bạn để kiểu AUTOINCREMENT)
                string query = $"INSERT INTO Categories(CategoryId, Name, Description) " +
            $"VALUES ('{id}', '{name}', '{description}')";
                db.ExecuteQuery(query);

                MessageBox.Show("Đã thêm danh mục thành công!");

                // 3. Tải lại danh sách để cập nhật cả ID mới và STT mới
                LoadCategories();

                LoadCategories(); // Tải lại bảng để xem kết quả

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

       
    }
}