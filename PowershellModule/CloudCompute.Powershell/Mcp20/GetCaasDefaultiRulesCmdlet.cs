using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasDefaultIRules")]
    [OutputType(typeof(DefaultIruleType))]
    public class GetCaasDefaultIRulesCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the iRule name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The iRule name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }
        
        /// <summary>
        ///     Gets or sets iRule id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The iRule id")]
        public Guid RuleId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<DefaultIruleType> iRules = new List<DefaultIruleType>();
            base.ProcessRecord();

            try
            {
                iRules = Connection.ApiClient.Networking.VipSupport.GetDefaultIrules(NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                                                                            (ParameterSetName.Equals("Filtered") ? new DefaultIruleListOptions
                                                                                {
                                                                                    Id = RuleId != Guid.Empty ? RuleId : (Guid?)null,
                                                                                    Name = Name,
                                                                                } : null)).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
            WriteObject(iRules, true);
        }
    }
}
