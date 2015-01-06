using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Set, "CaasNetwork")]
    public class SetCaasNetworkCmdlet:PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Set the server name on CaaS")]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "NetworkName", HelpMessage = "Set new name for the network")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "NetworkName", HelpMessage = "Set the new description for the network")]
        public string Description { get; set; }

        [Parameter(Mandatory = false,ParameterSetName = "Multicast", HelpMessage = "Enable/Disable multicast on the network")]
        public bool Multicast { get; set; }

        protected override void ProcessRecord()
            {
                base.ProcessRecord();
                try
                {
                   
                    Status status = null;
                    switch (this.ParameterSetName)
                    {
                        case "Multicast":
                            status = CaaS.ApiClient.SetNetworkMulticast(Network.id, Multicast).Result;
                            break;
                        default:
                            status = CaaS.ApiClient.ModifyNetwork(Network.id, Name, Description).Result;
                            break;
                    }
                    status = CaaS.ApiClient.ModifyNetwork(Network.id, Name, Description).Result;
                    if (status != null)
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
