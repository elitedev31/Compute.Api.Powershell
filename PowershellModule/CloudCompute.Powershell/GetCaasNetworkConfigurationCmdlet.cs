using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Get, "CaasNetworkConfiguration")]
    [OutputType(typeof(NetworkConfigurationType[]))]
    public class GetCaasNetworkConfigurationCmdlet:PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Set the server name on CaaS")]
        public NetworkWithLocationsNetwork Network { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
          

                var network = Connection.ApiClient.GetNetworkConfig(Network.id).Result;
                if (network != null)
                        WriteObject(network);     
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
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }
        }

    }
}
