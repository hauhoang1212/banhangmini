namespace Quanlibanhang.Forms
{
    partial class FormLogin
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
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            txtPassLogin = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            txtUserLogin = new Sunny.UI.UITextBox();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            uiButton1 = new Sunny.UI.UIButton();
            btnLogin = new Sunny.UI.UIButton();
            uiTableLayoutPanel1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            uiTableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.Anchor = AnchorStyles.None;
            uiTableLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.Controls.Add(uiLabel1, 0, 0);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel2, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiTableLayoutPanel3, 0, 2);
            uiTableLayoutPanel1.Location = new Point(154, 64);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 135F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 91F));
            uiTableLayoutPanel1.Size = new Size(635, 305);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = DockStyle.Fill;
            uiLabel1.Font = new Font("Microsoft YaHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(3, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(629, 79);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "ĐĂNG NHẬP";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 2;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 432F));
            uiTableLayoutPanel2.Controls.Add(txtPassLogin, 1, 1);
            uiTableLayoutPanel2.Controls.Add(uiLabel2, 0, 0);
            uiTableLayoutPanel2.Controls.Add(uiLabel3, 0, 1);
            uiTableLayoutPanel2.Controls.Add(txtUserLogin, 1, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(1, 80);
            uiTableLayoutPanel2.Margin = new Padding(1);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 2;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel2.Size = new Size(633, 133);
            uiTableLayoutPanel2.TabIndex = 1;
            uiTableLayoutPanel2.TagString = null;
            // 
            // txtPassLogin
            // 
            txtPassLogin.Dock = DockStyle.Left;
            txtPassLogin.Font = new Font("Microsoft Sans Serif", 12F);
            txtPassLogin.Location = new Point(205, 71);
            txtPassLogin.Margin = new Padding(4, 5, 4, 5);
            txtPassLogin.MinimumSize = new Size(1, 16);
            txtPassLogin.Name = "txtPassLogin";
            txtPassLogin.Padding = new Padding(5);
            txtPassLogin.ShowText = false;
            txtPassLogin.Size = new Size(371, 57);
            txtPassLogin.TabIndex = 2;
            txtPassLogin.TextAlignment = ContentAlignment.MiddleCenter;
            txtPassLogin.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Dock = DockStyle.Fill;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(3, 3);
            uiLabel2.Margin = new Padding(3);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(195, 60);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "Username";
            uiLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            uiLabel3.Dock = DockStyle.Fill;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(3, 69);
            uiLabel3.Margin = new Padding(3);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(195, 61);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "Password";
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUserLogin
            // 
            txtUserLogin.Dock = DockStyle.Left;
            txtUserLogin.Font = new Font("Microsoft Sans Serif", 12F);
            txtUserLogin.Location = new Point(205, 5);
            txtUserLogin.Margin = new Padding(4, 5, 4, 5);
            txtUserLogin.MinimumSize = new Size(1, 16);
            txtUserLogin.Name = "txtUserLogin";
            txtUserLogin.Padding = new Padding(5);
            txtUserLogin.ShowText = false;
            txtUserLogin.Size = new Size(371, 56);
            txtUserLogin.TabIndex = 1;
            txtUserLogin.TextAlignment = ContentAlignment.MiddleCenter;
            txtUserLogin.Watermark = "";
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 2;
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            uiTableLayoutPanel3.Controls.Add(uiButton1, 0, 0);
            uiTableLayoutPanel3.Controls.Add(btnLogin, 1, 0);
            uiTableLayoutPanel3.Dock = DockStyle.Fill;
            uiTableLayoutPanel3.Location = new Point(0, 214);
            uiTableLayoutPanel3.Margin = new Padding(0);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 1;
            uiTableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel3.Size = new Size(635, 91);
            uiTableLayoutPanel3.TabIndex = 2;
            uiTableLayoutPanel3.TagString = null;
            // 
            // uiButton1
            // 
            uiButton1.Anchor = AnchorStyles.None;
            uiButton1.FillColor = Color.Silver;
            uiButton1.Font = new Font("Microsoft Sans Serif", 12F);
            uiButton1.Location = new Point(95, 23);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(125, 44);
            uiButton1.TabIndex = 0;
            uiButton1.Text = "Đăng kí";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.Font = new Font("Microsoft Sans Serif", 12F);
            btnLogin.Location = new Point(403, 11);
            btnLogin.MinimumSize = new Size(1, 1);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(143, 68);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng nhập";
            btnLogin.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnLogin.Click += btnLogin_Click;
            // 
            // UserSession
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 452);
            Controls.Add(uiTableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UserSession";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserSession";
            uiTableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITextBox txtPassLogin;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtUserLogin;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton btnLogin;
    }
}