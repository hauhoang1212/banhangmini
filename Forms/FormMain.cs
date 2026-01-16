using Quanlibanhang.Data;
using Quanlibanhang.Forms;
using Sunny.UI;
using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            PhanQuyen();
            btnFilter.PerformClick(); // Tự động nhấn nút lọc để hiện dữ liệu lần đầu
            
            
        }

        private void PhanQuyen()
        {
            // Kiểm tra quyền hạn từ Session
            bool isAdmin = (Session.Role == 1);

            // 1. Ẩn/Hiện Menu Danh mục
            danhMụcToolStripMenuItem.Visible = isAdmin;

            // 2. Ẩn/Hiện toàn bộ khu vực báo cáo (Biểu đồ và Bộ lọc)
            // Ẩn biểu đồ cột và biểu đồ tròn
            if (chartRevenue != null) chartRevenue.Visible = isAdmin;
            if (chartTopProducts != null) chartTopProducts.Visible = isAdmin;

            // Ẩn bộ lọc ngày tháng và nút Lọc báo cáo để nhân viên không tự bấm load lại được
            if (dtpFromDate != null) dtpFromDate.Visible = isAdmin;
            if (dtpToDate != null) dtpToDate.Visible = isAdmin;
            if (btnFilter != null) btnFilter.Visible = isAdmin;

            // 3. Cập nhật nhãn trạng thái dưới thanh Footer
            if (isAdmin)
            {
                lblStatus.Text = "Quyền hạn: Quản lý hệ thống";
            }
            else
            {
                lblStatus.Text = "Quyền hạn: Nhân viên bán hàng";
               
            }
        }
        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void timerSystem_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
        private void InitRevenueChart(string fromDate, string toDate)
        {
            string sql = $@"
                SELECT strftime('%d/%m', OrderDate) as Ngay, SUM(TotalAmount) as DoanhThu 
                FROM Orders 
                WHERE OrderDate BETWEEN '{fromDate}' AND '{toDate}'
                GROUP BY Ngay 
                ORDER BY OrderDate ASC";

            DataTable dt = db.ExecuteQuery(sql);

            if (dt == null || dt.Rows.Count == 0) return;

            UIBarOption option = new UIBarOption();
            option.Title = new UITitle { Text = "Báo cáo doanh thu theo thời gian" };
            option.ToolTip = new UIBarToolTip();
            option.Grid.Left = 80; // Tránh lỗi hiển thị số tiền lớn

            UIBarSeries series = new UIBarSeries();
            series.Name = "Doanh thu";
            series.ShowValue = true;

            foreach (DataRow row in dt.Rows)
            {
                option.XAxis.Data.Add(row["Ngay"].ToString());
                series.AddData(Convert.ToDouble(row["DoanhThu"]));
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


        private void InitPieChart(string fromDate, string toDate)
        {
            // Sử dụng cột LineTotal đã có sẵn trong bảng OrderDetails để tính doanh thu
            string sql = $@"
        SELECT p.Name, SUM(d.LineTotal) as Revenue
        FROM OrderDetails d
        JOIN Products p ON d.ProductId = p.ProductId
        JOIN Orders o ON d.OrderId = o.OrderId
        WHERE o.OrderDate BETWEEN '{fromDate}' AND '{toDate}'
        GROUP BY p.Name
        ORDER BY Revenue DESC
        LIMIT 5";

            DataTable dt = db.ExecuteQuery(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                
                return;
            }

            var option = new UIPieOption();
            option.Title = new UITitle { Text = "Top 5 Sản phẩm Doanh thu cao" };

            // Thêm ToolTip để khi di chuột vào sẽ hiện con số
            option.ToolTip = new UIPieToolTip();

            UIPieSeries series = new UIPieSeries();
            series.Name = "Doanh thu";

            foreach (DataRow row in dt.Rows)
            {
                // AddData(tên_mảnh, giá_trị)
                series.AddData(row["Name"].ToString(), Convert.ToDouble(row["Revenue"]));
            }

            option.Series.Add(series);
            chartTopProducts.SetOption(option);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Chỉ cho phép chạy nếu là Quản lý
            if (Session.Role != 1)
            {
                return;
            }
            // Lấy giá trị từ UIDatePicker và định dạng chuẩn SQL
            string fromDate = dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
            string toDate = dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");

            // Gọi hàm vẽ biểu đồ với tham số ngày đã chọn
            InitRevenueChart(fromDate, toDate);

            // Gọi thêm hàm biểu đồ tròn (Pie Chart) nếu bạn đã viết
             InitPieChart(fromDate, toDate);
        }
    }
}