using Quanlibanhang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlibanhang.Forms
{
    public partial class FormLog : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            // 1. Thiết lập mặc định cho bộ lọc ngày tháng (7 ngày gần nhất)
            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;

            // 2. Cấu hình DataGridView
            dgvLogs.AutoGenerateColumns = false; // Sử dụng cột đã tạo trong Designer
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Dãn đều cột

            // 3. Hiển thị toàn bộ nhật ký lần đầu
            LoadLogs();
        }



        private void LoadLogs()
        {
            try
            {
                string fromDate = dtpFrom.Value.ToString("yyyy-MM-dd 00:00:00");
                string toDate = dtpTo.Value.ToString("yyyy-MM-dd 23:59:59");

                string sql = $@"SELECT LogTime AS 'Thời gian', 
                               UserName AS 'Người thực hiện', 
                               Action AS 'Hành động', 
                               TargetTable AS 'Bảng tác động', 
                               Description AS 'Chi tiết' 
                        FROM ActivityLogs 
                        WHERE LogTime BETWEEN '{fromDate}' AND '{toDate}'
                        ORDER BY LogTime DESC";

                DataTable dt = db.ExecuteQuery(sql);

                dgvLogs.AutoGenerateColumns = false;
                dgvLogs.DataSource = dt;

                if (dgvLogs.Columns.Count > 0)
                {
                    if (dgvLogs.Columns.Contains("cDescription"))
                        dgvLogs.Columns["cDescription"].FillWeight = 250;

               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhật ký: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset lại bộ lọc và tải lại dữ liệu
            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;

            LoadLogs();
        }
       
        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
