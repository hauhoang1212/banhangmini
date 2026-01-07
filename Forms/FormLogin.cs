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
    public partial class FormLogin : Form
    {
        private SQLiteUtils db = new SQLiteUtils();
        public FormLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserLogin.Text.Trim();
            string pass = txtPassLogin.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo");
                return;
            }

            try
            {
                // 1. Mở kết nối thông qua Utils
                db.OpenConnection();
                var conn = db.GetConnection();

                // 2. Câu lệnh SQL kiểm tra sự tồn tại của tài khoản
                // Sử dụng bảng 'Users' khớp với FormRegister
                string sql = "SELECT FullName FROM Users WHERE Username = @user AND Password = @pass";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    // ExecuteScalar trả về giá trị đầu tiên tìm thấy (FullName)
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string fullName = result.ToString();

                        Session.FullName = fullName;
                        Session.Username = user;
                        MessageBox.Show($"Đăng nhập thành công! Chào mừng {fullName}", "Thành công");

                        // 3. Mở Form Chính (Form To) và ẩn Form đăng nhập
                        FormMain frmMain = new FormMain();
                        frmMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
            finally
            {
                // Luôn luôn đóng kết nối sau khi kiểm tra xong
                db.CloseConnection();
            }
        }

        // Nút để chuyển sang Form Đăng ký nếu chưa có tài khoản
        
        private void btnOpenRegister_Click_1(object sender, EventArgs e)
        {
            FormRegister frmReg = new FormRegister();
            // Khi Form đăng ký đóng lại, ta sẽ hiện lại Form đăng nhập
            frmReg.FormClosed += (s, args) => this.Show();

            frmReg.Show(); // Hiện màn hình đăng ký
            this.Hide();   // Ẩn màn hình đăng nhập
        }
    }
}
   