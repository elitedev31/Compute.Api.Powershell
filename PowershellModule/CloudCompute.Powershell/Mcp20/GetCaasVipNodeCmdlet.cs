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
    /// Get Caas VIP Node CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVipNode")]
    [OutputType(typeof(NodeType))]
    public class GetCaasVipNodeCmdlet : PSCmdletCaasWithConnectionBase
    {     
        /// <summary>
        ///     Gets or sets VIP Node id.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The VIP Node Id")]
        public Guid NodeId { get; set; }

        protected override void ProcessRecord()
        {
            NodeType vipNode = null;
            base.ProcessRecord();

            try
            {
                vipNode = Connection.ApiClient.Networking.VipNode.GetNode(NodeId).Result;
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
     
            WriteObject(vipNode);
        }
    }
}
