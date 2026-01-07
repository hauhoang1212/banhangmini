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

            // ErrorProvider
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.ContainerControl = this;

            // DataGridView: chỉ cho tick checkbox
            dgvCategories.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvCategories.Columns)
            {
                if (col.Name != "cchoose") col.ReadOnly = true;
            }
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;

            // Ban đầu: khóa input (màu xám)
            SetEditingState(false);

            // Load dữ liệu
            LoadCategories();

            // Khi mới vào form: nếu có data thì đổ dòng đầu lên input (nhưng vẫn khóa)
            if (dgvCategories.Rows.Count > 0 && !dgvCategories.Rows[0].IsNewRow)
            {
                dgvCategories.Rows[0].Selected = true;
                FillInputsFromRow(dgvCategories.Rows[0]);
            }

            // (Nếu bạn có nút export CSV trong UI thì hãy gán Click gọi ExportCsv())
            // btnExportCsv.Click += (s, e) => ExportCsv();
        }

        // =========================
        // LOAD
        // =========================
        private void LoadCategories(string keyword = "")
        {
            try
            {
                dgvCategories.Rows.Clear();

                string sql = @"SELECT CategoryId, Name, IFNULL(Description,'') AS Description
                               FROM Categories
                               WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim().Replace("'", "''");
                    sql += $" AND (Name LIKE '%{keyword}%' OR Description LIKE '%{keyword}%')";
                }

                sql += " ORDER BY CategoryId";

                DataTable dt = db.ExecuteQuery(sql);

                int stt = 1;
                foreach (DataRow r in dt.Rows)
                {
                    dgvCategories.Rows.Add(
                        false,                 // cchoose
                        stt++,                 // sSTT
                        r["CategoryId"],       // cCategoryId
                        r["Name"],             // cName
                        r["Description"]       // cDescription
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadCategories: " + ex.Message);
                Utils.LogDB("LoadCategories", ex);
            }
        }

        // =========================
        // UI STATE (khóa/mở + màu xám)
        // =========================
        private void SetEditingState(bool editing)
        {
            // Input
            txtCategoryId.Enabled = editing;
            txtCategoryName.Enabled = editing;
            txtDescription.Enabled = editing;

            // Màu xám khi disabled (Sunny.UI vẫn nhìn rõ)
            ApplyTextBoxStyle(txtCategoryId, editing);
            ApplyTextBoxStyle(txtCategoryName, editing);
            ApplyTextBoxStyle(txtDescription, editing);

            // Buttons
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing;
            btnDelete.Enabled = !editing;

            // Search vẫn dùng được
            txtSearch.Enabled = !editing;
            btnFilter.Enabled = !editing;
        }

        private void ApplyTextBoxStyle(dynamic tb, bool enabled)
        {
            try
            {
                // Sunny.UI UITextBox có FillColor
                tb.FillColor = enabled ? Color.White : Color.Gainsboro;
            }
            catch
            {
                // fallback nếu control khác
                try { tb.BackColor = enabled ? Color.White : SystemColors.Control; } catch { }
            }
        }

        private void ClearInput()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
            ep.SetError(txtCategoryId, "");
            ep.SetError(txtCategoryName, "");
        }

        private void FillInputsFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            txtCategoryId.Text = row.Cells["cCategoryId"].Value?.ToString() ?? "";
            txtCategoryName.Text = row.Cells["cName"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["cDescription"].Value?.ToString() ?? "";
        }

        // =========================
        // VALIDATE (ErrorProvider)
        // =========================
        private bool ValidateInput()
        {
            bool ok = true;
            ep.SetError(txtCategoryId, "");
            ep.SetError(txtCategoryName, "");

            string id = txtCategoryId.Text.Trim();
            string name = txtCategoryName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                ep.SetError(txtCategoryId, "Vui lòng nhập ID loại (vd: D01)");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                ep.SetError(txtCategoryName, "Vui lòng nhập Tên loại");
                ok = false;
            }

            if (!ok) MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
            return ok;
        }

        // =========================
        // EVENTS
        // =========================
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // không cần code, tick checkbox để chọn dòng
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvCategories.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            FillInputsFromRow(row);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lọc realtime
            LoadCategories(txtSearch.Text.Trim());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadCategories(txtSearch.Text.Trim());
        }

        // =========================
        // ADD / EDIT / CANCEL
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetEditingState(true);
            txtCategoryId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GetFirstCheckedRow();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng tích chọn (v) 1 dòng để sửa!");
                return;
            }

            FillInputsFromRow(selectedRow);

            isAdding = false;
            SetEditingState(true);

            // Không cho sửa khóa chính khi sửa (đúng chuẩn)
            txtCategoryId.Enabled = false;
            ApplyTextBoxStyle(txtCategoryId, false);

            txtCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearInput();

            // bỏ tick checkbox
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (!row.IsNewRow) row.Cells["cchoose"].Value = false;
            }

            SetEditingState(false);

            // đổ lại dòng đang select (nếu có)
            if (dgvCategories.CurrentRow != null && !dgvCategories.CurrentRow.IsNewRow)
            {
                FillInputsFromRow(dgvCategories.CurrentRow);
            }
        }

        // =========================
        // SAVE (THÊM / SỬA)
        // =========================
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
                    // check trùng ID
                    DataTable dtCheck = db.ExecuteQuery($"SELECT COUNT(*) FROM Categories WHERE CategoryId='{id}'");
                    if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                    {
                        MessageBox.Show("ID loại đã tồn tại!");
                        return;
                    }

                    sql = $@"
                        INSERT INTO Categories(CategoryId, Name, Description)
                        VALUES('{id}', '{name}', '{desc}')
                    ";
                }
                else
                {
                    // Sửa theo ID
                    sql = $@"
                        UPDATE Categories
                        SET Name='{name}', Description='{desc}'
                        WHERE CategoryId='{id}'
                    ";
                }

                if (db.ExecuteNonQuery(sql))
                {
                    MessageBox.Show(isAdding ? "Thêm loại thành công!" : "Cập nhật loại thành công!");

                    LoadCategories(txtSearch.Text.Trim());

                    // reset trạng thái
                    isAdding = false;
                    SetEditingState(false);

                    // bỏ tick
                    foreach (DataGridViewRow row in dgvCategories.Rows)
                    {
                        if (!row.IsNewRow) row.Cells["cchoose"].Value = false;
                    }

                    // chọn lại dòng vừa lưu
                    SelectRowByCategoryId(id);
                }
                else
                {
                    MessageBox.Show("Lưu thất bại! Vui lòng xem log DB.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                Utils.LogDB("Category_Save", ex);
            }
        }

        private void SelectRowByCategoryId(string id)
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;
                if ((row.Cells["cCategoryId"].Value?.ToString() ?? "") == id)
                {
                    row.Selected = true;
                    dgvCategories.CurrentCell = row.Cells["cName"];
                    FillInputsFromRow(row);
                    return;
                }
            }

            // nếu không thấy (ví dụ đang lọc) thì clear input
            FillInputsFromRow(dgvCategories.CurrentRow);
        }

        // =========================
        // DELETE (không xóa nếu còn Product)
        // =========================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> ids = GetCheckedCategoryIds();
            if (ids.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất 1 loại để xóa!");
                return;
            }

            // kiểm tra ràng buộc Product thuộc Category
            foreach (var idRaw in ids)
            {
                string id = idRaw.Replace("'", "''");
                DataTable dt = db.ExecuteQuery($"SELECT COUNT(*) FROM Products WHERE CategoryID='{id}'");
                int cnt = (dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0][0]) : 0;
                if (cnt > 0)
                {
                    MessageBox.Show($"Không thể xóa loại {id} vì đang có {cnt} sản phẩm thuộc loại này!");
                    return;
                }
            }

            string msg = ids.Count == 1
                ? $"Bạn có chắc muốn xóa loại {ids[0]} không?"
                : $"Bạn có chắc muốn xóa {ids.Count} loại đã chọn không?";

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                int success = 0;
                foreach (var idRaw in ids)
                {
                    string id = idRaw.Replace("'", "''");
                    if (db.ExecuteNonQuery($"DELETE FROM Categories WHERE CategoryId='{id}'"))
                        success++;
                }

                MessageBox.Show($"Đã xóa {success} loại!");
                LoadCategories(txtSearch.Text.Trim());
                btnCancel_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
                Utils.LogDB("Category_Delete", ex);
            }
        }

        // =========================
        // EXPORT CSV (Advanced)
        // =========================
        private void ExportCsv()
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.FileName = $"Categories_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();
                    sb.AppendLine("CategoryId,Name,Description");

                    foreach (DataGridViewRow row in dgvCategories.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string id = (row.Cells["cCategoryId"].Value?.ToString() ?? "").Replace("\"", "\"\"");
                        string name = (row.Cells["cName"].Value?.ToString() ?? "").Replace("\"", "\"\"");
                        string desc = (row.Cells["cDescription"].Value?.ToString() ?? "").Replace("\"", "\"\"");

                        sb.AppendLine($"\"{id}\",\"{name}\",\"{desc}\"");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất CSV thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi export CSV: " + ex.Message);
                Utils.LogDB("Category_ExportCSV", ex);
            }
        }

        // =========================
        // HELPERS: checkbox selection
        // =========================
        private DataGridViewRow GetFirstCheckedRow()
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cchoose"].Value != null
                                 && Convert.ToBoolean(row.Cells["cchoose"].Value);

                if (isChecked) return row;
            }
            return null;
        }

        private List<string> GetCheckedCategoryIds()
        {
            var ids = new List<string>();

            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = row.Cells["cchoose"].Value != null
                                 && Convert.ToBoolean(row.Cells["cchoose"].Value);

                if (isChecked)
                {
                    string id = row.Cells["cCategoryId"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(id))
                        ids.Add(id.Trim());
                }
            }
            return ids;
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
    }
}
