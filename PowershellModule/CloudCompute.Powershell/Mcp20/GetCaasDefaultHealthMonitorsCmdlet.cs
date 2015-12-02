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

    [Cmdlet(VerbsCommon.Get, "CaasDefaultHealthMonitors")]
    [OutputType(typeof(DefaultHealthMonitorType))]
    public class GetCaasDefaultHealthMonitorsCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the Health Monitor name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The health monitor name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets health monitor id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The health monitor id")]
        public Guid MonitorId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<DefaultHealthMonitorType> healthMonitors = new List<DefaultHealthMonitorType>();
            base.ProcessRecord();

            try
            {
                healthMonitors = Connection.ApiClient.Networking.VipSupport.GetDefaultHealthMonitors(NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                                                                            (ParameterSetName.Equals("Filtered") ? new DefaultHealthMonitorListOptions
                                                                                {
                                                                                    Id = MonitorId != Guid.Empty ? MonitorId : (Guid?)null,
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
            WriteObject(healthMonitors, true);
        }
    }
}
