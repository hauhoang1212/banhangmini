namespace Quanlibanhang
{
    partial class FormCategory
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
<<<<<<< Updated upstream
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormCategory";
=======
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiPanel1 = new Sunny.UI.UIPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtDescription = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtCategoryId = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            txtCategoryName = new Sunny.UI.UITextBox();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            btnCancel = new Sunny.UI.UIButton();
            btnDelete = new Sunny.UI.UIButton();
            btnEdit = new Sunny.UI.UIButton();
            btnAdd = new Sunny.UI.UIButton();
            btnSave = new Sunny.UI.UIButton();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            btnExportCsv = new Sunny.UI.UIButton();
            uiLabel2 = new Sunny.UI.UILabel();
            txtSearch = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            dgvCategories = new DataGridView();
            cchoose = new DataGridViewCheckBoxColumn();
            sSTT = new DataGridViewTextBoxColumn();
            cCategoryId = new DataGridViewTextBoxColumn();
            cName = new DataGridViewTextBoxColumn();
            cDescription = new DataGridViewTextBoxColumn();
            uiTableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            uiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(uiPanel1, 0, 0);
            uiTableLayoutPanel1.Controls.Add(tableLayoutPanel1, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel2, 0, 2);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel3, 0, 3);
            uiTableLayoutPanel1.Controls.Add(uiLabel4, 0, 4);
            uiTableLayoutPanel1.Controls.Add(dgvCategories, 0, 5);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 7;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            uiTableLayoutPanel1.Size = new Size(1158, 659);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
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
            uiPanel1.Size = new Size(1158, 40);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = "QUÁN LÍ LOẠI SẢN PHẤM";
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.45592F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.54408F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 228F));
            tableLayoutPanel1.Controls.Add(txtDescription, 3, 0);
            tableLayoutPanel1.Controls.Add(uiLabel5, 2, 0);
            tableLayoutPanel1.Controls.Add(txtCategoryId, 1, 1);
            tableLayoutPanel1.Controls.Add(uiLabel3, 0, 1);
            tableLayoutPanel1.Controls.Add(uiLabel1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtCategoryName, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(2, 42);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1154, 76);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Font = new Font("Microsoft Sans Serif", 12F);
            txtDescription.Location = new Point(928, 2);
            txtDescription.Margin = new Padding(2);
            txtDescription.MinimumSize = new Size(1, 16);
            txtDescription.Name = "txtDescription";
            txtDescription.Padding = new Padding(5);
            txtDescription.ShowText = false;
            txtDescription.Size = new Size(224, 34);
            txtDescription.TabIndex = 8;
            txtDescription.TextAlignment = ContentAlignment.MiddleLeft;
            txtDescription.Watermark = "";
            // 
            // uiLabel5
            // 
            uiLabel5.BackColor = Color.Silver;
            uiLabel5.Dock = DockStyle.Fill;
            uiLabel5.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(801, 7);
            uiLabel5.Margin = new Padding(7);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(118, 24);
            uiLabel5.TabIndex = 5;
            uiLabel5.Text = "Mô tả";
            uiLabel5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCategoryId
            // 
            txtCategoryId.Dock = DockStyle.Fill;
            txtCategoryId.Font = new Font("Microsoft Sans Serif", 12F);
            txtCategoryId.Location = new Point(220, 40);
            txtCategoryId.Margin = new Padding(2);
            txtCategoryId.MinimumSize = new Size(1, 16);
            txtCategoryId.Name = "txtCategoryId";
            txtCategoryId.Padding = new Padding(5);
            txtCategoryId.ShowText = false;
            txtCategoryId.Size = new Size(572, 34);
            txtCategoryId.TabIndex = 4;
            txtCategoryId.TextAlignment = ContentAlignment.MiddleLeft;
            txtCategoryId.Watermark = "";
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Silver;
            uiLabel3.Dock = DockStyle.Fill;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(7, 45);
            uiLabel3.Margin = new Padding(7);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(204, 24);
            uiLabel3.TabIndex = 2;
            uiLabel3.Text = "ID loại";
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Silver;
            uiLabel1.Dock = DockStyle.Fill;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(7, 7);
            uiLabel1.Margin = new Padding(7);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(204, 24);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "Tên loại";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Dock = DockStyle.Fill;
            txtCategoryName.Font = new Font("Microsoft Sans Serif", 12F);
            txtCategoryName.Location = new Point(220, 2);
            txtCategoryName.Margin = new Padding(2);
            txtCategoryName.MinimumSize = new Size(1, 16);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Padding = new Padding(5);
            txtCategoryName.ShowText = false;
            txtCategoryName.Size = new Size(572, 34);
            txtCategoryName.TabIndex = 3;
            txtCategoryName.TextAlignment = ContentAlignment.MiddleLeft;
            txtCategoryName.Watermark = "";
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 6;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730547F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.6383762F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6730452F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6694355F));
            uiTableLayoutPanel2.Controls.Add(btnCancel, 4, 0);
            uiTableLayoutPanel2.Controls.Add(btnDelete, 2, 0);
            uiTableLayoutPanel2.Controls.Add(btnEdit, 1, 0);
            uiTableLayoutPanel2.Controls.Add(btnAdd, 0, 0);
            uiTableLayoutPanel2.Controls.Add(btnSave, 5, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(3, 123);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 1;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Size = new Size(1152, 46);
            uiTableLayoutPanel2.TabIndex = 2;
            uiTableLayoutPanel2.TagString = null;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancel.Location = new Point(838, 3);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(151, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Huỷ";
            btnCancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Microsoft Sans Serif", 12F);
            btnDelete.Location = new Point(317, 3);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(151, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xoá";
            btnDelete.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(160, 3);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(151, 40);
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
            btnAdd.Size = new Size(151, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F);
            btnSave.Location = new Point(995, 3);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(154, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSave.Click += btnSave_Click;
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 4;
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.14844F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.53906F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.3125F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            uiTableLayoutPanel3.Controls.Add(btnExportCsv, 3, 0);
            uiTableLayoutPanel3.Controls.Add(uiLabel2, 0, 0);
            uiTableLayoutPanel3.Controls.Add(txtSearch, 1, 0);
            uiTableLayoutPanel3.Dock = DockStyle.Fill;
            uiTableLayoutPanel3.Location = new Point(0, 172);
            uiTableLayoutPanel3.Margin = new Padding(0);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 1;
            uiTableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel3.Size = new Size(1158, 40);
            uiTableLayoutPanel3.TabIndex = 3;
            uiTableLayoutPanel3.TagString = null;
            // 
            // btnExportCsv
            // 
            btnExportCsv.Dock = DockStyle.Fill;
            btnExportCsv.Font = new Font("Microsoft Sans Serif", 12F);
            btnExportCsv.Location = new Point(839, 2);
            btnExportCsv.Margin = new Padding(2);
            btnExportCsv.MinimumSize = new Size(1, 1);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(317, 36);
            btnExportCsv.TabIndex = 4;
            btnExportCsv.Text = "Export CSV";
            btnExportCsv.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Gray;
            uiLabel2.Dock = DockStyle.Fill;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(2, 2);
            uiLabel2.Margin = new Padding(2);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(223, 36);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "Tìm kiếm";
            uiLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F);
            txtSearch.Location = new Point(228, 1);
            txtSearch.Margin = new Padding(1);
            txtSearch.MinimumSize = new Size(1, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(5);
            txtSearch.ShowText = false;
            txtSearch.Size = new Size(438, 38);
            txtSearch.TabIndex = 3;
            txtSearch.TextAlignment = ContentAlignment.MiddleLeft;
            txtSearch.Watermark = "";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = SystemColors.ActiveCaption;
            uiLabel4.Dock = DockStyle.Fill;
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(3, 212);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(1152, 32);
            uiLabel4.TabIndex = 4;
            uiLabel4.Text = "Danh sách các loại sản phẩm";
            uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCategories
            // 
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { cchoose, sSTT, cCategoryId, cName, cDescription });
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(3, 247);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(1152, 389);
            dgvCategories.TabIndex = 5;
            // 
            // cchoose
            // 
            cchoose.HeaderText = "Chọn";
            cchoose.MinimumWidth = 6;
            cchoose.Name = "cchoose";
            cchoose.Resizable = DataGridViewTriState.True;
            cchoose.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // sSTT
            // 
            sSTT.HeaderText = "STT";
            sSTT.MinimumWidth = 6;
            sSTT.Name = "sSTT";
            // 
            // cCategoryId
            // 
            cCategoryId.HeaderText = "ID loại";
            cCategoryId.MinimumWidth = 6;
            cCategoryId.Name = "cCategoryId";
            // 
            // cName
            // 
            cName.HeaderText = "Tên loại";
            cName.MinimumWidth = 6;
            cName.Name = "cName";
            // 
            // cDescription
            // 
            cDescription.HeaderText = "Mô tả";
            cDescription.MinimumWidth = 6;
            cDescription.Name = "cDescription";
            // 
            // FormCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 659);
            Controls.Add(uiTableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCategory";
            uiTableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
>>>>>>> Stashed changes
        }

        #endregion
    }
}