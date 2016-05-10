using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    /// Un-Reserve Private IPV4 Address CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasReservePrivateIpv4Address")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasReservePrivateIpv4AddressCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "With_MCP2", ValueFromPipeline = true, HelpMessage = "The unique identifier of MCP 2.0 VLAN")]
        public string VlanId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_MCP1", ValueFromPipeline = true, HelpMessage = "The unique identifier of an MCP 1.0 Cloud Network")]
        public string NetworkId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The IPv4 address")]
        public string IpAddress { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                response =
                    Connection.ApiClient.Networking.IpAddress.UnreservePrivateIpv4Address(
                        new UnreservePrivateIpv4AddressType
                        {
                            Item = ParameterSetName.Equals("With_MCP2") ? VlanId : NetworkId,
                            ItemElementName = ParameterSetName.Equals("With_MCP2") ? NetworkIdOrVlanIdChoiceType.vlanId : NetworkIdOrVlanIdChoiceType.networkId,
                            ipAddress = IpAddress
                        }).Result;
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