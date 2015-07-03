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
	/// The get deployed server/s cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasServer")]
	[OutputType(typeof (ServerWithBackupType))]
	public class GetCaasServerCmdlet : PsCmdletCaasBase
	{
		
		/// <summary>
		/// Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "Server id  to filter")]
		public string ServerId { get; set; }

	
		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                IEnumerable<ServerWithBackupType> servers = GetDeployedServers(ServerId, string.Empty, string.Empty, string.Empty).Result;
				if (servers != null)
				{
	                WriteObject(servers.SingleOrDefault(), false);
	
				}
				else
					WriteError(
						new ErrorRecord(
							new ItemNotFoundException(
								"This command cannot find a matching object with the given parameters."
                                ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, ServerId));
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