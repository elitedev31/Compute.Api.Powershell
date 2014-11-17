using DD.CBU.Compute.Api.Contracts.Network;

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
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, HelpMessage = "Name to filter")]
        public string Name { get; set; }


        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var resultlist = GetNatRules();
                if (resultlist != null && resultlist.Any())
                {

                    if (!string.IsNullOrEmpty(Name))
                        resultlist = resultlist.Where(net => net.name.ToLower() == Name.ToLower());

                    switch (resultlist.Count())
                    {
                        case 0:
                            WriteDebug("Object(s) not found");
                            break;
                        case 1:
                            WriteObject(resultlist.First());
                            break;
                        default:
                            WriteObject(resultlist, true);
                            break;
                    }
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