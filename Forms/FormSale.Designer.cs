namespace Quanlibanhang
{
    partial class FormSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblProduct = new Sunny.UI.UILabel();
            cboProduct = new Sunny.UI.UIComboBox();
            nudQuantity = new NumericUpDown();
            btnAddToCart = new Sunny.UI.UIButton();
            lblQuantity = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            lblCart = new Sunny.UI.UILabel();
            uiDataGridView1 = new Sunny.UI.UIDataGridView();
            cChose = new DataGridViewCheckBoxColumn();
            cSTT = new DataGridViewTextBoxColumn();
            cProductName = new DataGridViewTextBoxColumn();
            cQty = new DataGridViewTextBoxColumn();
            cUnitPrice = new DataGridViewTextBoxColumn();
            cLineTotal = new DataGridViewTextBoxColumn();
            uiPanel1 = new Sunny.UI.UIPanel();
            btnCart = new Sunny.UI.UIButton();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            lblCustomer = new Sunny.UI.UILabel();
            lblPhone = new Sunny.UI.UILabel();
            lblTotal = new Sunny.UI.UILabel();
            txtCustomer = new Sunny.UI.UITextBox();
            txtPhone = new Sunny.UI.UITextBox();
            txtTotal = new Sunny.UI.UITextBox();
            btnCheckout = new Sunny.UI.UIButton();
            btnExportTxt = new Sunny.UI.UIButton();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).BeginInit();
            uiPanel1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 176F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.Controls.Add(lblProduct, 0, 0);
            tableLayoutPanel1.Controls.Add(cboProduct, 1, 0);
            tableLayoutPanel1.Controls.Add(nudQuantity, 3, 0);
            tableLayoutPanel1.Controls.Add(btnAddToCart, 4, 0);
            tableLayoutPanel1.Controls.Add(lblQuantity, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1180, 48);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblProduct
            // 
            lblProduct.Dock = DockStyle.Fill;
            lblProduct.Font = new Font("Microsoft Sans Serif", 12F);
            lblProduct.ForeColor = Color.FromArgb(48, 48, 48);
            lblProduct.Location = new Point(3, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(194, 48);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Sản Phẩm:";
            lblProduct.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboProduct
            // 
            cboProduct.DataSource = null;
            cboProduct.Dock = DockStyle.Fill;
            cboProduct.FillColor = Color.White;
            cboProduct.Font = new Font("Microsoft Sans Serif", 12F);
            cboProduct.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboProduct.Items.AddRange(new object[] { "Mì Tôm 3 Miền", "Mì Kokomi", "Mì SiuKay", "Thuốc Lá", "Dầu Gội", "Sữa Tắm", "Bột Giặt", "Kẹo Mút", "Bánh Quy", "Bánh Dẻo", "Hạt Điều", "Pepsi", "Bò Húc", "Siting" });
            cboProduct.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboProduct.Location = new Point(204, 5);
            cboProduct.Margin = new Padding(4, 5, 4, 5);
            cboProduct.MinimumSize = new Size(63, 0);
            cboProduct.Name = "cboProduct";
            cboProduct.Padding = new Padding(0, 0, 30, 2);
            cboProduct.Size = new Size(332, 38);
            cboProduct.SymbolSize = 24;
            cboProduct.TabIndex = 1;
            cboProduct.TextAlignment = ContentAlignment.MiddleCenter;
            cboProduct.Watermark = "";
            // 
            // nudQuantity
            // 
            nudQuantity.Dock = DockStyle.Fill;
            nudQuantity.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuantity.Location = new Point(743, 3);
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(221, 38);
            nudQuantity.TabIndex = 3;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddToCart
            // 
            btnAddToCart.Dock = DockStyle.Fill;
            btnAddToCart.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddToCart.Location = new Point(970, 3);
            btnAddToCart.MinimumSize = new Size(1, 1);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(170, 42);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Thêm vào giỏ";
            btnAddToCart.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.Dock = DockStyle.Fill;
            lblQuantity.Font = new Font("Microsoft Sans Serif", 12F);
            lblQuantity.ForeColor = Color.FromArgb(48, 48, 48);
            lblQuantity.Location = new Point(543, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(194, 48);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số lượng:";
            lblQuantity.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = DockStyle.Top;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(0, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(1180, 50);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "Bán Hàng";
            uiLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(lblCart, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiDataGridView1, 0, 2);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 98);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel1.Size = new Size(1180, 533);
            uiTableLayoutPanel1.TabIndex = 2;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lblCart
            // 
            lblCart.Dock = DockStyle.Fill;
            lblCart.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCart.ForeColor = Color.FromArgb(48, 48, 48);
            lblCart.Location = new Point(3, 30);
            lblCart.Name = "lblCart";
            lblCart.Size = new Size(1174, 47);
            lblCart.TabIndex = 0;
            lblCart.Text = "Giỏ Hàng";
            lblCart.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            uiDataGridView1.BackgroundColor = Color.White;
            uiDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            uiDataGridView1.ColumnHeadersHeight = 32;
            uiDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            uiDataGridView1.Columns.AddRange(new DataGridViewColumn[] { cChose, cSTT, cProductName, cQty, cUnitPrice, cLineTotal });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            uiDataGridView1.Dock = DockStyle.Fill;
            uiDataGridView1.EnableHeadersVisualStyles = false;
            uiDataGridView1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridView1.GridColor = Color.FromArgb(80, 160, 255);
            uiDataGridView1.Location = new Point(3, 80);
            uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            uiDataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            uiDataGridView1.SelectedIndex = -1;
            uiDataGridView1.Size = new Size(1174, 450);
            uiDataGridView1.StripeOddColor = Color.FromArgb(235, 243, 255);
            uiDataGridView1.TabIndex = 1;
            // 
            // cChose
            // 
            cChose.HeaderText = "Chọn";
            cChose.MinimumWidth = 6;
            cChose.Name = "cChose";
            cChose.Width = 176;
            // 
            // cSTT
            // 
            cSTT.HeaderText = "STT";
            cSTT.MinimumWidth = 6;
            cSTT.Name = "cSTT";
            cSTT.Width = 175;
            // 
            // cProductName
            // 
            cProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cProductName.HeaderText = "Sản phẩm";
            cProductName.MinimumWidth = 6;
            cProductName.Name = "cProductName";
            // 
            // cQty
            // 
            cQty.HeaderText = "Số Lượng";
            cQty.MinimumWidth = 6;
            cQty.Name = "cQty";
            cQty.Width = 175;
            // 
            // cUnitPrice
            // 
            cUnitPrice.HeaderText = "Đơn Giá";
            cUnitPrice.MinimumWidth = 6;
            cUnitPrice.Name = "cUnitPrice";
            cUnitPrice.Width = 200;
            // 
            // cLineTotal
            // 
            cLineTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cLineTotal.HeaderText = "Thành Tiền";
            cLineTotal.MinimumWidth = 6;
            cLineTotal.Name = "cLineTotal";
            cLineTotal.Width = 200;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(btnCart);
            uiPanel1.Dock = DockStyle.Bottom;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.ForeColor = Color.White;
            uiPanel1.ForeDisableColor = Color.White;
            uiPanel1.Location = new Point(0, 454);
            uiPanel1.Margin = new Padding(0);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RectColor = Color.White;
            uiPanel1.RectDisableColor = Color.White;
            uiPanel1.Size = new Size(1180, 52);
            uiPanel1.TabIndex = 3;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnCart
            // 
            btnCart.Dock = DockStyle.Left;
            btnCart.FillColor = Color.Firebrick;
            btnCart.Font = new Font("Microsoft Sans Serif", 12F);
            btnCart.Location = new Point(0, 0);
            btnCart.MinimumSize = new Size(1, 1);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(164, 52);
            btnCart.TabIndex = 0;
            btnCart.Text = "Xóa khỏi giỏ";
            btnCart.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCart.Click += btnCart_Click;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 4;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.19976F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.14681F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.6522274F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.0012054F));
            uiTableLayoutPanel2.Controls.Add(lblCustomer, 0, 0);
            uiTableLayoutPanel2.Controls.Add(lblPhone, 2, 0);
            uiTableLayoutPanel2.Controls.Add(lblTotal, 0, 1);
            uiTableLayoutPanel2.Controls.Add(txtCustomer, 1, 0);
            uiTableLayoutPanel2.Controls.Add(txtPhone, 3, 0);
            uiTableLayoutPanel2.Controls.Add(txtTotal, 1, 1);
            uiTableLayoutPanel2.Controls.Add(btnCheckout, 2, 1);
            uiTableLayoutPanel2.Controls.Add(btnExportTxt, 3, 1);
            uiTableLayoutPanel2.Dock = DockStyle.Bottom;
            uiTableLayoutPanel2.Location = new Point(0, 506);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 3;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            uiTableLayoutPanel2.Size = new Size(1180, 125);
            uiTableLayoutPanel2.TabIndex = 4;
            uiTableLayoutPanel2.TagString = null;
            // 
            // lblCustomer
            // 
            lblCustomer.Dock = DockStyle.Fill;
            lblCustomer.Font = new Font("Microsoft Sans Serif", 12F);
            lblCustomer.ForeColor = Color.FromArgb(48, 48, 48);
            lblCustomer.Location = new Point(3, 0);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(161, 52);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Tên khách:";
            lblCustomer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPhone
            // 
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Font = new Font("Microsoft Sans Serif", 12F);
            lblPhone.ForeColor = Color.FromArgb(48, 48, 48);
            lblPhone.Location = new Point(620, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(214, 52);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "SĐT:";
            lblPhone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F);
            lblTotal.ForeColor = Color.FromArgb(48, 48, 48);
            lblTotal.Location = new Point(3, 52);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(161, 52);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Tổng tiền:";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCustomer
            // 
            txtCustomer.Dock = DockStyle.Fill;
            txtCustomer.Font = new Font("Microsoft Sans Serif", 12F);
            txtCustomer.Location = new Point(171, 5);
            txtCustomer.Margin = new Padding(4, 5, 4, 5);
            txtCustomer.MinimumSize = new Size(1, 16);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Padding = new Padding(5);
            txtCustomer.ShowText = false;
            txtCustomer.Size = new Size(442, 42);
            txtCustomer.TabIndex = 3;
            txtCustomer.TextAlignment = ContentAlignment.MiddleLeft;
            txtCustomer.Watermark = "";
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Microsoft Sans Serif", 12F);
            txtPhone.Location = new Point(841, 5);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.MinimumSize = new Size(1, 16);
            txtPhone.Name = "txtPhone";
            txtPhone.Padding = new Padding(5);
            txtPhone.ShowText = false;
            txtPhone.Size = new Size(335, 42);
            txtPhone.TabIndex = 4;
            txtPhone.TextAlignment = ContentAlignment.MiddleCenter;
            txtPhone.Watermark = "";
            // 
            // txtTotal
            // 
            txtTotal.Dock = DockStyle.Fill;
            txtTotal.Font = new Font("Microsoft Sans Serif", 12F);
            txtTotal.Location = new Point(171, 57);
            txtTotal.Margin = new Padding(4, 5, 4, 5);
            txtTotal.MinimumSize = new Size(1, 16);
            txtTotal.Name = "txtTotal";
            txtTotal.Padding = new Padding(5);
            txtTotal.ShowText = false;
            txtTotal.Size = new Size(442, 42);
            txtTotal.TabIndex = 5;
            txtTotal.TextAlignment = ContentAlignment.MiddleLeft;
            txtTotal.Watermark = "";
            // 
            // btnCheckout
            // 
            btnCheckout.Dock = DockStyle.Fill;
            btnCheckout.Font = new Font("Microsoft Sans Serif", 12F);
            btnCheckout.Location = new Point(620, 55);
            btnCheckout.MinimumSize = new Size(1, 1);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(214, 46);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Thanh Toán";
            btnCheckout.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnExportTxt
            // 
            btnExportTxt.Dock = DockStyle.Fill;
            btnExportTxt.Font = new Font("Microsoft Sans Serif", 12F);
            btnExportTxt.Location = new Point(840, 55);
            btnExportTxt.MinimumSize = new Size(1, 1);
            btnExportTxt.Name = "btnExportTxt";
            btnExportTxt.Size = new Size(337, 46);
            btnExportTxt.TabIndex = 7;
            btnExportTxt.Text = "Xuất hóa đơn TXT";
            btnExportTxt.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnExportTxt.Click += btnExportTxt_Click;
            // 
            // FormSale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 631);
            Controls.Add(uiPanel1);
            Controls.Add(uiTableLayoutPanel2);
            Controls.Add(uiTableLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(uiLabel1);
            Name = "FormSale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán Hàng";
            Load += FormSale_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).EndInit();
            uiPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel lblProduct;
        private Sunny.UI.UIComboBox cboProduct;
        private Sunny.UI.UILabel lblQuantity;
        private NumericUpDown nudQuantity;
        private Sunny.UI.UIButton btnAddToCart;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lblCart;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIButton btnCart;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UILabel lblCustomer;
        private Sunny.UI.UILabel lblPhone;
        private Sunny.UI.UILabel lblTotal;
        private Sunny.UI.UITextBox txtCustomer;
        private Sunny.UI.UITextBox txtPhone;
        private Sunny.UI.UITextBox txtTotal;
        private Sunny.UI.UIButton btnCheckout;
        private Sunny.UI.UIButton btnExportTxt;
        private DataGridViewCheckBoxColumn cChose;
        private DataGridViewTextBoxColumn cSTT;
        private DataGridViewTextBoxColumn cProductName;
        private DataGridViewTextBoxColumn cQty;
        private DataGridViewTextBoxColumn cUnitPrice;
        private DataGridViewTextBoxColumn cLineTotal;
    }
}