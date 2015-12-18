namespace DD.CBU.Compute.Api.Client.Server20
{
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Server20;

	/// <summary>
	/// The server management accessor.
	/// </summary>
	public class ServerManagementAccessor : IServerManagementAccessor
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="ServerManagementAccessor"/> class.
		/// </summary>
		/// <param name="webApi">
		/// The webapi.
		/// </param>
		public ServerManagementAccessor(IWebApi webApi)
		{
            Server = new ServerAccessor(webApi);
            ServerImage = new ServerImageAccessor(webApi);
            AntiAffinityRule = new AntiAffinityRuleAccessor(webApi);
            Monitoring = new MonitoringAccessor(webApi);
        }

        /// <summary>
        /// Gets the Server Accessor.
        /// </summary>
        public IServerAccessor Server { get; private set; }

        /// <summary>
        /// Gets the Server Images Accessor
        /// </summary>
	    public IServerImageAccessor ServerImage { get; }

	    /// <summary>
        /// Gets the Anti Affinity Rule Accessor.
        /// </summary>
        public IAntiAffinityRuleAccessor AntiAffinityRule { get; private set; }

        /// <summary>
        /// Gets the Monitoring Accessor.
        /// </summary>
        public IMonitoringAccessor Monitoring { get; private set; }
    }
}
