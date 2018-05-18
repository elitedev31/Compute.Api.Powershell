namespace DD.CBU.Compute.Powershell
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    public class HttpTraceLogger
    {
        private readonly Cmdlet _cmdlet;
        private List<HttpTraceMessage> _messages;

        public HttpTraceLogger(Cmdlet cmdlet)
        {
            _cmdlet = cmdlet;
            _messages = new List<HttpTraceMessage>();
        }

        public void LogRequestHandler(string requestMethod, string requestUri, string responseStatusCode, double timeTaken, string userName, string requestContent, string responseContent)
        {
            _messages.Add(new HttpTraceMessage($"HTTP Request Verb: {requestMethod}", HttpTraceMessageType.Verrbose));
            _messages.Add(new HttpTraceMessage($"HTTP Request Uri: {requestUri}", HttpTraceMessageType.Verrbose));
            _messages.Add(new HttpTraceMessage($"HTTP Response Status Code: {responseStatusCode}", HttpTraceMessageType.Verrbose));
            _messages.Add(new HttpTraceMessage($"HTTP Request Time Taken(in ms): {timeTaken}", HttpTraceMessageType.Verrbose));
            _messages.Add(new HttpTraceMessage($"HTTP Requested UserName: {userName}", HttpTraceMessageType.Verrbose));
            if (!string.IsNullOrWhiteSpace(requestContent))
            {
                _messages.Add(new HttpTraceMessage($"HTTP Request Content: {requestContent}", HttpTraceMessageType.Verrbose));
            }
            if (responseStatusCode != "OK")
            {
                _messages.Add(new HttpTraceMessage($"HTTP Response Content: {responseContent}", HttpTraceMessageType.Verrbose));
            }
            else
            {
                _messages.Add(new HttpTraceMessage($"HTTP Response Content: {responseContent}", HttpTraceMessageType.Debug));
            }
        }

        public void LogMessages()
        {
            if (_messages == null || !_messages.Any())
            {
                return;
            }
            foreach (var message in _messages)
            {
                switch (message.MessageType)
                {
                    case HttpTraceMessageType.Debug:
                        _cmdlet.WriteDebug($"{message.Message}");
                        break;
                    case HttpTraceMessageType.Verrbose:
                        _cmdlet.WriteVerbose($"{message.Message}");
                        break;
                    default:
                        _cmdlet.WriteVerbose($"{message.Message}");
                        break;
                }
            }
        }
    }
}