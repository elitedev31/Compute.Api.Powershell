using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    /// <summary>
    /// Get Caas VIP Virtual Listener CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVIPVirtualListener")]
    [OutputType(typeof(VirtualListenerType))]
    public class GetCaasVIPVirtualListenerCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets VIP Node id.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The VIP virtual listener Id")]
        public Guid Id { get; set; }

        protected override void ProcessRecord()
        {
            VirtualListenerType vipVirtualListener = null;
            base.ProcessRecord();

            try
            {
                vipVirtualListener = Connection.ApiClient.Networking.VipVirtualListener.GetVirtualListener(Id).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }

            WriteObject(vipVirtualListener);
        }
    }
}
