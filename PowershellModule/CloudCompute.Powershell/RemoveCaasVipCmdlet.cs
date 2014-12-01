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
     [Cmdlet(VerbsCommon.Remove, "CaasVip",SupportsShouldProcess = true)]
    public class RemoveCaasVipCmdlet:PsCmdletCaasBase
    {

        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipelineByPropertyName = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The real server to be deleted
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The vip to be deleted",ValueFromPipeline = true)]
        public Vip Vip { get; set; }


         protected override void ProcessRecord()
         {
             try
             {
                 if (!ShouldProcess(Vip.name)) return;
                 var status = CaaS.ApiClient.RemoveVip(Network.id,Vip.id).Result;

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
