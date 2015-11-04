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

    [Cmdlet(VerbsCommon.Get, "CaasVipPoolMembers")]
    [OutputType(typeof(PoolMemberType[]))]
    public class GetCaasVipPoolMembersCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets the data center.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The data center")]
        public DatacenterType Datacenter { get; set; }

        /// <summary>
        ///     Gets or sets VIP Node.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP Node")]
        public PoolType VipNode { get; set; }

        /// <summary>
        ///     Gets or sets VIP Pool.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP Pool")]
        public PoolType VipPool { get; set; }

        /// <summary>
        ///     Gets or sets VIP Pool member id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP pool member Id")]
        public Guid MemberId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<PoolMemberType> poolMembers = new List<PoolMemberType>();
            base.ProcessRecord();

            try
            {
                poolMembers = Connection.ApiClient.Networking.VipPool.GetPoolMembers(
                                                                            (ParameterSetName.Equals("Filtered") ? new PoolMemberListOptions
                                                                            {
                                                                                Id = MemberId != Guid.Empty ? MemberId : (Guid?)null,                                                                                
                                                                                NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                                                                                DatacenterId = Datacenter != null ? Guid.Parse(Datacenter.id) : Guid.Empty,
                                                                                NodeId = VipNode != null ? Guid.Parse(VipNode.id) : Guid.Empty,
                                                                                PoolId = VipPool != null ? Guid.Parse(VipPool.id) : Guid.Empty
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

            if (poolMembers != null && poolMembers.Count() == 1)
            {
                WriteObject(poolMembers.First());
            }
            else
            {
                WriteObject(poolMembers);
            }
        }
    }
}
