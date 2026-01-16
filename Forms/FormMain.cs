using Quanlibanhang.Data;
using Quanlibanhang.Forms;
using Sunny.UI;
using System.Data;
using System.Windows.Forms;

namespace Quanlibanhang
{
    // Thêm hàm này vào SQLiteUtils.cs hoặc gọi trực tiếp trong FormMain

    public partial class FormMain : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            // Đóng toàn bộ ứng dụng
            Application.Exit();

            // Hoặc chỉ đóng Form chính (nếu nó là Form chính duy nhất)
            // this.Close();
        }

        private void menuItemManageCategory_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form
            FormCategory frmCategory = new FormCategory();

            // 2. Tùy chọn: Thiết lập FormMain là MDI Parent
            // Nếu bạn đã đặt FormMain.IsMdiContainer = true
            // frmCategory.MdiParent = this;

            // 3. Hiển thị Form
            // Dùng Show() để cho phép FormMain vẫn tương tác (thường dùng cho MDI)
            frmCategory.ShowDialog();

            // Hoặc dùng ShowDialog() nếu muốn FormMain phải đợi Form con đóng lại
            // frmCategory.ShowDialog();
        }

        private void menuItemManageProduct_Click(object sender, EventArgs e)
        {
            FormProduct frmProduct = new FormProduct();

            // 2. Tùy chọn: Thiết lập MDI Parent
            // frmSale.MdiParent = this;

            // 3. Hiển thị Form
            frmProduct.ShowDialog();
        }

        private void menuItemSale_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form
            FormSale frmSale = new FormSale();

            // 2. Tùy chọn: Thiết lập MDI Parent
            // frmSale.MdiParent = this;

            // 3. Hiển thị Form
            frmSale.ShowDialog();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Trạng thái: Đang hoạt động";


            lblTime.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

            // Giả sử bạn có một Label tên là lblUser
            if (!string.IsNullOrEmpty(Session.FullName))
            {
                // Cấu trúc: (Điều kiện) ? "Giá trị nếu đúng" : "Giá trị nếu sai"
                string chucVu = (Session.Role == 1) ? "Quản lý: " : "Nhân viên: ";
                lblUser.Text = chucVu + Session.FullName;
            }
            InitRevenueChart();
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            // Nếu là nhân viên (Role = 0)
            if (Session.Role == 0)
            {
                // Ẩn menu Danh mục (Quản lý sản phẩm, loại sản phẩm)
                danhMụcToolStripMenuItem.Visible = false;

                // Ẩn menu Hệ thống hoặc các nút quản trị khác nếu cần
                // hệThốngToolStripMenuItem.Visible = false;

                // Nếu bạn có biểu đồ doanh thu, cũng nên ẩn đi đối với nhân viên
                if (chartRevenue != null) chartRevenue.Visible = false;

                lblStatus.Text = "Quyền hạn: Nhân viên bán hàng";
            }
            else
            {
                // Quản lý (Role = 1) sẽ thấy tất cả
                danhMụcToolStripMenuItem.Visible = true;
                if (chartRevenue != null) chartRevenue.Visible = true;

                lblStatus.Text = "Quyền hạn: Quản lý hệ thống";
            }
        }
        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void timerSystem_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
        private void InitRevenueChart()
        {
            DataTable dt = db.ExecuteQuery(@"
        SELECT strftime('%d/%m', OrderDate) as Ngay, SUM(TotalAmount) as DoanhThu 
        FROM Orders 
        GROUP BY Ngay ORDER BY Ngay ASC LIMIT 7");

            if (dt == null || dt.Rows.Count == 0) return;

            UIBarOption option = new UIBarOption();
            option.Title = new UITitle { Text = "Doanh thu 7 ngày gần nhất" };
            option.ToolTip = new UIBarToolTip();

            // CHỈNH LỖI 000000: Tăng khoảng cách lề trái để hiện đủ số tiền lớn
            option.Grid.Left = 80;

            UIBarSeries series = new UIBarSeries();
            series.Name = "Doanh thu";

            // HIỂN THỊ SỐ TIỀN TRÊN ĐẦU MỖI CỘT
            series.ShowValue = true;

            foreach (DataRow row in dt.Rows)
            {
                string ngay = row["Ngay"].ToString();
                double doanhThu = Convert.ToDouble(row["DoanhThu"]);

                option.XAxis.Data.Add(ngay);
                series.AddData(doanhThu);
            }

            option.Series.Add(series);
            chartRevenue.SetOption(option);
        }

        private void chartRevenue_Click(object sender, EventArgs e)
        {

        }

        private void menuItemExit_Click_1(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi đóng hẳn ứng dụng
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Lệnh thoát toàn bộ ứng dụng và giải phóng file CSDL
                Application.Exit();
            }
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            // 1. Hỏi xác nhận để tránh bấm nhầm
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Xóa thông tin phiên làm việc cũ để đảm bảo an toàn
                Session.Username = null;
                Session.FullName = null;
                Session.Role = 0;

                // 3. Ẩn Form hiện tại (FormMain)
                this.Hide();

                // 4. Khởi tạo và hiển thị lại Form Đăng nhập
                FormLogin frmLogin = new FormLogin();
                frmLogin.Show();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu Form đang hiển thị mà bị đóng (nhấn dấu X)
            // thì gọi Application.Exit() để tắt hẳn chương trình
            if (this.Visible)
            {
                Application.Exit();
            }
        }
    }
}