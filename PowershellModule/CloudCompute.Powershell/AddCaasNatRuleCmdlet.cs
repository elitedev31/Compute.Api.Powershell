
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Net;

    using Api.Client;

    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    ///	The Add CaaS NAT Rule Cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "CaasNatRule")]
    [OutputType(typeof(NatRuleType))]
    public class AddCaasNatRuleCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The target network to add the NAT rule into.", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The NAT Rule name")]
        public string NatRuleName { get; set; }

        [Parameter(HelpMessage = "The source IP Address.")]
        public IPAddress SourceIpAddress { get; set; }

        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var natRule = CreateNatRule();

                if (natRule != null)
                {
                    WriteObject(natRule);
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

        private NatRuleType CreateNatRule()
        {
            return CaaS.ApiClient.CreateNatRule(Network.id, NatRuleName, SourceIpAddress).Result;
        }
    }
}