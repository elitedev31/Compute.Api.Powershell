namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The Set VIP Node CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasVipNode")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasVipNodeCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the VIP Node.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The VIP Node")]
        public NodeType Node { get; set; }
        
        /// <summary>
		///     Gets or sets the VIP Node Description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The Node description")]
        public string Description { get; set; }

        /// <summary>
		///     Gets or sets the status.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP Node Status")]
        public bool? Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the health monitor id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP Node Health Monitor Id")]
        public string HealthMonitorId { get; set; }

        /// <summary>
        ///     Gets or sets the connection limit.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP Node Connection Limit")]
        public int ConnectionLimit { get; set; }


        /// <summary>
        ///     Gets or sets the connection rate limit.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP Node Connection Rate Limit")]
        public int ConnectionRateLimit { get; set; }

        public SetCaasVipNodeCmdlet()
        {
            Enabled = null;
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
                var vipNode = new EditNodeType
                {
                    id = Node.id,
                    description = !string.IsNullOrWhiteSpace(Description) ? Description : Node.description,
                    status = Enabled.HasValue ? (Enabled.Value ? "ENABLED" : "DISABLED") : Node.status,
                    healthMonitorId = !string.IsNullOrWhiteSpace(HealthMonitorId) ? HealthMonitorId : Node.healthMonitor != null ? Node.healthMonitor.id : null,
                    connectionLimit = ConnectionLimit > 0 ? ConnectionLimit : Node.connectionLimit,
                    connectionRateLimit = ConnectionRateLimit > 0 ? ConnectionRateLimit : Node.connectionRateLimit
                };

                response = Connection.ApiClient.Networking.VipNode.EditNode(vipNode).Result;
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