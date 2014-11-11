namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The get deployed server/s cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDeployedServer")]
    [OutputType(typeof(ServerWithBackupType[]))]
    public class GetCaasDeployedServerCmdlet : PsCmdletCaasBase
    {

        /// <summary>
        /// Get a CaaS server by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "Name of the server to filter")]
        public string Name { get; set; }

        /// <summary>
        /// Get a CaaS server by ServerId
        /// </summary>
        [Parameter(Mandatory = false,  HelpMessage = "Server id  to filter")]
        public string ServerId { get; set; }

        /// <summary>
        /// Get a CaaS server by network
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The network to show the servers from")]
        public NetworkWithLocationsNetwork Network { get; set; }

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
                var servers = this.GetDeployedServers(ServerId, Name, networkid, Location).Result;
                if (servers!=null)
                {
                    if (servers.Count() == 1)
                        WriteObject(servers.First(), false);
                    else
                        WriteObject(servers, true);

                }
                else
                    WriteDebug("Object(s) not found");
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                        }
                        return true;
                    });
            }
        }

        /// <summary>
        /// Gets the deployed servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(string serverId, string name, string networkId,string location)
        {
            return await CaaS.ApiClient.GetDeployedServers(serverId, name, networkId, location);
        }
    }
}