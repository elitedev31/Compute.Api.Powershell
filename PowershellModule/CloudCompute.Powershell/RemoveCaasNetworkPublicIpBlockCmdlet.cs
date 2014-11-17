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
   [Cmdlet(VerbsCommon.Remove, "CaasNetworkPublicIpBlock")]
   public class RemoveCaasNetworkPublicIpBlockCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to release the public ip addresses", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

       /// <summary>
        /// The public ip block to be released
       /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The public ip block to be released")]
        public IpBlockType PublicIpBlock { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {

                var status = CaaS.ApiClient.ReleaseNetworkPublicIpAddressBlock(Network.id,PublicIpBlock.id).Result;
                if (status != null)
                {
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));


                }

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
