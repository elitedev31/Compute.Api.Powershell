using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Api.Contracts.Network;

    /// <summary>
    /// List Reserved Private IPV4 Addresses CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasReservePrivateIpv4Address")]
    [OutputType(typeof(ReservedPrivateIpv4AddressType))]
    public class GetCaasReservePrivateIpv4AddressCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "With_Vlan", HelpMessage = "Identifies VLAN (MCP 2.0)")]
        public VlanType Vlan { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "With_Vlan", HelpMessage = "Identifies VLAN (MCP 2.0)")]
        public Guid? VlanId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "With_Network", HelpMessage = "Identifies Cloud Network (MCP 1.0)")]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "With_Network", HelpMessage = "Identifies Cloud Network (MCP 1.0)")]
        public Guid? NetworkId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Identifies an individual Private IPV4")]
        public string IpAddress { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.IpAddress.GetReservedPrivateIpv4AddressesPaginated(
                            new Api.Contracts.Requests.Network20.ReservedPrivateIpv4ListOptions
                            {
                                VlanId = Vlan != null ? Guid.Parse(Vlan.id) : VlanId,
                                NetworkId = Network != null ? Network.id : (NetworkId.HasValue? NetworkId.Value.ToString() : null),
                                IpAddress = IpAddress
                            },
                        PageableRequest).Result);
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
        }
    }
}