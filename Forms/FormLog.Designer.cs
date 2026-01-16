namespace Quanlibanhang.Forms
{
    partial class FormLog
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
            uiTextBox1 = new Sunny.UI.UITextBox();
            dgvLogs = new Sunny.UI.UIDataGridView();
            cLogTime = new DataGridViewTextBoxColumn();
            cUserName = new DataGridViewTextBoxColumn();
            cAction = new DataGridViewTextBoxColumn();
            cTargetTable = new DataGridViewTextBoxColumn();
            cDescription = new DataGridViewTextBoxColumn();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            dtpFrom = new Sunny.UI.UIDatePicker();
            dtpTo = new Sunny.UI.UIDatePicker();
            btnSearch = new Sunny.UI.UIButton();
            btnRefresh = new Sunny.UI.UIButton();
            uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            uiTableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(uiTextBox1, 0, 0);
            uiTableLayoutPanel1.Controls.Add(dgvLogs, 0, 2);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel2, 0, 1);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 336F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            uiTableLayoutPanel1.Size = new Size(800, 450);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Dock = DockStyle.Fill;
            uiTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox1.Location = new Point(4, 5);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(792, 35);
            uiTextBox1.TabIndex = 0;
            uiTextBox1.Text = "Lịch sử chỉnh sửa";
            uiTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox1.Watermark = "";
            // 
            // dgvLogs
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogs.BackgroundColor = Color.White;
            dgvLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLogs.ColumnHeadersHeight = 32;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLogs.Columns.AddRange(new DataGridViewColumn[] { cLogTime, cUserName, cAction, cTargetTable, cDescription });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLogs.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.EnableHeadersVisualStyles = false;
            dgvLogs.Font = new Font("Microsoft Sans Serif", 12F);
            dgvLogs.GridColor = Color.FromArgb(80, 160, 255);
            dgvLogs.Location = new Point(3, 88);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLogs.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvLogs.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvLogs.SelectedIndex = -1;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(794, 359);
            dgvLogs.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvLogs.TabIndex = 1;
            dgvLogs.CellContentClick += dgvLogs_CellContentClick;
            // 
            // cLogTime
            // 
            cLogTime.DataPropertyName = "Thời gian";
            cLogTime.HeaderText = "Thời gian";
            cLogTime.MinimumWidth = 6;
            cLogTime.Name = "cLogTime";
            cLogTime.ReadOnly = true;
            // 
            // cUserName
            // 
            cUserName.DataPropertyName = "Người thực hiện";
            cUserName.HeaderText = "Người thực hiện";
            cUserName.MinimumWidth = 6;
            cUserName.Name = "cUserName";
            cUserName.ReadOnly = true;
            // 
            // cAction
            // 
            cAction.DataPropertyName = "Hành động";
            cAction.HeaderText = "Hành động";
            cAction.MinimumWidth = 6;
            cAction.Name = "cAction";
            cAction.ReadOnly = true;
            // 
            // cTargetTable
            // 
            cTargetTable.DataPropertyName = "Bảng tác động";
            cTargetTable.HeaderText = "Bảng tác động";
            cTargetTable.MinimumWidth = 6;
            cTargetTable.Name = "cTargetTable";
            cTargetTable.ReadOnly = true;
            // 
            // cDescription
            // 
            cDescription.DataPropertyName = "Chi tiết";
            cDescription.HeaderText = "Chi tiết";
            cDescription.MinimumWidth = 6;
            cDescription.Name = "cDescription";
            cDescription.ReadOnly = true;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 4;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.625F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.25F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.75F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.375F));
            uiTableLayoutPanel2.Controls.Add(dtpFrom, 0, 0);
            uiTableLayoutPanel2.Controls.Add(dtpTo, 1, 0);
            uiTableLayoutPanel2.Controls.Add(btnSearch, 2, 0);
            uiTableLayoutPanel2.Controls.Add(btnRefresh, 3, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(0, 45);
            uiTableLayoutPanel2.Margin = new Padding(0);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 1;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Size = new Size(800, 40);
            uiTableLayoutPanel2.TabIndex = 2;
            uiTableLayoutPanel2.TagString = null;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.None;
            dtpFrom.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtpFrom.FillColor = Color.White;
            dtpFrom.Font = new Font("Microsoft Sans Serif", 12F);
            dtpFrom.Location = new Point(14, 5);
            dtpFrom.Margin = new Padding(4, 5, 4, 5);
            dtpFrom.MaxLength = 10;
            dtpFrom.MinimumSize = new Size(63, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Padding = new Padding(0, 0, 30, 2);
            dtpFrom.Size = new Size(152, 30);
            dtpFrom.SymbolDropDown = 61555;
            dtpFrom.SymbolNormal = 61555;
            dtpFrom.SymbolSize = 24;
            dtpFrom.TabIndex = 1;
            dtpFrom.Text = "2026-01-16";
            dtpFrom.TextAlignment = ContentAlignment.MiddleLeft;
            dtpFrom.Value = new DateTime(2026, 1, 16, 14, 26, 2, 263);
            dtpFrom.Watermark = "";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.None;
            dtpTo.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtpTo.FillColor = Color.White;
            dtpTo.Font = new Font("Microsoft Sans Serif", 12F);
            dtpTo.Location = new Point(198, 5);
            dtpTo.Margin = new Padding(4, 5, 4, 5);
            dtpTo.MaxLength = 10;
            dtpTo.MinimumSize = new Size(63, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Padding = new Padding(0, 0, 30, 2);
            dtpTo.Size = new Size(152, 30);
            dtpTo.SymbolDropDown = 61555;
            dtpTo.SymbolNormal = 61555;
            dtpTo.SymbolSize = 24;
            dtpTo.TabIndex = 2;
            dtpTo.Text = "2026-01-16";
            dtpTo.TextAlignment = ContentAlignment.MiddleLeft;
            dtpTo.Value = new DateTime(2026, 1, 16, 14, 26, 4, 989);
            dtpTo.Watermark = "";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.None;
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(411, 3);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Font = new Font("Microsoft Sans Serif", 12F);
            btnRefresh.Location = new Point(628, 3);
            btnRefresh.MinimumSize = new Size(1, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(125, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FormLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uiTableLayoutPanel1);
            Name = "FormLog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLog";
            uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            uiTableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIDataGridView dgvLogs;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UIDatePicker dtpFrom;
        private Sunny.UI.UIDatePicker dtpTo;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UIButton btnRefresh;
        private DataGridViewTextBoxColumn cLogTime;
        private DataGridViewTextBoxColumn cUserName;
        private DataGridViewTextBoxColumn cAction;
        private DataGridViewTextBoxColumn cTargetTable;
        private DataGridViewTextBoxColumn cDescription;
    }
}