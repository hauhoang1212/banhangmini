namespace Quanlibanhang
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

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
            frmCategory.Show();

            // Hoặc dùng ShowDialog() nếu muốn FormMain phải đợi Form con đóng lại
            // frmCategory.ShowDialog();
        }

        private void menuItemManageProduct_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form
            FormProduct frmProduct = new FormProduct();

            // 2. Tùy chọn: Thiết lập MDI Parent
            // frmProduct.MdiParent = this;

            // 3. Hiển thị Form
            frmProduct.Show();
        }

        private void menuItemSale_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form
            FormSale frmSale = new FormSale();

            // 2. Tùy chọn: Thiết lập MDI Parent
            // frmSale.MdiParent = this;

            // 3. Hiển thị Form
            frmSale.Show();
        }
    }
}
