using System.Security.Cryptography;
using System.Text;

namespace FileStorageSystem
{
    public class Props
    {
        // Шифрование строки технологией SHA512
        public static string ToSHA512(string TheEncryptionString)
        {
            using var sha512 = SHA512.Create();
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(TheEncryptionString));

            var userPasswordToHash = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                userPasswordToHash.Append(bytes[i].ToString("X2"));
            }

            Logger.LogInfo($"User=---Login_User---",
                           $"Hashing user string {TheEncryptionString}. " +
                           $"id=---ID_User---");

            return userPasswordToHash.ToString();
        }
    }

    // Логирование приложения
    public static class Logger
    {
        private static readonly object _lock = new object();
        private static string _logFilePath = "application_log.txt";

        public static void LogInfo(string user, string action)
            => WriteLog("INFO", user, action, null);
        public static void LogError(string user, string action, Exception ex)
            => WriteLog("ERROR", user, action, ex);

        private static void WriteLog(string level, string user, string action, Exception? ex)
        {
            try
            {
                lock (_lock)
                {
                    using (var writer = new StreamWriter(_logFilePath, true))
                    {
                        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.Write($"{time} [{level}] ");
                        writer.Write($"User: {user}, Action: {action}");
                        if (ex != null)
                        {
                            writer.Write($", Exception: {ex.GetType().Name}, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch { }
        }
    }
}
