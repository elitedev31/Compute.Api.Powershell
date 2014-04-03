using System;

namespace DD.CBU.Compute.Api.Client
{
    using System.Diagnostics.Contracts;

    /// <summary>
    ///		Constants and formatters for API URLs.
    /// </summary>
    public static class ApiUris
    {
        /// <summary>
        ///		The path (relative to the base API URL) of the My Account action.
        /// </summary>
        public static readonly Uri MyAccount = new Uri("myaccount", UriKind.Relative);

        /// <summary>
        ///		Get the base URI for the CaaS REST API.
        /// </summary>
        /// <param name="targetRegionName">
        ///		The target region's short name ("au", for example).
        /// </param>
        /// <returns>
        ///		The base URI for the CaaS REST API.
        /// </returns>
        public static Uri ComputeBase(string targetRegionName)
        {
            if (String.IsNullOrWhiteSpace(targetRegionName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.",
                    "targetRegionName");

            return new Uri(String.Format("https://api-{0}.dimensiondata.com/oec/0.9/", targetRegionName.ToLower()));
        }

        /// <summary>
        ///		Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.
        /// </summary>
        /// <param name="organizationId">
        ///		The organisation Id.
        /// </param>
        /// <returns>
        ///		The relative action Uri.
        /// </returns>
        public static Uri DatacentersWithDiskSpeedDetails(Guid organizationId)
        {
            if (organizationId == Guid.Empty) throw new ArgumentException("GUID cannot be empty: 'organizationId'.", "organizationId");

            return new Uri(String.Format("{0}/datacenterWithDiskSpeed", organizationId), UriKind.Relative);
        }

        /// <summary>
        ///		Get the relative URI for the CaaS API action that retrieves a list of all system-defined images deployed in the specified data centre.
        /// </summary>
        /// <param name="locationName">
        ///		The data centre location name.
        /// </param>
        /// <returns>
        ///		The relative action Uri.
        /// </returns>
        public static Uri ImagesWithSoftwareLabels(string locationName)
        {
            if (String.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.",
                    "locationName");

            return new Uri(String.Format("base/image/deployedWithSoftwareLabels/{0}", locationName), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of all deployed servers.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>A list of deployed servers</returns>
        public static Uri DeployedServers(Guid orgId)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization Id cannot be empty");

            return new Uri(string.Format("{0}/serverWithBackup", orgId), UriKind.Relative);
        }

        internal static Uri OsServerImages(string networkLocation)
        {
            return new Uri(
                string.Format("base/image/deployedWithSoftwareLabels/{0}", networkLocation),
                UriKind.Relative);
        }

        /// <summary>
        /// Lists the Networks deployed across all data center locations for the supplied organization.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for a list of networks</returns>
        internal static Uri NetworkWithLocations(Guid orgId)
        {
            return new Uri(string.Format("{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that allows a server to be deployed
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        internal static Uri DeployServer(Guid orgId)
        {
            return new Uri(string.Format("{0}/server", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Deletes the server.
        /// <remarks>The Server must be stopped before it can be deleted</remarks>
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a deletion of the server</returns>
        internal static Uri DeleteServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?delete", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// A “graceful” stop of a server by initiating a shutdown sequence within the guest operating system.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a graceful shutdown of the server</returns>
        internal static Uri ShutdownServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?shutdown", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Powers on an existing deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for starting the server</returns>
        internal static Uri PowerOnServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?start", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// An abrupt power off of the server. Success is guarenteed
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for powering off the server</returns>
        internal static Uri PoweroffServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?poweroff", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// A "graceful" reboot of the server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        internal static Uri RebootServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?reboot", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Enables the Backup service for a deployed Server. Requires the Organization ID, Server ID and the Service Plan being enabled.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for enabling the backup on the server</returns>
        internal static Uri EnableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Disables the Backup service for a deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for disabling the backup on the server</returns>
        internal static Uri DisableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup?disable", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Modify the backup service plan for a deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for modifying the backup service pland of the server</returns>
        internal static Uri ChangeBackupPlan(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup/modify", orgId, serverId), UriKind.Relative);
        }
    }
}
