using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.VIP;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Server;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// The new CaaS VIP Real cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasRealServer")]
    [OutputType(typeof(RealServer))]
    public class NewCaasRealServerCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipelineByPropertyName = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The server to be added as real server
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The server to be added as real server", ValueFromPipeline = true)]
        public ServerWithBackupType Server { get; set; }

        /// <summary>
        /// The name for the real server
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name for the real server")]
        public string Name { get; set; }

        /// <summary>
        /// The real server status
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The real server status")]
        public bool InService { get; set; }


        /// <summary>
        /// The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the RealServer object")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                var status = CaaS.ApiClient.CreateRealServer(Network.id, Name, Server.id, InService).Result;
                if (status != null && PassThru.IsPresent)
                {

                   
                    //Regex to extract the Id from the status result detail: Real-Server (id:b1a3aea6-37) created
                    var regexObj = new Regex(@"\x28id\x3A([-\w]*)\x29");
                    var match = regexObj.Match(status.resultDetail);
                    if (match.Success && match.Groups.Count > 1)
                    {
                        var rserver = new RealServer
                        {
                            id = match.Groups[1].Value,
                            name = Name,
                            inService = InService.ToString().ToLower(),
                            serverName = Server.name,
                            serverId = Server.id,
                            serverIp = Server.privateIp
                        };
                        WriteObject(rserver);
                    }
                    else
                    {
                        WriteError(new ErrorRecord(new CloudComputePsException("object Id not returned from API"), "-1", ErrorCategory.InvalidData, status));
                    }
            
                }
                WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));


                
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
    }
}
