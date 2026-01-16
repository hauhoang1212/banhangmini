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
                db.OpenConnection();
                var conn = db.GetConnection();

                // CHỈNH SỬA TẠI ĐÂY: Lấy thêm cột Role từ bảng Users
                string sql = "SELECT FullName, Role FROM Users WHERE Username = @user AND Password = @pass";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    // Thay đổi sang ExecuteReader để đọc được nhiều cột (FullName và Role)
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ các cột tương ứng
                            string fullName = reader["FullName"].ToString();
                            int role = Convert.ToInt32(reader["Role"]);

                            // GÁN DỮ LIỆU VÀO SESSION TẠI ĐÂY
                            Session.FullName = fullName;
                            Session.Username = user;
                            Session.Role = role; // Lưu quyền vào Session để FormMain sử dụng

                            MessageBox.Show($"Đăng nhập thành công! Chào mừng {fullName}", "Thành công");

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
            finally
            {
                db.CloseConnection(); // Luôn đóng kết nối để giải phóng file DB
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
   