namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;

    public class EventLogger: Cmdlet
    {
        public void LogRequestHandler(string requestMethod, string requestUri, string responseStatusCode, double timeTaken, string userName, string requestContent, string responseContent)
        {
            WriteVerbose($"HTTP Request Verb: {requestMethod}");
            WriteVerbose($"HTTP Request Uri: {requestUri}");
            WriteVerbose($"HTTP Response Status Code: {responseStatusCode}");
            WriteVerbose($"HTTP Request Time Taken(in ms): {timeTaken}");
            WriteVerbose($"HTTP Requested UserName: {userName}");
            if (!string.IsNullOrWhiteSpace(requestContent))
            {
                WriteVerbose($"HTTP Request Content: {requestContent}");
            }
            if (responseStatusCode != "OK")
            {
                WriteVerbose($"HTTP Response Content: {responseContent}");
            }
            else
            {
                WriteDebug($"HTTP Response Content: {responseContent}");
            }
        } 
    }
}