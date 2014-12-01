using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.VIP;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Set, "CaasVip")]
    public class SetCaasVipCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipelineByPropertyName = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The real server to be deleted
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The vip to be deleted", ValueFromPipeline = true)]
        public Vip Vip { get; set; }

        /// <summary>
        /// The Vip status
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Vip status")]
        public bool InService { get; set; }

        /// <summary>
        /// The vip reply to ICMP status
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The vip reply to ICMP status")]
        public bool ReplyToIcmp { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {

                var status = CaaS.ApiClient.ModifyVip(Network.id, Vip.id,ReplyToIcmp,InService).Result;

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
