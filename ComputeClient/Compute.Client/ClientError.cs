// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientError.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the reason that a <see cref="ComputeApiClientException" /> was raised.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// Represents the reason that a <see cref="ComputeApiClientException"/> was raised.
	/// </summary>
	public enum ClientError
	{
		/// <summary>
		/// An unknown reason.
		/// </summary>
		/// <remarks>
		/// Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0, 

		/// <summary>
		/// The client has not logged into the CaaS API.
		/// </summary>
		/// <remarks>
		/// Call <see cref="ComputeApiClient.LoginAsync"/> before calling other operations.
		/// </remarks>
		NotLoggedIn = 1, 

		/// <summary>
		/// The client is already logged into the CaaS API.
		/// </summary>
		/// <remarks>
		/// To log in with different credentials than those currently used by the client, first call
		///     <see cref="ComputeApiClient.Logout"/> before calling <see cref="ComputeApiClient.LoginAsync"/>.
		/// </remarks>
		AlreadyLoggedIn = 2
	}
}