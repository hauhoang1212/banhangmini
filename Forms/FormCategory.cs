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

                string query = $"SELECT * FROM Categories ";
                SQLiteUtils sQL = new SQLiteUtils();
                DataTable dt = sQL.ExecuteQuery(query);

                foreach (DataRow dr in dt.Rows)
                {
                    dgvCategories.Rows.Add(
                        false,
                        dr["CategoryID"],
                        dr["Name"],
                        dr["Description"]
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utils.Log("LoadData: ", ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }
                string name = txtCategoryName.Text;
                string description = txtDescription.Text;
                string query = $"INSERT INTO Categories(Name, Description) " +
                    $"VALUES ('{name}', '{description}')";
                SQLiteUtils sQL = new SQLiteUtils();

                DataTable dtCheck = sQL.ExecuteQuery($"SELECT * FROM Categories WHERE Name='{name}");
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("Danh mục đã tồn tại");
                    return;
                }
                sQL.ExecuteQuery(query);
                MessageBox.Show("Đã thêm danh mục thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utils.Log("Add Category: ", ex);
            }
            
        }
        private bool ValidateInput()
        {
            // Kiểm tra nếu ô Tên bị trống hoặc chỉ có dấu cách
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus(); // Đưa con trỏ chuột vào ô Tên
                return false;
            }

            // Bạn có thể thêm kiểm tra cho ô Mô tả nếu cần, hoặc để trống cũng được
            return true; // Nếu mọi thứ ổn thì trả về true
        }
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
