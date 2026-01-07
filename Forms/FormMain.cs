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
                lblUser.Text = "Nhân viên: " + Session.FullName;
            }
            InitRevenueChart();
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
            // Đảm bảo đã khai báo: private readonly SQLiteUtils db = new SQLiteUtils(); ở đầu Class FormMain
            DataTable dt = db.ExecuteQuery(@"
        SELECT strftime('%d/%m', OrderDate) as Ngay, SUM(TotalAmount) as DoanhThu 
        FROM Orders 
        GROUP BY Ngay ORDER BY Ngay ASC LIMIT 7");

            if (dt == null || dt.Rows.Count == 0) return;

            UIBarOption option = new UIBarOption();
            option.Title = new UITitle { Text = "Doanh thu 7 ngày gần nhất" };

            // Sửa lỗi CS0029: Ép kiểu đúng loại ToolTip cho BarChart
            option.ToolTip = new UIBarToolTip();

            UIBarSeries series = new UIBarSeries();
            series.Name = "Doanh thu";

            foreach (DataRow row in dt.Rows)
            {
                string ngay = row["Ngay"].ToString();
                double doanhThu = Convert.ToDouble(row["DoanhThu"]);

                option.XAxis.Data.Add(ngay);

                // SỬA LỖI CS1501: Thêm cả giá trị vào Series
                series.AddData(doanhThu);
            }

            option.Series.Add(series);
            chartRevenue.SetOption(option);
        }

        private void chartRevenue_Click(object sender, EventArgs e)
        {

        }
    }

}