// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasDeployedServersCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get deployed server/s cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Server20;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;
using ServerType = DD.CBU.Compute.Api.Contracts.Network20.ServerType;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The get deployed server/s cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasServers")]
	[OutputType(typeof(ServerType[]))]
	public class GetCaasServersCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Get a CaaS server by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "Name of the server to filter")]
		public string Name { get; set; }

		/// <summary>
		/// Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Server id  to filter")]
		public string ServerId { get; set; }

		/// <summary>
		/// Get a CaaS server by network
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network to show the servers from")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// Get a CaaS server by network
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network domain to show the servers from")]
		public NetworkDomainType NetworkDomain { get; set; }

		/// <summary>	
		/// 	Gets or sets the identifier of the network domain. 
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network domain to show the servers from")]
		public string NetworkDomainId { get; set; }

		/// <summary>	Gets or sets the vlan. </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VLAN to filter by")]
		public VlanType Vlan { get; set; }

		/// <summary>	Gets or sets the identifier of the vlan. </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VLAN ID to filter by")]
		public string VlanId { get; set; }

		/// <summary>
		/// Get a CaaS server by location
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Location of the server to filter")]
		public string Location { get; set; }


		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				string networkid = Network == null ? null : Network.id;
				string networkDomainId = NetworkDomain == null ? NetworkDomainId : NetworkDomain.id;
				string vlanId = Vlan == null ? VlanId : Vlan.id;

				IEnumerable<ServerType> servers = GetDeployedServers(ServerId, Name, networkid, Location, networkDomainId, vlanId).Result;
				if (servers != null)
				{
					if (servers.Count() == 1)
						WriteObject(servers.First(), false);
					else
						WriteObject(servers, true);
				}
				else
					WriteError(
						new ErrorRecord(
							new ItemNotFoundException(
								"This command cannot find a matching object with the given parameters."
								), "ItemNotFoundException", ErrorCategory.ObjectNotFound, servers));
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						if (e is ComputeApiException)
						{
							WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
						}
						else
						{
							// if (e is HttpRequestException)
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}

		/// <summary>
		/// Gets the deployed servers from the CaaS
		/// </summary>
		/// <param name="serverId">
		/// The server Id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="networkId">
		/// The network Id.
		/// </param>
		/// <param name="location">
		/// The location.
		/// </param>
		/// <returns>
		/// The images
		/// </returns>
		private async Task<IEnumerable<ServerType>> GetDeployedServers(string serverId, string name,
			string networkId, string location, string networkDomainId, string vlanId)
		{
			ServersResponseCollection serverResponse = await Connection.ApiClient.GetMcp2DeployedServers();

			IEnumerable<ServerType> servers = serverResponse.Server;

			// Filter by server id
			if (!String.IsNullOrWhiteSpace(serverId))
			{
				servers = serverResponse.Server.Where(server => server.id == serverId);
			}

			// Filter by name
			if (!String.IsNullOrWhiteSpace(name))
			{
				servers = servers.Where(server => server.name == name);
			}

			// Filter by network ID
			if (!String.IsNullOrWhiteSpace(networkId))
			{
				servers = servers.Where(server => server.nic != null).Where(server => server.nic.First().networkId == networkId);
			}

			// Filter by datacenter ID
			if (!String.IsNullOrWhiteSpace(location))
			{
				servers = servers.Where(server => server.datacenterId == location);
			}

			// Filter by network domain ID
			if (!String.IsNullOrWhiteSpace(networkDomainId))
			{
				servers = servers.Where(server => server.networkInfo != null).Where(server => server.networkInfo.networkDomainId == networkDomainId);
			}

			// Filter by VLAN ID
			if (!String.IsNullOrWhiteSpace(vlanId))
			{
				servers = servers.Where(server => server.networkInfo != null).Where(server =>
					server.networkInfo.primaryNic.vlanId == vlanId
					|| (server.networkInfo.additionalNic != null && server.networkInfo.additionalNic.Any(nic => nic.vlanId == vlanId)));
			}
			return servers;
		}
	}
}