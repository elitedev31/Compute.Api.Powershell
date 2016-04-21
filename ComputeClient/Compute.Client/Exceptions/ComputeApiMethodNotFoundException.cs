using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	using DD.CBU.Compute.Api.Contracts.General;

    /// <summary>
	/// The bad request exception.
	/// </summary>
	[Serializable]
	public class ComputeApiMethodNotFoundException : ComputeApiException
    {
        /// <summary>
		/// The error message.
		/// </summary>
		const string ErrorMessage =
            "The Cloud Control Api seems to be down or missing.";

        /// <summary>
        /// Initialises a new instance of the <see cref="ComputeApiMethodNotFoundException"/> class.
        /// </summary>  
        /// <param name="uri">
        /// The uri.
        /// </param>
        public ComputeApiMethodNotFoundException(Uri uri)
			: base(ComputeApiError.ApiMethodNotFoundError, uri, ErrorMessage)
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
        protected ComputeApiMethodNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
        }
    }
}
