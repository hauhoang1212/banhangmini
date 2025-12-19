using System;
using System.Data;
using System.Data.SQLite; // Đảm bảo dùng System.Data.SQLite

namespace Quanlibanhang.Helpers
{
    public class DatabaseHelper
    {
        // Đường dẫn tương đối đến file database trong thư mục dự án
        private string connectionString = @"Data Source=.\DB\QLLSP.db;Version=3;";

        public DataTable ExecuteQuery(string sql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}