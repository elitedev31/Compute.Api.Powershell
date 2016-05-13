namespace DD.CBU.Compute.Api.Client.Exceptions
{
    using System.Net;
    using System.Net.Http;
    using System;
	using System.Runtime.Serialization;

    /// <summary>
    /// The CaaS Internal Server Error.
    /// </summary>	
    [Serializable]
    public class ComputeApiHttpException : ComputeApiException
	{
        /// <summary>
        /// Http Response Code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Http Method
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Http Response
        /// </summary>
        public string Response { get; set; }
       
        /// <summary>
        /// Initialises a new instance of the <see cref="ComputeApiHttpException"/> class.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <param name="httpMethod">Http Method</param>
        /// <param name="httpStatusCode">Http Status Code</param>
        /// <param name="response">Http Response</param>
        public ComputeApiHttpException(Uri uri, HttpMethod httpMethod, HttpStatusCode httpStatusCode, string response)
			: base(ComputeApiError.HttpException, uri, string.Empty)
        {
            HttpStatusCode = httpStatusCode;
            HttpMethod = httpMethod;
            Response = response;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ComputeApiHttpException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected ComputeApiHttpException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
            HttpStatusCode = (HttpStatusCode)info.GetValue("HttpStatusCode", typeof(HttpStatusCode));
            HttpMethod = (HttpMethod)info.GetValue("HttpMethod", typeof(HttpMethod));
            Response = (string)info.GetValue("Response", typeof(string));
        }

        /// <summary>
        /// Get exception data for serialisation.
        /// </summary>
        /// <param name="info">
        /// A <see cref="SerializationInfo"/> serialisation data store that will hold the serialized exception data.
        /// </param>
        /// <param name="context">
        /// A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="SerializationException">
        /// The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
        /// </exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            base.GetObjectData(info, context);
            info.AddValue("HttpStatusCode", HttpStatusCode);
            info.AddValue("HttpMethod", HttpMethod);
            info.AddValue("Response", Response);
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format(
                    "CaaS API returned HTTP status code {0} ({1}) when performing {2} {3} on '{4}', Response: '{5}'.",
                    (int) HttpStatusCode,
                    HttpStatusCode,
                    Uri.Scheme,
                    HttpMethod,
                    Uri,
                    Response);
            }
        }
    }
}
