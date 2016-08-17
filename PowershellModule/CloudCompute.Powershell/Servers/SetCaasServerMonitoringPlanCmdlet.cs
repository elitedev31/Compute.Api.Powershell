using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The Set Caas Server Monitoring Plan
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerMonitoringPlan")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasServerMonitoringPlanCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets Server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Server")]
        public ServerType Server { get; set; }

        /// <summary>
        /// Gets or sets Service Plan
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Monitoring service plan")]
        public string ServicePlan { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var monitoringType = new ChangeServerMonitoringPlanType
                {
                    id = Server.id,
                    servicePlan = ServicePlan
                };

                response = Connection.ApiClient.ServerManagement.Monitoring.ChangeServerMonitoringPlan(monitoringType).Result;
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