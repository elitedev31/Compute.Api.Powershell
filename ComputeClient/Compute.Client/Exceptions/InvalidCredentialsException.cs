namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;

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
	}
}
