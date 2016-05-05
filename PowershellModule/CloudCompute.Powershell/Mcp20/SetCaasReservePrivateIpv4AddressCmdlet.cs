using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    /// Reserve Private IPV4 Address CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CassReservePrivateIpv4Address")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasReservePrivateIpv4AddressCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The unique identifier of either an MCP 1.0 Cloud Network or an MCP 2.0 VLAN. Use New-CaasReservePrivateIpv4AddressType command to create the type")]
        public ReservePrivateIpv4Address ReservePrivateIpv4AddressElement { get; set; }

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
                    Connection.ApiClient.Networking.IpAddress.ReservePrivateIpv4Address(
                        new ReservePrivateIpv4AddressType
                        {
                            Item = ReservePrivateIpv4AddressElement.NetworkIdOrVlanId,
                            ItemElementName = (NetworkIdOrVlanIdChoiceType)ReservePrivateIpv4AddressElement.NetworkIdOrVlanIdType,
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