using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The NAT Rule list options type.
    /// </summary>
    public class PublicIpListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "datacenterId" field name.
        /// </summary>
        public const string DatacenterIdField = "datacenterId";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";
        
        /// <summary>
        /// The "baseIp" field name.
        /// </summary>
        public const string BaseIpField = "baseIp";

        /// <summary>
        /// The "size" field name.
        /// </summary>
        public const string SizeField = "size";

        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
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
        /// Identifies an Datacenter.
        /// </summary>
        public string BaseIp
        {
            get { return GetFilter<string>(BaseIpField); }
            set { SetFilter(BaseIpField, value); }
        }

        /// <summary>
        /// Filters by size.
        /// </summary>
        public int? Size
        {
            get { return GetFilter<int?>(SizeField); }
            set { SetFilter(SizeField, value); }
        }

        /// <summary>
        /// Filters by State.
        /// </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeBefore filter.
        /// </summary>
        public DateTimeOffset? CreateTimeBefore
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.LessThan); }
            set { SetFilter(CreateTimeField, FilterOperator.LessThan, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeAfter filter.
        /// </summary>
        public DateTimeOffset? CreateTimeAfter
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.GreaterThan); }
            set { SetFilter(CreateTimeField, FilterOperator.GreaterThan, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeAfter Inclusive filter.
        /// </summary>
        public DateTimeOffset? CreateTimeMin
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.LessOrEqual); }
            set { SetFilter(CreateTimeField, FilterOperator.LessOrEqual, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeMax filter.
        /// </summary>
        public DateTimeOffset? CreateTimeMax
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.GreaterOrEqual); }
            set { SetFilter(CreateTimeField, FilterOperator.GreaterOrEqual, value); }
        }
    }
}