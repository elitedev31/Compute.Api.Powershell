using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The pool list options.
    /// </summary>
    public class PoolListOptions: FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string NetworkDomainIdField = "networkDomainId";

        /// <summary>
        /// The "datacenterId" field name.
        /// </summary>
        public const string DatacenterIdField = "datacenterId";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "loadBalancedMethod" field name.
        /// </summary>
        public const string LoadBalancedMethodField = "loadBalancedMethod";

        /// <summary>
        /// The "serviceDownAction" field name.
        /// </summary>
        public const string ServiceDownActionField = "serviceDownAction";

        /// <summary>
        /// The "slowRampTime" field name.
        /// </summary>
        public const string SlowRampTimeField = "slowRampTime";

        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Network Domain.
        /// </summary>
        public Guid? NetworkDomainId
        {
            get { return GetFilter<Guid?>(NetworkDomainIdField); }
            set { SetFilter(NetworkDomainIdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Data Center.
        /// </summary>
        public string DatacenterId
        {
            get { return GetFilter<string>(DatacenterIdField); }
            set { SetFilter(DatacenterIdField, value); }
        }

        /// <summary>	
        /// Identifies Pools by their name.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary>	
        /// Identifies Pools by their state.
        /// Case insensitive. The initial possible set of values for state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE" and
        /// "REQUIRES_SUPPORT".
        /// </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }

        /// <summary>	
        /// Identifies Pools with the supplied loadBalanceMethod(s).
        /// loadBalanceMethod=ROUND_ROBIN
        /// </summary>
        public string LoadBalancedMethod
        {
            get { return GetFilter<string>(LoadBalancedMethodField); }
            set { SetFilter(LoadBalancedMethodField, value); }
        }

        /// <summary>	
        /// Filters the list to Pools with the supplied serviceDownAction(s).
        /// serviceDownAction=DROP
        /// </summary>
        public string ServiceDownAction
        {
            get { return GetFilter<string>(ServiceDownActionField); }
            set { SetFilter(ServiceDownActionField, value); }
        }

        /// <summary>	
        /// Filters the list to Pools with the supplied slowRampTime(s).
        /// </summary>
        public int? SlowRampTime
        {
            get { return GetFilter<int?>(SlowRampTimeField); }
            set { SetFilter(SlowRampTimeField, value); }
        }
    }
}