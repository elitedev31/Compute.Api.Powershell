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
    /// Get Caas VIP Nodes CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVipNodes")]
    [OutputType(typeof(NodeType[]))]
    public class GetCaasVipNodesCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the VIP Node name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP Node name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets VIP Node id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP Node id")]
        public Guid NodeId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<NodeType> vipNodes = new List<NodeType>();
            base.ProcessRecord();

            try
            {
                vipNodes = Connection.ApiClient.Networking.VipNode.GetNodes((ParameterSetName.Equals("Filtered") ? new NodeListOptions 
                                                                                        {
                                                                                            Id = NodeId != Guid.Empty ? NodeId : (Guid?)null,
                                                                                            Name = Name,
                                                                                            NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty
                                                                                        } : null)).Result;
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

            if (vipNodes != null && vipNodes.Count() == 1)
            {
                WriteObject(vipNodes.First());
            }
            else
            {
                WriteObject(vipNodes);
            }
        }
    }
}
