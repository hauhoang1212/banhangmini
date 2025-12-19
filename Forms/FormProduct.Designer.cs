namespace Quanlibanhang
{
    partial class FormProduct
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            lblSanPham = new Sunny.UI.UILabel();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            lblName = new Sunny.UI.UILabel();
            lblCategory = new Sunny.UI.UILabel();
            lblPrice = new Sunny.UI.UILabel();
            lblStock = new Sunny.UI.UILabel();
            txtNameProduct = new Sunny.UI.UITextBox();
            txtPrice = new Sunny.UI.UITextBox();
            txtStock = new Sunny.UI.UITextBox();
            cboCategory = new Sunny.UI.UIComboBox();
            uiCheckBox1 = new Sunny.UI.UICheckBox();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            btnAdd = new Sunny.UI.UIButton();
            btnEdit = new Sunny.UI.UIButton();
            btnDelete = new Sunny.UI.UIButton();
            btnSave = new Sunny.UI.UIButton();
            btnCancel = new Sunny.UI.UIButton();
            btnSearch = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            dgvProduct = new Sunny.UI.UIDataGridView();
            cChose = new DataGridViewCheckBoxColumn();
            cSTT = new DataGridViewTextBoxColumn();
            cProductID = new DataGridViewTextBoxColumn();
            cName = new DataGridViewTextBoxColumn();
            cCategory = new DataGridViewTextBoxColumn();
            cPrice = new DataGridViewTextBoxColumn();
            cStock = new DataGridViewTextBoxColumn();
            cIsActive = new DataGridViewCheckBoxColumn();
            uiTableLayoutPanel1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // lblSanPham
            // 
            lblSanPham.Dock = DockStyle.Top;
            lblSanPham.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSanPham.ForeColor = Color.FromArgb(48, 48, 48);
            lblSanPham.Location = new Point(0, 0);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(1111, 50);
            lblSanPham.TabIndex = 2;
            lblSanPham.Text = "Quản Lý Sản Phẩm";
            lblSanPham.TextAlign = ContentAlignment.TopCenter;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 4;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.Controls.Add(lblName, 0, 0);
            uiTableLayoutPanel1.Controls.Add(lblCategory, 2, 0);
            uiTableLayoutPanel1.Controls.Add(lblPrice, 0, 1);
            uiTableLayoutPanel1.Controls.Add(lblStock, 0, 2);
            uiTableLayoutPanel1.Controls.Add(txtNameProduct, 1, 0);
            uiTableLayoutPanel1.Controls.Add(txtPrice, 1, 1);
            uiTableLayoutPanel1.Controls.Add(txtStock, 1, 2);
            uiTableLayoutPanel1.Controls.Add(cboCategory, 3, 0);
            uiTableLayoutPanel1.Controls.Add(uiCheckBox1, 3, 1);
            uiTableLayoutPanel1.Dock = DockStyle.Top;
            uiTableLayoutPanel1.Location = new Point(0, 50);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel1.Size = new Size(1111, 125);
            uiTableLayoutPanel1.TabIndex = 3;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lblName
            // 
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Microsoft Sans Serif", 12F);
            lblName.ForeColor = Color.FromArgb(48, 48, 48);
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(194, 41);
            lblName.TabIndex = 0;
            lblName.Text = "Tên Sản Phẩm:";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Font = new Font("Microsoft Sans Serif", 12F);
            lblCategory.ForeColor = Color.FromArgb(48, 48, 48);
            lblCategory.Location = new Point(558, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(194, 41);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category:";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Font = new Font("Microsoft Sans Serif", 12F);
            lblPrice.ForeColor = Color.FromArgb(48, 48, 48);
            lblPrice.Location = new Point(3, 41);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(194, 41);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Giá:";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStock
            // 
            lblStock.Dock = DockStyle.Fill;
            lblStock.Font = new Font("Microsoft Sans Serif", 12F);
            lblStock.ForeColor = Color.FromArgb(48, 48, 48);
            lblStock.Location = new Point(3, 82);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(194, 43);
            lblStock.TabIndex = 3;
            lblStock.Text = "Stock:";
            lblStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNameProduct
            // 
            txtNameProduct.Dock = DockStyle.Fill;
            txtNameProduct.Font = new Font("Microsoft Sans Serif", 12F);
            txtNameProduct.Location = new Point(204, 5);
            txtNameProduct.Margin = new Padding(4, 5, 4, 5);
            txtNameProduct.MinimumSize = new Size(1, 16);
            txtNameProduct.Name = "txtNameProduct";
            txtNameProduct.Padding = new Padding(5);
            txtNameProduct.ShowText = false;
            txtNameProduct.Size = new Size(347, 31);
            txtNameProduct.TabIndex = 4;
            txtNameProduct.TextAlignment = ContentAlignment.MiddleLeft;
            txtNameProduct.Watermark = "";
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Font = new Font("Microsoft Sans Serif", 12F);
            txtPrice.Location = new Point(204, 46);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.MinimumSize = new Size(1, 16);
            txtPrice.Name = "txtPrice";
            txtPrice.Padding = new Padding(5);
            txtPrice.ShowText = false;
            txtPrice.Size = new Size(347, 31);
            txtPrice.TabIndex = 5;
            txtPrice.TextAlignment = ContentAlignment.MiddleCenter;
            txtPrice.Watermark = "";
            // 
            // txtStock
            // 
            txtStock.Dock = DockStyle.Fill;
            txtStock.Font = new Font("Microsoft Sans Serif", 12F);
            txtStock.Location = new Point(204, 87);
            txtStock.Margin = new Padding(4, 5, 4, 5);
            txtStock.MinimumSize = new Size(1, 16);
            txtStock.Name = "txtStock";
            txtStock.Padding = new Padding(5);
            txtStock.ShowText = false;
            txtStock.Size = new Size(347, 33);
            txtStock.TabIndex = 6;
            txtStock.TextAlignment = ContentAlignment.MiddleCenter;
            txtStock.Watermark = "";
            // 
            // cboCategory
            // 
            cboCategory.DataSource = null;
            cboCategory.Dock = DockStyle.Fill;
            cboCategory.FillColor = Color.White;
            cboCategory.Font = new Font("Microsoft Sans Serif", 12F);
            cboCategory.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboCategory.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboCategory.Location = new Point(759, 5);
            cboCategory.Margin = new Padding(4, 5, 4, 5);
            cboCategory.MinimumSize = new Size(63, 0);
            cboCategory.Name = "cboCategory";
            cboCategory.Padding = new Padding(0, 0, 30, 2);
            cboCategory.Size = new Size(348, 31);
            cboCategory.SymbolSize = 24;
            cboCategory.TabIndex = 8;
            cboCategory.TextAlignment = ContentAlignment.MiddleLeft;
            cboCategory.Watermark = "";
            // 
            // uiCheckBox1
            // 
            uiCheckBox1.Dock = DockStyle.Fill;
            uiCheckBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiCheckBox1.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox1.Location = new Point(758, 44);
            uiCheckBox1.MinimumSize = new Size(1, 1);
            uiCheckBox1.Name = "uiCheckBox1";
            uiCheckBox1.Size = new Size(350, 35);
            uiCheckBox1.TabIndex = 9;
            uiCheckBox1.Text = "Đang Bán";
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 7;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Controls.Add(btnAdd, 0, 0);
            uiTableLayoutPanel2.Controls.Add(btnEdit, 1, 0);
            uiTableLayoutPanel2.Controls.Add(btnDelete, 2, 0);
            uiTableLayoutPanel2.Controls.Add(btnSave, 3, 0);
            uiTableLayoutPanel2.Controls.Add(btnCancel, 4, 0);
            uiTableLayoutPanel2.Controls.Add(btnSearch, 5, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Top;
            uiTableLayoutPanel2.Location = new Point(0, 175);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.Padding = new Padding(10);
            uiTableLayoutPanel2.RowCount = 1;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Size = new Size(1111, 71);
            uiTableLayoutPanel2.TabIndex = 4;
            uiTableLayoutPanel2.TagString = null;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(13, 13);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 45);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(113, 13);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 45);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Microsoft Sans Serif", 12F);
            btnDelete.Location = new Point(213, 13);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 45);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F);
            btnSave.Location = new Point(313, 13);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 45);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancel.Location = new Point(413, 13);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(513, 13);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 45);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm Kiếm";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = DockStyle.Top;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(0, 246);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Padding = new Padding(10, 20, 10, 10);
            uiLabel1.Size = new Size(1111, 51);
            uiLabel1.TabIndex = 5;
            uiLabel1.Text = "Danh Sách Sản Phẩm\r\n";
            uiLabel1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dgvProduct
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvProduct.BackgroundColor = Color.White;
            dgvProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvProduct.ColumnHeadersHeight = 32;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProduct.Columns.AddRange(new DataGridViewColumn[] { cChose, cSTT, cProductID, cName, cCategory, cPrice, cStock, cIsActive });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvProduct.DefaultCellStyle = dataGridViewCellStyle8;
            dgvProduct.Dock = DockStyle.Fill;
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.Font = new Font("Microsoft Sans Serif", 12F);
            dgvProduct.GridColor = Color.FromArgb(80, 160, 255);
            dgvProduct.Location = new Point(0, 297);
            dgvProduct.Name = "dgvProduct";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dgvProduct.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvProduct.SelectedIndex = -1;
            dgvProduct.Size = new Size(1111, 223);
            dgvProduct.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvProduct.TabIndex = 6;
            // 
            // cChose
            // 
            cChose.HeaderText = "Chọn";
            cChose.MinimumWidth = 6;
            cChose.Name = "cChose";
            cChose.Width = 125;
            // 
            // cSTT
            // 
            cSTT.HeaderText = "STT";
            cSTT.MinimumWidth = 6;
            cSTT.Name = "cSTT";
            cSTT.Resizable = DataGridViewTriState.True;
            cSTT.SortMode = DataGridViewColumnSortMode.NotSortable;
            cSTT.Width = 125;
            // 
            // cProductID
            // 
            cProductID.HeaderText = "ID Sản Phẩm";
            cProductID.MinimumWidth = 6;
            cProductID.Name = "cProductID";
            cProductID.Resizable = DataGridViewTriState.True;
            cProductID.SortMode = DataGridViewColumnSortMode.NotSortable;
            cProductID.Width = 125;
            // 
            // cName
            // 
            cName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cName.HeaderText = "Sản Phẩm";
            cName.MinimumWidth = 6;
            cName.Name = "cName";
            cName.Resizable = DataGridViewTriState.True;
            cName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cCategory
            // 
            cCategory.HeaderText = "Loại";
            cCategory.MinimumWidth = 6;
            cCategory.Name = "cCategory";
            cCategory.Resizable = DataGridViewTriState.True;
            cCategory.SortMode = DataGridViewColumnSortMode.NotSortable;
            cCategory.Width = 125;
            // 
            // cPrice
            // 
            cPrice.HeaderText = "Giá";
            cPrice.MinimumWidth = 6;
            cPrice.Name = "cPrice";
            cPrice.Resizable = DataGridViewTriState.True;
            cPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            cPrice.Width = 125;
            // 
            // cStock
            // 
            cStock.HeaderText = "Stock";
            cStock.MinimumWidth = 6;
            cStock.Name = "cStock";
            cStock.Resizable = DataGridViewTriState.True;
            cStock.SortMode = DataGridViewColumnSortMode.NotSortable;
            cStock.Width = 125;
            // 
            // cIsActive
            // 
            cIsActive.HeaderText = "Đang Bán";
            cIsActive.MinimumWidth = 6;
            cIsActive.Name = "cIsActive";
            cIsActive.Width = 125;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 520);
            Controls.Add(dgvProduct);
            Controls.Add(uiLabel1);
            Controls.Add(uiTableLayoutPanel2);
            Controls.Add(uiTableLayoutPanel1);
            Controls.Add(lblSanPham);
            Name = "FormProduct";
            Text = "FormProduct";
            uiTableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel lblSanPham;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lblName;
        private Sunny.UI.UILabel lblCategory;
        private Sunny.UI.UILabel lblPrice;
        private Sunny.UI.UILabel lblStock;
        private Sunny.UI.UITextBox txtNameProduct;
        private Sunny.UI.UITextBox txtPrice;
        private Sunny.UI.UITextBox txtStock;
        private Sunny.UI.UIComboBox cboCategory;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UIButton btnAdd;
        private Sunny.UI.UIButton btnEdit;
        private Sunny.UI.UIButton btnDelete;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UIButton btnCancel;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIDataGridView dgvProduct;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private DataGridViewCheckBoxColumn cChose;
        private DataGridViewTextBoxColumn cSTT;
        private DataGridViewTextBoxColumn cProductID;
        private DataGridViewTextBoxColumn cName;
        private DataGridViewTextBoxColumn cCategory;
        private DataGridViewTextBoxColumn cPrice;
        private DataGridViewTextBoxColumn cStock;
        private DataGridViewCheckBoxColumn cIsActive;
    }
}