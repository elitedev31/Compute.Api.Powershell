using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Linq;

    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The new IP Address List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasIpAddressList")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasIpAddressListCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain id")]
        public string NetworkDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The IP Address List name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The IP Address List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The IP version (IPv4 / IPv6)")]
        public string IPVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Define one or more individual IP addresses or ranges of IP addresses. Use New-CaasIpAddressRangeType to create type")]
        public IpAddressListRangeType[] IpAddress { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Define one or more individual IP Address Lists on the same Network Domain")]
        public string[] ChildIpAddressListId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var ipAddressList = new createIpAddressList
                {
                    networkDomainId = NetworkDomainId,
                    name = Name,
                    description = Description,
                    ipVersion = IPVersion,
                    childIpAddressListId = ChildIpAddressListId,
                    ipAddress = IpAddress?
                        .Select(x => new IpAddressRangeType
                        {
                            begin = x.Begin,
                            end = x.End,
                            prefixSize = x.PrefixSize ?? 0,
                            prefixSizeSpecified = x.PrefixSize.HasValue
                        }).ToArray(),
                };

                response = Connection.ApiClient.Networking.FirewallRule.CreateIpAddressList(ipAddressList).Result;
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