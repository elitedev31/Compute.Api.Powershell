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
using DD.CBU.Compute.Api.Contracts.Server;

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
        ///     Use Guest OS Customization
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set to true for Guest OS customization")]
        public bool? GuestOsCustomization;

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
		            primaryNic = new NewNicType
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
                            
							id = item.DiskId, 
							speed = item.SpeedId
						};
					disks.Add(disk);
				}

				diskarray = disks.ToArray();
			}
            ResponseType response = null;

            if (GuestOsCustomization.HasValue && GuestOsCustomization == false)
            {
                var server = new DeployUncustomizedServerType
                {
                    name = ServerDetails.Name,
                    description = ServerDetails.Description,
                    imageId = ServerDetails.ImageId,
                    start = ServerDetails.IsStarted,
                    networkInfo = networkDomainInfo,
                    disk = diskarray,
                    cpu = ServerDetails.CpuDetails,
                    memoryGb = ServerDetails.MemoryGb,
                    memoryGbSpecified = (ServerDetails.MemoryGb > 0),
                    clusterId = ServerDetails.ClusterId
                };

                response = Connection.ApiClient.ServerManagement.Server.DeployUncustomizedServer(server).Result;
            }
            else
            {
                var server = new DeployServerType
                {
                    name = ServerDetails.Name,
                    description = ServerDetails.Description,
                    imageId = ServerDetails.ImageId,
                    start = ServerDetails.IsStarted,
                    administratorPassword = ServerDetails.AdministratorPassword,
                    network = networkInfo,
                    networkInfo = networkDomainInfo,
                    disk = diskarray,
                    cpu = ServerDetails.CpuDetails,
                    primaryDns = ServerDetails.PrimaryDns,
                    secondaryDns = ServerDetails.SecondaryDns,
                    microsoftTimeZone = ServerDetails.MicrosoftTimeZone,
                    memoryGb = ServerDetails.MemoryGb,
                    memoryGbSpecified = (ServerDetails.MemoryGb > 0),
                    clusterId = ServerDetails.ClusterId
                };

                response = Connection.ApiClient.ServerManagement.Server.DeployServer(server).Result;
            }

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