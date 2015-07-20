namespace DD.CBU.Compute.Api.Client.Exceptions
{
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
		public InvalidCredentialsException()
			: base(ComputeApiError.InvalidCredentials, ErrorMessage, ErrorMessage)
		{
		}
	}
}
