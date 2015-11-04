using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The new VIP Pool Member CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVipPoolMember")]
    [OutputType(typeof(ResponseType))]
    public class NewVipPoolMemberCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the VIP Pool.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The VIP Pool")]
        public PoolType VipPool { get; set; }

        /// <summary>
		///     Gets or sets the VIP Node.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Node")]
        public NodeType VipNode { get; set; }

        /// <summary>
		///     Gets or sets the port
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP pool member port")]
        public int? Port { get; set; }

        /// <summary>
        ///     Gets or sets Enabled.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Is pool member enabled?")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Constructor initialize enabled to true by default
        /// </summary>
        public NewVipPoolMemberCmdlet()
        {
            Enabled = true;
        }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var poolMember = new addPoolMember
                {
                    poolId = VipPool.id,
                    nodeId = VipNode != null ? VipNode.id : string.Empty,
                    port = Port.GetValueOrDefault(),
                    portSpecified = Port.HasValue,
                    status = Enabled ? "ENABLED" : "DISABLED"
                };

                response = Connection.ApiClient.Networking.VipPool.AddPoolMember(poolMember).Result;
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
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }

            WriteObject(response);
        }
    }
}