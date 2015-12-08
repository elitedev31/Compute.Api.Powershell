using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The new VIP Virutal Listener CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVIPVirtualListener")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasVIPVirtualListenerCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the VIP virtual listener name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The virtual listener name")]
        public string Name { get; set; }

        /// <summary>
		///     Gets or sets the virtual listener description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The virtual listener description")]
        public string Description { get; set; }

        /// <summary>
		///     Gets or sets the IP Type.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP virtual listener IP Type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the protocol.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP virtual listener Protocol")]
        public string Protocol { get; set; }

        /// <summary>
		///     Gets or sets the IP Address.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener IP Address")]
        public string IPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the Port.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Port")]
        public int? Port { get; set; }
        
        /// <summary>
		///     Gets or sets the status.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Status")]
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the connection limit.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP virtual listener Connection Limit")]
        public int ConnectionLimit { get; set; }

        /// <summary>
        ///     Gets or sets the connection rate limit.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP virtual listener Connection Rate Limit")]
        public int ConnectionRateLimit { get; set; }

        /// <summary>
        ///     Gets or sets the source port preservation.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VIP virtual listener Source Port Preservation")]
        public string SourcePortPreservation { get; set; }
        
        /// <summary>
        ///     Gets or sets the pool id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Pool Id")]
        public string PoolId { get; set; }

        /// <summary>
        ///     Gets or sets the client clone pool id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Client Clone Pool Id")]
        public string ClientClonePoolId { get; set; }

        /// <summary>
        ///     Gets or sets the persistence profile id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Persistence Profile Id")]
        public string PersistenceProfileId { get; set; }

        /// <summary>
        ///     Gets or sets the fallback persistence profile id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Fallback Persistence Profile Id")]
        public string FallbackPersistenceProfileId { get; set; }

        /// <summary>
        ///     Gets or sets the optimization profile id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener Optimization Profile Id")]
        public string OptimizationProfileId { get; set; }

        /// <summary>
        ///     Gets or sets the iRule id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The VIP virtual listener iRule Ids")]
        public string[] iRuleId { get; set; }

        public NewCaasVIPVirtualListenerCmdlet()
        {
            Enabled = true;
            Port = null;
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
                var virtualListener = new createVirtualListener
                    {
                        networkDomainId = NetworkDomain.id,
                        name = Name,
                        description = Description,
                        type = Type,
                        protocol = Protocol,
                        listenerIpAddress = IPAddress,
                        port = Port.GetValueOrDefault(),
                        portSpecified = Port.HasValue,
                        enabled = Enabled,
                        connectionLimit = ConnectionLimit.ToString(),
                        connectionRateLimit = ConnectionRateLimit.ToString(),
                        sourcePortPreservation = SourcePortPreservation,
                        poolId = PoolId,
                        clientClonePoolId = ClientClonePoolId,
                        persistenceProfileId = PersistenceProfileId,
                        fallbackPersistenceProfileId = FallbackPersistenceProfileId,
                        optimizationProfile = OptimizationProfileId,
                        iruleId = iRuleId
                    };

                response = Connection.ApiClient.Networking.VipVirtualListener.CreateVirtualListener(virtualListener).Result;
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