namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;

    /// <summary>	A VLAN list options model. </summary>
    public class SecurityGroupListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>
        /// Gets or sets the Name filter.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary>	Identifies VLANs by their state.
        /// Case insensitive. The initial possible
        /// set of values for vlan.state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE",
        /// "REQUIRES_SUPPORT"
        /// This set of values should not be
        /// assumed to be static and can
        /// increase at any time. </summary>
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
