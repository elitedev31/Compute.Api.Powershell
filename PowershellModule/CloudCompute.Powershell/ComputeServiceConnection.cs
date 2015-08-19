// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeServiceConnection.cs" company="">
//   
// </copyright>
// <summary>
//   Represents a connection to the CaaS API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Net.FtpClient;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     Represents a connection to the CaaS API.
	/// </summary>
	public sealed class ComputeServiceConnection
		: IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ComputeServiceConnection"/> class. 
		/// Initialises a new instance of the <see cref="ComputeServiceConnection"/> class.
		///     Create a new compute service connection.
		/// </summary>
		/// <param name="apiClient">
		/// The CaaS API client represented by the connection.
		/// </param>
		public ComputeServiceConnection(IComputeApiClient apiClient)
		{
			if (apiClient == null)
				throw new ArgumentNullException("apiClient");

			ApiClient = apiClient;
		}

		/// <summary>
		///     The CaaS account targeted by the connection.
		/// </summary>
		public IAccount Account { get; internal set; }

		/// <summary>
		///     The CaaS FTP client.
		/// </summary>
		public FtpClient FtpClient { get; set; }

		/// <summary>
		///     The CaaS API client represented by the connection.
		/// </summary>
		internal IComputeApiClient ApiClient { get; private set; }

		/// <summary>
		///     Dispose of resources being used by the CaaS API connection.
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