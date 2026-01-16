namespace Quanlibanhang
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            uiLabel1 = new Sunny.UI.UILabel();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            menuItemExit = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            menuItemManageCategory = new ToolStripMenuItem();
            menuItemManageProduct = new ToolStripMenuItem();
            nghiệpVụToolStripMenuItem = new ToolStripMenuItem();
            menuItemSale = new ToolStripMenuItem();
            lblUser = new Label();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            dtpFromDate = new Sunny.UI.UIDatePicker();
            dtpToDate = new Sunny.UI.UIDatePicker();
            btnFilter = new Sunny.UI.UIButton();
            chartRevenue = new Sunny.UI.UIBarChart();
            chartTopProducts = new Sunny.UI.UIPieChart();
            timerSystem = new System.Windows.Forms.Timer(components);
            menulog = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            uiTableLayoutPanel1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(statusStrip1, 0, 4);
            tableLayoutPanel1.Controls.Add(uiLabel1, 0, 0);
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 1);
            tableLayoutPanel1.Controls.Add(lblUser, 0, 3);
            tableLayoutPanel1.Controls.Add(uiTableLayoutPanel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.Size = new Size(875, 494);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Fill;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblTime });
            statusStrip1.Location = new Point(0, 466);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(875, 28);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(818, 22);
            lblStatus.Spring = true;
            lblStatus.Text = "Hoạt động";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 22);
            lblTime.Text = "Time";
            lblTime.Click += lblTime_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Wheat;
            uiLabel1.Dock = DockStyle.Top;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(0, 0);
            uiLabel1.Margin = new Padding(0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(875, 30);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "QUÁN LÍ BÁN HÀNG";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, danhMụcToolStripMenuItem, nghiệpVụToolStripMenuItem });
            menuStrip1.Location = new Point(0, 30);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(875, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menulog, menuLogout, menuItemExit });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // menuItemExit
            // 
            menuItemExit.Name = "menuItemExit";
            menuItemExit.Size = new Size(224, 26);
            menuItemExit.Text = "Thoát";
            menuItemExit.Click += menuItemExit_Click_1;
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(224, 26);
            menuLogout.Text = "Đăng xuất";
            menuLogout.Click += menuLogout_Click;
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItemManageCategory, menuItemManageProduct });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(94, 24);
            danhMụcToolStripMenuItem.Text = "Danh mục ";
            // 
            // menuItemManageCategory
            // 
            menuItemManageCategory.Name = "menuItemManageCategory";
            menuItemManageCategory.Size = new Size(239, 26);
            menuItemManageCategory.Text = "Quản lý loại sản phẩm";
            menuItemManageCategory.Click += menuItemManageCategory_Click;
            // 
            // menuItemManageProduct
            // 
            menuItemManageProduct.Name = "menuItemManageProduct";
            menuItemManageProduct.Size = new Size(239, 26);
            menuItemManageProduct.Text = "Quản lý sản phẩm";
            menuItemManageProduct.Click += menuItemManageProduct_Click;
            // 
            // nghiệpVụToolStripMenuItem
            // 
            nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItemSale });
            nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
            nghiệpVụToolStripMenuItem.Size = new Size(95, 24);
            nghiệpVụToolStripMenuItem.Text = "Nghiệp vụ ";
            // 
            // menuItemSale
            // 
            menuItemSale.Name = "menuItemSale";
            menuItemSale.Size = new Size(224, 26);
            menuItemSale.Text = "Bán hàng";
            menuItemSale.Click += menuItemSale_Click;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(2, 438);
            lblUser.Margin = new Padding(2);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(871, 26);
            lblUser.TabIndex = 3;
            lblUser.Text = "...";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel2, 0, 0);
            uiTableLayoutPanel1.Controls.Add(chartRevenue, 0, 1);
            uiTableLayoutPanel1.Controls.Add(chartTopProducts, 1, 1);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(3, 61);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.8279572F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.17204F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            uiTableLayoutPanel1.Size = new Size(869, 372);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 3;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            uiTableLayoutPanel2.Controls.Add(dtpFromDate, 0, 0);
            uiTableLayoutPanel2.Controls.Add(dtpToDate, 1, 0);
            uiTableLayoutPanel2.Controls.Add(btnFilter, 2, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(0, 0);
            uiTableLayoutPanel2.Margin = new Padding(0);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 1;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Size = new Size(479, 39);
            uiTableLayoutPanel2.TabIndex = 0;
            uiTableLayoutPanel2.TagString = null;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Anchor = AnchorStyles.None;
            dtpFromDate.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtpFromDate.FillColor = Color.White;
            dtpFromDate.Font = new Font("Microsoft Sans Serif", 12F);
            dtpFromDate.Location = new Point(4, 5);
            dtpFromDate.Margin = new Padding(4, 5, 4, 5);
            dtpFromDate.MaxLength = 10;
            dtpFromDate.MinimumSize = new Size(63, 0);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Padding = new Padding(0, 0, 30, 2);
            dtpFromDate.Size = new Size(142, 29);
            dtpFromDate.SymbolDropDown = 61555;
            dtpFromDate.SymbolNormal = 61555;
            dtpFromDate.SymbolSize = 24;
            dtpFromDate.TabIndex = 0;
            dtpFromDate.Text = "2026-01-16";
            dtpFromDate.TextAlignment = ContentAlignment.MiddleLeft;
            dtpFromDate.Value = new DateTime(2026, 1, 16, 10, 19, 27, 124);
            dtpFromDate.Watermark = "";
            // 
            // dtpToDate
            // 
            dtpToDate.Anchor = AnchorStyles.None;
            dtpToDate.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtpToDate.FillColor = Color.White;
            dtpToDate.Font = new Font("Microsoft Sans Serif", 12F);
            dtpToDate.Location = new Point(154, 5);
            dtpToDate.Margin = new Padding(4, 5, 4, 5);
            dtpToDate.MaxLength = 10;
            dtpToDate.MinimumSize = new Size(63, 0);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Padding = new Padding(0, 0, 30, 2);
            dtpToDate.Size = new Size(142, 29);
            dtpToDate.SymbolDropDown = 61555;
            dtpToDate.SymbolNormal = 61555;
            dtpToDate.SymbolSize = 24;
            dtpToDate.TabIndex = 1;
            dtpToDate.Text = "2026-01-16";
            dtpToDate.TextAlignment = ContentAlignment.MiddleLeft;
            dtpToDate.Value = new DateTime(2026, 1, 16, 10, 19, 29, 904);
            dtpToDate.Watermark = "";
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.None;
            btnFilter.Font = new Font("Microsoft Sans Serif", 12F);
            btnFilter.Location = new Point(303, 3);
            btnFilter.MinimumSize = new Size(1, 1);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(174, 33);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Lọc báo cáo";
            btnFilter.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnFilter.Click += btnFilter_Click;
            // 
            // chartRevenue
            // 
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Font = new Font("Microsoft Sans Serif", 12F);
            chartRevenue.LegendFont = new Font("Microsoft Sans Serif", 9F);
            chartRevenue.Location = new Point(3, 42);
            chartRevenue.MinimumSize = new Size(1, 1);
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Size = new Size(473, 285);
            chartRevenue.SubFont = new Font("Microsoft Sans Serif", 9F);
            chartRevenue.TabIndex = 1;
            chartRevenue.Text = "uiBarChart1";
            // 
            // chartTopProducts
            // 
            chartTopProducts.Font = new Font("Microsoft Sans Serif", 12F);
            chartTopProducts.LegendFont = new Font("Microsoft Sans Serif", 9F);
            chartTopProducts.Location = new Point(482, 42);
            chartTopProducts.MinimumSize = new Size(1, 1);
            chartTopProducts.Name = "chartTopProducts";
            chartTopProducts.Size = new Size(384, 285);
            chartTopProducts.SubFont = new Font("Microsoft Sans Serif", 9F);
            chartTopProducts.TabIndex = 2;
            chartTopProducts.Text = "Sản phẩm bán chạy";
            // 
            // timerSystem
            // 
            timerSystem.Enabled = true;
            timerSystem.Tick += timerSystem_Tick;
            // 
            // menulog
            // 
            menulog.Name = "menulog";
            menulog.Size = new Size(224, 26);
            menulog.Text = "Lịch sử";
            menulog.Click += menulog_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 494);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FormMain_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            uiTableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem menuItemExit;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem menuItemManageCategory;
        private ToolStripMenuItem menuItemManageProduct;
        private ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private ToolStripMenuItem menuItemSale;
        private Label lblUser;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerSystem;
        private ToolStripMenuItem menuLogout;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UIDatePicker dtpFromDate;
        private Sunny.UI.UIDatePicker dtpToDate;
        private Sunny.UI.UIButton btnFilter;
        private Sunny.UI.UIBarChart chartRevenue;
        private Sunny.UI.UIPieChart chartTopProducts;
        private ToolStripMenuItem menulog;
    }
}
