using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Net;
    using Api.Contracts.Network;

    /// <summary>
    ///     The new NAT Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasNatRule")]
    [OutputType(typeof(ResponseType), ParameterSetName = new []{ "MCP2" })]
    [OutputType(typeof(NatRuleType), ParameterSetName = new[] { "MCP1" })]
    public class NewCaasNatRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the Internal IP Address.
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The NAT rule Internal IP")]
        public string InternalIP { get; set; }

        /// <summary>
        ///     Gets or sets the External IP Address.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The NAT rule External IP")]
        public string ExternalIP { get; set; }

        /// <summary>
        ///     Gets or sets the network.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The target network to add the NAT rule into.", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Gets or sets the nat rule name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The NAT Rule name")]
        public string NatRuleName { get; set; }

        /// <summary>
        ///     Gets or sets the source ip address.
        /// </summary>
        [Parameter(ParameterSetName = "MCP1", HelpMessage = "The source IP Address.")]
        public IPAddress SourceIpAddress { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            object response = null;
            base.ProcessRecord();
            try
            {
                if (ParameterSetName.Equals("MCP2"))
                {
                    var natrule = new createNatRule
                    {
                        Item = NetworkDomain.id,
                        internalIp = InternalIP,
                        externalIp = ExternalIP
                    };

                    response = Connection.ApiClient.Networking.Nat.CreateNatRule(natrule)
                                         .Result;
                }
                else if (ParameterSetName.Equals("MCP1"))
                {
                    response = Connection.ApiClient.NetworkingLegacy.Network.CreateNatRule(Network.id, NatRuleName, SourceIpAddress).Result;
                }
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