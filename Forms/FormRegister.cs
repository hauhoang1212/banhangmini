using Quanlibanhang.Data;
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

namespace Quanlibanhang.Forms
{
    
    public partial class FormRegister : Form
    {
        SQLiteUtils db = new SQLiteUtils();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string name = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

            try
            {
                // Sử dụng kết nối từ SQLiteUtils của bạn
                db.OpenConnection();
                var conn = db.GetConnection();

                // Câu lệnh SQL (Đảm bảo bảng trong QLBH.db tên là Users)
                string sql = "INSERT INTO Users (Username, Password, FullName) VALUES (@user, @pass, @name)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Truyền tham số để bảo mật
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@name", name);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đăng ký thành công!");
                db.CloseConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                // Nếu bị lỗi "no such table", hãy kiểm tra lại file QLBH.db
                MessageBox.Show("Lỗi: " + ex.Message);
                db.CloseConnection();
            }
        }
    }
    }

