namespace DD.CBU.Compute.Powershell
{
    public class HttpTraceMessage
    {
        public string Message { get; set; }
        public HttpTraceMessageType MessageType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public HttpTraceMessage(string message, HttpTraceMessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }

    public enum HttpTraceMessageType
    {
        Verrbose,
        Debug
    }
}