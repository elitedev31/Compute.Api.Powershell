using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasVipPool")]
    [OutputType(typeof(PoolType))]
    public class GetCaasVipPoolCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the VIP Pool name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP Pool name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets VIP pool id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP Pool id")]
        public Guid PoolId { get; set; }

        /// <summary>
        ///     Gets or sets VIP Pool State
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP Pool state")]
        public string State { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.VipPool.GetPoolsPaginated(
                        (ParameterSetName.Equals("Filtered")
                            ? new PoolListOptions
                            {
                                Id = PoolId != Guid.Empty ? PoolId : (Guid?) null,
                                Name = Name,
                                NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : (Guid?) null,
                                State = State
                            }
                            : null),
                        PageableRequest).Result);
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
        }
    }
}
