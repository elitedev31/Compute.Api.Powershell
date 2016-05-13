using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Powershell.Mcp20.Model;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The new Firewall Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasFirewallRule")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasFirewallRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the Firewall rule name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Firewall rule name")]
        public string FirewallRuleName { get; set; }

        /// <summary>
		///     Gets or sets the action.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Firewall action (Drop / Accept Decisively)")]
        public string FirewallAction { get; set; }

        /// <summary>
        ///     Gets or sets the IP Version.
        /// </summary>        
        [Parameter(Mandatory = true, HelpMessage = "The IP version (IPv4 / IPv6)")]
        public IpVersion IpVersion { get; set; }

        /// <summary>
        ///     Gets or sets the IP Version.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The protocol type")]
        public AclProtocolType Protocol { get; set; }

        /// <summary>
        /// Gets or sets Source IP and Port
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The source IP and Port , use New-CaasIpAndPortType")]
        public IpAndPortType Source { get; set; }

        /// <summary>
        /// Gets or sets Destination IP and Port
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The destination IP and Port , use New-CaasIpAndPortType")]
        public IpAndPortType Destination { get; set; }

        /// <summary>
        /// Gets or sets Firewall rule position type
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Rule position")]
        public RulePositionType Position { get; set; }

        /// <summary>
        ///  Gets or Sets Firewall rule relative position
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rule relative position")]
        public FirewallRuleType RelativeToRule { get; set; }

        /// <summary>
        /// Gets or sets enabled for firewall rule
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Is Firewall enabled?")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Constructor initialize enabled to true by default
        /// </summary>
        public NewCaasFirewallRuleCmdlet()
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
                RulePlacementType rulePlacement = new RulePlacementType
                {
                    position = Position
                };

                if (Position == RulePositionType.AFTER || Position == RulePositionType.BEFORE)
                {
                    if (RelativeToRule == null)
                    {
                        ThrowTerminatingError(
                            new ErrorRecord(
                                new ArgumentException("For relative rule placement, please provide the RelativeRule"), "-3", ErrorCategory.InvalidArgument, Connection));
                        return;
                    }

                    rulePlacement.relativeToRule = RelativeToRule.name;
                }               

                var firewall = new CreateFirewallRuleType
                {
                    networkDomainId = NetworkDomain.id,
                    name = FirewallRuleName,
                    ipVersion = IpVersion.ToString(),
                    protocol = Protocol.ToString(),
                    action = FirewallAction,                    
                    source = Source,
                    destination = Destination,
                    placement = rulePlacement,
                    enabled = Enabled
                };

                response = Connection.ApiClient.Networking.FirewallRule.CreateFirewallRule(firewall).Result;
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