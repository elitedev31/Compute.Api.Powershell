using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Interfaces;

    /// <summary>
    /// Extension methods for the Network section of the CaaS API.
    /// </summary>
    public static class ComputeApiClientNetworkExtensions
    {
        /// <summary>
        /// This function deploys a new network domains to Cloud
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="server">
        /// The network Domain.
        /// </param>
        /// <returns>
        /// Response containing status.
        /// </returns>
		public static async Task<ResponseType> DeployServerOnNetworkDomain(this IComputeApiClient client, DeployServerType server)
        {
			var response = await client.WebApi.PostAsync<DeployServerType, ResponseType>(ApiUris.DeployServerOnNetworkDomain(client.WebApi.OrganizationId), server);
            return response;
        }

	    /// <summary>
	    /// 	An IComputeApiClient extension method that adds a NIC to server to 'addNic'.
	    /// </summary>
	    /// <remarks>	Anthony, 4/24/2015. </remarks>
	    /// <param name="client">	The compute client. </param>
	    /// <param name="addNic">	The add NIC. </param>
	    /// <returns>	A standard response. </returns>
	    public static async Task<ResponseType> AddNicToServer(this IComputeApiClient client, AddNicType addNic)
	    {
		    return
				await client.WebApi.PostAsync<AddNicType, ResponseType>(ApiUris.AddNic(client.WebApi.OrganizationId), addNic);
	    }
    }
}
