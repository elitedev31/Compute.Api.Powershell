namespace DD.CBU.Compute.Api.Client.Interfaces.Server10
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Server;

	/// <summary>
	/// The i server.
	/// </summary>
	public interface IServerAccessor
	{
		/// <summary>
		/// The get deployed servers.
		/// </summary>
		/// <param name="serverid">
		/// The serverid.
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
		Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(
			string serverid,
			string name,
			string networkId,
			string location);

		/// <summary>
		/// The get deployed servers.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<ServerWithBackupType>> GetDeployedServers();

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
		Task<Status> ModifyServer(string serverId, string name, string description, int memory, int cpucount, string privateIp);


		/// <summary>
		/// Powers on the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerPowerOn(string serverId);

		/// <summary>
		/// Powers off the server.
		/// </summary>
		/// <param name="serverId">
		/// Server Id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerPowerOff(string serverId);

		/// <summary>
		/// Restart the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerRestart(string serverId);

		/// <summary>	Power cycles an existing deployed server. This is the equivalent of pulling and replacing the power cord for
		/// a physical server. Requires your organization ID and the ID of the target server.. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	Returns a status of the HTTP request </returns>
		Task<Status> ServerReset(string serverId);

		/// <summary>
		/// Shutdown the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerShutdown(string serverId);


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
		Task<Status> ChangeServerDiskSize(string serverId, string diskId, string sizeInGb);


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
		Task<Status> ChangeServerDiskSpeed(string serverId, string diskId, string speedId);


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
		Task<Status> AddServerDisk(string serverId, string size, string speedId);


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
		Task<Status> RemoveServerDisk(string serverId, string diskId);


		/// <summary>
		/// Triggers an update of the VMWare Tools software running on the guest OS of a virtual server
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerUpdateVMwareTools(string serverId);


		/// <summary>
		/// Delete the server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ServerDelete(string serverId);


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
		Task<Status> ServerCloneToCustomerImage(string serverId, string imageName, string imageDesc);

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
		Task<Status> DeployServerWithDiskSpeedImageTask(
			string name,
			string description,
			string networkId,
			string privateIp,
			string imageId,
			string adminPassword,
			bool start,
			Disk[] disk
			);

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
		Task<Status> DeployServerWithDiskSpeedImageTask(
			string name,
			string description,
			string networkId,
			string privateIp,
			string imageId,
			string adminPassword,
			bool start
			);
	}
}
