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
    /// Remove Caas VIP Virtual Listener CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasVIPVirtualListener")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasVIPVirtualListenerCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets VIP virtual listener.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The VIP virtual listener")]
        public VirtualListenerType VirtualListener { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();

            try
            {
                response = Connection.ApiClient.Networking.VipVirtualListener.DeleteVirtualListener(Guid.Parse(VirtualListener.id)).Result;
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

            WriteObject(response);
        }
    }
}
