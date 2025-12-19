using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;


namespace Quanlibanhang.Helpers
{
    public class Utils
    {

        public static string ReadTextFile(string file)
        {
            return File.Exists(file) ? File.ReadAllText(file).Trim() : "";
        }
        private static object lockFile = new object();
        private static object lockFileAction = new object();




        public static void Logs(Exception ex, [CallerMemberName] string methodName = "")
        {
            Log(methodName, ex);
        }
        public static void Log(string function, Exception ex, string UID = "", string Note = "")
        {
            lock (lockFile)
            {
                try
                {
                    //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    //string logDirectory = Path.Combine(baseDirectory, "Log");
                    //string logFile = Path.Combine(logDirectory, $"log{DateTime.Now:ddMMyyyy}.txt");
                    //WriteLog(logFile, function, ex, UID, Note);

                    //int retentionDays = 30;
                    //DeleteOldLogFiles(logDirectory, retentionDays);


                    WriteLog(PathLog.ErrorLog, function, ex, UID, Note);
                    DeleteOldLogFiles(Path.GetDirectoryName(PathLog.ErrorLog), 30);
                }
                catch (Exception e)
                {
                    // Có thể thêm ghi log cho exception tại đây nếu cần
                }
            }
        }

        public static void LogDB(string function, Exception ex, string UID = "", string Note = "")
        {
            lock (lockFile)
            {
                try
                {
                    //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    //string logDirectory = Path.Combine(baseDirectory, "Log");
                    //string logFile = Path.Combine(logDirectory, $"logdatabase{DateTime.Now:ddMMyyyy}.txt");
                    //WriteLog(logFile, function, ex, UID, Note);

                    //int retentionDays = 30;
                    //DeleteOldLogFiles(logDirectory, retentionDays);

                    WriteLog(PathLog.DBLog, function, ex, UID, Note);
                    DeleteOldLogFiles(Path.GetDirectoryName(PathLog.DBLog), 30);
                }
                catch (Exception e)
                {
                    // Có thể thêm ghi log cho exception tại đây nếu cần
                }
            }
        }


        private static void WriteLog(string file, string function, Exception ex, string UID, string Note)
        {
            lock (lockFile)
            {
                try
                {
                    //string logDirectory = Path.GetDirectoryName(file);
                    //if (!Directory.Exists(logDirectory))
                    //{
                    //    Directory.CreateDirectory(logDirectory);
                    //}

                    //using (StreamWriter streamWriter = new StreamWriter(file, append: true))
                    //{
                    //    streamWriter.WriteLine("-----------------------------------------------------------------------------");
                    //    streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    //    streamWriter.WriteLine("Function: " + function);
                    //    if (!string.IsNullOrEmpty(UID))
                    //    {
                    //        streamWriter.WriteLine("UID: " + UID);
                    //    }
                    //    if (!string.IsNullOrEmpty(Note))
                    //    {
                    //        streamWriter.WriteLine("Note: " + Note);
                    //    }
                    //    if (ex != null)
                    //    {
                    //        streamWriter.WriteLine("Type: " + ex.GetType().FullName);
                    //        streamWriter.WriteLine("Message: " + ex.Message);
                    //        streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
                    //        while (ex.InnerException != null)
                    //        {
                    //            ex = ex.InnerException;
                    //            streamWriter.WriteLine("InnerException Type: " + ex.GetType().FullName);
                    //            streamWriter.WriteLine("InnerException Message: " + ex.Message);
                    //            streamWriter.WriteLine("InnerException StackTrace: " + ex.StackTrace);
                    //        }
                    //    }
                    //}

                    string logDirectory = Path.GetDirectoryName(file);
                    if (!Directory.Exists(logDirectory))
                        Directory.CreateDirectory(logDirectory);

                    using StreamWriter sw = new(file, append: true);
                    sw.WriteLine("-----------------------------------------------------------------------------");
                    sw.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    sw.WriteLine("Function: " + function);
                    if (!string.IsNullOrEmpty(UID)) sw.WriteLine("UID: " + UID);
                    if (!string.IsNullOrEmpty(Note)) sw.WriteLine("Note: " + Note);
                    if (ex != null)
                    {
                        sw.WriteLine("Type: " + ex.GetType().FullName);
                        sw.WriteLine("Message: " + ex.Message);
                        sw.WriteLine("StackTrace: " + ex.StackTrace);

                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                            sw.WriteLine("InnerException Type: " + ex.GetType().FullName);
                            sw.WriteLine("InnerException Message: " + ex.Message);
                            sw.WriteLine("InnerException StackTrace: " + ex.StackTrace);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Có thể thêm ghi log cho exception tại đây nếu cần
                }
            }
        }

        private static void DeleteOldLogFiles(string directory, int days)
        {
            try
            {
                var dirInfo = new DirectoryInfo(directory);
                foreach (var file in dirInfo.GetFiles("*.txt"))
                {
                    if (file.CreationTime < DateTime.Now.AddDays(-days))
                    {
                        file.Delete();
                    }
                }

            }
            catch (Exception e)
            {
                // Có thể thêm ghi log cho exception tại đây nếu cần
            }
        }




    }

    public class PathLog
    {
        private static readonly string BaseLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        private static readonly string DateSuffix = DateTime.Now.ToString("yyyyMMdd");

        public static string ChromeLog => Path.Combine(BaseLog, "Chrome", $"log{DateSuffix}.txt");
        public static string ChromePageLog => Path.Combine(BaseLog, "Chrome", "LogPage");
        public static string ChromeHTMLLog => Path.Combine(BaseLog, "Chrome", "LogHTML");
        public static string ErrorLog => Path.Combine(BaseLog, "Exception", $"log{DateSuffix}.txt");
        public static string DBLog => Path.Combine(BaseLog, "DB", $"log{DateSuffix}.txt");

        public static string ActionLog => Path.Combine(BaseLog, "Action");
    }
}

