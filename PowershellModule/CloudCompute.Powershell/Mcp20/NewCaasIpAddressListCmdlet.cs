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
        [Parameter(Mandatory = true, ParameterSetName = "With_NetworkDomainId", HelpMessage = "The network domain id")]
        public string NetworkDomainId { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_NetworkDomain", HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IP Address List name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IP Address List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The IP version (IPv4 / IPv6)")]
        public IpVersion IpVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP addresses or ranges of IP addresses. Use New CaasIpAddressRangeType to create type")]
        public IpAddressListRangeType[] IpAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP Address Lists on the same Network Domain")]
        public string[] ChildIpAddressListId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The network domain id")]
        public IpAddressListType[] ChildIpAddressList { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                if (NetworkDomain != null)
                {
                    NetworkDomainId = NetworkDomain.id;
                }

                if (ChildIpAddressList != null && ChildIpAddressList.Length > 0)
                {
                    ChildIpAddressListId = ChildIpAddressList.Select(x => x.id).ToArray();
                }

                var ipAddressList = new createIpAddressList
                {
                    networkDomainId = NetworkDomainId,
                    name = Name,
                    description = Description,
                    ipVersion = IpVersion.ToString(),
                    childIpAddressListId = ChildIpAddressListId,
                    ipAddress = IpAddress != null
                        ? IpAddress.Select(x => new IpAddressRangeType
                        {
                            begin = x.Begin,
                            end = x.End,
                            prefixSize = x.PrefixSize ?? 0,
                            prefixSizeSpecified = x.PrefixSize.HasValue
                        }).ToArray()
                        : null,
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