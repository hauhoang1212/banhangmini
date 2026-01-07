namespace Quanlibanhang.Forms
{
    partial class FormRegister
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
            txtFullName = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            txtPassword = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            txtUsername = new Sunny.UI.UITextBox();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            btnRegister = new Sunny.UI.UIButton();
            btnOpenLogin = new Sunny.UI.UIButton();
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
            uiTableLayoutPanel1.Location = new Point(83, 73);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 178F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            uiTableLayoutPanel1.Size = new Size(644, 328);
            uiTableLayoutPanel1.TabIndex = 1;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.None;
            uiLabel1.Font = new Font("Microsoft YaHei UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(7, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(629, 63);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "ĐĂNG KÍ";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 2;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 432F));
            uiTableLayoutPanel2.Controls.Add(txtFullName, 1, 2);
            uiTableLayoutPanel2.Controls.Add(uiLabel4, 0, 2);
            uiTableLayoutPanel2.Controls.Add(txtPassword, 1, 1);
            uiTableLayoutPanel2.Controls.Add(uiLabel2, 0, 0);
            uiTableLayoutPanel2.Controls.Add(uiLabel3, 0, 1);
            uiTableLayoutPanel2.Controls.Add(txtUsername, 1, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.Location = new Point(1, 64);
            uiTableLayoutPanel2.Margin = new Padding(1);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 3;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayoutPanel2.Size = new Size(642, 176);
            uiTableLayoutPanel2.TabIndex = 1;
            uiTableLayoutPanel2.TagString = null;
            // 
            // txtFullName
            // 
            txtFullName.Dock = DockStyle.Left;
            txtFullName.Font = new Font("Microsoft Sans Serif", 12F);
            txtFullName.Location = new Point(214, 121);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.MinimumSize = new Size(1, 16);
            txtFullName.Name = "txtFullName";
            txtFullName.Padding = new Padding(5);
            txtFullName.ShowText = false;
            txtFullName.Size = new Size(371, 50);
            txtFullName.TabIndex = 4;
            txtFullName.TextAlignment = ContentAlignment.MiddleCenter;
            txtFullName.Watermark = "";
            // 
            // uiLabel4
            // 
            uiLabel4.Dock = DockStyle.Fill;
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(3, 119);
            uiLabel4.Margin = new Padding(3);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(204, 54);
            uiLabel4.TabIndex = 3;
            uiLabel4.Text = "FullName";
            uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Left;
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F);
            txtPassword.Location = new Point(214, 63);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.MinimumSize = new Size(1, 16);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(5);
            txtPassword.ShowText = false;
            txtPassword.Size = new Size(371, 48);
            txtPassword.TabIndex = 2;
            txtPassword.TextAlignment = ContentAlignment.MiddleCenter;
            txtPassword.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Dock = DockStyle.Fill;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(3, 3);
            uiLabel2.Margin = new Padding(3);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(204, 52);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "Username";
            uiLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            uiLabel3.Dock = DockStyle.Fill;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(3, 61);
            uiLabel3.Margin = new Padding(3);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(204, 52);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "Password";
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Left;
            txtUsername.Font = new Font("Microsoft Sans Serif", 12F);
            txtUsername.Location = new Point(214, 5);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.MinimumSize = new Size(1, 16);
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(5);
            txtUsername.ShowText = false;
            txtUsername.Size = new Size(371, 48);
            txtUsername.TabIndex = 1;
            txtUsername.TextAlignment = ContentAlignment.MiddleCenter;
            txtUsername.Watermark = "";
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 2;
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            uiTableLayoutPanel3.Controls.Add(btnRegister, 0, 0);
            uiTableLayoutPanel3.Controls.Add(btnOpenLogin, 1, 0);
            uiTableLayoutPanel3.Dock = DockStyle.Fill;
            uiTableLayoutPanel3.Location = new Point(0, 241);
            uiTableLayoutPanel3.Margin = new Padding(0);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 1;
            uiTableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel3.Size = new Size(644, 87);
            uiTableLayoutPanel3.TabIndex = 2;
            uiTableLayoutPanel3.TagString = null;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.None;
            btnRegister.Font = new Font("Microsoft Sans Serif", 12F);
            btnRegister.Location = new Point(74, 14);
            btnRegister.MinimumSize = new Size(1, 1);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(175, 59);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Đăng kí";
            btnRegister.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnRegister.Click += btnRegister_Click;
            // 
            // btnOpenLogin
            // 
            btnOpenLogin.Anchor = AnchorStyles.None;
            btnOpenLogin.FillColor = Color.Gray;
            btnOpenLogin.Font = new Font("Microsoft Sans Serif", 12F);
            btnOpenLogin.Location = new Point(427, 18);
            btnOpenLogin.MinimumSize = new Size(1, 1);
            btnOpenLogin.Name = "btnOpenLogin";
            btnOpenLogin.RectColor = Color.FromArgb(224, 224, 224);
            btnOpenLogin.RectDisableColor = Color.FromArgb(224, 224, 224);
            btnOpenLogin.Size = new Size(114, 50);
            btnOpenLogin.TabIndex = 0;
            btnOpenLogin.Text = "Đăng nhập";
            btnOpenLogin.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnOpenLogin.Click += btnOpenLogin_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uiTableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegister";
            uiTableLayoutPanel1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtUsername;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UIButton btnRegister;
        private Sunny.UI.UIButton btnOpenLogin;
        private Sunny.UI.UITextBox txtFullName;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
    }
}