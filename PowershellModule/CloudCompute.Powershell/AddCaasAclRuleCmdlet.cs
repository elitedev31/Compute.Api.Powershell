    using System;
    using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
    using System.Net;

    using Api.Client;

    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    ///	The Add CaaS ACL Rule Cmdlet.
    /// </summary>
    /// <remarks>
    ///	Imports a new customer image.
    /// </remarks>
    [Cmdlet(VerbsCommon.Add, "CaasAclRule", SupportsShouldProcess = true)]
    [OutputType(typeof(AclRuleType))]
    public class AddCaasAclRuleCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The target network to add the ACL rule into.", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The ACL Rule name")]
        public string AclRuleName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The position of the ACL rule to add")]
        [ValidateRange(100, 500)]
        public int Position { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The ACL action type: Permit or Deny")]
        public AclActionType Action { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The protocol")]
        public ComputeApiClientNetworkExtensions.AclProtocolType Protocol { get; set; }

        [Parameter(HelpMessage = "The source IP Address. If not supplied, ANY IP address is assumed.")]
        public IPAddress SourceIpAddress { get; set; }

        [Parameter(HelpMessage = "The source Netmask. If supplied with the SourceIpAddress, represents CIDR boundary for the network.")]
        public IPAddress SourceNetmask { get; set; }

        [Parameter(HelpMessage = "The destination IP Address. If not supplied, ANY IP address is assumed.")]
        public IPAddress DestinationIpAddress { get; set; }

        [Parameter(HelpMessage = "The destination Netmask. If supplied with the DestinationIpAddress, represents CIDR boundary for the network.")]
        public IPAddress DestinationNetmask { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The port range type")]
        public PortRangeTypeType PortRangeType { get; set; }

        [Parameter(HelpMessage = "Depending on the port range type - will define the port criteria")]
        [ValidateRange(1, 65535)]
        public int Port1 { get; set; }

        [Parameter(HelpMessage = "Depending on the port range type - will define the port criteria")]
        [ValidateRange(1, 65535)]
        public int Port2 { get; set; }

        [Parameter(HelpMessage = "The type of the ACL. One of OUTSIDE_ACL or INSIDE_ACL. Default is OUTSIDE_ACL.")]
        [PSDefaultValue(Value = AclType.OUTSIDE_ACL)]
        public AclType Type { get; set; }
        
        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var aclRule = CreateAclRule();

                if (aclRule != null)
                {
                    WriteObject(aclRule);
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                        }
                        return true;
                    });
            }
        }

        private AclRuleType CreateAclRule()
        {
            return
                CaaS.ApiClient.CreateAclRule(
                    Network.id,
                    AclRuleName,
                    Position,
                    Action,
                    Protocol,
                    PortRangeType,
                    SourceIpAddress,
                    SourceNetmask,
                    DestinationIpAddress,
                    DestinationNetmask,
                    Port1,
                    Port2,
                    Type).Result;
        }
    }
}