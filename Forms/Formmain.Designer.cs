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
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            menuItemManageCategory = new ToolStripMenuItem();
            menuItemManageProduct = new ToolStripMenuItem();
            nghiệpVụToolStripMenuItem = new ToolStripMenuItem();
            menuItemSale = new ToolStripMenuItem();
            lblUser = new Label();
            chartRevenue = new Sunny.UI.UIBarChart();
            timerSystem = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(chartRevenue, 0, 2);
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
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItemExit });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // menuItemExit
            // 
            menuItemExit.Name = "menuItemExit";
            menuItemExit.Size = new Size(130, 26);
            menuItemExit.Text = "Thoát";
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
            menuItemSale.Size = new Size(154, 26);
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
            // chartRevenue
            // 
            chartRevenue.Anchor = AnchorStyles.None;
            chartRevenue.Font = new Font("Microsoft Sans Serif", 12F);
            chartRevenue.LegendFont = new Font("Microsoft Sans Serif", 9F);
            chartRevenue.Location = new Point(42, 82);
            chartRevenue.MinimumSize = new Size(1, 1);
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Size = new Size(791, 329);
            chartRevenue.SubFont = new Font("Microsoft Sans Serif", 9F);
            chartRevenue.TabIndex = 4;
            chartRevenue.Text = "Báo cáo doanh thu tuần";
            chartRevenue.Click += chartRevenue_Click;
            // 
            // timerSystem
            // 
            timerSystem.Enabled = true;
            timerSystem.Tick += timerSystem_Tick;
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
        private Sunny.UI.UIBarChart chartRevenue;
    }
}
