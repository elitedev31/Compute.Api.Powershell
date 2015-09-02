namespace DD.CBU.Compute.Api.Contracts.Directory
{
    /// <summary>	Sub-Administrator role type. </summary>
    public enum RoleType 
	{
        /// <summary>	An enum constant representing the network option. </summary>
        Network,

        /// <summary>	An enum constant representing the backup option. </summary>
        Backup,

        /// <summary>	An enum constant representing the server option. </summary>
        Server,

        /// <summary>	An enum constant representing the create image option. </summary>
        CreateImage,

        /// <summary>	An enum constant representing the storage option. </summary>
        Storage,

        /// <summary>	An enum constant representing the reports option. </summary>
        Reports,

        /// <summary>	An enum constant representing the read only option. </summary>
        ReadOnly
    }
}