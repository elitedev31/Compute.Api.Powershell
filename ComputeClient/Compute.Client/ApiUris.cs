namespace DD.CBU.Compute.Api.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Constants and formatters for API URLs.
    /// </summary>
    public static class ApiUris
    {
        /// <summary>	The MCP 1.0 prefix. </summary>
        public const string MCP1_0_PREFIX = "oec/0.9/";

        /// <summary>	The MCP 2.3 prefix. </summary>
        public const string MCP2_3_PREFIX = "caas/2.3/";

        /// <summary>
        /// The path (relative to the base API URL) of the My Account action.
        /// </summary>
        public static Uri MyAccount = new Uri(MCP1_0_PREFIX + "myaccount", UriKind.Relative);

        /// <summary>	Accounts the given organisation identifier. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri Account(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account", orgId), UriKind.Relative);
        }

        /// <summary>	The path (relative to the base API URL) to Account With Phone Number  action.</summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	The <see cref="Uri"/>. </returns>
        public static Uri AccountWithPhoneNumber(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/accountWithPhoneNumber", orgId), UriKind.Relative);
        }

        /// <summary>The path (relative to the base API URL) to update My Account action.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri UpdateAdministrator(Guid orgId, string username)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}", orgId, username), UriKind.Relative);
        }


        /// <summary>The path (relative to the base API URL) to Account With Phone Number  action.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AccountWithPhoneNumber(Guid orgId, string username)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/accountWithPhoneNumber/{1}", orgId, username), UriKind.Relative);
        }

        /// <summary>The path (relative to the base API URL) set primary administrator action.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri SetPrimaryAdministrator(Guid orgId, string username)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}?primary", orgId, username), UriKind.Relative);
        }

        /// <summary>The path (relative to the base API URL) delete sub administrator action.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteSubAdministrator(Guid orgId, string username)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}?delete", orgId, username), UriKind.Relative);
        }


        /// <summary>Get the base URI for the CaaS REST API.</summary>
        /// <param name="targetRegionName">The target region's short name ("au", for example).</param>
        /// <returns>The base URI for the CaaS REST API.</returns>
        public static Uri ComputeBase(string targetRegionName)
        {
            if (string.IsNullOrWhiteSpace(targetRegionName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.", 
                    "targetRegionName");

            return new Uri(string.Format("https://api-{0}.dimensiondata.com/oec/0.9/", targetRegionName.ToLower()));
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all software labels for deployment by the
        ///     specified organisation.</summary>
        /// <param name="organizationId">The organisation Id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri SoftwareLabels(Guid organizationId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/softwarelabel", organizationId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of Multiple Geography Regions for deployment by the
        ///     specified organisation.</summary>
        /// <param name="organizationId">The organisation Id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri MultiGeographyRegions(Guid organizationId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/multigeo", organizationId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the
        ///     specified organisation.</summary>
        /// <param name="organizationId">The organisation Id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri DatacentersWithDiskSpeedDetails(Guid organizationId)
        {
            if (organizationId == Guid.Empty)
                throw new ArgumentException("GUID cannot be empty: 'organizationId'.", "organizationId");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/datacenterWithDiskSpeed", organizationId), UriKind.Relative);
        }

        /// <summary>The network domains.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri NetworkDomains(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/networkDomain", orgId), UriKind.Relative);
        }

        /// <summary>The network domain.</summary>
        /// <param name="orgId">The org id.</param>
        /// <param name="networkDomainId">The network Domain Id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri NetworkDomain(Guid orgId, Guid networkDomainId)
        {
            return new Uri(
                string.Format(MCP2_3_PREFIX + "{0}/network/networkDomain/{1}", orgId, networkDomainId), 
                UriKind.Relative);
        }

        /// <summary>	Adds a NIC to a server </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri AddNic(Guid orgId)
        {
            return new Uri(
                String.Format(MCP2_3_PREFIX + "{0}/server/addNic", orgId), UriKind.Relative);
        }

        /// <summary>	Removes a NIC from a server </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri RemoveNic(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/removeNic", orgId), UriKind.Relative);
        }


        /// <summary>	Lists Nics under a VLAN </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <param name="vlanId">The VLAN Id</param>
        /// <returns>	An URI. </returns>
        public static Uri ListNics(Guid orgId, Guid vlanId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/nic?vlanId={1}", orgId, vlanId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for Botify NIC IP change.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri NotifyNicIpChange(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/notifyNicIpChange", orgId), UriKind.Relative);
        }

        /// <summary>	Get the URI for creating a network domain. </summary>
        /// <param name="orgId">	The org id. </param>
        /// <returns>	The <see cref="Uri"/>. </returns>
        public static Uri CreateNetworkDomain(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deployNetworkDomain", orgId), UriKind.Relative);
        }

        /// <summary>The modify network domain.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ModifyNetworkDomain(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/editNetworkDomain", orgId), UriKind.Relative);
        }

        /// <summary>	Deletes the network domain described by orgId. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteNetworkDomain(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deleteNetworkDomain", orgId), UriKind.Relative);
        }

        /// <summary>Deploy server on network domains url.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeployServerOnNetworkDomain(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/deployServer", orgId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.</summary>
        /// <param name="orgId">The organisation Id</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri DataCentres(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/infrastructure/datacenter", orgId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.</summary>
        /// <param name="orgId">The organisation Id</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri DatacentresWithMaintanence(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/datacenterWithMaintenanceStatus", orgId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.</summary>
        /// <param name="orgId">The organisation Id</param>
        /// <param name="locationId">The location id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri DatacentreWithMaintanence(Guid orgId, string locationId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/datacenterWithMaintenanceStatus?location={1}", orgId, locationId), UriKind.Relative);
        }

        /// <summary>Get the relative URI for the CaaS API action that retrieves a list of all system-defined images deployed in the
        ///     specified data centre.</summary>
        /// <param name="locationName">The data centre location name.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri ImagesWithSoftwareLabels(string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.", 
                    "locationName");

            return new Uri(string.Format(MCP1_0_PREFIX + "base/image/deployedWithSoftwareLabels/{0}", locationName), UriKind.Relative);
        }


        /// <summary>Gets the relative URI for the CaaS API action that retrieves a filtered list of server images or servers.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="imagetype">The imagetype.</param>
        /// <param name="imageId">The image Id.</param>
        /// <param name="name">The server name</param>
        /// <param name="location">The server location</param>
        /// <param name="operatingSystemId">The operating System Id.</param>
        /// <param name="operatingSystemFamily">The operating System Family.</param>
        /// <returns>A list of deployed servers</returns>
        public static Uri ImagesWithDiskSpeed(
            Guid orgId, 
            ServerImageType imagetype, 
            string imageId, 
            string name, 
            string location, 
            string operatingSystemId, 
            string operatingSystemFamily)
        {
            string uri = MCP1_0_PREFIX + "base/imageWithDiskSpeed";
            if (imagetype == ServerImageType.CUSTOMER)
            {
                uri = string.Format(MCP1_0_PREFIX + "/{0}/imageWithDiskSpeed", orgId);
            }

            // build que query string paramenters
            var querystringcollection = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                querystringcollection.Add(name.Contains("*") ? "name.LIKE" : "name", name);
            if (!string.IsNullOrEmpty(imageId))
                querystringcollection.Add("id", imageId);
            if (!string.IsNullOrEmpty(location))
                querystringcollection.Add("location", location);
            if (!string.IsNullOrEmpty(operatingSystemId))
                querystringcollection.Add("operatingSystemId", operatingSystemId);
            if (!string.IsNullOrEmpty(operatingSystemFamily))
                querystringcollection.Add("operatingSystemFamily", operatingSystemFamily);

            if (querystringcollection.Keys.Any())
                uri = string.Concat(uri, "?");

            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(uri, UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that delete a customer image.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="imageId">The customer image id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri RemoveCustomerServerImage(Guid orgId, string imageId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/image/{1}?delete", orgId, imageId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that clean a failed customer image.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="imageId">The customer image id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CleanFailedCustomerServerImage(Guid orgId, string imageId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/image/{1}?clean", orgId, imageId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that copies customer source image.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CopyCustomerServerImage(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/copyCustomerImage", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a filtered list of deployed servers.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>A list of deployed servers</returns>
        public static Uri DeployedServers(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/serverWithBackup", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a filtered list of deployed servers.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server Id.</param>
        /// <param name="name">The server name</param>
        /// <param name="networkId">The server networkid</param>
        /// <param name="location">The server location</param>
        /// <returns>A list of deployed servers</returns>
        public static Uri DeployedServers(Guid orgId, string serverId, string name, string networkId, string location)
        {
            string uri = MCP1_0_PREFIX + "{0}/serverWithBackup";

            // build que query string paramenters
            var querystringcollection = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                querystringcollection.Add("name", name);
            if (!string.IsNullOrEmpty(serverId))
                querystringcollection.Add("id", serverId);
            if (!string.IsNullOrEmpty(networkId))
                querystringcollection.Add("networkid", networkId);
            if (!string.IsNullOrEmpty(location))
                querystringcollection.Add("location", location);

            if (querystringcollection.Keys.Any())
                uri = string.Concat(uri, "?");

            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a list of customer images with software labels</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkLocation">The network location id</param>
        /// <returns>A list of OS server images</returns>
        public static Uri CustomerImagesWithSoftwareLabels(Guid orgId, string networkLocation)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/image/deployedWithSoftwareLabels/{1}", orgId, networkLocation), 
                UriKind.Relative);
        }

        /// <summary>	(This method is obsolete) deploy server. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        [Obsolete("This Uri is deprecated, please use DeployServerWithDiskSpeed instead.")]
        public static Uri DeployServer(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server", orgId), UriKind.Relative);
        }

        /// <summary>	Deploy server with disk speed. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeployServerWithDiskSpeed(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/deployServer", orgId), UriKind.Relative);
        }


        /// <summary>Modify the server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a modify servers</returns>
        public static Uri ModifyServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}", orgId, serverId), UriKind.Relative);
        }

		/// <summary>Edit server metadata.</summary>
		/// <param name="orgId">The organization id</param>
		/// <returns>Returns the relative URI of the REST request for a Edit server metadata</returns>
		public static Uri EditServerMetadata(Guid orgId)
		{
			return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/editServerMetadata", orgId), UriKind.Relative);
		}

		/// <summary>Deletes the server.
		/// <remarks>
		/// The Server must be stopped before it can be deleted</remarks>
		/// </summary>
		/// <param name="orgId">The organization id</param>
		/// <param name="serverId">The server id</param>
		/// <returns>Returns the relative URI of the REST request for a deletion of the server</returns>
		public static Uri DeleteServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?delete", orgId, serverId), UriKind.Relative);
        }

        /// <summary>A “graceful” stop of a server by initiating a shutdown sequence within the guest operating system.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a graceful shutdown of the server</returns>
        public static Uri ShutdownServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?shutdown", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Powers on an existing deployed server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for starting the server</returns>
        public static Uri PowerOnServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?start", orgId, serverId), UriKind.Relative);
        }

        /// <summary>An abrupt power off of the server. Success is guarenteed</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for powering off the server</returns>
        public static Uri PoweroffMcp1Server(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?poweroff", orgId, serverId), UriKind.Relative);
        }

        /// <summary>A "graceful" reboot of the server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        public static Uri RebootServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?reboot", orgId, serverId), UriKind.Relative);
        }

        /// <summary>	Resets the server (hard reset). </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <param name="serverId">	The server Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri ResetServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?reset", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Triggers an update of the VMware Tools software running on the guest OS of a virtual server</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        public static Uri UpdateServerVMwareTools(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?updateVMwareTools", orgId, serverId), UriKind.Relative);
        }


        /// <summary>Initiates a clone of a server to create a Customer Image</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="imageName">The image Name.</param>
        /// <param name="imageDesc">The image Desc.</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        public static Uri CloneServerToCustomerImage(Guid orgId, string serverId, string imageName, string imageDesc)
        {
            Uri uri;
            if (string.IsNullOrEmpty(imageDesc))
                uri = new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?clone={2}", orgId, serverId, imageName), UriKind.Relative);
            else
                uri = new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?clone={2}&desc={3}", orgId, serverId, imageName, imageDesc), 
                    UriKind.Relative);
            return uri;
        }

        /// <summary>Change server disk speed</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="diskId">The disk id</param>
        /// <returns>Returns the relative URI of the REST request for change server disk size the server</returns>
        public static Uri ChangeServerDiskSpeed(Guid orgId, string serverId, string diskId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}/changeSpeed", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>Change server disk size</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="diskId">The disk id</param>
        /// <returns>Returns the relative URI of the REST request for change server disk size the server</returns>
        public static Uri ChangeServerDiskSize(Guid orgId, string serverId, string diskId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}/changeSize", orgId, serverId, diskId), UriKind.Relative);
        }

        /// <summary>Adds a additional disk to a CaaS server</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="size">The size of the new disk</param>
        /// <param name="speedId">The speed of the new disk</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AddServerDisk(Guid orgId, string serverId, string size, string speedId)
        {
            string uri = MCP1_0_PREFIX + "{0}/server/{1}?addLocalStorage&";
            var querystringcollection = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(size))
                querystringcollection.Add("amount", size);
            if (!string.IsNullOrEmpty(speedId))
                querystringcollection.Add("speed", speedId);

            // build the query string with parameters
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId, serverId), UriKind.Relative);
        }

        /// <summary>The relative URI for the CaaS API action that deletes a server disk</summary>
        /// <param name="orgId">The organisation id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="diskId">The disk id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri RemoveServerDisk(Guid orgId, string serverId, string diskId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}?delete", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>The relative URI for the CaaS API action that creates a anti affinity rule</summary>
        /// <param name="orgId">The organisation id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateAntiAffinityRule(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/antiAffinityRule", orgId), UriKind.Relative);
        }

        /// <summary>The relative URI for the CaaS API action that deletes a anti affinity rule</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="ruleId">The anti affinity rule id</param>
        /// <param name="location">The location</param>
        /// <param name="networkId">The network id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetAntiAffinityRule(Guid orgId, string ruleId, string location, string networkId)
        {
            string uri = MCP1_0_PREFIX + "{0}/antiAffinityRule";

            // build que query string paramenters
            var querystringcollection = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(ruleId))
                querystringcollection.Add("id", ruleId);
            if (!string.IsNullOrEmpty(networkId))
                querystringcollection.Add("networkid", networkId);
            if (!string.IsNullOrEmpty(location))
                querystringcollection.Add("location", location);

            if (querystringcollection.Keys.Any())
                uri = string.Concat(uri, "?");

            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId), UriKind.Relative);
        }

        /// <summary>	Removes the anti affinity rule. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <param name="ruleId">	The anti affinity rule id. </param>
        /// <returns>	An URI. </returns>
        public static Uri RemoveAntiAffinityRule(Guid orgId, string ruleId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/antiAffinityRule/{1}?delete", orgId, ruleId), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 servers. </summary>
        /// <remarks>	Anthony, 6/17/2015. </remarks>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	The MCP 2 servers. </returns>
        public static Uri GetMcp2Servers(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/server", orgId), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 server. </summary>
        /// <remarks>	Anthony, 6/17/2015. </remarks>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="serverId">	The server Id. </param>
        /// <returns>	The MCP 2 servers. </returns>
        public static Uri GetMcp2Server(Guid orgId, Guid serverId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/server/{1}", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Gets the list anti affinity rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetMcp2GetAntiAffinityRules(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/antiAffinityRule", orgId), UriKind.Relative);
        }

        /// <summary>Gets the list anti affinity rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="serverId">The server Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetMcp2GetAntiAffinityRulesForServer(Guid orgId, Guid serverId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/antiAffinityRule?serverId={1}", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Gets the list anti affinity rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="networkId">The network Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetMcp2GetAntiAffinityRulesForNetwork(Guid orgId, Guid networkId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/antiAffinityRule?networkId={1}", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Gets the list anti affinity rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="networkDomainId">The network domain Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetMcp2GetAntiAffinityRulesForNetworkDomain(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/antiAffinityRule?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        #region FirewallRule

        /// <summary>Gets the list firewall rules URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetFirewallRules(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/firewallRule", orgId), UriKind.Relative);
        }

        /// <summary>Gets the get firewall rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="firewallRuleId">The firewall rule Id.</param>
        /// <returns>The URL.</returns>
        public static Uri GetFirewallRule(Guid orgId, Guid firewallRuleId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/firewallRule/{1}", orgId, firewallRuleId), UriKind.Relative);
        }

        /// <summary>Gets the create firewall rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL.</returns>
        public static Uri CreateFirewallRule(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/createFirewallRule", orgId), UriKind.Relative);
        }

        /// <summary>Gets the edit firewall rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL.</returns>
        public static Uri EditFirewallRule(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/editFirewallRule", orgId), UriKind.Relative);
        }

        /// <summary>Gets the delete firewall rule URL.</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL.</returns>
        public static Uri DeleteFirewallRule(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deleteFirewallRule", orgId), UriKind.Relative);
        }

        #endregion

        #region VLAN

        /// <summary>The get Virtual LAN.</summary>
        /// <param name="orgId">The org id.</param>
        /// <param name="id">The id.</param>
        /// <param name="vlanName">The  Virtual LAN name.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetVlan(Guid orgId, Guid id, string vlanName, Guid networkDomainId)
        {
            var queryParameters = new List<string>();
            if (id != Guid.Empty)
            {
                queryParameters.Add(string.Format("Id={0}", id));
            }
            if (!String.IsNullOrEmpty(vlanName))
            {
                queryParameters.Add(string.Format("Name={0}", vlanName));
            }
            if (networkDomainId != Guid.Empty)
            {
                queryParameters.Add(string.Format("networkDomainId={0}", networkDomainId));
            }

            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/vlan?{1}", orgId, String.Join("&", queryParameters)), UriKind.Relative);
        }

        /// <summary>	The get Virtual LAN. </summary>
        /// <param name="orgId">	The org id. </param>
        /// <param name="vlanId">	Identifier for the vlan. </param>
        /// <returns>	The <see cref="Uri"/>. </returns>
        public static Uri GetVlan(Guid orgId, Guid vlanId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/vlan/{1}", orgId, vlanId), UriKind.Relative);
        }

        /// <summary>	Gets vlan by organisation identifier. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	The vlan by organisation identifier. </returns>
        public static Uri GetVlanByOrgId(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/vlan", orgId), UriKind.Relative);
        }

        /// <summary>	The relative URI for the CaaS API for deploying the VLan. </summary>
        /// <param name="orgId">	The organization ID. </param>
        /// <returns>	A URI. </returns>
        public static Uri DeployVlan(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deployVlan", orgId), UriKind.Relative);
        }

        /// <summary>	The relative URI for the CaaS API for editing the VLan. </summary>
        /// <param name="orgId">	The organization ID. </param>
        /// <returns>	A URI. </returns>
        public static Uri EditVlan(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/editVlan", orgId), UriKind.Relative);
        }

        /// <summary>	The relative URI for the CaaS API for expanding the VLan. </summary>
        /// <param name="orgId">	The organization ID. </param>
        /// <returns>	A URI. </returns>
        public static Uri ExpandVlan(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/expandVlan", orgId), UriKind.Relative);
        }

        /// <summary>	Deletes the vlan described by orgId. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteVlan(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deleteVlan", orgId), UriKind.Relative);
        }

        #endregion

        #region Network API

        /// <summary>Lists the Networks deployed across all data center locations for the supplied organization.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for a list of networks</returns>
        public static Uri NetworkWithLocations(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>Lists the Networks deployed across all data center locations for the supplied organization.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="locationId">The identifier of the location to get the networks from.</param>
        /// <returns>Returns the relative URI of the REST request for a list of networks</returns>
        public static Uri NetworkWithLocation(Guid orgId, string locationId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/networkWithLocation/{1}", orgId, locationId), UriKind.Relative);
        }

        /// <summary>Create an ACL rule</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>Returns the relative URI of the REST request for creating an ACL rule</returns>
        public static Uri CreateAclRule(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Removes the ACL rule</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="aclId">The ACL rule id</param>
        /// <returns>Returns the relative URI of the REST request for removing an ACL rule</returns>
        public static Uri DeleteAclRule(Guid orgId, string networkId, string aclId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule/{2}?delete", orgId, networkId, aclId), UriKind.Relative);
        }

        /// <summary>Getting all the ACL rules in the network</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>Returns the relative URI of the REST request for getting ACL rules</returns>
        public static Uri GetAclRules(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Gets all the NAT rules for a specified network.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <returns>Returns the relative URI of the REST request for getting the NAT rules</returns>
        public static Uri GetNatRules(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Creates a new NAT rule.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <returns>Returns the relative URI of the REST request for creating a new NAT rule</returns>
        public static Uri CreateNatRule(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Deletes a specified NAT rule</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <param name="natRuleId">The NAT rule id to delete</param>
        /// <returns>Returns the relative URI of the REST request for deleting an existing NAT rule</returns>
        public static Uri DeleteNatRule(Guid orgId, string networkId, string natRuleId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule/{2}?delete", orgId, networkId, natRuleId), 
                UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that creates a network in a specified data centre location.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for creating a network.</returns>
        public static Uri CreateNetwork(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>	Deletes the network. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteNetwork(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}?delete", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Modify network. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	An URI. </returns>
        public static Uri ModifyNetwork(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Gets network configuration. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The network configuration. </returns>
        public static Uri GetNetworkConfig(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/config", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Reserve network public IP address block. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	An URI. </returns>
        public static Uri ReserveNetworkPublicIpAddressBlock(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip?reserveNewWithSize", orgId, networkId), UriKind.Relative);
        }

        /// <summary>Release public ip address block</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="ipBlockId">The block id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ReleaseNetworkPublicIpAddressBlock(Guid orgId, string networkId, string ipBlockId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip/{2}?release ", orgId, networkId, ipBlockId), UriKind.Relative);
        }

        /// <summary>Set server to vip ip address block setting</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="ipBlockId">The block id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri SetServerToVipNetworkPublicIpAddressBlock(Guid orgId, string networkId, string ipBlockId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip/{2} ", orgId, networkId, ipBlockId), UriKind.Relative);
        }

        /// <summary>Set multicast on network setting</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri SetNetworkMulticast(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/multicast ", orgId, networkId), UriKind.Relative);
        }

        #endregion // Network API

        #region Backup URIs

        /// <summary>Enables the Backup service for a deployed Server. Requires the Organization ID, Server ID and the Service Plan
        ///     being enabled.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for enabling the backup on the server</returns>
        public static Uri EnableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Disables the Backup service for a deployed server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for disabling the backup on the server</returns>
        public static Uri DisableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup?disable", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Modify the backup service plan for a deployed server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for modifying the backup service pland of the server</returns>
        public static Uri ChangeBackupPlan(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}/backup/modify", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Backup client types associated with a specific server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the client types for the server</returns>
        public static Uri BackupClientTypes(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/type", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Backup storage policies associated with a specific server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the storage policies for the server</returns>
        public static Uri BackupStoragePolicies(Guid orgId, string serverId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/storagePolicy", orgId, serverId), 
                UriKind.Relative);
        }

        /// <summary>Backup schedule policies associated with a specific server.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the schedule policies for the server</returns>
        public static Uri BackupSchedulePolicies(Guid orgId, string serverId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/schedulePolicy", orgId, serverId), 
                UriKind.Relative);
        }

        /// <summary>Retrieves complete details of how the Backup service is configured for a specific deployed Server.
        ///     Requires the Organization ID and Server ID for the Server and that the Server already has the Backup service
        ///     enabled.
        ///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for getting the backup details of the server</returns>
        public static Uri GetBackupDetails(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Provisions a new Backup Client for a deployed Server.
        ///     Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service
        ///     enabled.
        ///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for adding a backup client to the server</returns>
        public static Uri AddBackupClient(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Removes a Backup Client for the Backup service on a deployed Server. Requires the Organization ID, 
        ///     Server ID and Backup Client ID for the relevant Backup Client and Server and that the Server already has
        ///     the Backup service enabled. The user must be the Primary Administrator or a Sub-Administrator with the “backup”
        ///     role.
        ///     Note that the Backup Client ID is available from the backupClient.id additionalInformation element in the
        ///     response received when the Backup Client was originally added. See Add Backup Client for details.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id to remove</param>
        /// <returns>Returns the relative URI of the REST request for removing a backup client from the server</returns>
        public static Uri RemoveBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?remove", orgId, serverId, backupClientId), 
                UriKind.Relative);
        }

        /// <summary>	Restore backup. </summary>
        /// <param name="orgId">		 	The org Id. </param>
        /// <param name="serverId">		 	The server Id. </param>
        /// <param name="backupClientId">	The backup client id restore. </param>
        /// <returns>	An URI. </returns>
        public static Uri RestoreBackup(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}/restore", orgId, serverId, backupClientId), 
                UriKind.Relative);
        }

        /// <summary>Modifies the settings of an existing Backup Client for a deployed Server.
        ///     Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service
        ///     enabled.
        ///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role.
        /// <remarks>
        /// Note that the Backup Client type cannot be changed.</remarks>
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id to modify</param>
        /// <returns>Returns the relative URI of the REST request for modifying a backup client for the server</returns>
        public static Uri ModifyBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}/modify", orgId, serverId, backupClientId), 
                UriKind.Relative);
        }

        /// <summary>Requests an immediate Backup for a Backup Client</summary>
        /// <param name="organizationId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id</param>
        /// <returns>Returns the relative URI of the REST request for initiating a backup on the client</returns>
        public static Uri InitiateBackup(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?backupNow", organizationId, serverId, backupClientId), 
                UriKind.Relative);
        }

        /// <summary>Requests a cancellation of all running jobs for a backup client</summary>
        /// <param name="organizationId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id</param>
        /// <returns>Returns the relative URI of the REST request for cancelling backup jobs on the client</returns>
        public static Uri CancelBackupJobs(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?cancelJob", organizationId, serverId, backupClientId), 
                UriKind.Relative);
        }

        #endregion // Backup URIs

        #region Import and Export Customer Image API

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a list of OVF Packages</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for getting the OVF Packages</returns>
        public static Uri GetOvfPackages(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/ovfPackage", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that POST a request to import a customer image</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for importing a customer image</returns>
        public static Uri ImportCustomerImage(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageImport", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that copy an OVF package from a remote geo.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI.</returns>
        public static Uri RemoteOvfPackageCopy(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/remoteOvfPackageCopy", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action to get the OVF package copies in progress.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI.</returns>
        public static Uri GetRemoteOvfPackageCopyInProgress(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/remoteOvfPackageCopy", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action to get the OVF package copy history.</summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="count">The maximum number of items to return.</param>
        /// <returns>Returns the relative URI.</returns>
        public static Uri GetRemoteOvfPackageCopyHistory(Guid orgId, int count)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/remoteOvfPackageCopyHistory?pageSize={1}&orderBy=startDate.DESCENDING", orgId, count), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that POST a request to export a customer image</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for exporting a customer image</returns>
        public static Uri ExportCustomerImage(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExport", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a list of customer image imports in progress.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>A list of customer image imports in progress</returns>
        public static Uri GetCustomerImageImports(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/imageImport", orgId), UriKind.Relative);
        }

        /// <summary>Gets the relative URI for the CaaS API action that retrieves a list of customer image exports in progress.</summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>A list of customer image exports in progress</returns>
        public static Uri GetCustomerImageExports(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExport", orgId), UriKind.Relative);
        }

        /// <summary>Gets the customer image export history.</summary>
        /// <param name="organizationId">The organization identifier.</param>
        /// <param name="count">The number of results to return.</param>
        /// <returns>The URI for the API.</returns>
        public static Uri GetCustomerImageExportHistory(Guid organizationId, int count = 20)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExportHistory?count=", organizationId, count), UriKind.Relative);
        }

        #endregion

        #region VIP

        /// <summary>The relative URI for the CaaS API action that list or creates VIP real servers</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateOrGetVipRealServers(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer", orgId, networkId), UriKind.Relative);
        }


        /// <summary>The relative URI for the CaaS API action that deletes VIP real servers</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="rServerId">The real server id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteVipRealServers(Guid orgId, string networkId, string rServerId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer/{2}?delete", orgId, networkId, rServerId), UriKind.Relative);
        }

        /// <summary>The relative URI for the CaaS API action that deletes VIP real servers</summary>
        /// <param name="orgId">The org id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="rServerId">The real server id</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ModifyVipRealServers(Guid orgId, string networkId, string rServerId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer/{2}", orgId, networkId, rServerId), UriKind.Relative);
        }

        /// <summary>	Creates or get vip probes. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The new or get vip probes. </returns>
        public static Uri CreateOrGetVipProbes(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/probe", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	The relative URI for the CaaS API action that deletes VIP probes. </summary>
        /// <param name="orgId">		The org id. </param>
        /// <param name="networkId">	The network id. </param>
        /// <param name="probeId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteVipProbes(Guid orgId, string networkId, string probeId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/probe/{2}?delete", orgId, networkId, probeId), UriKind.Relative);
        }

        /// <summary>	Modify vip probes. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="probeId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri ModifyVipProbes(Guid orgId, string networkId, string probeId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/probe/{2}", orgId, networkId, probeId), UriKind.Relative);
        }

        /// <summary>	Creates or get vip server farm. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The new or get vip server farm. </returns>
        public static Uri CreateOrGetVipServerFarm(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/serverFarm", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Deletes the vip server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteVipServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}?delete", orgId, networkId, serverFarmId), 
                UriKind.Relative);
        }

        /// <summary>	Gets vip server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	The vip server farm. </returns>
        public static Uri GetVipServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}", orgId, networkId, serverFarmId), UriKind.Relative);
        }

        /// <summary>	Adds a vip real server to server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri AddVipRealServerToServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/addRealServer", orgId, networkId, serverFarmId), 
                UriKind.Relative);
        }

        /// <summary>	Removes the vip real server from server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri RemoveVipRealServerFromServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/removeRealServer", orgId, networkId, serverFarmId), 
                UriKind.Relative);
        }

        /// <summary>	Adds a vip probe to server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri AddVipProbeToServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/addProbe", orgId, networkId, serverFarmId), 
                UriKind.Relative);
        }

        /// <summary>	Removes the vip probe from server farm. </summary>
        /// <param name="orgId">	   	The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="serverFarmId">	The probe id. </param>
        /// <returns>	An URI. </returns>
        public static Uri RemoveVipProbeFromServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/serverFarm/{2}/removeProbe", orgId, networkId, serverFarmId), 
                UriKind.Relative);
        }

        /// <summary>	Creates or get vip persistence profile. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The new or get vip persistence profile. </returns>
        public static Uri CreateOrGetVipPersistenceProfile(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/persistenceProfile", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Deletes the vip persistence profile. </summary>
        /// <param name="orgId">			The org Id. </param>
        /// <param name="networkId">		The server networkid. </param>
        /// <param name="persProfileId">	Identifier for the pers profile. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteVipPersistenceProfile(Guid orgId, string networkId, string persProfileId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/persistenceProfile/{2}?delete", orgId, networkId, persProfileId), 
                UriKind.Relative);
        }

        /// <summary>	Creates or get vip. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The new or get vip. </returns>
        public static Uri CreateOrGetVip(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Deletes the vip. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="vipId">		The vip id. </param>
        /// <returns>	An URI. </returns>
        public static Uri DeleteVip(Guid orgId, string networkId, string vipId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip/{2}?delete", orgId, networkId, vipId), UriKind.Relative);
        }

        /// <summary>	Modify vip. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <param name="vipId">		The vip id. </param>
        /// <returns>	An URI. </returns>
        public static Uri ModifyVip(Guid orgId, string networkId, string vipId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip/{2}", orgId, networkId, vipId), UriKind.Relative);
        }

        #endregion

        #region Server Monitoring

        /// <summary>Gets the URL to enable server monitoring</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL</returns>
        public static Uri EnableServerMonitoring(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/enableServerMonitoring", orgId), UriKind.Relative);
        }

        /// <summary>Gets the URL to change the server monitoring plan</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL</returns>
        public static Uri ChangeServerMonitoringPlan(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/changeServerMonitoringPlan", orgId), UriKind.Relative);
        }

        /// <summary>Gets the URL to disable server monitoring</summary>
        /// <param name="orgId">The org Id.</param>
        /// <returns>The URL</returns>
        public static Uri DisableServerMonitoring(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/disableServerMonitoring", orgId), UriKind.Relative);
        }

        /// <summary>Gets the URL to retrieve server monitoring usage report</summary>
        /// <param name="orgId">The org Id.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The URL</returns>
        public static Uri GetMonitoringUsageReport(Guid orgId, DateTime startDate, DateTime? endDate)
        {
            var url = string.Format(MCP2_3_PREFIX + "{0}/report/usageMonitoring?startDate={1}", orgId, startDate.ToString("yyyy-MM-dd"));

            if (endDate.HasValue)
            {
                url += string.Format("&endDate={0}", endDate.Value.ToString("yyyy-MM-dd"));
            }

            return new Uri(url, UriKind.Relative);
        }

        #endregion

        /// <summary>	Adds a public IP block. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri AddPublicIpBlock(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/addPublicIpBlock", orgId), UriKind.Relative);
        }

        /// <summary>	Gets public IP blocks. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <param name="networkDomainId">	The network Domain Id. </param>
        /// /// 
        /// <returns>	The public IP blocks. </returns>
        public static Uri GetPublicIpBlocks(Guid orgId, string networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/publicIpBlock?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>	Gets public IP block. </summary>
        /// <param name="orgId">		  	The org Id. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The public IP block. </returns>
        public static Uri GetPublicIpBlock(Guid orgId, string publicIpBlockId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/publicIpBlock/{1}", orgId, publicIpBlockId), UriKind.Relative);
        }

        /// <summary>	Gets reserved public addresses. </summary>
        /// <param name="orgId">		  	The org Id. </param>
        /// <param name="networkDomainId">	The network Domain Id. </param>
        /// <returns>	The reserved public addresses. </returns>
        public static Uri GetReservedPublicAddresses(Guid orgId, string networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservedPublicIpv4Address?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>	Gets reserved public addresses for network. </summary>
        /// <param name="orgId">		The org Id. </param>
        /// <param name="networkId">	The server networkid. </param>
        /// <returns>	The reserved public addresses for network. </returns>
        public static Uri GetReservedPublicAddressesForNetwork(Guid orgId, string networkId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservedPublicIpv4Address?networkId={1}", orgId, networkId), UriKind.Relative);
        }

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <param name="vlanId">	The VLAN Id. </param>
        /// <returns>	The reserved public addresses. </returns>
        public static Uri GetReservedPrivateAddresses(Guid orgId, string vlanId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservedPrivateIpv4Address?vlanId={1}", orgId, vlanId), UriKind.Relative);
        }

        /// <summary>	Deletes the server. </summary>
        /// <param name="orgId">	The organization id. </param>
        /// <returns>	Returns the relative URI of the REST request for a deletion of the server. </returns>
        public static Uri DeleteServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/deleteServer", orgId), UriKind.Relative);
        }

        /// <summary>	Starts a server. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri StartServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/startServer", orgId), UriKind.Relative);
        }

        /// <summary>	Resets the server (hard reset). </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri ResetServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/resetServer", orgId), UriKind.Relative);
        }

        /// <summary>	A "graceful" reboot of the server. </summary>
        /// <param name="orgId">	The organization id. </param>
        /// <returns>	Returns the relative URI of the REST request for rebooting the server. </returns>
        public static Uri RebootServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/rebootServer", orgId), UriKind.Relative);
        }

        /// <summary>	A “graceful” stop of a server by initiating a shutdown sequence within the guest
        /// 	operating system.</summary>
        /// <param name="orgId">	The organization id. </param>
        /// <returns>	Returns the relative URI of the REST request for a graceful shutdown of the server.</returns>
        public static Uri ShutdownServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/shutdownServer", orgId), UriKind.Relative);
        }

        /// <summary>	Power off server. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri PowerOffServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/powerOffServer", orgId), UriKind.Relative);
        }

        /// <summary>	Updates the vmware tools described by orgId. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri UpdateVmwareTools(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/updateVmwareTools", orgId), UriKind.Relative);
        }

        /// <summary>	upgrade virtual hardware for the server. </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI. </returns>
        public static Uri UpgradeVirtualHardware(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/upgradeVirtualHardware", orgId), UriKind.Relative);
        }

        /// <summary>Gets all the NAT rules for a specified network.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network id.</param>
        /// <returns>Returns the relative URI of the REST request for getting the NAT rules</returns>
        public static Uri GetDomainNatRules(Guid orgId, string networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/natRule?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>Deletes a NAT Rule. </summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="natRuleId">The NAT Rule id to be deleted.</param>
        /// <returns>Returns the relative URI of the REST request for getting the NAT rule.</returns>
        public static Uri GetNatRule(Guid orgId, string natRuleId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/natRule/{1}", orgId, natRuleId), UriKind.Relative);
        }

        /// <summary>Creates a NAT Rule on a Network Domain in an MCP 2.0 data center location.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>Returns the relative URI of the REST request for creating the NAT rule.</returns>
        public static Uri CreateNatRule(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/createNatRule", orgId), UriKind.Relative);
        }

        /// <summary>Deletes a NAT Rule. </summary>
        /// <param name="orgId">The NAT Rule.</param>
        /// <returns>Returns the relative URI of the REST request for deleting the NAT rule.</returns>
        public static Uri DeleteNatRule(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deleteNatRule", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for creating the Pool.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreatePool(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/createPool", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Pools.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetPools(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/pool", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Single Pool details.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="poolId">The Pool id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetPool(Guid orgId, Guid poolId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/pool/{1}", orgId, poolId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for updating the Pool.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditPool(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/editPool", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for deleting the Pool.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeletePool(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/deletePool", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for creating the Pool Member.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AddPoolMember(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/addPoolMember", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Pool Members.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetPoolMembers(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/poolMember", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Single Pool Member details.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="poolMemberId">The Pool Member id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetPoolMember(Guid orgId, Guid poolMemberId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/poolMember/{1}", orgId, poolMemberId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for updating the Pool Member.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditPoolMember(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/editPoolMember", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for deleting the Pool Member.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeletePoolMember(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/removePoolMember", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for creating the VIP Node.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AddVipNode(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/createNode", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the VIP Nodes.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetVipNodes(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/node", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Single VIP Node details.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="vipNodeId">The VIP Node id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetVipNode(Guid orgId, Guid vipNodeId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/node/{1}", orgId, vipNodeId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for updating the VIP Node.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditVipNode(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/editNode", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for deleting the VIP Node.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteVipNode(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/deleteNode", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for creating the Virtual Listener.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateVirtualListener(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/createVirtualListener", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Virtual Listeners.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetVirtualListeners(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/virtualListener", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for getting the Single Virtual Listener details.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="virtualListenerId">The Virtual Listener id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetVirtualListener(Guid orgId, Guid virtualListenerId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/virtualListener/{1}", orgId, virtualListenerId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for updating the Virtual Listener.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditVirtualListener(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/editVirtualListener", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for deleting the Virtual Listener.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteVirtualListener(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/deleteVirtualListener", orgId), UriKind.Relative);
        }

        /// <summary>Returns the get default health monitor URL.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetDefaultHealthMonitors(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/defaultHealthMonitor?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>Returns the get default persistence profile URL.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetDefaultPersistenceProfile(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/defaultPersistenceProfile?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>Returns the get default iRule URL.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetDefaultIrule(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/networkDomainVip/defaultIrule?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for notify private IP address change.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="serverId">The Server Id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri NotifyPrivateIpChange(Guid orgId, string serverId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for removing a Public IPv4 Address Block from a Network Domain.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri RemovePublicIpv4AddressBlock(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/removePublicIpBlock", orgId), UriKind.Relative);
        }

        /// <summary>	Deploy server via MCP 2.0 api </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI for the mcp2.0 deploy server api. </returns>
        public static Uri DeployMCP20Server(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/deployServer", orgId), UriKind.Relative);
        }

        /// <summary>	Clean server via MCP 2.0 api </summary>
        /// <param name="orgId">	The org Id. </param>
        /// <returns>	An URI for the mcp2.0 clean server api. </returns>
        public static Uri CleanServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/cleanServer", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for usage summary.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri SummaryUsageReport(Guid orgId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/report/usage?startDate={1:yyyy-MM-dd}&endDate={2:yyyy-MM-dd}", orgId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for detailed usage.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DetailedUsageReport(Guid orgId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/report/usageDetailed?startDate={1:yyyy-MM-dd}&endDate={2:yyyy-MM-dd}", orgId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for software units usage report.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri SoftwareUnitsReport(Guid orgId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/report/usageSoftwareUnits?startDate={1:yyyy-MM-dd}&endDate={2:yyyy-MM-dd}", orgId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for backup usage report.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="datacenterId">The datacenter Id</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri BackupUsageReport(Guid orgId, string datacenterId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/backup/detailedUsageReport?datacenterId={1}&fromDate={2:yyyy-MM-dd}&toDate={3:yyyy-MM-dd}", orgId, datacenterId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for administrator logs report.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AdminLogReport(Guid orgId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/auditlog?startDate={1:yyyy-MM-dd}&endDate={2:yyyy-MM-dd}", orgId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for DRS Server Pairs usage report.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DrsPairsUsageReport(Guid orgId, DateTime startDate, DateTime endDate)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/report/usageDrsPairs?startDate={1:yyyy-MM-dd}&endDate={2:yyyy-MM-dd}", orgId, startDate, endDate), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 os images. </summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	The MCP 2 images. </returns>
        public static Uri GetMcp2OsImages(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/image/osImage", orgId), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 os images. </summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="imageId">	The image Id. </param>
        /// <returns>	The MCP 2 images. </returns>
        public static Uri GetMcp2OsImage(Guid orgId, Guid imageId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/image/osImage/{1}", orgId, imageId), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 customer images. </summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	The MCP 2 images. </returns>
        public static Uri GetMcp2CustomerImages(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/image/customerImage", orgId), UriKind.Relative);
        }

        /// <summary>	Gets MCP 2 customer image. </summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="imageId">	The image Id. </param>
        /// <returns>	The MCP 2 images. </returns>
        public static Uri GetMcp2CustomerImage(Guid orgId, Guid imageId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/image/customerImage/{1}", orgId, imageId), UriKind.Relative);
        }

        /// <summary>	Edit MCP 2 customer image metadata </summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri EditMcp2CustomerImageMetadata(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/image/editImageMetadata", orgId), UriKind.Relative);
        }

        /// <summary>	Get MCP 2 operating systems</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="dataCenterId">	The data center Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri GetMcp2OperatingSystems(Guid orgId, string dataCenterId)
        {
            return
                new Uri(
                    string.Format(MCP2_3_PREFIX + "{0}/infrastructure/operatingSystem?datacenterId={1}", orgId, 
                        dataCenterId), UriKind.Relative);
        }

        /// <summary>	Create security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri CreateSecurityGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/createSecurityGroup", orgId), UriKind.Relative);
        }

        /// <summary>	Edit security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri EditSecurityGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/editSecurityGroup", orgId), UriKind.Relative);
        }

        /// <summary>	Delete security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri DeleteSecurityGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/deleteSecurityGroup", orgId), UriKind.Relative);
        }

        /// <summary>	Add nic to security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri AddNicToSecurityGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/addNicToSecurityGroup", orgId), UriKind.Relative);
        }

        /// <summary>	Remove Nic from security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <returns>	Url endpoint </returns>
        public static Uri RemoveNicFromSecurityGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/removeNicFromSecurityGroup", orgId), UriKind.Relative);
        }

        /// <summary>	Get security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="vlanId">VLan Id</param>
        /// <returns>	Url endpoint </returns>
        public static Uri GetSecurityGroupForVlan(Guid orgId, Guid vlanId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/securityGroup?vlanId={1}", orgId, vlanId), 
                UriKind.Relative);
        }

        /// <summary>	Get security group</summary>
        /// <param name="orgId">	The organization Id. </param>
        /// <param name="serverId">Server Id</param>
        /// <returns>	Url endpoint </returns>
        public static Uri GetSecurityGroupForServer(Guid orgId, Guid serverId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/securityGroup/securityGroup?serverId={1}", orgId, serverId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for reconfiguring the server.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ReconfigureServer(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/reconfigureServer", orgId), UriKind.Relative);
        }

        /// <summary>Retrieves a list of compatible target Servers for an Out of Place given a specific deployed Server and Backup Client Type as input.</summary>
        /// <param name="organizationId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientType">The backup client id</param>
        /// <returns>Returns the relative URI of the REST request for initiating a backup on the client</returns>
        public static Uri ListofTargetServers(Guid organizationId, Guid serverId, string backupClientType)
        {
            return new Uri(
                string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}/systemRestoreTarget", organizationId, serverId.ToString(), backupClientType), 
                UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for two factor authentication status.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri TwoFactorAuthenicationStatus(Guid orgId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/twoFactorAuth", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for create ip address list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateIpAddressList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/createIpAddressList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for list ip address list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ListIpAddressList(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/ipAddressList?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }


        /// <summary>Returns the relative URI of the REST request for get ip address list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="ipAddressListId">The Ip address list id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetIpAddressList(Guid orgId, Guid ipAddressListId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/ipAddressList/{1}", orgId, ipAddressListId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for edit ip address list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditIpAddressList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/editIpAddressList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for delete ip address list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteIpAddressList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deleteIpAddressList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for create port list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreatePortList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/createPortList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for list port list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ListPortList(Guid orgId, Guid networkDomainId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/portList?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
        }


        /// <summary>Returns the relative URI of the REST request for get port list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="portListId">The Ip address list id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetPortList(Guid orgId, Guid portListId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/portList/{1}", orgId, portListId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for edit port list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditPortList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/editPortList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for delete port list.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeletePortList(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/deletePortList", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for adding disk to server.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri AddDisk(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/addDisk", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for removing disk from server.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri RemoveDisk(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/server/removeDisk", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for reserving private ip v4 address.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ReservePrivateIpv4Address(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservePrivateIpv4Address", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for unreserving private ip v4 address.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri UnreservePrivateIpv4Address(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/unreservePrivateIpv4Address", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for reserving ip v6 address.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ReserveIpv6Address(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reserveIpv6Address", orgId), UriKind.Relative);
        }

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetReservedIpv6Addresses(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservedIpv6Address", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for unreserving ip v6 address.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri UnreserveIpv6Address(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/unreserveIpv6Address", orgId), UriKind.Relative);
        }

        /// <summary>The get reserved private ipv 4 addresses.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetReservedPrivateIpv4Addresses(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/network/reservedPrivateIpv4Address", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for create tag key.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateTagKey(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/createTagKey", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for list tag key.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ListTagKeys(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/tagKey", orgId), UriKind.Relative);
        }


        /// <summary>Returns the relative URI of the REST request for get tag key.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="tagKeyId">The tag key id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetTagKey(Guid orgId, Guid tagKeyId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/tagKey/{1}", orgId, tagKeyId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for edit tag key.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri EditTagKey(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/editTagKey", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for delete tag key.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri DeleteTagKey(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/deleteTagKey", orgId), UriKind.Relative);
        }


        /// <summary>The apply tags.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri ApplyTags(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/applyTags", orgId), UriKind.Relative);
        }

        /// <summary>The get tags.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetTags(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/tag", orgId), UriKind.Relative);
        }

        /// <summary>The remove tag.</summary>
        /// <param name="orgId">The org id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri RemoveTag(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/tag/removeTags", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for get consistency groups.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri GetConsistencyGroups(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/consistencyGroup", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for create consistency groups.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri CreateConsistencyGroups(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/createConsistencyGroup", orgId), UriKind.Relative);
        }

		/// <summary>Returns the relative URI of the REST request for get consistency group snapshots.</summary>
		/// <param name="orgId">The organization id.</param>
		/// <returns>The <see cref="Uri"/>.</returns>
		public static Uri GetConsistencyGroupSnapshots(Guid orgId)
		{
			return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/snapshot", orgId), UriKind.Relative);
		}

        /// <summary>Returns the relative URI of the REST request for stop preview snapshot of a consistency group.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri StopPreviewSnapshot(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/stopPreviewSnapshot", orgId), UriKind.Relative);
        }

		/// <summary>Returns the relative URI of the REST request for start preview snapshot of a consistency group.</summary>
		/// <param name="orgId">The organization id.</param>
		/// <returns>The <see cref="Uri"/>.</returns>
		public static Uri StartPreviewSnapshot(Guid orgId)
		{
			return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/startPreviewSnapshot", orgId), UriKind.Relative);
		}

        /// <summary>Returns the relative URI of the REST request for delete consistency group.</summary>
		/// <param name="orgId">The organization id.</param>
		/// <returns>The <see cref="Uri"/>.</returns>
		public static Uri DeleteConsistencyGroup(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/deleteConsistencyGroup", orgId), UriKind.Relative);
        }

        /// <summary>Returns the relative URI of the REST request for initiate failover for a consistency group.</summary>
        /// <param name="orgId">The organization id.</param>
        /// <returns>The <see cref="Uri"/>.</returns>
        public static Uri InitiateFailover(Guid orgId)
        {
            return new Uri(string.Format(MCP2_3_PREFIX + "{0}/consistencyGroup/initiateFailover", orgId), UriKind.Relative);
        }
    }
}