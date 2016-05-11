using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The Edit IP Address List CMD Let
    /// </summary>
    [Cmdlet("Update", "CaasIpAddressList")]
    [OutputType(typeof(ResponseType))]
    public class UpdateCaasIpAddressListCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IP address list id")]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IP Address List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP addresses or ranges of IP addresses. Use New CaasIpAddressRangeType create to create type")]
        public IpAddressListRangeType[] IpAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual IP Address Lists on the same Network Domain")]
        public string[] ChildIpAddressIdList { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Define one or more individual IP Address Lists on the same Network Domain")]
        public IpAddressListType[] ChildIpAddressList { get; set; }

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
                var addresses = new editIpAddressListIpAddress[0];

                if (IpAddress != null)
                {
                    addresses =
                        IpAddress.Select(
                            x =>
                            new editIpAddressListIpAddress
                                {
                                    begin = x.Begin,
                                    end = x.End,
                                    prefixSize = x.PrefixSize ?? 0,
                                    prefixSizeSpecified = x.PrefixSize.HasValue
                                }).ToArray();
                }

                if (ChildIpAddressList != null && ChildIpAddressList.Length > 0)
                {
                    ChildIpAddressIdList = ChildIpAddressList.Select(x => x.id).ToArray();
                }

                var editIpAddressList = new editIpAddressList
                {
                    id = Id.ToString(),
                    description = Description,
                    descriptionSpecified = Description != dummyText,
                    childIpAddressListId = ChildIpAddressIdList,
                    childIpAddressListIdSpecified = ChildIpAddressIdList != null && ChildIpAddressIdList.Length > 0,
                    ipAddress = addresses.Length > 0 ? addresses : null,
                    ipAddressSpecified = addresses.Length > 0
                };

                response = Connection.ApiClient.Networking.FirewallRule.EditIpAddressList(editIpAddressList).Result;
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