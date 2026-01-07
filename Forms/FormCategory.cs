using Quanlibanhang.Data;
using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class FormCategory : Form
    {
        private readonly SQLiteUtils db = new SQLiteUtils();
        private bool isAdding = false;                 // true = Thêm, false = Sửa
        private readonly ErrorProvider ep = new ErrorProvider();

        public FormCategory()
        {
            InitializeComponent();
            SetupComponents();
            LoadCategories();
        }
        private void SetupComponents()
        {
            // Cấu hình ErrorProvider
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.ContainerControl = this;

            // Cấu hình DataGridView
            dgvCategories.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvCategories.Columns)
            {
                if (col.Name != "cchoose") col.ReadOnly = true;
            }
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;

            // Trạng thái ban đầu
            SetEditingState(false);
        }
        private void LoadCategories(string keyword = "")
        {
            try
            {
                dgvCategories.Rows.Clear();
                string sql = "SELECT CategoryId, Name, IFNULL(Description,'') AS Description FROM Categories WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Chống SQL Injection cơ bản bằng cách replace dấu nháy đơn
                    string safeKeyword = keyword.Replace("'", "''");
                    sql += $" AND (Name LIKE '%{safeKeyword}%' OR CategoryId LIKE '%{safeKeyword}%' OR Description LIKE '%{safeKeyword}%')";
                }

                sql += " ORDER BY CategoryId ASC";
                DataTable dt = db.ExecuteQuery(sql);

                if (dt != null)
                {
                    int stt = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        dgvCategories.Rows.Add(
                            false,
                            stt++,
                            r["CategoryId"],
                            r["Name"],
                            r["Description"]
                        );
                    }
                }

                // Nếu có data, tự động chọn dòng đầu
                if (dgvCategories.Rows.Count > 0)
                {
                    FillInputsFromRow(dgvCategories.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load dữ liệu: " + ex.Message);
                Utils.LogDB("LoadCategories", ex);
            }
        }
        private void SetEditingState(bool editing)
        {
            // Mở/Khóa các ô nhập liệu
            txtCategoryId.Enabled = editing;
            txtCategoryName.Enabled = editing;
            txtDescription.Enabled = editing;

            // Đổi màu nền để người dùng dễ nhận biết (SunnyUI FillColor hoặc BackColor)
            Color bgColor = editing ? Color.White : Color.Gainsboro;
            txtCategoryId.FillColor = bgColor;
            txtCategoryName.FillColor = bgColor;
            txtDescription.FillColor = bgColor;

            // Điều khiển các nút bấm
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing;
            btnDelete.Enabled = !editing;

            // Khóa search khi đang soạn thảo
            txtSearch.Enabled = !editing;
            btnFilter.Enabled = !editing;
        }
        private void FillInputsFromRow(DataGridViewRow row)
        {
            if (row == null || row.IsNewRow) return;
            txtCategoryId.Text = row.Cells["cCategoryId"].Value?.ToString() ?? "";
            txtCategoryName.Text = row.Cells["cName"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["cDescription"].Value?.ToString() ?? "";
        }

        private bool ValidateInput()
        {
            ep.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                ep.SetError(txtCategoryId, "Vui lòng nhập Mã loại!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                ep.SetError(txtCategoryName, "Vui lòng nhập Tên loại!");
                ok = false;
            }

            if (!ok) MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc!");
            return ok;
        }
        // =========================
        // XỬ LÝ SỰ KIỆN NÚT BẤM
        // =========================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
            SetEditingState(true);
            txtCategoryId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lấy dòng đang được tích checkbox
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cchoose"].Value))
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng tích chọn (v) một dòng để sửa!");
                return;
            }

            FillInputsFromRow(selectedRow);
            isAdding = false;
            SetEditingState(true);

            // Không cho sửa Mã (Khóa chính) khi đang Edit
            txtCategoryId.Enabled = false;
            txtCategoryId.FillColor = Color.Gainsboro;
            txtCategoryName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Thu thập các ID đã chọn
            List<string> selectedIds = new List<string>();
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cchoose"].Value))
                {
                    selectedIds.Add(row.Cells["cCategoryId"].Value?.ToString());
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một loại để xoá!");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xoá {selectedIds.Count} dòng đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int count = 0;
                    foreach (string id in selectedIds)
                    {
                        // Kiểm tra ràng buộc (nếu có bảng Sản phẩm tham chiếu tới)
                        DataTable dtCheck = db.ExecuteQuery($"SELECT 1 FROM Products WHERE CategoryId='{id}' LIMIT 1");
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                        {
                            MessageBox.Show($"Không thể xóa mã {id} vì đang có sản phẩm thuộc loại này!");
                            continue;
                        }

                        if (db.ExecuteNonQuery($"DELETE FROM Categories WHERE CategoryId='{id}'")) count++;
                    }

                    if (count > 0) MessageBox.Show($"Đã xoá thành công {count} dòng!");
                    LoadCategories();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xoá: " + ex.Message); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ep.Clear();
            SetEditingState(false);
            if (dgvCategories.CurrentRow != null) FillInputsFromRow(dgvCategories.CurrentRow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string id = txtCategoryId.Text.Trim().Replace("'", "''");
            string name = txtCategoryName.Text.Trim().Replace("'", "''");
            string desc = txtDescription.Text.Trim().Replace("'", "''");

            try
            {
                string sql;
                if (isAdding)
                {
                    // Check trùng ID trước khi thêm
                    DataTable dt = db.ExecuteQuery($"SELECT 1 FROM Categories WHERE CategoryId='{id}'");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã loại này đã tồn tại trong hệ thống!");
                        return;
                    }
                    sql = $"INSERT INTO Categories(CategoryId, Name, Description) VALUES('{id}', '{name}', '{desc}')";
                }
                else
                {
                    sql = $"UPDATE Categories SET Name='{name}', Description='{desc}' WHERE CategoryId='{id}'";
                }

                if (db.ExecuteNonQuery(sql))
                {
                    MessageBox.Show("Lưu thành công!");
                    SetEditingState(false);
                    LoadCategories(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
                Utils.LogDB("Category_Save", ex);
            }
        }
        // =========================
        // SỰ KIỆN DATAGRIDVIEW
        // =========================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCategories(txtSearch.Text.Trim());
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isAdding) // Không đổi input khi đang ở chế độ Thêm mới
            {
                FillInputsFromRow(dgvCategories.Rows[e.RowIndex]);
            }
        }
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadCategories(txtSearch.Text.Trim());
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
        private void ExportCsv()
        {
            try
            {
                using (var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = $"Categories_{DateTime.Now:yyyyMMdd}.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("CategoryId,Name,Description");
                        foreach (DataGridViewRow row in dgvCategories.Rows)
                        {
                            if (row.IsNewRow) continue;
                            sb.AppendLine($"\"{row.Cells["cCategoryId"].Value}\",\"{row.Cells["cName"].Value}\",\"{row.Cells["cDescription"].Value}\"");
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất CSV thành công!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất CSV: " + ex.Message); }
        }
    }
}

