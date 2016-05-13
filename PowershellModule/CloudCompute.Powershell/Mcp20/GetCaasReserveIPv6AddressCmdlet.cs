using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    /// Get Reserve IPV6 Address List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasReserveIPv6Address")]
    [OutputType(typeof(ReservedIpv6AddressType))]
    public class GetCaasReserveIPv6AddressCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Alias("Id"), Parameter(Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Filtered", HelpMessage = "The unique identifier of MCP 2.0 VLAN")]
        public Guid? VlanId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The IPv6 address")]
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
                    Connection.ApiClient.Networking.IpAddress.GetReservedIpv6AddressesPaginated(
                        ParameterSetName.Equals("Filtered")
                            ? new Api.Contracts.Requests.Network20.ReservedIpv6ListOptions
                            {
                                VlanId = VlanId,
                                IpAddress = IpAddress
                            }
                            : null,
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