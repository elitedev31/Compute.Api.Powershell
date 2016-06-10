using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	using Contracts.General;

    /// <summary>
	/// The bad request exception.
	/// </summary>
	[Serializable]
	public class BadRequestException : ComputeApiWithStatusException
    {				
		/// <summary>
		/// Initialises a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="caasOperationStatus">
		/// The caa operation status.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public BadRequestException(Status caasOperationStatus, Uri uri)
			: base(ComputeApiError.BadRequest, caasOperationStatus, uri)
		{			
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="caasOperationResponse">
		/// The caa operation response.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public BadRequestException(ResponseType caasOperationResponse, Uri uri)
            : base(ComputeApiError.BadRequest, caasOperationResponse, uri)
        {			
		}

        /// <summary>
		/// Initialises a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="rawResponse">
		/// The caas operation raw response.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public BadRequestException(string rawResponse, Uri uri)
            : base(ComputeApiError.BadRequest, rawResponse, uri)
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
        protected BadRequestException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{			
		}				
	}
}
