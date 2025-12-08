namespace Quanlibanhang
{
    partial class Formmain
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
            tableLayoutPanel1 = new TableLayoutPanel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            uiLabel1 = new Sunny.UI.UILabel();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            menuItemExit = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            menuItemManageCategory = new ToolStripMenuItem();
            menuItemManageProduct = new ToolStripMenuItem();
            nghiệpVụToolStripMenuItem = new ToolStripMenuItem();
            menuItemSale = new ToolStripMenuItem();
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
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 163F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.Size = new Size(875, 494);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 468);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(875, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(81, 20);
            toolStripStatusLabel1.Text = "Hoạt động";
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Wheat;
            uiLabel1.Dock = DockStyle.Fill;
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
            menuItemExit.Click += menuItemExit_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 494);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
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
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem menuItemExit;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem menuItemManageCategory;
        private ToolStripMenuItem menuItemManageProduct;
        private ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private ToolStripMenuItem menuItemSale;
    }
}
