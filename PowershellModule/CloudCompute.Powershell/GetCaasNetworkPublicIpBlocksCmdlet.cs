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
    [Cmdlet(VerbsCommon.Get, "CaasNetworkPublicIpBlock")]
    [OutputType(typeof(IpBlockType[]))]
    public class GetCaasNetworkPublicIpBlocksCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to list the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to release the public ip addresses", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }


        /// <summary>
        /// Filter the list based on the based public Ip block
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Filter the list based on the based public Ip block", ValueFromPipeline = true)]
        public string BaseIp { get; set; }

        protected override void ProcessRecord()
        {

            base.ProcessRecord();
            try
            {

                var resultlist = CaaS.ApiClient.GetNetworkPublicIpAddressBlock(Network.id).Result;
                if (resultlist != null && resultlist.Any())
                {
                    if (!string.IsNullOrEmpty(BaseIp))
                        resultlist = resultlist.Where(ip => ip.baseIp == BaseIp);

                    switch (resultlist.Count())
                    {
                        case 0:
                            WriteError(
                                 new ErrorRecord(
                                     new ItemNotFoundException(
                                         "This command cannot find a matching object with the given parameters."
                                         ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                            break;
                        case 1:
                            WriteObject(resultlist.First());
                            break;
                        default:
                            WriteObject(resultlist, true);
                            break;
                    }


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
