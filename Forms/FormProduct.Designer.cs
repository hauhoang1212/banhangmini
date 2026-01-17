namespace Quanlibanhang.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            btnCancel = new Sunny.UI.UIButton();
            btnDelete = new Sunny.UI.UIButton();
            btnEdit = new Sunny.UI.UIButton();
            btnAdd = new Sunny.UI.UIButton();
            btnSave = new Sunny.UI.UIButton();
            dgvProduct = new Sunny.UI.UIDataGridView();
            cChose = new DataGridViewCheckBoxColumn();
            cSTT = new DataGridViewTextBoxColumn();
            cProductID = new DataGridViewTextBoxColumn();
            cName = new DataGridViewTextBoxColumn();
            cPrice = new DataGridViewTextBoxColumn();
            cCategory = new DataGridViewTextBoxColumn();
            cDSC = new DataGridViewTextBoxColumn();
            cStock = new DataGridViewTextBoxColumn();
            cIsActive = new DataGridViewCheckBoxColumn();
            uiLabel4 = new Sunny.UI.UILabel();
            uiTableLayoutPanel4 = new Sunny.UI.UITableLayoutPanel();
            btnImportCsv = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            txtSearchh = new Sunny.UI.UITextBox();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            txtStock = new Sunny.UI.UITextBox();
            chkIsActive = new Sunny.UI.UICheckBox();
            uiLabel3 = new Sunny.UI.UILabel();
            txtDescription = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            lblName = new Sunny.UI.UILabel();
            lblCategory = new Sunny.UI.UILabel();
            lblPrice = new Sunny.UI.UILabel();
            lblStock = new Sunny.UI.UILabel();
            txtProductID = new Sunny.UI.UITextBox();
            txtNameProduct = new Sunny.UI.UITextBox();
            txtPrice = new Sunny.UI.UITextBox();
            cboCategory = new Sunny.UI.UIComboBox();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiTableLayoutPanel1.SuspendLayout();
            uiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            uiTableLayoutPanel4.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel3, 0, 2);
            uiTableLayoutPanel1.Controls.Add(dgvProduct, 0, 5);
            uiTableLayoutPanel1.Controls.Add(uiLabel4, 0, 4);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel4, 0, 3);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel2, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiPanel1, 0, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Margin = new Padding(0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 7;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            uiTableLayoutPanel1.Size = new Size(990, 488);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 6;
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730547F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.6383762F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6694355F));
            uiTableLayoutPanel3.Controls.Add(btnCancel, 4, 0);
            uiTableLayoutPanel3.Controls.Add(btnDelete, 2, 0);
            uiTableLayoutPanel3.Controls.Add(btnEdit, 1, 0);
            uiTableLayoutPanel3.Controls.Add(btnAdd, 0, 0);
            uiTableLayoutPanel3.Controls.Add(btnSave, 5, 0);
            uiTableLayoutPanel3.Dock = DockStyle.Fill;
            uiTableLayoutPanel3.Location = new Point(0, 200);
            uiTableLayoutPanel3.Margin = new Padding(0);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 1;
            uiTableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel3.Size = new Size(990, 40);
            uiTableLayoutPanel3.TabIndex = 9;
            uiTableLayoutPanel3.TagString = null;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancel.Location = new Point(721, 3);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 34);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Huỷ";
            btnCancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Microsoft Sans Serif", 12F);
            btnDelete.Location = new Point(273, 3);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xoá";
            btnDelete.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(138, 3);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(129, 34);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(3, 3);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F);
            btnSave.Location = new Point(856, 3);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSave.Click += btnSave_Click;
            // 
            // dgvProduct
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.BackgroundColor = Color.White;
            dgvProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProduct.ColumnHeadersHeight = 32;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProduct.Columns.AddRange(new DataGridViewColumn[] { cChose, cSTT, cProductID, cName, cPrice, cCategory, cDSC, cStock, cIsActive });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProduct.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProduct.Dock = DockStyle.Fill;
            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.Font = new Font("Microsoft Sans Serif", 12F);
            dgvProduct.GridColor = Color.FromArgb(80, 160, 255);
            dgvProduct.Location = new Point(3, 323);
            dgvProduct.Name = "dgvProduct";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvProduct.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvProduct.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvProduct.SelectedIndex = -1;
            dgvProduct.Size = new Size(984, 136);
            dgvProduct.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvProduct.TabIndex = 8;
            // 
            // cChose
            // 
            cChose.HeaderText = "Chọn";
            cChose.MinimumWidth = 6;
            cChose.Name = "cChose";
            // 
            // cSTT
            // 
            cSTT.HeaderText = "STT";
            cSTT.MinimumWidth = 6;
            cSTT.Name = "cSTT";
            cSTT.Resizable = DataGridViewTriState.True;
            cSTT.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cProductID
            // 
            cProductID.HeaderText = "ID Sản Phẩm";
            cProductID.MinimumWidth = 6;
            cProductID.Name = "cProductID";
            cProductID.Resizable = DataGridViewTriState.True;
            cProductID.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cName
            // 
            cName.HeaderText = "Tên Sản Phẩm";
            cName.MinimumWidth = 6;
            cName.Name = "cName";
            cName.Resizable = DataGridViewTriState.True;
            cName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cPrice
            // 
            cPrice.HeaderText = "Đơn Giá";
            cPrice.MinimumWidth = 6;
            cPrice.Name = "cPrice";
            cPrice.Resizable = DataGridViewTriState.True;
            cPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cCategory
            // 
            cCategory.HeaderText = "Tên Loại";
            cCategory.MinimumWidth = 6;
            cCategory.Name = "cCategory";
            cCategory.Resizable = DataGridViewTriState.True;
            cCategory.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cDSC
            // 
            cDSC.HeaderText = "Mô tả";
            cDSC.MinimumWidth = 6;
            cDSC.Name = "cDSC";
            // 
            // cStock
            // 
            cStock.HeaderText = "Stock";
            cStock.MinimumWidth = 6;
            cStock.Name = "cStock";
            cStock.Resizable = DataGridViewTriState.True;
            cStock.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cIsActive
            // 
            cIsActive.HeaderText = "Đang Bán";
            cIsActive.MinimumWidth = 6;
            cIsActive.Name = "cIsActive";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = SystemColors.ActiveCaption;
            uiLabel4.Dock = DockStyle.Fill;
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(3, 280);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(984, 40);
            uiLabel4.TabIndex = 7;
            uiLabel4.Text = "Danh sách sản phẩm";
            uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel4
            // 
            uiTableLayoutPanel4.ColumnCount = 4;
            uiTableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4623146F));
            uiTableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.79397F));
            uiTableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.0653267F));
            uiTableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.67839F));
            uiTableLayoutPanel4.Controls.Add(btnImportCsv, 3, 0);
            uiTableLayoutPanel4.Controls.Add(uiLabel1, 0, 0);
            uiTableLayoutPanel4.Controls.Add(txtSearchh, 1, 0);
            uiTableLayoutPanel4.Dock = DockStyle.Fill;
            uiTableLayoutPanel4.Location = new Point(0, 240);
            uiTableLayoutPanel4.Margin = new Padding(0);
            uiTableLayoutPanel4.Name = "uiTableLayoutPanel4";
            uiTableLayoutPanel4.RowCount = 1;
            uiTableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel4.Size = new Size(990, 40);
            uiTableLayoutPanel4.TabIndex = 6;
            uiTableLayoutPanel4.TagString = null;
            // 
            // btnImportCsv
            // 
            btnImportCsv.Dock = DockStyle.Fill;
            btnImportCsv.Font = new Font("Microsoft Sans Serif", 12F);
            btnImportCsv.Location = new Point(638, 3);
            btnImportCsv.MinimumSize = new Size(1, 1);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(349, 34);
            btnImportCsv.TabIndex = 4;
            btnImportCsv.Text = "Import CSV";
            btnImportCsv.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Gray;
            uiLabel1.Dock = DockStyle.Fill;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(2, 2);
            uiLabel1.Margin = new Padding(2);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(168, 36);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "Tìm kiếm";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearchh
            // 
            txtSearchh.Dock = DockStyle.Fill;
            txtSearchh.Font = new Font("Microsoft Sans Serif", 12F);
            txtSearchh.Location = new Point(176, 5);
            txtSearchh.Margin = new Padding(4, 5, 4, 5);
            txtSearchh.MinimumSize = new Size(1, 16);
            txtSearchh.Name = "txtSearchh";
            txtSearchh.Padding = new Padding(5);
            txtSearchh.ShowText = false;
            txtSearchh.Size = new Size(326, 30);
            txtSearchh.TabIndex = 3;
            txtSearchh.TextAlignment = ContentAlignment.MiddleLeft;
            txtSearchh.Watermark = "";
            txtSearchh.Click += txtSearchh_TextChanged;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 4;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.Controls.Add(txtStock, 3, 2);
            uiTableLayoutPanel2.Controls.Add(chkIsActive, 3, 3);
            uiTableLayoutPanel2.Controls.Add(uiLabel3, 2, 2);
            uiTableLayoutPanel2.Controls.Add(txtDescription, 3, 1);
            uiTableLayoutPanel2.Controls.Add(uiLabel2, 2, 1);
            uiTableLayoutPanel2.Controls.Add(lblName, 0, 0);
            uiTableLayoutPanel2.Controls.Add(lblCategory, 2, 0);
            uiTableLayoutPanel2.Controls.Add(lblPrice, 0, 1);
            uiTableLayoutPanel2.Controls.Add(lblStock, 0, 2);
            uiTableLayoutPanel2.Controls.Add(txtProductID, 1, 0);
            uiTableLayoutPanel2.Controls.Add(txtNameProduct, 1, 1);
            uiTableLayoutPanel2.Controls.Add(txtPrice, 1, 2);
            uiTableLayoutPanel2.Controls.Add(cboCategory, 3, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(0, 40);
            uiTableLayoutPanel2.Margin = new Padding(0);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 4;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            uiTableLayoutPanel2.Size = new Size(990, 160);
            uiTableLayoutPanel2.TabIndex = 4;
            uiTableLayoutPanel2.TagString = null;
            // 
            // txtStock
            // 
            txtStock.Dock = DockStyle.Fill;
            txtStock.Font = new Font("Microsoft Sans Serif", 12F);
            txtStock.Location = new Point(699, 91);
            txtStock.Margin = new Padding(4, 5, 4, 5);
            txtStock.MinimumSize = new Size(1, 16);
            txtStock.Name = "txtStock";
            txtStock.Padding = new Padding(5);
            txtStock.ShowText = false;
            txtStock.Size = new Size(287, 33);
            txtStock.TabIndex = 20;
            txtStock.TextAlignment = ContentAlignment.MiddleLeft;
            txtStock.Watermark = "";
            // 
            // chkIsActive
            // 
            chkIsActive.Dock = DockStyle.Fill;
            chkIsActive.Font = new Font("Microsoft Sans Serif", 12F);
            chkIsActive.ForeColor = Color.FromArgb(48, 48, 48);
            chkIsActive.Location = new Point(698, 132);
            chkIsActive.MinimumSize = new Size(1, 1);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(289, 25);
            chkIsActive.TabIndex = 19;
            chkIsActive.Text = "Đang Bán";
            // 
            // uiLabel3
            // 
            uiLabel3.Dock = DockStyle.Fill;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(498, 86);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(194, 43);
            uiLabel3.TabIndex = 15;
            uiLabel3.Text = "Stock";
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Font = new Font("Microsoft Sans Serif", 12F);
            txtDescription.Location = new Point(699, 48);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.MinimumSize = new Size(1, 16);
            txtDescription.Name = "txtDescription";
            txtDescription.Padding = new Padding(5);
            txtDescription.ReadOnly = true;
            txtDescription.ShowText = false;
            txtDescription.Size = new Size(287, 33);
            txtDescription.TabIndex = 14;
            txtDescription.TextAlignment = ContentAlignment.MiddleLeft;
            txtDescription.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Dock = DockStyle.Fill;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(498, 43);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(194, 43);
            uiLabel2.TabIndex = 13;
            uiLabel2.Text = "Mô tả";
            uiLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.BackColor = SystemColors.Control;
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Microsoft Sans Serif", 12F);
            lblName.ForeColor = Color.FromArgb(48, 48, 48);
            lblName.Location = new Point(5, 5);
            lblName.Margin = new Padding(5);
            lblName.Name = "lblName";
            lblName.Size = new Size(190, 33);
            lblName.TabIndex = 0;
            lblName.Text = "ID Sản Phẩm:";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Font = new Font("Microsoft Sans Serif", 12F);
            lblCategory.ForeColor = Color.FromArgb(48, 48, 48);
            lblCategory.Location = new Point(498, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(194, 43);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Tên loại";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Font = new Font("Microsoft Sans Serif", 12F);
            lblPrice.ForeColor = Color.FromArgb(48, 48, 48);
            lblPrice.Location = new Point(3, 43);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(194, 43);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Tên sản phẩm";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStock
            // 
            lblStock.Dock = DockStyle.Fill;
            lblStock.Font = new Font("Microsoft Sans Serif", 12F);
            lblStock.ForeColor = Color.FromArgb(48, 48, 48);
            lblStock.Location = new Point(3, 86);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(194, 43);
            lblStock.TabIndex = 3;
            lblStock.Text = "Đơn giá";
            lblStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtProductID
            // 
            txtProductID.Dock = DockStyle.Fill;
            txtProductID.Font = new Font("Microsoft Sans Serif", 12F);
            txtProductID.Location = new Point(204, 5);
            txtProductID.Margin = new Padding(4, 5, 4, 5);
            txtProductID.MinimumSize = new Size(1, 16);
            txtProductID.Name = "txtProductID";
            txtProductID.Padding = new Padding(5);
            txtProductID.ShowText = false;
            txtProductID.Size = new Size(287, 33);
            txtProductID.TabIndex = 4;
            txtProductID.TextAlignment = ContentAlignment.MiddleLeft;
            txtProductID.Watermark = "";
            // 
            // txtNameProduct
            // 
            txtNameProduct.Dock = DockStyle.Fill;
            txtNameProduct.Font = new Font("Microsoft Sans Serif", 12F);
            txtNameProduct.Location = new Point(204, 48);
            txtNameProduct.Margin = new Padding(4, 5, 4, 5);
            txtNameProduct.MinimumSize = new Size(1, 16);
            txtNameProduct.Name = "txtNameProduct";
            txtNameProduct.Padding = new Padding(5);
            txtNameProduct.ShowText = false;
            txtNameProduct.Size = new Size(287, 33);
            txtNameProduct.TabIndex = 5;
            txtNameProduct.TextAlignment = ContentAlignment.MiddleLeft;
            txtNameProduct.Watermark = "";
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Font = new Font("Microsoft Sans Serif", 12F);
            txtPrice.Location = new Point(204, 91);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.MinimumSize = new Size(1, 16);
            txtPrice.Name = "txtPrice";
            txtPrice.Padding = new Padding(5);
            txtPrice.ShowText = false;
            txtPrice.Size = new Size(287, 33);
            txtPrice.TabIndex = 6;
            txtPrice.TextAlignment = ContentAlignment.MiddleLeft;
            txtPrice.Watermark = "";
            // 
            // cboCategory
            // 
            cboCategory.DataSource = null;
            cboCategory.Dock = DockStyle.Fill;
            cboCategory.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cboCategory.FillColor = Color.White;
            cboCategory.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboCategory.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboCategory.Location = new Point(699, 4);
            cboCategory.Margin = new Padding(4);
            cboCategory.MinimumSize = new Size(63, 0);
            cboCategory.Name = "cboCategory";
            cboCategory.Padding = new Padding(0, 0, 30, 2);
            cboCategory.Radius = 1;
            cboCategory.Size = new Size(287, 35);
            cboCategory.SymbolSize = 24;
            cboCategory.TabIndex = 8;
            cboCategory.TextAlignment = ContentAlignment.MiddleLeft;
            cboCategory.Watermark = "";
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = Color.Lime;
            uiPanel1.Dock = DockStyle.Fill;
            uiPanel1.FillColor = Color.DeepSkyBlue;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 0);
            uiPanel1.Margin = new Padding(0);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(990, 40);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = "QUÁN LÍ SẢN PHẨM";
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 488);
            Controls.Add(uiTableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProduct";
            uiTableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            uiTableLayoutPanel4.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITextBox txtStock;
        private Sunny.UI.UICheckBox chkIsActive;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtDescription;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel lblName;
        private Sunny.UI.UILabel lblCategory;
        private Sunny.UI.UILabel lblPrice;
        private Sunny.UI.UILabel lblStock;
        private Sunny.UI.UITextBox txtProductID;
        private Sunny.UI.UITextBox txtNameProduct;
        private Sunny.UI.UITextBox txtPrice;
        private Sunny.UI.UIComboBox cboCategory;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel4;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtSearchh;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIDataGridView dgvProduct;
        private DataGridViewCheckBoxColumn cChose;
        private DataGridViewTextBoxColumn cSTT;
        private DataGridViewTextBoxColumn cProductID;
        private DataGridViewTextBoxColumn cName;
        private DataGridViewTextBoxColumn cPrice;
        private DataGridViewTextBoxColumn cCategory;
        private DataGridViewTextBoxColumn cDSC;
        private DataGridViewTextBoxColumn cStock;
        private DataGridViewCheckBoxColumn cIsActive;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UIButton btnCancel;
        private Sunny.UI.UIButton btnDelete;
        private Sunny.UI.UIButton btnEdit;
        private Sunny.UI.UIButton btnAdd;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UIButton btnImportCsv;
    }
}