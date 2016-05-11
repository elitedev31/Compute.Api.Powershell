using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Api.Contracts.Network;
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    /// Reserve Private IPV4 Address CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CassReservePrivateIpv4Address")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasReservePrivateIpv4AddressCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "With_MCP2_VlanId", ValueFromPipeline = true, HelpMessage = "The unique identifier of MCP 2.0 VLAN")]
        public string VlanId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_MCP1_NetworkId", ValueFromPipeline = true, HelpMessage = "The unique identifier of an MCP 1.0 Cloud Network")]
        public string NetworkId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "With_MCP2_Vlan", HelpMessage = "Identifies VLAN (MCP 2.0)")]
        public VlanType Vlan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "With_MCP1_Network", HelpMessage = "Identifies Cloud Network (MCP 1.0)")]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IPv4 address")]
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
                var item = string.Empty;
                switch (ParameterSetName)
                {
                    case "With_MCP2_VlanId":
                        item = VlanId;
                        break;
                    case "With_MCP2_Vlan":
                        item = Vlan != null ? Vlan.id : string.Empty;
                        break;
                    case "With_MCP1_NetworkId":
                        item = NetworkId;
                        break;
                    case "With_MCP1_Networ":
                        item = Network != null ? Network.id : string.Empty;
                        break;
                }

                response =
                    Connection.ApiClient.Networking.IpAddress.ReservePrivateIpv4Address(
                        new ReservePrivateIpv4AddressType
                        {
                            Item = item,
                            ItemElementName = ParameterSetName.Equals("With_MCP2_VlanId") || ParameterSetName.Equals("With_MCP2_Vlan") ? NetworkIdOrVlanIdChoiceType.vlanId : NetworkIdOrVlanIdChoiceType.networkId,
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