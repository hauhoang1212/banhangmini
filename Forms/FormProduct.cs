using Quanlibanhang.Data;
using Quanlibanhang.Helpers;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quanlibanhang.Forms
{
    public partial class FormProduct : Form
    {
        SQLiteUtils db = new SQLiteUtils();
        private bool isAdding = false;
        public FormProduct()
        {
            InitializeComponent();
            LoadProducts();
            LoadCategoriesToCombo(); // Lấy danh sách loại sản phẩm vào ComboBox

            // Cấu hình DataGridView: Chỉ cho phép tích checkbox, không cho sửa nội dung khác
            dgvProduct.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                if (col.Name != "cChose") col.ReadOnly = true;
            }
        }
        private void LoadProducts()
        {
            try
            {
                dgvProduct.Rows.Clear();
                string query = "SELECT * FROM Products";
                 DataTable dt = db.ExecuteQuery(query); 

                if (dt != null)
                {
                    int stt = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProduct.Rows.Add(
                            false,
                            stt++,
                            dr["ProductID"],
                            dr["Name"],
                            dr["Price"],
                            dr["CategoryName"],
                            dr["Description"],
                            dr["Stock"],
                            Convert.ToInt32(dr["IsActive"]) == 1
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message);
            }
        }

        // 2. Lấy dữ liệu tên loại từ bảng Categories đổ vào ComboBox
        private void LoadCategoriesToCombo()
        {
            try
            {
                string query = "SELECT Name FROM Categories";
                 DataTable dt = db.ExecuteQuery(query); 

                cboCategory.Items.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cboCategory.Items.Add(dr["Name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                 Utils.LogDB("LoadCategoriesToCombo", ex); 
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 0. Kiểm tra nhập liệu (Validate)
                if (string.IsNullOrWhiteSpace(txtProductID.Text) || string.IsNullOrWhiteSpace(txtNameProduct.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã sản phẩm và Tên sản phẩm!");
                    return;
                }

                string id = txtProductID.Text.Trim();
                string name = txtNameProduct.Text.Trim();
                string price = txtPrice.Text.Trim();
                string category = cboCategory.Text; // Loại chọn từ ComboBox nạp từ FormCategory
                string description = txtDescription.Text.Trim();
                string stock = txtStock.Text.Trim();
                int isActive = chkIsActive.Checked ? 1 : 0; // Trạng thái đang bán

                // 1. Kiểm tra trùng mã ID Sản phẩm
                string checkIdQuery = $"SELECT * FROM Products WHERE ProductID = '{id}'";
                DataTable dtCheckId = db.ExecuteQuery(checkIdQuery);

                if (dtCheckId != null && dtCheckId.Rows.Count > 0)
                {
                    MessageBox.Show("Mã ID sản phẩm này đã tồn tại, vui lòng nhập mã khác!");
                    return;
                }

                // 2. Thêm vào Database
                // Lưu ý: Cấu trúc bảng Products cần khớp với các trường này
                string query = $"INSERT INTO Products(ProductID, Name, Price, CategoryName, Description, Stock, IsActive) " +
                               $"VALUES ('{id}', '{name}', '{price}', '{category}', '{description}', '{stock}', {isActive})";

                
                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Đã thêm sản phẩm thành công!");

                    // 3. Tải lại danh sách để cập nhật bảng hiển thị
                    LoadProducts();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Utils.LogDB("btnAdd_Click", ex); // Ghi log lỗi vào hệ thống
            }
        }
        private void dgvProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProduct.IsCurrentCellDirty)
            {
                dgvProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
