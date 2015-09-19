namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// The caa s organization not set exception.
	/// </summary>	
	public class InvalidCredentialsException : ComputeApiException
	{
		/// <summary>
		/// The error message.
		/// </summary>
		const string ErrorMessage =
			"The supplied login / password is not valid";		

		/// <summary>
		/// Initialises a new instance of the <see cref="InvalidCredentialsException"/> class.
		/// </summary>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public InvalidCredentialsException(Uri uri)
			: base(ComputeApiError.InvalidCredentials, uri, ErrorMessage)
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
		protected InvalidCredentialsException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
