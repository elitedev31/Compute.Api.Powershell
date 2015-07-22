namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces.Network10;
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;
	using DD.CBU.Compute.Api.Contracts.Directory;

	/// <summary>
    /// The interface of the CaaS API Client
    /// </summary>
	public interface IComputeApiClient : IDisposable, IDeprecatedComputeApiClient
    {   
        /// <summary>
        /// The web API that requests directly from the REST API.
        /// </summary>
        IWebApi WebApi { get; }      

	    /// <summary>
	    /// The login async.
	    /// </summary>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<IAccount> Login();

	    /// <summary>	Gets the networking 2.0 methods. </summary>
	    INetworkingAccessor Networking { get; }

		/// <summary>	Gets the networking legacy 1.0 methods </summary>
		INetworkingLegacyAccessor NetworkingLegacy { get; }
    }
}