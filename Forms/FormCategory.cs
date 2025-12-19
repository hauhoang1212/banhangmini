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
        public FormCategory()
        {
            InitializeComponent();
            LoadCategories();
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
        /// <summary>
        /// sửa xoá các kiểu
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ControlButtons(bool isEditing)
        {
            // Các ô nhập liệu chỉ mở khi đang Thêm hoặc Sửa
            txtCategoryName.Enabled = isEditing;
            txtDescription.Enabled = isEditing;

            // Nút chức năng
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
            btnDelete.Enabled = !isEditing;

            btnSave.Enabled = isEditing;
            btnCancel.Enabled = isEditing;
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
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có ID trong TextBox chưa (ID này được lấy từ CellClick ở trên)
            if (string.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("Vui lòng click chọn một hàng trên bảng trước khi xóa!");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa mã {txtCategoryId.Text} không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SQLiteUtils db = new SQLiteUtils();

                    // Xóa đúng cái ID đang nằm trong TextBox (là hàng bạn vừa click)
                    string idXoa = txtCategoryId.Text.Trim();
                    string sql = $"DELETE FROM Categories WHERE CategoryId = '{idXoa}'";

                    if (db.ExecuteNonQuery(sql))
                    {
                        MessageBox.Show("Xóa thành công hàng đã chọn!");
                        LoadCategories(); // Tải lại bảng

                        // Xóa trắng để tránh bấm Xóa lần nữa vào ID cũ
                        txtCategoryId.Clear();
                        txtCategoryName.Clear();
                        txtDescription.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thực thi: " + ex.Message);
                }
            }
        }
    }
}