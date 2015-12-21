using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.General;
    using Api.Contracts.Network;
    using Mcp1 = Api.Contracts.Network;
    using Mcp2 = Api.Contracts.Network20;

    /// <summary>
    ///     The Remove NAT Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasNatRule")]
    [OutputType(typeof(ResponseType), ParameterSetName = new[] { "MCP2" })]
    public class RemoveCaasNATRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the NAT Rule.
        /// </summary>        
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The NAT Rule")]
        public PSObject NatRule { get; set; }

        /// <summary>
        ///     Gets or sets the network.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The network that the ACL Rule exists", ValueFromPipelineByPropertyName = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Gets or sets the network.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The network domain that the NAT Rule exists", ValueFromPipelineByPropertyName = true)]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                if (ParameterSetName.Equals("MCP1"))
                {
                    var natRule = NatRule.BaseObject as Mcp1.NatRuleType;
                    if (natRule == null)
                    {
                        ThrowTerminatingError(
                           new ErrorRecord(new ArgumentException("NatRule type cannot be converted to " + typeof(Mcp1.NatRuleType)), "-3",
                               ErrorCategory.InvalidArgument, Connection));
                        return;
                    }

                    if (!ShouldProcess(natRule.name))
                        return;

                    Status status = Connection.ApiClient.NetworkingLegacy.Network.DeleteNatRule(Network.id, natRule.id).Result;

                    if (status != null)
                    {
                        WriteDebug(
                            string.Format(
                                "{0} resulted in {1} ({2}): {3}",
                                status.operation,
                                status.result,
                                status.resultCode,
                                status.resultDetail));
                    }                    
                }
                else if (ParameterSetName.Equals("MCP2"))
                {
                    var natRule = NatRule.BaseObject as Mcp2.NatRuleType;
                    if (natRule == null)
                    {
                        ThrowTerminatingError(
                           new ErrorRecord(new ArgumentException("NatRule type cannot be converted to " + typeof(Mcp2.NatRuleType)), "-3",
                               ErrorCategory.InvalidArgument, Connection));
                        return;
                    }
                    response = Connection.ApiClient.Networking.Nat.DeleteNatRule(Guid.Parse(natRule.id)).Result;
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