namespace DD.CBU.Compute.Api.Contracts.Requests
{
    /// <summary>
    /// The filter operator.
    /// </summary>
    public enum FilterOperator
    {
        /// <summary>
        /// The equals
        /// </summary>
        Equals,

        /// <summary>
        /// The like
        /// </summary>
        Like,

        /// <summary>
        /// The greater than
        /// </summary>
        GreaterThan,

        /// <summary>
        /// The greater or equal
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// The less than
        /// </summary>
        LessThan,

        /// <summary>
        /// The less or equal
        /// </summary>
        LessOrEqual
    }
}