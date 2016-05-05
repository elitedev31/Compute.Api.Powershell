using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The new IP Address List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasReservePrivateIpv4AddressType")]
    [OutputType(typeof(ReservePrivateIpv4Address))]
    public class NewCaasReservePrivateIpv4AddressTypeCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Network Id Or Vlan Id to Reserve Private Ipv4 Address")]
        public string NetworkIdOrVlanId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Type of Network Id Or Vlan Id to Reserve Private Ipv4 Address")]
        public NetworkIdOrVlanIdType NetworkIdOrVlanIdType { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ReservePrivateIpv4Address response = null;
            try
            {
                response = new ReservePrivateIpv4Address
                               {
                                   NetworkIdOrVlanId = NetworkIdOrVlanId,
                                   NetworkIdOrVlanIdType = NetworkIdOrVlanIdType
                               };
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