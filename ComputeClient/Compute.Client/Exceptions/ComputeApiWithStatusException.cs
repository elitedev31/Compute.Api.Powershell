using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Api.Client.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    using DD.CBU.Compute.Api.Contracts.General;

    using Newtonsoft.Json;

    /// <summary>
    /// The bad request exception.
    /// </summary>
    [Serializable]
    public class ComputeApiWithStatusException : ComputeApiException
    {
        /// <summary>
        /// Gets or sets the caas operation status. for MCP 1.0 operations
        /// </summary>
        public Status CaaSOperationStatus { get; set; }

        /// <summary>
        /// Gets or sets the caas operation response. for MCP 2.0 operations
        /// </summary>
        public ResponseType CaaSOperationResponse { get; set; }

        /// <summary>
        /// Gets or sets the caas operation response. for other operations
        /// </summary>
        public string CaasRawResponse { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="DD.CBU.Compute.Api.Client.Exceptions.ComputeApiWithStatusException"/> class.
        /// </summary>
        /// <param name="error">Error Type, for older clients</param>
        /// <param name="caasRawResponse">
        /// The caa operation status.
        /// </param>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public ComputeApiWithStatusException(ComputeApiError error, string caasRawResponse, Uri uri)
            : base(error, uri, String.Empty)
        {
            CaasRawResponse = caasRawResponse;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DD.CBU.Compute.Api.Client.Exceptions.ComputeApiWithStatusException"/> class.
        /// </summary>
        /// <param name="error">Error Type, for older clients</param>
        /// <param name="caasOperationStatus">
        /// The caa operation status.
        /// </param>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public ComputeApiWithStatusException(ComputeApiError error, Status caasOperationStatus, Uri uri)
            : base(error, uri, String.Empty)
        {
            CaaSOperationStatus = caasOperationStatus;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DD.CBU.Compute.Api.Client.Exceptions.BadRequestException"/> class.
        /// </summary>
        /// <param name="error">Error Type</param>
        /// <param name="caasOperationResponse">
        /// The caa operation response.
        /// </param>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public ComputeApiWithStatusException(ComputeApiError error, ResponseType caasOperationResponse, Uri uri)
            : base(error, uri, String.Empty)
        {
            CaaSOperationResponse = caasOperationResponse;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ComputeApiException"/> class. 
        /// Deserialisation constructor for <see cref="ComputeApiException"/>.
        /// </summary>
        /// <param name="info">
        /// A <see cref="SerializationInfo"/> serialisation data store that holds the serialized exception data.
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
        protected ComputeApiWithStatusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            CaaSOperationStatus = (Status)info.GetValue("CaaSOperationStatus", typeof(Status));
            CaaSOperationResponse = (ResponseType)info.GetValue("CaaSOperationResponse", typeof(ResponseType));
            CaasRawResponse = (string)info.GetValue("CaasRawResponse", typeof(string));
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
            info.AddValue("CaaSOperationStatus", CaaSOperationStatus);
            info.AddValue("CaaSOperationResponse", CaaSOperationResponse);
            info.AddValue("CaasRawResponse", CaasRawResponse);
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder(base.Message);

                if (CaaSOperationStatus != null)
                {
                    sb.AppendFormat("CaaSOperationStatus: {0}", JsonConvert.SerializeObject(CaaSOperationStatus));
                }
                if (CaaSOperationResponse != null)
                {
                    sb.AppendFormat("CaaSOperationResponse: {0}", JsonConvert.SerializeObject(CaaSOperationResponse));
                }
                if (!string.IsNullOrWhiteSpace(CaasRawResponse))
                {
                    sb.AppendFormat("CaasRawResponse: {0}", CaasRawResponse);
                }
                return sb.ToString();
            }
        }
    }
}
