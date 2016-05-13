using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Api.Contracts.Network;
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    /// Un-Reserve Private IPV4 Address CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasReservePrivateIpv4Address")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasReservePrivateIpv4AddressCmdlet : PSCmdletCaasWithConnectionBase
    {        
        [Parameter(Mandatory = true, ParameterSetName = "With_VlanId",  HelpMessage = "The unique identifier of MCP 2.0 VLAN")]
        public Guid? VlanId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_NetworkId", HelpMessage = "The unique identifier of an MCP 1.0 Cloud Network")]
        public Guid? NetworkId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_Vlan", HelpMessage = "Identifies VLAN (MCP 2.0)")]
        public VlanType Vlan { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_Network", HelpMessage = "Identifies Cloud Network (MCP 1.0)")]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IPv4 address")]
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
                if (Vlan != null)
                {
                    VlanId = Guid.Parse(Vlan.id);
                }
                else if (Network != null)
                {
                    NetworkId = Guid.Parse(Network.id);
                }

                response =
                    Connection.ApiClient.Networking.IpAddress.UnreservePrivateIpv4Address(
                        new UnreservePrivateIpv4AddressType
                        {
                            Item = VlanId.HasValue ? VlanId.ToString() : NetworkId.HasValue ? NetworkId.ToString() : null,
                            ItemElementName = VlanId.HasValue ? NetworkIdOrVlanIdChoiceType.vlanId : NetworkIdOrVlanIdChoiceType.networkId,
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