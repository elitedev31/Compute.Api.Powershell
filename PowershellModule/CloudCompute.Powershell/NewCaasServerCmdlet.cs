// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    ///     The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasServer")]
	[OutputType(typeof(Api.Contracts.Network20.ServerType))]
	public class NewCaasServerCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The Server Details that will be used to deploy the VM
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, 
			HelpMessage = "The server details created by New-CaasServerDetails")]
		public CaasServerDetails ServerDetails { get; set; }

		/// <summary>
		///     Switch to return the server object after execution
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Return the Server object after execution")]
		public SwitchParameter PassThru { get; set; }


		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			Api.Contracts.Network20.ServerType server = null;
			base.ProcessRecord();
			try
			{
				server = DeployServerTask();
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

			if (PassThru.IsPresent)
				WriteObject(server);
		}

        /// <summary>
        ///     The deploy server task.
        /// </summary>
        /// <returns>
        ///     The <see cref="ServerType" />.
        /// </returns>
        private Api.Contracts.Network20.ServerType DeployServerTask()
		{
			Api.Contracts.Network20.ServerType deployedServer = null;
		    DeployServerTypeNetwork networkInfo = null;
		    DeployServerTypeNetworkInfo networkDomainInfo = null;

		    if (ServerDetails.NetworkDomain != null)
		    {              
		        networkDomainInfo = new DeployServerTypeNetworkInfo
		        {
		            networkDomainId = ServerDetails.NetworkDomain.id,
		            primaryNic = new VlanIdOrPrivateIpType
                    {
                        vlanId = ServerDetails.PrimaryVlan != null ? ServerDetails.PrimaryVlan.id : null,
                        privateIpv4 = ServerDetails.PrivateIp
                    }
                };
		    }
		    else
		    {
                networkInfo = new DeployServerTypeNetwork
		        {
		            networkId = ServerDetails.Network != null ? ServerDetails.Network.id : null,
		            privateIpv4 = ServerDetails.PrivateIp
		        };
		    }

			// convert CaasServerDiskDetails to Disk[]
			DeployServerTypeDisk[] diskarray = null;
			if (ServerDetails.InternalDiskDetails != null &&
			    ServerDetails.InternalDiskDetails.Count > 0)
			{
				var disks = new List<DeployServerTypeDisk>();
				foreach (CaasServerDiskDetails item in ServerDetails.InternalDiskDetails)
				{
					var disk =
						new DeployServerTypeDisk
                        {
							scsiId = ushort.Parse(item.ScsiId), 
							speed = item.SpeedId
						};
					disks.Add(disk);
				}

				diskarray = disks.ToArray();
			}

            var server = new DeployServerType
            {
                name = ServerDetails.Name,
                description = ServerDetails.Description,
                imageId = ServerDetails.Image.id,
                start = ServerDetails.IsStarted,
                administratorPassword = ServerDetails.AdministratorPassword,
                network = networkInfo,
                networkInfo = networkDomainInfo,
                disk = diskarray
            };

            var response = Connection.ApiClient.ServerManagement.Server.DeployServer(server).Result;

            // get the server id from status message
            var serverInfo = response.info.Single(info => info.name == "serverId");
            if (serverInfo != null)
            {
                deployedServer = Connection.ApiClient.ServerManagement.Server.GetServer(Guid.Parse(serverInfo.value)).Result;
            }

			if (response != null)
				WriteDebug(
					string.Format(
						"{0} resulted in {1} ({2}): requestId: {3}",
                        response.operation,
                        response.responseCode,
                        response.message,
                        response.requestId));
			return deployedServer;
		}
	}
}