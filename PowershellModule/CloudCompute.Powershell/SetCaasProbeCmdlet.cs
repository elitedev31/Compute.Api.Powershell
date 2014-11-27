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
    [Cmdlet(VerbsCommon.Set, "CaasProbe")]
    public class SetCaasProbeCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The name for the real server
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Probe object",ValueFromPipeline = true)]
        public Probe Probe { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The interval to probe in seconds. valid range 15-65535")]
        [ValidateRange(15, 65535)]
        public int ProbeIntervalSeconds { get; set; }

        /// <remarks/>
        [Parameter(Mandatory = false, HelpMessage = "The number of errors before declaring a server failure. valid range 1-65535")]
        [ValidateRange(1, 65535)]
        public int ErrorCountBeforeServerFail { get; set; }


        /// <remarks/>
        [Parameter(Mandatory = false, HelpMessage = "The number of sucesses before reenable a failed server. valid range 1-65535")]
        [ValidateRange(1, 65535)]
        public int SuccessCountBeforeServerEnable { get; set; }


        /// <remarks/>
        [Parameter(Mandatory = false, HelpMessage = "The number of sucesses before reenable a failed server. valid range 15-65535")]
        [ValidateRange(15, 65535)]
        public int FailedProbeIntervalSeconds { get; set; }


        /// <remarks/>
        [Parameter(Mandatory = false, HelpMessage = "The max number of seconds to wait for a response from a server. valid range 2-65535")]
        [ValidateRange(2, 65535)]
        public int MaxReplyWaitSeconds { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {

                var status = CaaS.ApiClient.ModifyProbe(Network.id, Probe.id,ProbeIntervalSeconds,ErrorCountBeforeServerFail,SuccessCountBeforeServerEnable,FailedProbeIntervalSeconds,MaxReplyWaitSeconds).Result;

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
