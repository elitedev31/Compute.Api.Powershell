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
    [Cmdlet(VerbsCommon.New, "CaasIpAddressRangeType")]
    [OutputType(typeof(IpAddressListRangeType))]
    public class NewCaasIpAddressRangeTypeCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "Ip_Address", HelpMessage = "The IP Address")]
        public string IpAddress { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Range_Ip_Address", HelpMessage = "The IP Address Begin of the Range")]
        public string Begin { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Range_Ip_Address", HelpMessage = "The IP Address End of the Range")]
        public string End { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Ip_Address", HelpMessage = "The IP Address Range Prefix")]
        public int? PrefixSize { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            IpAddressListRangeType response = null;
            try
            {
                response = new IpAddressListRangeType
                {
                    Begin = ParameterSetName.Equals("Range_Ip_Address") ? Begin : IpAddress,
                    End = End,
                    PrefixSize = PrefixSize
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