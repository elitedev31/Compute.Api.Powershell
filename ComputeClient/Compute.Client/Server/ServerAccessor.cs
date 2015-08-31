namespace DD.CBU.Compute.Api.Client.Server
{
    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Server;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Server;
    using DD.CBU.Compute.Api.Contracts.Server;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The server accessor.
    /// </summary>
    public class ServerAccessor : IServerAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="ServerAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public ServerAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

		/// <summary>
		/// The get deployed servers.
		/// </summary>
		/// <param name="serverId">
		/// The server Id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="location">
		/// The location.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(
			string serverId,
			string name,
			string networkId,
			string location)
		{
			ServersWithBackup servers =
				await
				_apiClient.GetAsync<ServersWithBackup>(
					ApiUris.DeployedServers(_apiClient.OrganizationId, serverId, name, networkId, location));
			return servers.server;
		}

		/// <summary>
		/// The get deployed servers.
		/// </summary>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>		
		public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(
            ServerListOptions filteringOptions = null,
            IPageableRequest pagingOptions = null)
		{
			ServersWithBackup servers = await _apiClient.GetAsync<ServersWithBackup>(
                ApiUris.DeployedServers(_apiClient.OrganizationId),
                pagingOptions,
                filteringOptions);
			return servers.server;
		}

		/// <summary>
		/// The modify server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <param name="memory">
		/// The memory.
		/// </param>
		/// <param name="cpucount">
		/// The CPU count.
		/// </param>
		/// <param name="privateIp">
		/// The private IP.
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

			return await _apiClient.PostAsync<Status>(ApiUris.ModifyServer(_apiClient.OrganizationId, serverId), poststring);
		}

		/// <summary>
		/// Powers on the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>		
		public async Task<Status> ServerPowerOn(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.PowerOnServer(_apiClient.OrganizationId, serverId));
		}

		/// <summary>
		/// Powers off the server.
		/// </summary>
		/// <param name="serverId">
		/// Server Id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ServerPowerOff(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.PoweroffMcp1Server(_apiClient.OrganizationId, serverId));
		}


		/// <summary>
		/// Restart the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>	
		public async Task<Status> ServerRestart(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.RebootServer(_apiClient.OrganizationId, serverId));
		}

		/// <summary>	Power cycles an existing deployed server. This is the equivalent of pulling and replacing the power cord for
		/// a physical server. Requires your organization ID and the ID of the target server.. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	Returns a status of the HTTP request </returns>	
		public async Task<Status> ServerReset(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.ResetServer(_apiClient.OrganizationId, serverId));
		}

		/// <summary>
		/// Shutdown the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ServerShutdown(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.ShutdownServer(_apiClient.OrganizationId, serverId));
		}

		/// <summary>
		/// Modify server disk size.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <param name="sizeInGb">
		/// Size In GB.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>		
		public async Task<Status> ChangeServerDiskSize(string serverId, string diskId, string sizeInGb)
		{
			return
				await
				_apiClient.PostAsync<ChangeDiskSize, Status>(
					ApiUris.ChangeServerDiskSize(_apiClient.OrganizationId, serverId, diskId),
					new ChangeDiskSize
						{
							newSizeGb = sizeInGb
						});
		}

		/// <summary>
		/// Modify server disk speed.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <param name="speedId">
		/// Size in GB.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>		
		public async Task<Status> ChangeServerDiskSpeed(string serverId, string diskId, string speedId)
		{
			return
				await
				_apiClient.PostAsync<ChangeDiskSpeed, Status>(
					ApiUris.ChangeServerDiskSpeed(_apiClient.OrganizationId, serverId, diskId),
					new ChangeDiskSpeed
						{
							speed = speedId
						});
		}

		/// <summary>
		/// Add Disk to Server
		/// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="size">
		/// The size of the new disk
		/// </param>
		/// <param name="speedId">
		/// The speed Id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>		
		public async Task<Status> AddServerDisk(string serverId, string size, string speedId)
		{
			return await
				_apiClient.GetAsync<Status>(
					ApiUris.AddServerDisk(_apiClient.OrganizationId, serverId, size, speedId));
		}

		/// <summary>
		/// Modify server server settings.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		public async Task<Status> RemoveServerDisk(string serverId, string diskId)
		{
			return await
				_apiClient.GetAsync<Status>(
					ApiUris.RemoveServerDisk(_apiClient.OrganizationId, serverId, diskId));
		}
		/// <summary>
		/// Triggers an update of the VMWare Tools software running on the guest OS of a virtual server
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>		
		public async Task<Status> ServerUpdateVMwareTools(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.UpdateServerVMwareTools(_apiClient.OrganizationId, serverId));
		}

		/// <summary>
		/// Delete the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>		
		public async Task<Status> ServerDelete(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.DeleteServer(_apiClient.OrganizationId, serverId));
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
				_apiClient.GetAsync<Status>(ApiUris.CloneServerToCustomerImage(_apiClient.OrganizationId, serverId, imageName, imageDesc));
		}

		/// <summary>
		/// Deploy a server using an image in a specified network.
		/// </summary>
		/// <param name="name">
		/// The name of the new server.
		/// </param>
		/// <param name="description">
		/// The description of the new server.
		/// </param>
		/// <param name="networkId">
		/// The network id to deploy the server.
		/// </param>
		/// <param name="privateIp">
		/// The privateIp address to deploy the server.
		/// </param>
		/// <param name="imageId">
		/// The image id to deploy the server.
		/// </param>
		/// <param name="adminPassword">
		/// The administrator password.
		/// </param>
		/// <param name="start">
		/// Will the server powers on after deployment?
		/// </param>
		/// <param name="disk">
		/// Array od disk configurations
		/// </param>
		/// <returns>
		/// The status of the deployment.
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
				_apiClient.PostAsync<NewServerToDeployWithDiskSpeed, Status>(
					ApiUris.DeployServerWithDiskSpeed(_apiClient.OrganizationId),
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
				_apiClient.PostAsync<NewServerToDeployWithDiskSpeed, Status>(
					ApiUris.DeployServerWithDiskSpeed(_apiClient.OrganizationId),
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
		/// Creates a new Server Anti-Affinity Rule between two servers on the same Cloud network. 
		/// </summary>
		/// <param name="serverId1">
		/// The server Id for the 1'st server
		/// </param>
		/// <param name="serverId2">
		/// The server Id for the 2'nd server
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> CreateServerAntiAffinityRule(string serverId1, string serverId2)
		{
			return
				await
				_apiClient.PostAsync<NewAntiAffinityRule, Status>(
					ApiUris.CreateAntiAffinityRule(_apiClient.OrganizationId),
					new NewAntiAffinityRule
						{
							serverId = new[]
											{
												serverId1, serverId2
											}
						});
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
				_apiClient.GetAsync<AntiAffinityRules>(
					ApiUris.GetAntiAffinityRule(_apiClient.OrganizationId, ruleId, location, networkId));
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
			return await _apiClient.GetAsync<Status>(ApiUris.RemoveAntiAffinityRule(_apiClient.OrganizationId, ruleId));
		}
	}
}
