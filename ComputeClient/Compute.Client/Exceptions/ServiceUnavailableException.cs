namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

    /// <summary>
	/// The bad request exception.
	/// </summary>
	[Serializable]
	public class ServiceUnavailableException : ComputeApiException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>   
        /// <param name="uri">
        /// The uri.
        /// </param>
        public ServiceUnavailableException(Uri uri)
			: base(ComputeApiError.ServiceUnavailable, uri, "Region is under maintenance")
		{
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
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
        }
    }
}
