using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CBU.Compute.Api.Client
{
    using System.Diagnostics.Contracts;

    /// <summary>
	/// Constants and formatters for API URLs.
    /// </summary>
    public static class ApiUris
    {
		/// <summary>	The MCP 1.0 prefix. </summary>
		public const string MCP1_0_PREFIX = "oec/0.9/";

		/// <summary>	The MCP 2.0 prefix. </summary>
		public const string MCP2_0_PREFIX = "caas/2.0/";

        /// <summary>
		/// The path (relative to the base API URL) of the My Account action.
        /// </summary>
        public static Uri MyAccount = new Uri(MCP1_0_PREFIX + "myaccount", UriKind.Relative);

        /// <summary>
        /// The path (relative to the base API URL) to list accounts action.
        /// </summary>
        /// <param name="orgId">
        /// The org Id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri Account(Guid orgId)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account", orgId), UriKind.Relative);
        }


        /// <summary>
        /// The path (relative to the base API URL) to list accounts action.
        /// </summary>
        /// <param name="orgId">
        /// The org Id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri AccountWithPhoneNumber(Guid orgId)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/accountWithPhoneNumber", orgId), UriKind.Relative);
        }

        /// <summary>
		/// The path (relative to the base API URL) to update My Account action.
        /// </summary>
		/// <param name="orgId">
		/// The org Id.
		/// </param>
		/// <param name="username">
		/// The username.
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
		public static Uri UpdateAdministrator(Guid orgId, string username)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}", orgId, username), UriKind.Relative);
        }


        /// <summary>
        /// The path (relative to the base API URL) to Account With Phone Number  action.
        /// </summary>
        /// <param name="orgId">
        /// The org Id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri AccountWithPhoneNumber(Guid orgId, string username)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/accountWithPhoneNumber/{1}", orgId, username), UriKind.Relative);
        }

        /// <summary>
        /// The path (relative to the base API URL) set primary administrator action.
        /// </summary>
        /// <param name="orgId">
        /// The org Id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri SetPrimaryAdministrator(Guid orgId, string username)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}?primary", orgId, username), UriKind.Relative);
        }

        /// <summary>
        /// The path (relative to the base API URL) delete sub administrator action.
        /// </summary>
        /// <param name="orgId">
        /// The org Id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri DeleteSubAdministrator(Guid orgId, string username)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/account/{1}?delete", orgId, username), UriKind.Relative);
        }


        /// <summary>
		/// Get the base URI for the CaaS REST API.
        /// </summary>
        /// <param name="targetRegionName">
		/// The target region's short name ("au", for example).
        /// </param>
        /// <returns>
		/// The base URI for the CaaS REST API.
        /// </returns>
        public static Uri ComputeBase(string targetRegionName)
        {
			if (string.IsNullOrWhiteSpace(targetRegionName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.",
                    "targetRegionName");

			return new Uri(string.Format("https://api-{0}.dimensiondata.com/oec/0.9/", targetRegionName.ToLower()));
        }
        /// <summary>
        /// Get the relative URI for the CaaS API action that retrieves a list of all software labels for deployment by the
        ///     specified organisation.
        /// </summary>
        /// <param name="organizationId">The organisation Id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri SoftwareLabels(Guid organizationId)
        {
          
           return new Uri(string.Format(MCP1_0_PREFIX + "{0}/softwarelabel", organizationId), UriKind.Relative);
        }

        /// <summary>
        /// Get the relative URI for the CaaS API action that retrieves a list of Multiple Geography Regions for deployment by the
        ///     specified organisation.
        /// </summary>
        /// <param name="organizationId">The organisation Id.</param>
        /// <returns>The relative action Uri.</returns>
        public static Uri MultiGeographyRegions(Guid organizationId)
        {
            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/multigeo", organizationId), UriKind.Relative);
           
        }

        /// <summary>
		/// Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the
		///     specified organisation.
        /// </summary>
        /// <param name="organizationId">
		/// The organisation Id.
        /// </param>
        /// <returns>
		/// The relative action Uri.
        /// </returns>
        public static Uri DatacentersWithDiskSpeedDetails(Guid organizationId)
        {
			if (organizationId == Guid.Empty)
				throw new ArgumentException("GUID cannot be empty: 'organizationId'.", "organizationId");

			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/datacenterWithDiskSpeed", organizationId), UriKind.Relative);
        }

        /// <summary>
		/// The network domains.
		/// </summary>
		/// <param name="orgId">
		/// The org id.
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
		public static Uri NetworkDomains(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/networkDomain", orgId), UriKind.Relative);
		}

        /// <summary>
        /// The network domains.
        /// </summary>
        /// <param name="orgId">
        /// The org id.
        /// </param>
        /// <param name="networkDomainId">
        /// The network Domain Id.
        /// </param>
        /// <param name="networkName">
        /// The network Name.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri NetworkDomain(Guid orgId, Guid networkDomainId, string networkName)
        {
            var queryParameters = new List<string>();
            if (networkDomainId != Guid.Empty)
            {
                queryParameters.Add(string.Format("Id={0}", networkDomainId));
            }
            if (!String.IsNullOrEmpty(networkName))
            {
                queryParameters.Add(string.Format("Name={0}", networkName));
            }
            return new Uri(
				string.Format(MCP2_0_PREFIX + "{0}/network/networkDomain?{1}", orgId, String.Join("&", queryParameters)),
                UriKind.Relative);
        }

	    /// <summary>	Adds a NIC to a server </summary>
	    /// <remarks>	Anthony, 4/24/2015. </remarks>
	    /// <param name="orgId">	The org Id. </param>
	    /// <returns>	An URI. </returns>
	    public static Uri AddNic(Guid orgId)
	    {
		    return new Uri(
				String.Format(MCP2_0_PREFIX + "{0}//server/addNic", orgId), UriKind.Relative);
	    }

		/// <summary>	Get the URI for creating a network domain. </summary>
		/// <param name="orgId">	The org id. </param>
		/// <returns>	The <see cref="Uri"/>. </returns>
		public static Uri CreateNetworkDomain(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/deployNetworkDomain", orgId), UriKind.Relative);
		}

		/// <summary>	Deletes the network domain described by orgId. </summary>
		/// <param name="orgId">	The org Id. </param>
		/// <returns>	An URI. </returns>
		public static Uri DeleteNetworkDomain(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/deleteNetworkDomain", orgId), UriKind.Relative);
		}

        /// <summary>
        /// Deploy server on network domains url.
        /// </summary>
        /// <param name="orgId">
        /// The org id.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        public static Uri DeployServerOnNetworkDomain(Guid orgId)
        {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/server/deployServer", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.
        /// </summary>
		/// <param name="orgId">
		/// The organisation Id
		/// </param>
		/// <returns>
		/// The relative action Uri.
		/// </returns>
        public static Uri DatacentresWithMaintanence(Guid orgId)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format(MCP1_0_PREFIX + "{0}/datacenterWithMaintenanceStatus", orgId), UriKind.Relative);
        }

        /// <summary>
		/// Get the relative URI for the CaaS API action that retrieves a list of all system-defined images deployed in the
		///     specified data centre.
        /// </summary>
        /// <param name="locationName">
		/// The data centre location name.
        /// </param>
        /// <returns>
		/// The relative action Uri.
        /// </returns>
        public static Uri ImagesWithSoftwareLabels(string locationName)
        {
			if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.",
                    "locationName");

			return new Uri(string.Format(MCP1_0_PREFIX + "base/image/deployedWithSoftwareLabels/{0}", locationName), UriKind.Relative);
        }


        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a filtered list of server images or servers.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="imagetype">
		/// The imagetype.
		/// </param>
		/// <param name="imageId">
		/// The image Id.
		/// </param>
		/// <param name="name">
		/// The server name
		/// </param>
		/// <param name="location">
		/// The server location
		/// </param>
		/// <param name="operatingSystemId">
		/// The operating System Id.
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The operating System Family.
		/// </param>
		/// <returns>
		/// A list of deployed servers
		/// </returns>
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
                Contract.Requires(orgId != Guid.Empty, "Organization Id cannot be empty");
				uri = string.Format(MCP1_0_PREFIX + "/{0}/imageWithDiskSpeed", orgId);
            }

// build que query string paramenters
            var querystringcollection = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                querystringcollection.Add("name", name);
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

        /// <summary>
        /// Gets the relative URI for the CaaS API action that delete a customer image.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="imageId">
		/// The customer image id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri RemoveCustomerServerImage(Guid orgId, string imageId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/image/{1}?delete", orgId, imageId), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a filtered list of deployed servers.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server Id.
		/// </param>
		/// <param name="name">
		/// The server name
		/// </param>
		/// <param name="networkId">
		/// The server networkid
		/// </param>
		/// <param name="location">
		/// The server location
		/// </param>
		/// <returns>
		/// A list of deployed servers
		/// </returns>
        public static Uri DeployedServers(Guid orgId, string serverId, string name, string networkId, string location)
        {
           Contract.Requires(orgId != Guid.Empty, "Organization Id cannot be empty");
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

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of customer images with software labels
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="networkLocation">
		/// The network location id
		/// </param>
		/// <returns>
		/// A list of OS server images
		/// </returns>
        public static Uri CustomerImagesWithSoftwareLabels(Guid orgId, string networkLocation)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/image/deployedWithSoftwareLabels/{1}", orgId, networkLocation),
                UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that allows a server to be deployed
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        [Obsolete("This Uri is deprecated, please use DeployServerWithDiskSpeed instead.")]
        public static Uri DeployServer(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server", orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that allows a server to be deployed
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri DeployServerWithDiskSpeed(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/deployServer", orgId), UriKind.Relative);
        }


        /// <summary>
        /// Modify the server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for a modify servers
		/// </returns>
        public static Uri ModifyServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}", orgId, serverId), UriKind.Relative);
        }


        /// <summary>
        /// Deletes the server.
		///     <remarks>
		/// The Server must be stopped before it can be deleted
		/// </remarks>
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for a deletion of the server
		/// </returns>
        public static Uri DeleteServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?delete", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// A “graceful” stop of a server by initiating a shutdown sequence within the guest operating system.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for a graceful shutdown of the server
		/// </returns>
        public static Uri ShutdownServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?shutdown", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Powers on an existing deployed server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for starting the server
		/// </returns>
        public static Uri PowerOnServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?start", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// An abrupt power off of the server. Success is guarenteed
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for powering off the server
		/// </returns>
        public static Uri PoweroffServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?poweroff", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
		/// A "graceful" reboot of the server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for rebooting the server
		/// </returns>
        public static Uri RebootServer(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?reboot", orgId, serverId), UriKind.Relative);
        }

		/// <summary>	Resets the server (hard reset). </summary>
		/// <param name="orgId">   	The org Id. </param>
		/// <param name="serverId">	The server Id. </param>
		/// <returns>	An URI. </returns>
		public static Uri ResetServer(Guid orgId, string serverId)
		{
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}?reset", orgId, serverId), UriKind.Relative);
		}

        /// <summary>
        /// Triggers an update of the VMware Tools software running on the guest OS of a virtual server
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for rebooting the server
		/// </returns>
        public static Uri UpdateServerVMwareTools(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?updateVMwareTools", orgId, serverId), UriKind.Relative);
        }


        /// <summary>
        /// Initiates a clone of a server to create a Customer Image
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="imageName">
		/// The image Name.
		/// </param>
		/// <param name="imageDesc">
		/// The image Desc.
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for rebooting the server
		/// </returns>
		public static Uri CloneServerToCustomerImage(Guid orgId, string serverId, string imageName, string imageDesc)
        {
            Uri uri = null;
            if (string.IsNullOrEmpty(imageDesc))
				uri = new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?clone={2}", orgId, serverId, imageName), UriKind.Relative);
            else
				uri = new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}?clone={2}&desc={3}", orgId, serverId, imageName, imageDesc), 
					UriKind.Relative);
            return uri;
        }

        /// <summary>
        /// Change server disk speed
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for change server disk size the server
		/// </returns>
        public static Uri ChangeServerDiskSpeed(Guid orgId, string serverId, string diskId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}/changeSpeed", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>
        /// Change server disk size
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for change server disk size the server
		/// </returns>
		public static Uri ChangeServerDiskSize(Guid orgId, string serverId, string diskId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}/changeSize", orgId, serverId, diskId), UriKind.Relative);
        }

        /// <summary>
        /// Adds a additional disk to a CaaS server
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="size">
		/// The size of the new disk
		/// </param>
		/// <param name="speedId">
		/// The speed of the new disk
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
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

        /// <summary>
		/// The relative URI for the CaaS API action that deletes a server disk
        /// </summary>
		/// <param name="orgId">
		/// The organisation id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri RemoveServerDisk(Guid orgId, string serverId, string diskId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/disk/{2}?delete", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>
        /// The relative URI for the CaaS API action that creates a anti affinity rule
        /// </summary>
		/// <param name="orgId">
		/// The organisation id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri CreateAntiAffinityRule(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/antiAffinityRule", orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes a anti affinity rule
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="ruleId">
		/// The anti affinity rule id
		/// </param>
		/// <param name="location">
		/// The location
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
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

        /// <summary>
        /// The relative URI for the CaaS API action that deletes a anti affinity rule
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <param name="ruleId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri RemoveAntiAffinityRule(Guid orgId, string ruleId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/antiAffinityRule/{1}?delete", orgId, ruleId), UriKind.Relative);
        }



        /// <summary>
        /// The get Virtual LAN.
        /// </summary>
        /// <param name="orgId">
        /// The org id.
        /// </param>
        /// <param name="Id">
        /// The id.
        /// </param>
        /// <param name="vlanName">
        /// The  Virtual LAN name.
        /// </param>
        /// <param name="networkDomainId">
        /// The network domain id.
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
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

			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/vlan?{1}", orgId, String.Join("&", queryParameters)), UriKind.Relative);
        }

	    /// <summary>	The get Virtual LAN. </summary>
	    /// <param name="orgId"> 	The org id. </param>
	    /// <param name="vlanId">	Identifier for the vlan. </param>
	    /// <returns>	The <see cref="Uri"/>. </returns>
	    public static Uri GetVlan(Guid orgId, Guid vlanId)
	    {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/vlan/{1}", orgId, vlanId), UriKind.Relative);
	    }

		/// <summary>	Gets vlan by organisation identifier. </summary>
		/// <param name="orgId">	The org Id. </param>
		/// <returns>	The vlan by organisation identifier. </returns>
		public static Uri GetVlanByOrgId(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/vlan", orgId), UriKind.Relative);
		}

        /// <summary>	The relative URI for the CaaS API for deploying the VLan. </summary>
        /// <param name="orgId">	The organization ID. </param>
        /// <returns>	A URI. </returns>
        public static Uri DeployVlan(Guid orgId)
        {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/deployVlan", orgId), UriKind.Relative);
        }

		/// <summary>	Deletes the vlan described by orgId. </summary>
		/// <param name="orgId">	The org Id. </param>
		/// <returns>	An URI. </returns>
		public static Uri DeleteVlan(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/deleteVlan", orgId), UriKind.Relative);
		}

		/// <summary>	Gets MCP 2 servers. </summary>
		/// <remarks>	Anthony, 6/17/2015. </remarks>
		/// <param name="orgId">	The organization Id. </param>
		/// <returns>	The MCP 2 servers. </returns>
		public static Uri GetMcp2Servers(Guid orgId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/server/server", orgId), UriKind.Relative);
		}

		/// <summary>	Gets MCP 2 server. </summary>
		/// <remarks>	Anthony, 6/17/2015. </remarks>
		/// <param name="orgId">   	The organization Id. </param>
		/// <param name="serverId">	The server Id. </param>
		/// <returns>	The MCP 2 servers. </returns>
		public static Uri GetMcp2Server(Guid orgId, Guid serverId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/server/server/{1}", orgId, serverId), UriKind.Relative);
		}

        #region Network API

        /// <summary>
        /// Lists the Networks deployed across all data center locations for the supplied organization.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for a list of networks
		/// </returns>
        public static Uri NetworkWithLocations(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Create an ACL rule
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for creating an ACL rule
		/// </returns>
        public static Uri CreateAclRule(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Removes the ACL rule
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="aclId">
		/// The ACL rule id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for removing an ACL rule
		/// </returns>
        public static Uri DeleteAclRule(Guid orgId, string networkId, string aclId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule/{2}?delete", orgId, networkId, aclId), UriKind.Relative);
        }

        /// <summary>
        /// Getting all the ACL rules in the network
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for getting ACL rules
		/// </returns>
        public static Uri GetAclRules(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Gets all the NAT rules for a specified network.
        /// </summary>
		/// <param name="orgId">
		/// The organization id.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for getting the NAT rules
		/// </returns>
        public static Uri GetNatRules(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Creates a new NAT rule.
        /// </summary>
		/// <param name="orgId">
		/// The organization id.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for creating a new NAT rule
		/// </returns>
        public static Uri CreateNatRule(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Deletes a specified NAT rule
        /// </summary>
		/// <param name="orgId">
		/// The organization id.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="natRuleId">
		/// The NAT rule id to delete
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for deleting an existing NAT rule
		/// </returns>
        public static Uri DeleteNatRule(Guid orgId, string networkId, string natRuleId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/network/{1}/natrule/{2}?delete", orgId, networkId, natRuleId),
                UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that creates a network in a specified data centre location.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for creating a network.
		/// </returns>
        public static Uri CreateNetwork(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <param name="networkId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri DeleteNetwork(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}?delete", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <param name="networkId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri ModifyNetwork(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// </summary>
		/// <param name="orgId">
		/// </param>
		/// <param name="networkId">
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri GetNetworkConfig(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/config", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Reseve public ip address block
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri ReserveNetworkPublicIpAddressBlock(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip?reserveNewWithSize", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Release public ip address block
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="ipBlockId">
		/// The block id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri ReleaseNetworkPublicIpAddressBlock(Guid orgId, string networkId, string ipBlockId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip/{2}?release ", orgId, networkId, ipBlockId), UriKind.Relative);
        }

        /// <summary>
        /// Set server to vip ip address block setting
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="ipBlockId">
		/// The block id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri SetServerToVipNetworkPublicIpAddressBlock(Guid orgId, string networkId, string ipBlockId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/publicip/{2} ", orgId, networkId, ipBlockId), UriKind.Relative);
        }

        /// <summary>
        /// Set multicast on network setting
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri SetNetworkMulticast(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/multicast ", orgId, networkId), UriKind.Relative);
        }
        
        #endregion // Network API

        #region Backup URIs

        /// <summary>
		/// Enables the Backup service for a deployed Server. Requires the Organization ID, Server ID and the Service Plan
		///     being enabled.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for enabling the backup on the server
		/// </returns>
        public static Uri EnableBackup(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Disables the Backup service for a deployed server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for disabling the backup on the server
		/// </returns>
        public static Uri DisableBackup(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup?disable", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Modify the backup service plan for a deployed server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for modifying the backup service pland of the server
		/// </returns>
        public static Uri ChangeBackupPlan(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/server/{1}/backup/modify", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Backup client types associated with a specific server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request listing the client types for the server
		/// </returns>
        public static Uri BackupClientTypes(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/type", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Backup storage policies associated with a specific server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request listing the storage policies for the server
		/// </returns>
        public static Uri BackupStoragePolicies(Guid orgId, string serverId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/storagePolicy", orgId, serverId),
                UriKind.Relative);
        }

        /// <summary>
        /// Backup schedule policies associated with a specific server.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request listing the schedule policies for the server
		/// </returns>
        public static Uri BackupSchedulePolicies(Guid orgId, string serverId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/schedulePolicy", orgId, serverId),
                UriKind.Relative);
        }

        /// <summary>
        /// Retrieves complete details of how the Backup service is configured for a specific deployed Server.
		///     Requires the Organization ID and Server ID for the Server and that the Server already has the Backup service
		///     enabled.
		///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for getting the backup details of the server
		/// </returns>
        public static Uri GetBackupDetails(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Provisions a new Backup Client for a deployed Server.
		///     Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service
		///     enabled.
		///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for adding a backup client to the server
		/// </returns>
        public static Uri AddBackupClient(Guid orgId, string serverId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Removes a Backup Client for the Backup service on a deployed Server. Requires the Organization ID, 
		///     Server ID and Backup Client ID for the relevant Backup Client and Server and that the Server already has
		///     the Backup service enabled. The user must be the Primary Administrator or a Sub-Administrator with the “backup”
		///     role.
		///     Note that the Backup Client ID is available from the backupClient.id additionalInformation element in the
		///     response received when the Backup Client was originally added. See Add Backup Client for details.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClientId">
		/// The backup client id to remove
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for removing a backup client from the server
		/// </returns>
        public static Uri RemoveBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?remove", orgId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Modifies the settings of an existing Backup Client for a deployed Server.
		///     Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service
		///     enabled.
		///     The user must be the Primary Administrator or a Sub-Administrator with the “backup” role.
		///     <remarks>
		/// Note that the Backup Client type cannot be changed.
		/// </remarks>
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClientId">
		/// The backup client id to modify
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for modifying a backup client for the server
		/// </returns>
        public static Uri ModifyBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}/modify", orgId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Requests an immediate Backup for a Backup Client
        /// </summary>
		/// <param name="organizationId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClientId">
		/// The backup client id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for initiating a backup on the client
		/// </returns>
        public static Uri InitiateBackup(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?backupNow", organizationId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Requests a cancellation of all running jobs for a backup client
        /// </summary>
		/// <param name="organizationId">
		/// The organization id
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClientId">
		/// The backup client id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for cancelling backup jobs on the client
		/// </returns>
        public static Uri CancelBackupJobs(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
				string.Format(MCP1_0_PREFIX + "{0}/server/{1}/backup/client/{2}?cancelJob", organizationId, serverId, backupClientId),
                UriKind.Relative);
        }

        #endregion // Backup URIs

        #region Import and Export Customer Image API

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of OVF Packages
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for getting the OVF Packages
		/// </returns>
        public static Uri GetOvfPackages(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/ovfPackage", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that POST a request to import a customer image
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for importing a customer image
		/// </returns>
        public static Uri ImportCustomerImage(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageImport", orgId), UriKind.Relative);
        }

		/// <summary>
		/// Gets the relative URI for the CaaS API action that POST a request to export a customer image
		/// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// Returns the relative URI of the REST request for exporting a customer image
		/// </returns>
		public static Uri ExportCustomerImage(Guid orgId)
		{
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExport", orgId), UriKind.Relative);
		}

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of customer image imports in progress.
        /// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// A list of customer image imports in progress
		/// </returns>
        public static Uri GetCustomerImageImports(Guid orgId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/imageImport", orgId), UriKind.Relative);
        }

		/// <summary>
		/// Gets the relative URI for the CaaS API action that retrieves a list of customer image exports in progress.
		/// </summary>
		/// <param name="orgId">
		/// The organization id
		/// </param>
		/// <returns>
		/// A list of customer image exports in progress
		/// </returns>
		public static Uri GetCustomerImageExports(Guid orgId)
		{
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExport", orgId), UriKind.Relative);
		}

		/// <summary>
		/// Gets the customer image export history.
		/// </summary>
		/// <param name="organizationId">
		/// The organization identifier.
		/// </param>
		/// <param name="count">
		/// The number of results to return.
		/// </param>
		/// <returns>
		/// The URI for the API.
		/// </returns>
		public static Uri GetCustomerImageExportHistory(Guid organizationId, int count = 20)
		{
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/imageExportHistory?count=", organizationId, count), UriKind.Relative);
		}

        #endregion

        #region VIP

        /// <summary>
		/// The relative URI for the CaaS API action that list or creates VIP real servers
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri CreateOrGetVipRealServers(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer", orgId, networkId), UriKind.Relative);
        }

      
        /// <summary>
		/// The relative URI for the CaaS API action that deletes VIP real servers
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="rServerId">
		/// The real server id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri DeleteVipRealServers(Guid orgId, string networkId, string rServerId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer/{2}?delete", orgId, networkId, rServerId), UriKind.Relative);
        }

        /// <summary>
		/// The relative URI for the CaaS API action that deletes VIP real servers
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="rServerId">
		/// The real server id
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public static Uri ModifyVipRealServers(Guid orgId, string networkId, string rServerId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/realServer/{2}", orgId, networkId, rServerId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that creates or lists VIP probes
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri CreateOrGetVipProbes(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/probe", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes VIP probes
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri DeleteVipProbes(Guid orgId, string networkId, string probeId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/probe/{2}?delete", orgId, networkId, probeId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that modify VIP probes
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri ModifyVipProbes(Guid orgId, string networkId, string probeId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/probe/{2}", orgId, networkId, probeId), UriKind.Relative);
        }


         /// <summary>
        /// The relative URI for the CaaS API action that creates or lists VIP server farms
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri CreateOrGetVipServerFarm(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/serverFarm", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes VIP server farms
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri DeleteVipServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}?delete", orgId, networkId, serverFarmId), 
				UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that get VIP server farm details
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri GetVipServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}", orgId, networkId, serverFarmId), UriKind.Relative);
        }

         /// <summary>
        /// The relative URI for the CaaS API action that add real server to server farm
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri AddVipRealServerToServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/addRealServer", orgId, networkId, serverFarmId), 
				UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that remove real server to server farm
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri RemoveVipRealServerFromServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/removeRealServer", orgId, networkId, serverFarmId), 
				UriKind.Relative);
        }


          /// <summary>
        /// The relative URI for the CaaS API action that add Probe to server farm
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri AddVipProbeToServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/serverFarm/{2}/addProbe", orgId, networkId, serverFarmId), 
				UriKind.Relative);
        }

          /// <summary>
        /// The relative URI for the CaaS API action that remove Probe to server farm
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri RemoveVipProbeFromServerFarm(Guid orgId, string networkId, string serverFarmId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "/{0}/network/{1}/serverFarm/{2}/removeProbe", orgId, networkId, serverFarmId), 
				UriKind.Relative);
        }


        /// <summary>
        /// The relative URI for the CaaS API action that list persistence profile
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri CreateOrGetVipPersistenceProfile(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/persistenceProfile", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes VIP server farms
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="persProfileId">
		/// The probe id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri DeleteVipPersistenceProfile(Guid orgId, string networkId, string persProfileId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/persistenceProfile/{2}?delete", orgId, networkId, persProfileId), 
				UriKind.Relative);
        }


        /// <summary>
        /// The relative URI for the CaaS API action that list VIPs
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri CreateOrGetVip(Guid orgId, string networkId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip", orgId, networkId), UriKind.Relative);
        }


        /// <summary>
        /// The relative URI for the CaaS API action that deletes VIPs 
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="vipId">
		/// The vip id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri DeleteVip(Guid orgId, string networkId, string vipId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip/{2}?delete", orgId, networkId, vipId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that modifies VIPs 
        /// </summary>
		/// <param name="orgId">
		/// The org id
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="vipId">
		/// The vip id
		/// </param>
		/// <returns>
		/// Uri
		/// </returns>
        public static Uri ModifyVip(Guid orgId, string networkId, string vipId)
        {
			return new Uri(string.Format(MCP1_0_PREFIX + "{0}/network/{1}/vip/{2}", orgId, networkId, vipId), UriKind.Relative);
        }

        #endregion

	    /// <summary>	Adds a public IP block. </summary>
	    /// <param name="orgId">	The org Id. </param>
	    /// <returns>	An URI. </returns>
	    public static Uri AddPublicIpBlock(Guid orgId)
	    {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/addPublicIpBlock", orgId), UriKind.Relative);
	    }

	    /// <summary>	Gets public IP blocks. </summary>
	    /// <param name="orgId">	The org Id. </param>
	    /// <returns>	The public IP blocks. </returns>
	    public static Uri GetPublicIpBlocks(Guid orgId)
	    {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/publicIpBlock", orgId), UriKind.Relative);
	    }

	    /// <summary>	Gets public IP block. </summary>
	    /// <param name="orgId">		  	The org Id. </param>
	    /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
	    /// <returns>	The public IP block. </returns>
	    public static Uri GetPublicIpBlock(Guid orgId, string publicIpBlockId)
	    {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/publicIpBlock/{1}", orgId, publicIpBlockId), UriKind.Relative);
	    }

	    /// <summary>	Gets reserved public addresses. </summary>
	    /// <param name="orgId">		  	The org Id. </param>
	    /// <param name="networkDomainId">	The network Domain Id. </param>
	    /// <returns>	The reserved public addresses. </returns>
	    public static Uri GetReservedPublicAddresses(Guid orgId, string networkDomainId)
	    {
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/reservedPublicIpv4Address?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
	    }

		/// <summary>	Gets reserved public addresses for network. </summary>
		/// <param name="orgId">		The org Id. </param>
		/// <param name="networkId">	The server networkid. </param>
		/// <returns>	The reserved public addresses for network. </returns>
		public static Uri GetReservedPublicAddressesForNetwork(Guid orgId, string networkId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/reservedPublicIpv4Address?networkId={1}", orgId, networkId), UriKind.Relative);
		}

		/// <summary>	Gets reserved private addresses. </summary>
		/// <param name="orgId">		  	The org Id. </param>
		/// <param name="networkDomainId">	The network Domain Id. </param>
		/// <returns>	The reserved public addresses. </returns>
		public static Uri GetReservedPrivateAddresses(Guid orgId, string networkDomainId)
		{
			return new Uri(string.Format(MCP2_0_PREFIX + "{0}/network/reservedPrivateIpv4Address?networkDomainId={1}", orgId, networkDomainId), UriKind.Relative);
		}
    }
}
