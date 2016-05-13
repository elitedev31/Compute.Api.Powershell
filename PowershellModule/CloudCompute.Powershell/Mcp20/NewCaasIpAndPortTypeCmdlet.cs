using System.Management.Automation;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The new IP Address List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasIpAndPortType")]
    [OutputType(typeof(IpAndPortType))]
    public class NewCaasIpAndPortTypeCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddressList_PortList", HelpMessage = "The IP Address List")]
        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddressList_Port", HelpMessage = "The IP Address List")]
        public IpAddressListType IpAddressList { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddress_PortList", HelpMessage = "The IP Address")]
        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddress_Port", HelpMessage = "The IP Address")]
        public string IpAddress { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddress_PortList", HelpMessage = "The IP Address Prefix size")]
        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddress_Port", HelpMessage = "The IP Address Prefix Size")]
        public int? PrefixSize { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddressList_PortList", HelpMessage = "The Port List")]
        [Parameter(Mandatory = true, ParameterSetName = "With_IpAddress_PortList", HelpMessage = "The Port List")]
        public PortListType PortList { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddressList_Port", HelpMessage = "The Port")]
        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddress_Port", HelpMessage = "The Port")]
        public ushort? BeginPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddressList_Port", HelpMessage = "The Port rang end")]
        [Parameter(Mandatory = false, ParameterSetName = "With_IpAddress_Port", HelpMessage = "The Port Range End")]
        public ushort? EndPort { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            IpAndPortType response = null;
            response = new IpAndPortType();

            if(IpAddressList != null)
            {
                response.Item =
                    IpAddressList.id;
            }
            else
            {
                response.Item = new IpAndPortTypeIP
                {
                    address = IpAddress,
                    prefixSize = PrefixSize.HasValue ? PrefixSize.Value : 0,
                    prefixSizeSpecified = PrefixSize.HasValue
                };
            }

            if (PortList != null)
            {
                response.Item1 = PortList.id;
            }
            else if(BeginPort.HasValue)
            {
                response.Item1 = new PortRangeType
                {
                    begin = BeginPort.HasValue ? BeginPort.Value : (ushort)0,
                    end = EndPort.HasValue ? EndPort.Value : (ushort)0,
                    endSpecified = EndPort.HasValue
                };
            }

            WriteObject(response);
        }
    }
}