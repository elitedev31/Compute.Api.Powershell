namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    /// The get CaaS NAT Rules cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNatRules")]
    [OutputType(typeof(NatRuleType[]))]
    public class GetCaasNatRulesCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The network to show the NAT rules from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the images from", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var rules = GetNatRules();
                if (rules != null && rules.Any())
                {
                    WriteObject(rules, true);
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

        /// <summary>
        /// Gets the NAT rules
        /// </summary>
        /// <returns>The NAT rules</returns>
        private IEnumerable<NatRuleType> GetNatRules()
        {
            return CaaS.ApiClient.GetNatRules(Network.id).Result;
        }
    }
}