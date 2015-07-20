namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;

	/// <summary>
	/// The caa s organization not set exception.
	/// </summary>
	public class CaaSOrganizationNotSetException : Exception
	{
		/// <summary>
		/// The error message.
		/// </summary>
		const string ErrorMessage =
			"CaaS organization for this user is not set, please call Login to set the organization details";

		/// <summary>
		/// Initialises a new instance of the <see cref="CaaSOrganizationNotSetException"/> class.
		/// </summary>
		public CaaSOrganizationNotSetException()
			: base(ErrorMessage)
		{
		}
	}
}
