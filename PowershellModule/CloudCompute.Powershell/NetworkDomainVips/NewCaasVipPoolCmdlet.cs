using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The new VIP Pool CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVipPool")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasVipPoolCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the VIP pool name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Pool name")]
        public string PoolName { get; set; }

        /// <summary>
		///     Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP Pool description")]
        public string Description { get; set; }

        /// <summary>
		///     Gets or sets the load balance method.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Pool Load balance method")]
        public string LoadBalanceMethod { get; set; }

        /// <summary>
		///     Gets or sets health monitor ids.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VIP Pool Health Monitor Ids")]
        public string[] HealthMonitorId { get; set; }

        /// <summary>
		///     Gets or sets the service down action.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Pool Service down action")]
        public string ServiceDownAction { get; set; }

        /// <summary>
		///     Gets or sets the slow ramp time.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VIP Pool Slow ramp time")]
        public string SlowRampTime { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var vipPool = new createPool
                {
                    networkDomainId = NetworkDomain.id,
                    name = PoolName,
                    description = Description,
                    healthMonitorId = HealthMonitorId,
                    loadBalanceMethod = LoadBalanceMethod,
                    serviceDownAction = ServiceDownAction,
                    slowRampTime = SlowRampTime                    
                };

                response = Connection.ApiClient.Networking.VipPool.CreatePool(vipPool).Result;
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