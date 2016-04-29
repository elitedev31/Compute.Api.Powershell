using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasIpAddressList")]
    [OutputType(typeof(IpAddressListType))]
    public class GetCaasIpAddressCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", HelpMessage = "The network domain id")]
        public Guid NetworkDomainId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The IP address list id")]
        public Guid? IpAddressListId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The IP Address List name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The IP version (IPv4 / IPv6)")]
        public string IPVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The State of the IP Address List")]
        public string State { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.FirewallRule.GetIpAddressListsPaginated(
                        NetworkDomainId,
                        ParameterSetName.Equals("Filtered")
                            ? new IpAddressListOptions
                            {
                                Id = IpAddressListId != Guid.Empty ? IpAddressListId : (Guid?)null,
                                IpVersion = IPVersion,
                                State = State,
                                Name = Name
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
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}
