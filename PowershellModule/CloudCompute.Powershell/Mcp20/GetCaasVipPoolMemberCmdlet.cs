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

    [Cmdlet(VerbsCommon.Get, "CaasVipPoolMember")]
    [OutputType(typeof(PoolMemberType))]
    public class GetCaasVipPoolMemberCmdlet : PsCmdletCaasPagedWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets the data center.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The data center")]
        public DatacenterType Datacenter { get; set; }

        /// <summary>
        ///     Gets or sets VIP Node.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP Node")]
        public NodeType VipNode { get; set; }

        /// <summary>
        ///     Gets or sets VIP Pool.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP Pool")]
        public PoolType VipPool { get; set; }

        /// <summary>
        ///     Gets or sets VIP Pool member id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP pool member Id")]
        public Guid MemberId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.VipPool.GetPoolMembersPaginated(
                        (ParameterSetName.Equals("Filtered")
                            ? new PoolMemberListOptions
                            {
                                Id = MemberId != Guid.Empty ? MemberId : (Guid?) null,
                                NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : (Guid?) null,
                                DatacenterId = Datacenter != null ? Datacenter.id : null,
                                NodeId = VipNode != null ? Guid.Parse(VipNode.id) : (Guid?) null,
                                PoolId = VipPool != null ? Guid.Parse(VipPool.id) : (Guid?) null
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
