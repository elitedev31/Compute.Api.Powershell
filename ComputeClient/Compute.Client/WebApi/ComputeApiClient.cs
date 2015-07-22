// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeApiClient.cs" company="">
//   
// </copyright>
// <summary>
//   A client for the Dimension Data Compute-as-a-Service (CaaS) API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
// Backwards compatibility, hence not moving the NameSpace
namespace DD.CBU.Compute.Api.Client
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Network10;
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;
	using DD.CBU.Compute.Api.Client.Network;
	using DD.CBU.Compute.Api.Client.Network20;
	using DD.CBU.Compute.Api.Client.Utilities;
	using DD.CBU.Compute.Api.Contracts.Datacenter;
	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Image;
	using DD.CBU.Compute.Api.Contracts.Server;
	using DD.CBU.Compute.Api.Contracts.Software;

	/// <summary>
	/// A client for the Dimension Data Compute-as-a-Service (CaaS) API.
	/// </summary>
	public sealed class ComputeApiClient
		: DisposableObject, IComputeApiClient
	{
		#region Obsolete Contructors
		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Create a new Compute-as-a-Service API client.
		/// </summary>
		/// <param name="targetRegionName">
		/// The name of the region whose CaaS API end-point is targeted by the client.
		/// </param>
		[Obsolete("Please use the GetComputeApiClient Factory methods")]
		public ComputeApiClient(string targetRegionName)
		{
			if (string.IsNullOrWhiteSpace(targetRegionName))
				throw new ArgumentException(
					"Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.", "targetRegionName");

			KnownApiRegion region = KnownApiRegion.Australia_AU;
			if (!KnownApiRegion.TryParse(targetRegionName, true, out region))
				throw new ArgumentException("targetRegionName doesnt map to a valid region", "targetRegionName");

			Uri baseUri = KnownApiUri.Instance.GetBaseUri(KnownApiVendor.DimensionData, region);
			_httpClientHandler = new HttpClientHandler();
			var httpClient = new HttpClientAdapter(
				new HttpClient(
					_httpClientHandler)
				{
					BaseAddress = baseUri
				});

			InitializeProperties(httpClient);
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Creates a new CaaS API client using a base URI.
		/// </summary>
		/// <param name="baseUri">
		/// The base URI to use for the CaaS API.
		/// </param>
		[Obsolete("Please use the GetComputeApiClient Factory methods")]
		public ComputeApiClient(Uri baseUri)
		{
			if (baseUri == null)
				throw new ArgumentNullException("baseUri", "Argument cannot be null");

			if (!baseUri.IsAbsoluteUri)
				throw new ArgumentException("Base URI supplied is not an absolute URI", "baseUri");
			
			_httpClientHandler = new HttpClientHandler();

			var httpClient = new HttpClientAdapter(
				new HttpClient(
					_httpClientHandler)
				{
					BaseAddress = baseUri
				});

			InitializeProperties(httpClient);
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Creates a new CaaS API client using a known vendor and region.
		/// </summary>
		/// <param name="vendor">
		/// The vendor
		/// </param>
		/// <param name="region">
		/// The region
		/// </param>
		[Obsolete("Please use the GetComputeApiClient Factory methods")]
		public ComputeApiClient(KnownApiVendor vendor, KnownApiRegion region)
		{
			Uri baseUri = KnownApiUri.Instance.GetBaseUri(vendor, region);
			_httpClientHandler = new HttpClientHandler();
			var httpClient = new HttpClientAdapter(
				new HttpClient(
					_httpClientHandler)
				{
					BaseAddress = baseUri
				});

			InitializeProperties(httpClient);
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Creates a new CaaS API client using a Dimension Data vendor and known region.
		/// </summary>
		/// <param name="region">
		/// The region
		/// </param>
		[Obsolete("Please use the GetComputeApiClient Factory methods")]
		public ComputeApiClient(KnownApiRegion region)
		{
			Uri baseUri = KnownApiUri.Instance.GetBaseUri(KnownApiVendor.DimensionData, region);
			_httpClientHandler = new HttpClientHandler();
			var httpClient = new HttpClientAdapter(
				new HttpClient(
					_httpClientHandler)
				{
					BaseAddress = baseUri
				});

			InitializeProperties(httpClient);
		}

		#endregion

		#region Constructor
		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class.
		/// </summary>
		/// <param name="httpClient">
		/// The http client.
		/// </param>
		/// <param name="organizationId">
		/// The organization id.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		[Obsolete("Please use the GetComputeApiClient Factory methods")]
		public ComputeApiClient(IHttpClient httpClient, Guid organizationId = default(Guid))
		{
			if (httpClient == null)
				throw new ArgumentNullException("httpClient", "httpClient cannot be null");

			InitializeProperties(httpClient, organizationId);
		}

		/// <summary>
		/// The initialize properties.
		/// </summary>
		/// <param name="httpClient">
		/// The http client.
		/// </param>
		/// <param name="organizationId">
		/// The organization Id.
		/// </param>
		private void InitializeProperties(IHttpClient httpClient, Guid organizationId = default(Guid))
		{
			WebApi = new WebApi(httpClient, organizationId);
			Networking = new Networking(WebApi);
			NetworkingLegacy = new NetworkingLegacy(WebApi);
		}

		#endregion

		#region Factory Methods

		/// <summary>
		/// The get compute api client.
		/// </summary>
		/// <param name="baseUri">
		/// The base uri.
		/// </param>
		/// <param name="credentials">
		/// The credentials.
		/// </param>
		/// <param name="organizationId">
		/// The organization id.
		/// </param>
		/// <returns>
		/// The <see cref="ComputeApiClient"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		/// <exception cref="ArgumentException">
		/// </exception>
		public static ComputeApiClient GetComputeApiClient(Uri baseUri, ICredentials credentials, Guid organizationId = default(Guid))
		{
			if (baseUri == null)
				throw new ArgumentNullException("baseUri", "baseUri cannot be null");

			if (!baseUri.IsAbsoluteUri)
				throw new ArgumentException("Base URI supplied is not an absolute URI", "baseUri");

			if (credentials == null)
				throw new ArgumentNullException("credentials", "credentials cannot be null");

			var messageHandler = new HttpClientHandler
			{
				Credentials = credentials,
				PreAuthenticate = true
			};

			var httpClient = new HttpClientAdapter(
				new HttpClient(
					messageHandler)
				{
					BaseAddress = baseUri
				});

			return new ComputeApiClient(httpClient, organizationId);
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Creates a new CaaS API client using a known vendor and region.
		/// </summary>
		/// <param name="vendor">
		/// The vendor
		/// </param>
		/// <param name="region">
		/// The region
		/// </param>
		/// <param name="credentials">
		/// The credentials.
		/// </param>
		/// <param name="organizationId">
		/// The organization Id.
		/// </param>
		/// <returns>
		/// The <see cref="ComputeApiClient"/>.
		/// </returns>
		public static ComputeApiClient GetComputeApiClient(KnownApiVendor vendor, KnownApiRegion region, ICredentials credentials, Guid organizationId = default(Guid))
		{
			Uri baseUri = KnownApiUri.Instance.GetBaseUri(vendor, region);
			return GetComputeApiClient(baseUri, credentials, organizationId);
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiClient"/> class. 
		/// Creates a new CaaS API client using a Dimension Data vendor and known region.
		/// </summary>
		/// <param name="region">
		/// The region
		/// </param>
		/// <param name="credentials">
		/// The credentials.
		/// </param>
		/// <param name="organizationId">
		/// The organization Id.
		/// </param>
		/// <returns>
		/// The <see cref="ComputeApiClient"/>.
		/// </returns>
		public static ComputeApiClient GetComputeApiClient(KnownApiRegion region, ICredentials credentials, Guid organizationId = default(Guid))
		{
			Uri baseUri = KnownApiUri.Instance.GetBaseUri(KnownApiVendor.DimensionData, region);
			return GetComputeApiClient(baseUri, credentials);
		}

		/// <summary>
		/// The get ftp host.
		/// </summary>
		/// <param name="vendor">
		/// The vendor.
		/// </param>
		/// <param name="region">
		/// The region.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public static string GetFtpHost(KnownApiVendor vendor, KnownApiRegion region)
		{
			return KnownApiUri.Instance.GetFtpHost(vendor, region);
		}

		#endregion

		#region Instance data
		/// <summary>
		/// The _http client handler.
		/// </summary>
		[Obsolete("The only intent to support this property is to support obsolete contructors and LoginAsync(Credentials)")]
		HttpClientHandler _httpClientHandler;

		/// <summary>	Gets the networking 2.0 methods. </summary>
		/// <value>	The networking. </value>		
		public INetworking Networking { get; private set; }

		/// <summary>	Gets the networking legacy 1.0 methods </summary>
		public INetworkingLegacy NetworkingLegacy { get; private set; }

		#endregion Instance data

		/// <summary>
		/// Dispose of resources being used by the CaaS API client.
		/// </summary>
		/// <param name="disposing">
		/// Explicit disposal?
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (WebApi != null)
				{
					WebApi.Dispose();
					WebApi = null;
				}

				if (_httpClientHandler != null)
				{
					_httpClientHandler.Dispose();
					_httpClientHandler = null;
				}
			}
		}
		
		#region Public properties

		/// <summary>
		/// Access to the web API for login/logout and account info
		/// </summary>
		public IWebApi WebApi { get; private set; }

		/// <summary>
		/// Asynchronously log into the CaaS API.
		/// </summary>
		/// <param name="accountCredentials">
		/// The CaaS account credentials used to authenticate against the CaaS API.
		/// </param>
		/// <returns>
		/// An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
		/// </returns>
		[Obsolete("Use GetComputeApiClient Factory passing accountCredentials and Login() method")]
		public async Task<IAccount> LoginAsync(ICredentials accountCredentials)
		{
			IAccount mcp1Account = await WebApi.LoginAsync();
			if (_httpClientHandler != null)
			{
				_httpClientHandler.Credentials = accountCredentials;
				_httpClientHandler.PreAuthenticate = true;				
			}			
			return mcp1Account;
		}

		/// <summary>
		/// The login async.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IAccount> Login()
		{
			return await WebApi.LoginAsync();
		}

		/// <summary>
		/// Gets a list of software labels
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels()
		{
			SoftwareLabels labels = await WebApi.GetAsync<SoftwareLabels>(ApiUris.SoftwareLabels(WebApi.OrganizationId));

			return labels.Items;
		}

		/// <summary>
		/// Returns a list of the Multi-Geography Regions available for the supplied {org-id
		///     An element is returned for each available Geographic Region.
		/// </summary>
		/// <returns>
		/// A list of regions associated with the org ID.
		/// </returns>
		public async Task<IEnumerable<Geo>> GetListOfMultiGeographyRegions()
		{
            Geos regions = await WebApi.GetAsync<Geos>(ApiUris.MultiGeographyRegions(WebApi.OrganizationId));

			return regions.Items;
		}

		/// <summary>
		/// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the
		///     same organization to become the Primary Administrator for the organization.
		///     The Sub-Administrator is identified by their <paramref name="username"/>.
		/// </summary>
		/// <param name="username">
		/// The Sub-Administrator account.
		/// </param>
		/// <returns>
		/// A <see cref="Status"/> result that describes whether or not the operation was successful.
		/// </returns>
		public async Task<Status> DeleteSubAdministratorAccount(string username)
		{
            return await WebApi.GetAsync<Status>(ApiUris.DeleteSubAdministrator(WebApi.OrganizationId, username));
		}

		/// <summary>
		/// Used to retrieve full details of an Administrator account associated with the Organization identified by {org Id}.
		///     The Sub-Administrator is identified by their <paramref name="username"/>.
		/// </summary>
		/// <param name="username">
		/// The Administrator or sub-administrator account.
		/// </param>
		/// <returns>
		/// A <see cref="Status"/> result that describes whether or not the operation was successful.
		/// </returns>
		public async Task<AccountWithPhoneNumber> GetAdministratorAccount(string username)
		{
			AccountWithPhoneNumber account =
				await WebApi.GetAsync<AccountWithPhoneNumber>(ApiUris.AccountWithPhoneNumber(WebApi.OrganizationId, username));
			return account;
		}


		/// <summary>
		/// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the
		///     same organization to become the Primary Administrator for the organization.
		///     The Sub-Administrator is identified by their <paramref name="username"/>.
		/// </summary>
		/// <param name="username">
		/// The Sub-Administrator account.
		/// </param>
		/// <returns>
		/// A <see cref="Status"/> result that describes whether or not the operation was successful.
		/// </returns>
		public async Task<Status> DesignatePrimaryAdministratorAccount(string username)
		{
            return await WebApi.GetAsync<Status>(ApiUris.SetPrimaryAdministrator(WebApi.OrganizationId,username));
		}


		/// <summary>
		/// This function identifies the list of data center 's available to the organization of the authenticating user.
		/// </summary>
		/// <returns>
		/// The list of data center 's associated with the organization.
		/// </returns>
		public async Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses()
		{
			DatacentersWithMaintenanceStatus dataCenters =
				await
					WebApi.GetAsync<DatacentersWithMaintenanceStatus>(ApiUris.DatacentresWithMaintanence(WebApi.OrganizationId));
			return dataCenters.datacenter;
		}

		/// <summary>
		/// Lists the Accounts belonging to the Organization identified by the organisation. The list will include all
		///     SubAdministrator accounts and the Primary Administrator account. The Primary Administrator is unique and is
		///     identified by the “primary administrator” role.
		/// </summary>
		/// <returns>
		/// A list of accounts associated with the organisation.
		/// </returns>
		public async Task<IEnumerable<Account>> GetAccounts()
		{
			Accounts accounts = await WebApi.GetAsync<Accounts>(ApiUris.Account(WebApi.OrganizationId));
			return accounts.Items;
		}

		/// <summary>
		/// Adds a new Sub-Administrator Account to the organization.
		///     The account is created with a set of roles defining the level of access to the organization’s Cloud
		///     resources or the account can be created as “read only”, restricted to just viewing Cloud resources and
		///     unable to generate Cloud Reports.
		/// </summary>
		/// <param name="account">
		/// The account that will be added to the org.
		/// </param>
		/// <returns>
		/// A <see cref="Status"/> object instance that shows the results of the operation.
		/// </returns>
		public async Task<Status> AddSubAdministratorAccount(AccountWithPhoneNumber account)
		{
			return await WebApi.PostAsync<AccountWithPhoneNumber, Status>(ApiUris.AccountWithPhoneNumber(WebApi.OrganizationId), account);
		}

		/// <summary>
		/// This function updates an existing Administrator Account.
		/// </summary>
		/// <param name="account">
		/// The account to be updated.
		/// </param>
		/// <returns>
		/// A <see cref="Status"/> object instance that shows the results of the operation.
		/// </returns>
		public async Task<Status> UpdateAdministratorAccount(AccountWithPhoneNumber account)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(account.password))
				parameters["password"] = account.password;
			if (!string.IsNullOrEmpty(account.emailAddress))
				parameters["emailAddress"] = account.emailAddress;
			if (!string.IsNullOrEmpty(account.fullName))
				parameters["fullName"] = account.fullName;
			if (!string.IsNullOrEmpty(account.firstName))
				parameters["firstName"] = account.firstName;
			if (!string.IsNullOrEmpty(account.lastName))
				parameters["lastName"] = account.lastName;
			if (!string.IsNullOrEmpty(account.department))
				parameters["department"] = account.department;
			if (!string.IsNullOrEmpty(account.customDefined1))
				parameters["customDefined1"] = account.customDefined1;
			if (!string.IsNullOrEmpty(account.customDefined2))
				parameters["customDefined2"] = account.customDefined2;
			if (!string.IsNullOrEmpty(account.phoneCountryCode))
				parameters["phoneCountryCode"] = account.phoneCountryCode;
			if (!string.IsNullOrEmpty(account.phoneNumber))
				parameters["phoneNumber"] = account.phoneNumber;

			string postBody = parameters.ToQueryString();

			if (account.MemberOfRoles.Any())
			{
				IEnumerable<string> roles = account.MemberOfRoles.Select(role => string.Format("role={0}", role.Name));
				string roleParameters = string.Join("&", roles);

				postBody = string.Join("&", postBody, roleParameters);
			}

			return
				await
					WebApi.PostAsync<Status>(ApiUris.UpdateAdministrator(WebApi.OrganizationId, account.userName), 
						postBody);
		}


		/// <summary>
		/// Asynchronously get a list of all CaaS data centres that are available for use by the specified organisation.
		/// </summary>
		/// <returns>
		/// A read-only list of <see cref="IDatacenterDetail"/>s representing the data centre information.
		/// </returns>
		[Obsolete("This method was replaced by GetListOfDataCentersWithMaintenanceStatuses based on CaaS API!")]
		public async Task<IReadOnlyList<DatacenterWithDiskSpeedDetails>> GetAvailableDataCenters()
		{
			CheckDisposed();

			DatacentersWithDiskSpeedDetails datacentersWithDiskSpeedDetails =
				await WebApi.GetAsync<DatacentersWithDiskSpeedDetails>(
					ApiUris.DatacentersWithDiskSpeedDetails(
						WebApi.OrganizationId
						)
					);

			return datacentersWithDiskSpeedDetails.datacenter;
		}

		/// <summary>
		/// Get a list of all system-defined images (with software labels) deployed in the specified data centre.
		/// </summary>
		/// <param name="locationName">
		/// The short name of the location in which the data centre is located.
		/// </param>
		/// <returns>
		/// A read-only list <see cref="DeployedImageWithSoftwareLabelsType"/>, sorted by UTC creation date / time,
		///     representing the images.
		/// </returns>
		[Obsolete]
		public async Task<IReadOnlyList<DeployedImageWithSoftwareLabelsType>> GetImages(string locationName)
		{
			if (string.IsNullOrWhiteSpace(locationName))
				throw new ArgumentException(
					"Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.", 
					"locationName");

			DeployedImagesWithSoftwareLabels imagesWithSoftwareLabels =
				await
					WebApi.GetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.ImagesWithSoftwareLabels(locationName));

			return imagesWithSoftwareLabels.DeployedImageWithSoftwareLabels;
		}

		/// <summary>
		/// Get OS server images, paramenters are just for filtering. Use String.Empty on the parameter where filtering is not
		///     required.
		/// </summary>
		/// <param name="imageId">
		/// The image Id.
		/// </param>
		/// <param name="name">
		/// The name filter
		/// </param>
		/// <param name="location">
		/// The location filter
		/// </param>
		/// <param name="operatingSystemId">
		/// The OS id
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The OS family
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetImages(string imageId, string name, string location, 
			string operatingSystemId, string operatingSystemFamily)
		{
			ImagesWithDiskSpeed imagesWithDiskSpeed =
				await
					WebApi.GetAsync<ImagesWithDiskSpeed>(ApiUris.ImagesWithDiskSpeed(WebApi.OrganizationId, ServerImageType.OS, 
						imageId, name, location, operatingSystemId, operatingSystemFamily));

			if (imagesWithDiskSpeed == null)
				return null;
			if (imagesWithDiskSpeed.image == null)
				return null;

			return imagesWithDiskSpeed.image;
		}


		/// <summary>
		/// This function lists the available Customer Images at a particular Location for the provided org-id.
		///     The response adds to the deprecated List Deployed Customer Images in Location function with
		///     the addition of zero to many, optional softwareLabel elements, listing the Priced Software packages installed on
		///     the Customer Image.
		/// </summary>
		/// <param name="networkLocation">
		/// The network location
		/// </param>
		/// <returns>
		/// A list of deployed customer images with software labels in location
		/// </returns>
		[Obsolete]
		public async Task<IEnumerable<DeployedImageWithSoftwareLabelsType>> GetCustomerServerImages(string networkLocation)
		{
			// Contract.Requires(!string.IsNullOrWhiteSpace(networkLocation), "Network location must not be empty or null");
			DeployedImagesWithSoftwareLabels images =
				await
					WebApi.GetAsync<DeployedImagesWithSoftwareLabels>(
						ApiUris.CustomerImagesWithSoftwareLabels(WebApi.OrganizationId, networkLocation));
			return images.DeployedImageWithSoftwareLabels;
		}


		/// <summary>
		/// Get customer server images
		/// </summary>
		/// <param name="imageId">
		/// The image Id.
		/// </param>
		/// <param name="name">
		/// The name filter
		/// </param>
		/// <param name="location">
		/// The location filter
		/// </param>
		/// <param name="operatingSystemId">
		/// The OS id
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The OS family
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetCustomerServerImages(string imageId, string name, 
			string location, string operatingSystemId, string operatingSystemFamily)
		{
			ImagesWithDiskSpeed imagesWithDiskSpeed =
				await
					WebApi.GetAsync<ImagesWithDiskSpeed>(ApiUris.ImagesWithDiskSpeed(WebApi.OrganizationId, 
						ServerImageType.CUSTOMER, imageId, name, location, operatingSystemId, operatingSystemFamily));

			if (imagesWithDiskSpeed.image == null)
				return null;

			return imagesWithDiskSpeed.image;
		}


		/// <summary>
		/// Remove customer server images
		/// </summary>
		/// <param name="imageId">
		/// The ImageId
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> RemoveCustomerServerImage(string imageId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.RemoveCustomerServerImage(WebApi.OrganizationId, imageId));
		}

		/// <summary>
		/// Deploys a server using an image into a specified network.
		/// </summary>
		/// <param name="name">
		/// </param>
		/// <param name="description">
		/// </param>
		/// <param name="networkId">
		/// </param>
		/// <param name="imageId">
		/// </param>
		/// <param name="adminPassword">
		/// </param>
		/// <param name="isStarted">
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("This method is deprecated, please use DeployServerWithDiskSpeedImageTask instead.")]
		public async Task<Status> DeployServerImageTask(string name, string description, string networkId, string imageId, 
			string adminPassword, bool isStarted)
		{
			// Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name), "name argument must not be empty");
			// Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(networkId), "network id must not be empty");
			// Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(imageId), "Image id must not be empty");
			// Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(adminPassword), "administrator password cannot be null or empty");
			return
				await
					WebApi.PostAsync<NewServerToDeploy, Status>(
						ApiUris.DeployServer(WebApi.OrganizationId), 
						new NewServerToDeploy
						{
							name = name, 
							description = description, 
							vlanResourcePath =
								string.Format("/oec/{0}/network/{1}", WebApi.OrganizationId, networkId), 
							imageResourcePath = string.Format("/oec/base/image/{0}", imageId), 
							administratorPassword = adminPassword, 
							isStarted = isStarted
						});
		}

		/// <summary>
		/// The deploy server with disk speed image task.
		/// </summary>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="privateIp">
		/// The private ip.
		/// </param>
		/// <param name="imageId">
		/// The image id.
		/// </param>
		/// <param name="adminPassword">
		/// The admin password.
		/// </param>
		/// <param name="start">
		/// The start.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> DeployServerWithDiskSpeedImageTask(
			string name,
			string description,
			string networkId,
			string privateIp,
			string imageId,
			string adminPassword,
			bool start)
		{
			return
				await
					WebApi.PostAsync<NewServerToDeployWithDiskSpeed, Status>(
						ApiUris.DeployServerWithDiskSpeed(WebApi.OrganizationId), 
						new NewServerToDeployWithDiskSpeed
						{
							name = name, 
							description = description, 
							imageId = imageId, 
							networkId = networkId, 
							privateIp = privateIp, 
							administratorPassword = adminPassword, 
							start = start
						});
		}

		/// <summary>
		/// The deploy server with disk speed image task.
		/// </summary>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="privateIp">
		/// The private ip.
		/// </param>
		/// <param name="imageId">
		/// The image id.
		/// </param>
		/// <param name="adminPassword">
		/// The admin password.
		/// </param>
		/// <param name="start">
		/// The start.
		/// </param>
		/// <param name="disk">
		/// The disk.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> DeployServerWithDiskSpeedImageTask(
			string name,
			string description,
			string networkId,
			string privateIp,
			string imageId,
			string adminPassword,
			bool start,
			Disk[] disk)
		{
			return
				await
					WebApi.PostAsync<NewServerToDeployWithDiskSpeed, Status>(
						ApiUris.DeployServerWithDiskSpeed(WebApi.OrganizationId), 
						new NewServerToDeployWithDiskSpeed
						{
							name = name, 
							description = description, 
							imageId = imageId, 
							networkId = networkId, 
							privateIp = privateIp, 
							administratorPassword = adminPassword, 
							start = start, 
							disk = disk
						});
		}


		/// <summary>
		/// Modify server server settings.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="name">
		/// The server new name on CaaS. This parameter does not change the machine/host name.
		/// </param>
		/// <param name="description">
		/// The new description for the server.
		/// </param>
		/// <param name="memory">
		/// Memory (in MB). Value must be represent a GB integer (e.g. 1024,. 2048, 3072, 4096, etc.)
		/// </param>
		/// <param name="cpucount">
		/// Number of virtual CPU’s (e.g. 1, 2, 4 etc.)
		/// </param>
		/// <param name="privateIp">
		/// The new privateIp of the server.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ModifyServer(
			string serverId,
			string name,
			string description,
			int memory,
			int cpucount,
			string privateIp)
		{
			// build que query string paramenters
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(name))
				parameters.Add("name", name);
			if (!string.IsNullOrEmpty(description))
				parameters.Add("description", description);
			if (memory > 0)
				parameters.Add("memory", memory.ToString());
			if (cpucount > 0)
				parameters.Add("cpuCount", cpucount.ToString());
			if (!string.IsNullOrEmpty(privateIp))
				parameters.Add("privateIp", privateIp);

			// build the query string
			string poststring = parameters.ToQueryString();

			return await WebApi.PostAsync<Status>(ApiUris.ModifyServer(WebApi.OrganizationId, serverId), poststring);
		}

		/// <summary>
		/// Powers on the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerPowerOn(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.PowerOnServer(WebApi.OrganizationId, serverId));
		}

		/// <summary>
		/// Powers off the server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerPowerOff(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.PoweroffServer(WebApi.OrganizationId, serverId));
		}

		/// <summary>
		/// Graceful reset of a server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerRestart(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.RebootServer(WebApi.OrganizationId, serverId));
		}

		/// <summary>	Power cycles an existing deployed server. This is the equivalent of pulling and replacing the power cord for
		/// a physical server. Requires your organization ID and the ID of the target server.. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	Returns a status of the HTTP request </returns>
		public async Task<Status> ServerReset(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.ResetServer(WebApi.OrganizationId, serverId));
		}

		/// <summary>
		/// "Graceful" shutdown of the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerShutdown(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.ShutdownServer(WebApi.OrganizationId, serverId));
		}


		/// <summary>
		/// Triggers an update of the VMWare Tools software running on the guest OS of a virtual server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerUpdateVMwareTools(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.UpdateServerVMwareTools(WebApi.OrganizationId, serverId));
		}


		/// <summary>
		/// Initiates a clone of a server to create a Customer Image
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="imageName">
		/// The customer image name.
		/// </param>
		/// <param name="imageDesc">
		/// The customer image description.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ServerCloneToCustomerImage(string serverId, string imageName, string imageDesc)
		{
			return
				await
				WebApi.GetAsync<Status>(ApiUris.CloneServerToCustomerImage(WebApi.OrganizationId, serverId, imageName, imageDesc));
		}

		/// <summary>
		/// Change server disk size
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <param name="sizeInGb">
		/// New size of the disk
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ChangeServerDiskSize(string serverId, string diskId, string sizeInGb)
		{
			return await
				WebApi.PostAsync<ChangeDiskSize, Status>(
					ApiUris.ChangeServerDiskSize(WebApi.OrganizationId, serverId, diskId), 
					new ChangeDiskSize
					{
						newSizeGb = sizeInGb
					}
					);
		}


		/// <summary>
		/// Change server disk speed
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <param name="speedId">
		/// New size of the disk
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ChangeServerDiskSpeed(string serverId, string diskId, string speedId)
		{
			return await
				WebApi.PostAsync<ChangeDiskSpeed, Status>(
					ApiUris.ChangeServerDiskSpeed(WebApi.OrganizationId, serverId, diskId), 
					new ChangeDiskSpeed
					{
						speed = speedId
					}
					);
		}

		/// <summary>
		/// Add disk to existing server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="size">
		/// Size in GB
		/// </param>
		/// <param name="speedId">
		/// The speed id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> AddServerDisk(string serverId, string size, string speedId)
		{
			return await
				WebApi.GetAsync<Status>(
					ApiUris.AddServerDisk(WebApi.OrganizationId, serverId, size, speedId));
		}

		/// <summary>
		/// Remove disk from existing server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="diskId">
		/// The disk id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> RemoveServerDisk(string serverId, string diskId)
		{
			return await
				WebApi.GetAsync<Status>(
					ApiUris.RemoveServerDisk(WebApi.OrganizationId, serverId, diskId));
		}


		/// <summary>
		/// Deletes the server.
		///     <remarks>
		/// The server must be turned off and with backup disabled
		/// </remarks>
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// Returns a status of the HTTP request
		/// </returns>
		public async Task<Status> ServerDelete(string serverId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.DeleteServer(WebApi.OrganizationId, serverId));
		}

		/// <summary>
		/// Gets all the deployed servers.
		/// </summary>
		/// <returns>
		/// A list of deployed servers
		/// </returns>
		public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers()
		{
			ServersWithBackup servers =
				await WebApi.GetAsync<ServersWithBackup>(ApiUris.DeployedServers(WebApi.OrganizationId, null, null, null, null));
			return servers.server;
		}

		/// <summary>
		/// Gets filtered list of the deployed servers.
		/// </summary>
		/// <param name="serverId">
		/// The server Id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="networkId">
		/// The network Id.
		/// </param>
		/// <param name="location">
		/// The location.
		/// </param>
		/// <returns>
		/// A list of deployed servers
		/// </returns>
		public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(
			string serverId,
			string name,
			string networkId,
			string location)
		{
			ServersWithBackup servers =
				await
				WebApi.GetAsync<ServersWithBackup>(
					ApiUris.DeployedServers(WebApi.OrganizationId, serverId, name, networkId, location));
			return servers.server;
		}
        /// <summary>
        /// Gets a deployed server by Id.
        /// </summary>
        /// <param name="serverId">The server Id.</param>
        /// <returns>A list of deployed servers</returns>
	    public async Task<ServerWithBackupType> GetDeployedServerById(string serverId)
	    {
            var servers = await GetDeployedServers(serverId, string.Empty, string.Empty, string.Empty);
            if (servers.Any())
                return servers.SingleOrDefault();
            else
                return null;
	    }


        /// <summary>
        /// Gets filtered list of the deployed servers by name
        /// </summary>
        /// <param name="name">The server name.</param>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServersByName(string name)
        {
            return await GetDeployedServers(string.Empty, name, string.Empty, string.Empty);       
        }

        /// <summary>
        /// Gets filtered list of the deployed servers by network id
        /// </summary>
        /// <param name="networkid">The network id.</param>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServersByNetworkId(string networkid)
        {
            return await GetDeployedServers(string.Empty, string.Empty, networkid, string.Empty);
        }

        /// <summary>
        /// Gets filtered list of the deployed servers by location
        /// </summary>
        /// <param name="location">The location code</param>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServersByLocation(string location)
        {
            return await GetDeployedServers(string.Empty, string.Empty, string.Empty, location);
        }


	    /// <summary>
		/// Creates a new Server Anti-Affinity Rule between two servers on the same Cloud network.
		/// </summary>
		/// <param name="serverId1">
		/// The serverId for the 1st server
		/// </param>
		/// <param name="serverId2">
		/// The serverId for the 2'nd server
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> CreateServerAntiAffinityRule(string serverId1, string serverId2)
		{
			return await
				WebApi.PostAsync<NewAntiAffinityRule, Status>(
					ApiUris.CreateAntiAffinityRule(WebApi.OrganizationId), 
					new NewAntiAffinityRule
					{
						serverId = new[] {serverId1, serverId2}
					}
					);
		}


		/// <summary>
		/// List all Server Anti-Affinity Rules
		/// </summary>
		/// <param name="ruleId">
		/// Filter by rule Id
		/// </param>
		/// <param name="location">
		/// Filter by location
		/// </param>
		/// <param name="networkId">
		/// Filter by network Id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<AntiAffinityRuleType>> GetServerAntiAffinityRules(
			string ruleId,
			string location,
			string networkId)
		{
			AntiAffinityRules rules =
				await
				WebApi.GetAsync<AntiAffinityRules>(ApiUris.GetAntiAffinityRule(WebApi.OrganizationId, ruleId, location, networkId));
			return rules.antiAffinityRule;
		}

		/// <summary>
		/// Remove a server Anti-Affinity Rule between two servers on the same Cloud network.
		/// </summary>
		/// <param name="ruleId">
		/// The ruleId
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> RemoveServerAntiAffinityRule(string ruleId)
		{
			return await WebApi.GetAsync<Status>(ApiUris.RemoveAntiAffinityRule(WebApi.OrganizationId, ruleId));
		}

		/// <summary>
		/// Since MultiGeo call is only valid for the home geo, use this method to discover what is your home geo and the
		///     applicable regions for this user.
		///     This is a multithreaded call that uses the underlying ComputeApiClient.GetListOfMultiGeographyRegions()
		///     to discover the home geo and multi geo for this user to all API endpoints known for vendor.
		///     Note: Most of the user vendor is DimensionData. Use this if you have to guess which vendor the user is under.
		/// </summary>
		/// <param name="vendor">
		/// The vendor of the user
		/// </param>
		/// <param name="credential">
		/// Credential of the user
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<Geo>> DiscoverHomeMultiGeo(KnownApiVendor vendor, ICredentials credential)
		{
			IEnumerable<KnownApiRegion> regionList = KnownApiUri.Instance.GetKnownRegionList(vendor);

			IDictionary<KnownApiRegion, ComputeApiClient> computeClients = regionList.Select(
				region =>
				new KeyValuePair<KnownApiRegion, ComputeApiClient>(
					region,
					ComputeApiClient.GetComputeApiClient(vendor, region, credential)))
					.ToDictionary(x => x.Key, x => x.Value);

			if (computeClients.Count == 0)
			{
				throw new Exception("No known end points for this vendor");
			}

			IDictionary<KnownApiRegion, Task<IAccount>> loginTasks = computeClients.Select(
				client => new KeyValuePair<KnownApiRegion, Task<IAccount>>(client.Key, client.Value.Login()))
																					.ToDictionary(x => x.Key, x => x.Value);

			// try login to all known regions simultaneoulsy. Note, not all regions may be enabled for this particular client.
			try
			{
				await Task.WhenAll(loginTasks.Values.ToArray());
			}
			catch (Exception)
			{
				// ignore (there might be region that this user is not enabled)
			}

			var loggedInClients = loginTasks.Where(client => client.Value.Status == TaskStatus.RanToCompletion).Select(login => computeClients[login.Key]).ToList();

			if (loggedInClients.Count == 0)
			{
				throw new Exception("Invalid login or user doesn't exists");
			}

			Task<IEnumerable<Geo>>[] multiGeoTasks =
				loggedInClients.Select(client => client.GetListOfMultiGeographyRegions()).ToArray();

			// multiGeo only works in the home geo.
			try
			{
				await Task.WhenAll(multiGeoTasks);
			}
			catch (Exception)
			{
				// ignore (only one task will return with valid result)
			}

			IEnumerable<Geo> validMultiGeo =
				multiGeoTasks.Single(task => task.Status == TaskStatus.RanToCompletion && task.Result != null).Result;
			return validMultiGeo;
		}			

		#endregion // Public methods
	}
}