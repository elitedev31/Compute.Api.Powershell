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

    [Cmdlet(VerbsCommon.Get, "CaasNatRules")]
    [OutputType(typeof(NatRuleType[]))]
    public class GetCaasNATRulesCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the Nat rule state.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The NAT rule state")]
        public string State { get; set; }

        /// <summary>	
        /// Gets or sets internal IP address.
        /// </summary>        
        public string InternalIp { get; set; }

        /// <summary>	
        /// Identifies internal IP address.
        /// </summary>        
        public string ExternalIp { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets NAT rule id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The firewall rule id")]
        public Guid NatRuleId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<NatRuleType> natRules = new List<NatRuleType>();
            base.ProcessRecord();

            try
            {
                natRules = Connection.ApiClient.Networking.Nat.GetNatRules(NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                                                                            (ParameterSetName.Equals("Filtered") ? new NatRuleListOptions
                                                                            {
                                                                                Id = NatRuleId != Guid.Empty ? NatRuleId : (Guid?)null,
                                                                                State = State,
                                                                                InternalIp = InternalIp,
                                                                                ExternalIp = ExternalIp
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

            if (natRules != null && natRules.Count() == 1)
            {
                WriteObject(natRules.First());
            }
            else
            {
                WriteObject(natRules);
            }
        }
    }
}
