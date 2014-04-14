namespace DD.CBU.Compute.Powershell
{
    using System;
    
    using Api.Client;
	using Api.Contracts.Directory;

    using DD.CBU.Compute.Api.Client.Interfaces;

    /// <summary>
	///		Represents a connection to the CaaS API.
	/// </summary>
	public sealed class ComputeServiceConnection
		: IDisposable
	{
	    /// <summary>
		///		Create a new compute service connection.
		/// </summary>
		/// <param name="apiClient">
		///		The CaaS API client represented by the connection.
		/// </param>
		public ComputeServiceConnection(IComputeApiClient apiClient)
		{
			if (apiClient == null)
				throw new ArgumentNullException("apiClient");

			ApiClient = apiClient;
		}

		/// <summary>
		///		The CaaS account targeted by the connection.
		/// </summary>
		public IAccount Account
		{
			get
			{
				return ApiClient.Account;
			}
		}

	    /// <summary>
	    ///		The CaaS API client represented by the connection.
	    /// </summary>
	    internal IComputeApiClient ApiClient { get; private set; }

	    /// <summary>
		///		Dispose of resources being used by the CaaS API connection.
		/// </summary>
		public void Dispose()
		{
			if (ApiClient != null)
			{
				ApiClient.Dispose();
				ApiClient = null;
			}
		}
	}
}
