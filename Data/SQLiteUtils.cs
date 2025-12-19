using Newtonsoft.Json.Linq;
using Quanlibanhang.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.Data
{
    internal class SQLiteUtils
    {
        private static readonly object LockDb = new object();
        private static readonly string DataFolder = Application.StartupPath;
        private string dbconnectionString;
        private SQLiteConnection connection;

        public SQLiteUtils()
        {
            string defaultDbPath = $"{DataFolder}\\DB\\QLBH.db";
            string jsonFilePath = $"{DataFolder}\\DB\\QLBH.json";

            try
            {
                // Đọc chuỗi kết nối từ file json hoặc sử dụng đường dẫn mặc định
                if (File.Exists(jsonFilePath))
                {
                    var json = File.ReadAllText(jsonFilePath);
                    var jObject = JObject.Parse(json);
                    dbconnectionString = jObject["type"]?.ToString() == "1" && !string.IsNullOrEmpty(jObject["path"]?.ToString()) ?
                        $"Data Source={jObject["path"]}" : $"Data Source={defaultDbPath}";
                }
                else
                {
                    dbconnectionString = $"Data Source={defaultDbPath}";
                }

                // Khởi tạo kết nối SQLite
                connection = new SQLiteConnection(dbconnectionString);
            }
            catch (Exception ex)
            {
                Utils.LogDB("SQLiteUtils Constructor", ex, "", "Không thể khởi tạo SQLiteUtils");
            }
        }
        public void BackupDataDaily()
        {
            try
            {
                // Lấy đường dẫn DB nguồn từ connection string (an toàn)
                var csb = new SQLiteConnectionStringBuilder(dbconnectionString);
                var sourceDbPath = csb.DataSource;

                if (string.IsNullOrWhiteSpace(sourceDbPath) || !File.Exists(sourceDbPath))
                    return; // Chưa có DB thì bỏ qua

                // Thư mục backup: ...\DB\Data\
                var backupFolder = Path.Combine(DataFolder, "DB", "Data");
                Directory.CreateDirectory(backupFolder);

                // Tên file backup theo ngày: DataYYYYMMDD.db
                var todayName = $"Data{DateTime.Now:yyyyMMdd}.db";
                var todayBackupPath = Path.Combine(backupFolder, todayName);

                // Nếu hôm nay đã có backup thì thôi (mỗi ngày 1 file)
                if (!File.Exists(todayBackupPath))
                {
                    lock (LockDb)
                    {
                        try
                        {
                            var srcBuilder = new SQLiteConnectionStringBuilder
                            {
                                DataSource = sourceDbPath,
                                ReadOnly = true
                            };
                            var dstBuilder = new SQLiteConnectionStringBuilder
                            {
                                DataSource = todayBackupPath
                            };

                            using (var src = new SQLiteConnection(srcBuilder.ToString()))
                            using (var dst = new SQLiteConnection(dstBuilder.ToString()))
                            {
                                src.Open();
                                dst.Open();
                                // copy toàn bộ "main" sang file đích
                                src.BackupDatabase(dst, "main", "main", -1, null, 0);
                            }
                        }
                        catch
                        {
                            // Fallback: nếu BackupDatabase không khả dụng, copy file thẳng
                            File.Copy(sourceDbPath, todayBackupPath, overwrite: true);
                        }
                    }
                }

                // === Chính sách giữ lại: tối đa 30 file mới nhất ===
                // Parse ngày trong tên "DataYYYYMMDD.db"; nếu không parse được thì dùng LastWriteTime làm khóa sắp xếp.
                DateTime? TryParseFromName(string filePath)
                {
                    var name = Path.GetFileNameWithoutExtension(filePath); // ví dụ: Data20250912
                    if (name?.StartsWith("Data") == true && name.Length == "DataYYYYMMDD".Length)
                    {
                        var datePart = name.Substring(4);
                        if (DateTime.TryParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None, out var d))
                            return d;
                    }
                    return null;
                }

                var backups = Directory.EnumerateFiles(backupFolder, "Data*.db")
                    .Select(p => new
                    {
                        Path = p,
                        SortKey = TryParseFromName(p) ?? File.GetLastWriteTime(p)
                    })
                    .OrderByDescending(x => x.SortKey)
                    .ToList();

                // Nếu nhiều hơn 30 file, xóa từ file thứ 31 trở đi
                if (backups.Count > 30)
                {
                    foreach (var old in backups.Skip(30))
                    {
                        try { File.Delete(old.Path); } catch { /* bỏ qua file đang bị lock */ }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("BackupDataDaily", ex, "", "Không thể backup DB theo ngày (giữ tối đa 30 bản).");
            }
        }


        /// <summary>
        /// Hàm khôi phục tài khoản đã xóa (active = 0) về trạng thái ban đầu (active = 1)
        /// </summary>
        /// <param name="lstId"></param>
        /// <returns></returns>
        public bool RevertAccount(List<string> lstId)
        {
            try
            {
                // 1) Khởi tạo và mở kết nối
                var sqlUtil = new SQLiteUtils();
                sqlUtil.OpenConnection();
                // 2) Bắt transaction duy nhất
                var conn = sqlUtil.GetConnection();
                using (var tran = conn.BeginTransaction())
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = tran;
                    cmd.CommandText = $"UPDATE accounts SET active = 1 WHERE id IN ({string.Join(',', lstId)})";
                    // 3) Thực thi
                    int affected = cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                // 4) Đóng kết nối
                sqlUtil.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Utils.Log("RevertAccount", ex);
                return false;
            }
        }

        // ======================= Thư viện SQLiteUtils =======================
        // ======================= SQLiteUtils.DeleteAccount =======================
        public bool DeleteAccount(List<string> lstId, bool isReallyDelete = false)
        {
            try
            {
                // 1) Khởi tạo và mở kết nối
                var sqlUtil = new SQLiteUtils();
                sqlUtil.OpenConnection();

                // 2) Bắt transaction duy nhất
                var conn = sqlUtil.GetConnection();
                using (var tran = conn.BeginTransaction())
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = tran;

                    if (isReallyDelete)
                    {
                        cmd.CommandText = $"DELETE FROM accounts WHERE id IN ({string.Join(',', lstId)})";
                    }
                    else
                    {
                        cmd.CommandText = $"UPDATE accounts SET active = 0 WHERE id IN ({string.Join(',', lstId)})";
                    }

                    // 3) Thực thi
                    int affected = cmd.ExecuteNonQuery();
                    tran.Commit();
                }

                // 4) Đóng kết nối
                sqlUtil.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Utils.Log("DeleteAccount", ex);
                return false;
            }
        }

        //======Xóa tài khoản khi chọn 500 acc=====
        public bool DeleteAccountv2(List<string> lstId, bool isReallyDelete)
        {
            try
            {
                // 1) Khởi tạo và mở kết nối
                var sqlUtil = new SQLiteUtils();
                sqlUtil.OpenConnection();

                // 2) Bắt transaction duy nhất
                var conn = sqlUtil.GetConnection();
                using (var tran = conn.BeginTransaction())
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = tran;

                    if (isReallyDelete)
                    {
                        // Chunk danh sách ID nếu quá dài
                        const int chunkSize = 500; // SQLite có giới hạn số lượng tham số
                        foreach (var chunk in lstId.Chunk(chunkSize))
                        {
                            string placeholders = string.Join(", ", chunk.Select((_, i) => $"@uid{i}"));
                            string deleteQuery = $"DELETE FROM accounts WHERE id IN ({placeholders})";

                            cmd = new SQLiteCommand(deleteQuery, conn, tran);
                            for (int i = 0; i < chunk.Count(); i++)
                            {
                                cmd.Parameters.AddWithValue($"@uid{i}", chunk.ElementAt(i));
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        cmd.CommandText = $"UPDATE accounts SET active = 0 WHERE id IN ({string.Join(',', lstId)})";
                    }

                    // 3) Thực thi
                    int affected = cmd.ExecuteNonQuery();
                    tran.Commit();
                }

                // 4) Đóng kết nối
                sqlUtil.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Utils.Log("DeleteAccount", ex);
                return false;
            }
        }


        public static DataTable GetAllFilesFromDatabase(bool isShowAll = false)
        {
            DataTable result = new DataTable();
            try
            {
                string query = "";
                if (isShowAll)
                {
                    // Xây dựng câu truy vấn khi hiển thị tất cả
                    query = $@"
                        SELECT id_category, name FROM category WHERE active=1
                        UNION SELECT -1 AS id_category, '[Tất cả thư mục]' AS name
                        UNION SELECT 999999 AS id_category, '[Chọn nhiều thư mục]' AS name
                        ORDER BY id_category ASC
                    ";
                }
                //  query = "select id, name from files where active=1 UNION SELECT -1 AS id, '" + "[Tất cả thư mục]" + "' AS name UNION SELECT 999999 AS id, '" + "[Chọn nhiều thư mục]" + "' AS name ORDER BY id ASC";
                else
                {
                    // Câu truy vấn khi không hiển thị tất cả
                    query = "SELECT id_category, name FROM category WHERE active=1";
                }

                // Sử dụng SQLiteUtils để thực thi truy vấn
                SQLiteUtils dbUtils = new SQLiteUtils();

                // Mở kết nối
                dbUtils.OpenConnection();

                // Thực thi truy vấn và lấy kết quả vào DataTable
                result = dbUtils.ExecuteQuery(query);

                // Đóng kết nối
                dbUtils.CloseConnection();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có ngoại lệ
                Utils.LogDB("GetAllFilesFromDatabase", ex, "", "Không thể lấy dữ liệu từ bảng files.");
            }
            return result;
        }

        public static DataTable GetAllInfoFromAccount(List<string> lstCategoryId, bool isGetActive = true)
        {
            DataTable result = new DataTable();
            try
            {
                // Kiểm tra điều kiện để tạo câu truy vấn SQL
                string whereClause = "";
                if (lstCategoryId != null && lstCategoryId.Count > 0)
                {
                    // Tạo điều kiện lọc theo danh sách id_category và trạng thái active
                    whereClause = "WHERE id_category IN (" + string.Join(",", lstCategoryId) + ") AND active=" + (isGetActive ? 1 : 0);
                }
                else
                {
                    // Điều kiện chỉ lọc theo trạng thái active
                    whereClause = "WHERE active=" + (isGetActive ? 1 : 0);
                }

                // Xây dựng câu truy vấn hoàn chỉnh
                string query = $@"
                    SELECT '-1' AS id, '[Tất cả tình trạng]' AS name
                    UNION
                    SELECT DISTINCT '0' AS id, status FROM accounts {whereClause}
                    ORDER BY id ASC
                ";

                // Sử dụng SQLiteUtils để thực thi truy vấn
                SQLiteUtils dbUtils = new SQLiteUtils();

                // Mở kết nối
                dbUtils.OpenConnection();

                // Thực thi truy vấn và lấy kết quả vào DataTable
                result = dbUtils.ExecuteQuery(query);

                // Đóng kết nối
                dbUtils.CloseConnection();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có ngoại lệ
                Utils.LogDB("GetAllInfoFromAccount", ex, "", "Không thể lấy dữ liệu từ bảng accounts.");
            }

            return result;
        }

    

        // Phương thức mở kết nối
        public void OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("OpenConnection", ex, "", "Không thể mở kết nối SQLite.");
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("CloseConnection", ex, "", "Không thể đóng kết nối SQLite.");
            }
        }

        // Phương thức mở kết nối với database khác
        public void OpenConnectionV2(string path)
        {
            try
            {
                dbconnectionString = $"Data Source={path}";
                // Khởi tạo kết nối SQLite
                connection = new SQLiteConnection(dbconnectionString);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("OpenConnection", ex, "", "Không thể mở kết nối SQLite.");
            }
        }

        // Phương thức đóng kết nối với database khác
        public void CloseConnectionV2(string path)
        {
            try
            {
                dbconnectionString = $"Data Source={path}";
                // Khởi tạo kết nối SQLite
                connection = new SQLiteConnection(dbconnectionString);
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.LogDB("CloseConnection", ex, "", "Không thể đóng kết nối SQLite.");
            }
        }

        // Phương thức thực thi truy vấn và trả về DataTable
        //public DataTable ExecuteQuery(string commandText)
        //{
        //    var resultTable = new DataTable();
        //    lock (LockDb)
        //    {
        //        try
        //        {
        //            // Kiểm tra và mở kết nối nếu cần
        //            if (connection.State != ConnectionState.Open)
        //            {
        //                connection.Open();
        //            }                
        //            // Tạo SQLiteCommand
        //            var command = new SQLiteCommand(commandText, connection);

        //            // Tạo SQLiteDataAdapter để fill dữ liệu vào DataTable
        //            var dataAdapter = new SQLiteDataAdapter(command);
        //            dataAdapter.Fill(resultTable);
        //        }
        //        catch (Exception ex)
        //        {
        //            Utils.LogDB("ExecuteQuery", ex, commandText, "Không thể thực thi truy vấn.");
        //        }
        //        // Không đóng kết nối ở đây để có thể tiếp tục sử dụng cho các lệnh tiếp theo
        //    }
        //    return resultTable;
        //}
        public DataTable ExecuteQuery(string commandText, params SQLiteParameter[] parameters)
        {
            var resultTable = new DataTable();
            // /4/
            lock (LockDb)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    using (var command = new SQLiteCommand(commandText, connection))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (var dataAdapter = new SQLiteDataAdapter(command))
                        {
                            dataAdapter.Fill(resultTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.LogDB("ExecuteQuery", ex, commandText, "Không thể thực thi truy vấn.");
                }
            }

            //1 2/ 3/
            return resultTable;
        }



        // Phương thức thực thi lệnh không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public bool ExecuteNonQuery(string commandText)
        {
            lock (LockDb)
            {
                try
                {
                    // Kiểm tra và mở kết nối nếu cần
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Tạo và thực thi lệnh
                    var command = new SQLiteCommand(commandText, connection);
                    command.ExecuteNonQuery();

                    // Trả về true nếu thành công
                    return true;
                }
                catch (Exception ex)
                {
                    Utils.LogDB("ExecuteNonQuery", ex, commandText, "Không thể thực thi lệnh non-query.");
                    // Trả về false nếu có lỗi
                    return false;
                }
                // Không đóng kết nối ở đây để có thể tiếp tục sử dụng cho các lệnh tiếp theo
            }
        }

        // Phương thức thực thi nhiều lệnh và nhận kết quả cho từng lệnh
        public List<bool> ExecuteMultipleCommands(IEnumerable<string> commandTexts)
        {
            var results = new List<bool>();
            lock (LockDb)
            {
                try
                {
                    // Mở kết nối một lần
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    foreach (var commandText in commandTexts)
                    {
                        try
                        {
                            // Thực thi từng lệnh và thêm kết quả vào danh sách
                            var command = new SQLiteCommand(commandText, connection);
                            command.ExecuteNonQuery();
                            results.Add(true); // Thành công
                        }
                        catch (Exception ex)
                        {
                            Utils.LogDB("ExecuteMultipleCommands", ex, commandText, "Lỗi khi thực thi lệnh.");
                            results.Add(false); // Thất bại
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.LogDB("ExecuteMultipleCommands", ex, "", "Lỗi trong quá trình thực thi nhiều lệnh.");
                }
                finally
                {
                    // Đóng kết nối sau khi hoàn thành
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
            return results;
        }
        public SQLiteConnection GetConnection()
        {
            return connection; // Trả về đối tượng SQLiteConnection đã được khởi tạo
        }



 
    }

}
