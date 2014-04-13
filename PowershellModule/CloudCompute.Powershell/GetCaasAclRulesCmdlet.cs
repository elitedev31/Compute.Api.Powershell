namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    /// The get CaaS ACL Rules cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasAclRules")]
    [OutputType(typeof(AclRuleType[]))]
    public class GetCaasAclRulesCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the ACL rules from", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork NetworkWithLocations { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var rules = GetAclRules();
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
        /// Gets the ACL rules from the specified network
        /// </summary>
        /// <returns>The ACL Rules</returns>
        private IEnumerable<AclRuleType> GetAclRules()
        {
            return CaaS.ApiClient.GetAclRules(NetworkWithLocations.id).Result;
        }
    }
}