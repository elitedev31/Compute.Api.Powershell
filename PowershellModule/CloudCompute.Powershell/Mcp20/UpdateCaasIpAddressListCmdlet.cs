using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Linq;

    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The Edit IP Address List CMD Let
    /// </summary>
    [Cmdlet("Update", "CaasIpAddressList")]
    [OutputType(typeof(ResponseType))]
    public class UpdateCaasIpAddressListCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain id")]
        public string NetworkDomainId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The IP address list id")]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IP Address List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP addresses or ranges of IP addresses")]
        public IpAddressListIpAddress[] IpAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP Address Lists on the same Network Domain")]
        public string[] ChildIpAddressListId { get; set; }

        private readonly string dummyText = "EmptyValue!!";

        public UpdateCaasIpAddressListCmdlet()
        {
            // assigned a dummy value to description to determine is modified or not
            this.Description = dummyText;
        }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var ipAddress = IpAddress.Select(x =>
                        new editIpAddressListIpAddress
                        {
                            begin = x.Begin,
                            end = x.End,
                            prefixSize = x.PrefixSize ?? 0,
                            prefixSizeSpecified = x.PrefixSize.HasValue
                        })
                        .ToArray();

                var ipAddressList = new EditIpAddressList
                {
                    id = Id.ToString(),
                    description = Description,
                    descriptionSpecified = Description != dummyText,
                    childIpAddressListId = ChildIpAddressListId,
                    childIpAddressListIdSpecified = ChildIpAddressListId.Length > 0,
                    ipAddress = ipAddress.Length > 0 ? ipAddress : null,
                    ipAddressSpecified = ipAddress.Length > 0
                };

                response = Connection.ApiClient.Networking.FirewallRule.EditIpAddressList(ipAddressList).Result;
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