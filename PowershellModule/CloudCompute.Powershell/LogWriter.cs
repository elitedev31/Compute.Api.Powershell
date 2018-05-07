namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.IO;

    public class LogWriter
    {
        private string _filePath;

        public LogWriter(string filePath, string connectionName)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentNullException(nameof(connectionName));
            }
            _filePath = Path.Combine(filePath, connectionName + ".log");
        }

        public void WriteLog(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(_filePath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{DateTime.Now.ToLocalTime()}, {logMessage}");
            }
            catch (Exception ex)
            {
            }
        }
    }
}