namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

    /// <summary>
    /// The CaaS organization not set exception.
    /// </summary>	
    [Serializable]
    public class PermissionDeniedException : ComputeApiException
	{
		/// <summary>
		/// The error message.
		/// </summary>
		const string ErrorMessage =
            "Invalid role or org-id invalid (does not match credentials).";

        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionDeniedException"/> class.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public PermissionDeniedException(Uri uri)
			: base(ComputeApiError.PermissionDenied, uri, ErrorMessage)
		{
		}

        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionDeniedException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected PermissionDeniedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{            
		}
	}
}
