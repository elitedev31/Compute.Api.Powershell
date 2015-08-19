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
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get deployed server/s cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasDeployedServer")]
	[OutputType(typeof (ServerWithBackupType[]))]
	[Obsolete("This command is obselete, use Get-CaasServers, the response of this command will not be accepted by any other commands.")]
	public class GetCaasDeployedServerCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Get a CaaS server by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "Name of the server to filter")]
		public string Name { get; set; }

		/// <summary>
		///     Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Server id  to filter")]
		public string ServerId { get; set; }

		/// <summary>
		///     Get a CaaS server by network
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network to show the servers from")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Get a CaaS server by location
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Location of the server to filter")]
		public string Location { get; set; }


		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				string networkid = Network == null ? null : Network.id;
				IEnumerable<ServerWithBackupType> servers = GetDeployedServers(ServerId, Name, networkid, Location).Result;
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
		private async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(string serverId, string name, 
			string networkId, string location)
		{
			return await Connection.ApiClient.GetDeployedServers(serverId, name, networkId, location);
		}
	}
}