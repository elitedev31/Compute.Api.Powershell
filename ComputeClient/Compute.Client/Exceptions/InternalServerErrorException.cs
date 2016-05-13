namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

    /// <summary>
    /// The CaaS Internal Server Error.
    /// </summary>	
    [Serializable]
    public class InternalServerErrorException : ComputeApiException
	{
		/// <summary>
		/// The error message.
		/// </summary>
		const string ErrorMessage =
			"Api Internal Server Error.";

        /// <summary>
        /// Initialises a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <param name="response">Http Response</param>
        public InternalServerErrorException(Uri uri, string response)
			: base(ComputeApiError.InternalServerError, uri, ErrorMessage + response)
		{
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="InvalidCredentialsException"/> class.
		/// </summary>
		/// <param name="info">
		/// The info.
		/// </param>
		/// <param name="context">
		/// The context.
		/// </param>
		protected InternalServerErrorException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
