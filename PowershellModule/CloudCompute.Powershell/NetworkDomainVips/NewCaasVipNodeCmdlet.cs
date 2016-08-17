using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The new VIP Node CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVipNode")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasVipNodeCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the VIP Node name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Node name")]
        public string NodeName { get; set; }

        /// <summary>
		///     Gets or sets the Node description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The Node description")]
        public string Description { get; set; }

        /// <summary>
		///     Gets or sets the IP Type.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Node IP Type")]
        public IpItemChoiceType IPType { get; set; }

        /// <summary>
		///     Gets or sets the IP Address.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Node IP Address")]
        public string IPAddress { get; set; }

        /// <summary>
		///     Gets or sets the status.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Node Status")]
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the health monitor id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP Node Health Monitor Id")]
        public string HealthMonitorId { get; set; }

        /// <summary>
        ///     Gets or sets the connection limit.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP Node Connection Limit")]
        public int ConnectionLimit { get; set; }


        /// <summary>
        ///     Gets or sets the connection rate limit.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP Node Connection Rate Limit")]
        public int ConnectionRateLimit { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var vipNode = new CreateNodeType
                {
                    networkDomainId = NetworkDomain.id,
                    name = NodeName,
                    description = Description,
                    ItemElementName = IPType,
                    Item = IPAddress,
                    status = Enabled ? "ENABLED" : "DISABLED",
                    healthMonitorId = HealthMonitorId,
                    connectionLimit = ConnectionLimit,
                    connectionRateLimit = ConnectionRateLimit
                };

                response = Connection.ApiClient.Networking.VipNode.CreateNode(vipNode).Result;
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