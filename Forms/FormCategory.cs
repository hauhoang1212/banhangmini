using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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

        private void LoadCategories()
        {
            DatabaseHelper db = new DatabaseHelper();
            dgvCategories.DataSource = db.ExecuteQuery("SELECT * FROM Categories");
        }
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào dòng dữ liệu (không phải tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào TextBox tương ứng
                txtCategoryId.Text = row.Cells["CategoryId"].Value.ToString();
                txtCategoryName.Text = row.Cells["Name"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            string sql = "INSERT INTO Categories (Name, Description) VALUES (@name, @desc)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@name", txtCategoryName.Text),
                new SQLiteParameter("@desc", txtDescription.Text)
            };

            // Thực thi lệnh
            db.ExecuteNonQuery(sql, parameters);

            LoadCategories();

            // Xóa chữ trong ô để nhập tiếp
            txtCategoryName.Clear();
            txtDescription.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
        private void ClearTextBoxes()
        {
            
        }
    }
}
