using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    /// Un-Reserve IPV6 Address CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasReserveIPv6Address")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasReserveIPv6AddressCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The unique identifier of MCP 2.0 VLAN")]
        public Guid VlanId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IPv6 address")]
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
                    Connection.ApiClient.Networking.IpAddress.UnreserveIpv6Address(
                        new UnreserveIpv6AddressType { vlanId = VlanId.ToString(), ipAddress = IpAddress }).Result;
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