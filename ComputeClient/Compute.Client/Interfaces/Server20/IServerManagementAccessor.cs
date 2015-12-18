namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
	/// <summary>
	/// The ServerManagementAccessor interface.
	/// </summary>
	public interface IServerManagementAccessor
	{
        /// <summary>
        /// Gets the Server Accessor.
        /// </summary>
        IServerAccessor Server { get; }

        /// <summary>
        /// Gets the Server Images Accessor.
        /// </summary>
        IServerImageAccessor ServerImage { get; }

        /// <summary>
        /// Gets the Anti Affinity Rule Accessor.
        /// </summary>
        IAntiAffinityRuleAccessor AntiAffinityRule { get; }

        /// <summary>
        /// Gets the Monitoring Accessor.
        /// </summary>
        IMonitoringAccessor Monitoring { get; }
    }
}
