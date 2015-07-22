// ReSharper disable once CheckNamespace
// backwards compatibility to support Existing clients
namespace DD.CBU.Compute.Api.Client.VIP
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Vip;

	/// <summary>
	/// The compute api vip extensions.
	/// </summary>
	public static class ComputeApiVipExtensions
	{
		/// <summary>
		/// Gets the list of Real Servers from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<IEnumerable<RealServer>> GetRealServers(this IComputeApiClient client, 
			string networkId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetRealServers(networkId);			
		}

		/// <summary>
		/// Gets the list of Real Servers from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="name">
		/// The real server name
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="inService">
		/// In service
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreateRealServer(
			this IComputeApiClient client,
			string networkId,
			string name,
			string serverId,
			bool inService)
		{
			return await client.NetworkingLegacy.NetworkVip.CreateRealServer(networkId, name, serverId, inService);		
		}

		/// <summary>
		/// Delete a of Real Servers from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="realServerId">
		/// The real server id
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveRealServer(
			this IComputeApiClient client,
			string networkId,
			string realServerId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemoveRealServer(networkId, realServerId);	
		}

		/// <summary>
		/// Modify a of Real Server on network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="realServerId">
		/// The real server id
		/// </param>
		/// <param name="inService">
		/// In service
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> ModifyRealServer(
			this IComputeApiClient client,
			string networkId,
			string realServerId,
			bool inService)
		{
			return await client.NetworkingLegacy.NetworkVip.ModifyRealServer(networkId, realServerId, inService);	
		}

		/// <summary>
		/// Gets the list of Probes from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<IEnumerable<Probe>> GetProbes(this IComputeApiClient client, 
			string networkId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetProbes(networkId);	
		}

		/// <summary>
		/// The create probe.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <param name="port">
		/// The port.
		/// </param>
		/// <param name="probeIntervalSeconds">
		/// The probe interval seconds.
		/// </param>
		/// <param name="errorCountBeforeServerFail">
		/// The error count before server fail.
		/// </param>
		/// <param name="successCountBeforeServerEnable">
		/// The success count before server enable.
		/// </param>
		/// <param name="failedProbeIntervalSeconds">
		/// The failed probe interval seconds.
		/// </param>
		/// <param name="maxReplyWaitSeconds">
		/// The max reply wait seconds.
		/// </param>
		/// <param name="statusCodeLowerBound">
		/// The status code lower bound.
		/// </param>
		/// <param name="statusCodeUpperBound">
		/// The status code upper bound.
		/// </param>
		/// <param name="requestMethod">
		/// The request method.
		/// </param>
		/// <param name="requestUrl">
		/// The request url.
		/// </param>
		/// <param name="matchContent">
		/// The match content.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreateProbe(this IComputeApiClient client, 
			string networkId, 
			string name, 
			ProbeType type, 
			int port, 
			int probeIntervalSeconds, 
			int errorCountBeforeServerFail, 
			int successCountBeforeServerEnable, 
			int failedProbeIntervalSeconds, 
			int maxReplyWaitSeconds, 
			int statusCodeLowerBound, 
			int statusCodeUpperBound, 
			ProbeRequestMethod requestMethod, 
			string requestUrl, 
			string matchContent)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.CreateProbe(
					networkId,
					name,
					type,
					port,
					probeIntervalSeconds,
					errorCountBeforeServerFail,
					successCountBeforeServerEnable,
					failedProbeIntervalSeconds,
					maxReplyWaitSeconds,
					statusCodeLowerBound,
					statusCodeUpperBound,
					requestMethod,
					requestUrl,
					matchContent);
		}

		/// <summary>
		/// The modify probe.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="probeId">
		/// The probe id.
		/// </param>
		/// <param name="probeIntervalSeconds">
		/// The probe interval seconds.
		/// </param>
		/// <param name="errorCountBeforeServerFail">
		/// The error count before server fail.
		/// </param>
		/// <param name="successCountBeforeServerEnable">
		/// The success count before server enable.
		/// </param>
		/// <param name="failedProbeIntervalSeconds">
		/// The failed probe interval seconds.
		/// </param>
		/// <param name="maxReplyWaitSeconds">
		/// The max reply wait seconds.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> ModifyProbe(this IComputeApiClient client, 
			string networkId, 
			string probeId, 
			int probeIntervalSeconds, 
			int errorCountBeforeServerFail, 
			int successCountBeforeServerEnable, 
			int failedProbeIntervalSeconds, 
			int maxReplyWaitSeconds
			)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.ModifyProbe(
					networkId,
					probeId,
					probeIntervalSeconds,
					errorCountBeforeServerFail,
					successCountBeforeServerEnable,
					failedProbeIntervalSeconds,
					maxReplyWaitSeconds);
		}


		/// <summary>
		/// Delete a Probe from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveProbe(this IComputeApiClient client, string networkId, string probeId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemoveProbe(networkId, probeId);
		}

		/// <summary>
		/// List all server farms from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<IEnumerable<ServerFarm>> GetServerFarms(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetServerFarms(networkId);
		}


		/// <summary>
		/// Get server farm details from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<ServerFarmDetails> GetServerFarmDetails(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetServerFarmDetails(networkId, serverFarmId);
		}

		/// <summary>
		/// Create a server farm from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="name">
		/// The server farm name
		/// </param>
		/// <param name="predictor">
		/// The server farm predictor
		/// </param>
		/// <param name="realServerId">
		/// The first real server Id
		/// </param>
		/// <param name="realServerPort">
		/// The first real server port 
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreateServerFarm(
			this IComputeApiClient client,
			string networkId,
			string name,
			ServerFarmPredictorType predictor,
			string realServerId,
			int realServerPort = 0,
			string probeId = null)
		{
			return await client.NetworkingLegacy.NetworkVip.CreateServerFarm(networkId,
			 name,
			 predictor,
			 realServerId,
			 realServerPort,
			 probeId);
		}


		/// <summary>
		/// Delete a ServerFarm from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemoveServerFarm(networkId, serverFarmId);
		}


		/// <summary>
		/// Modify a  ServerFarm
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <param name="predictor">
		/// Either LEAST_CONNECTIONS or ROUND_ROBIN 
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> ModifyServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId,
			ServerFarmPredictorType predictor)
		{
			return await client.NetworkingLegacy.NetworkVip.ModifyServerFarm(networkId, serverFarmId, predictor);
		}

		/// <summary>
		/// Adds a Real Server to ServerFarm
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <param name="realServerId">
		/// The real server id
		/// </param>
		/// <param name="realServerPort">
		/// The real server port
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> AddRealServerToServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.AddRealServerToServerFarm(networkId, serverFarmId, realServerId, realServerPort);
		}

		/// <summary>
		/// Removes a Real Server to ServerFarm
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <param name="realServerId">
		/// The real server id
		/// </param>
		/// <param name="realServerPort">
		/// The real server port
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveRealServerFromServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.RemoveRealServerFromServerFarm(
					networkId,
					serverFarmId,
					realServerId,
					realServerPort);
		}

		/// <summary>
		/// Adds a Probe to ServerFarm
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> AddProbeToServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId,
			string probeId)
		{
			return await client.NetworkingLegacy.NetworkVip.AddProbeToServerFarm(networkId, serverFarmId, probeId);
		}

		/// <summary>
		/// Removes a Probe to ServerFarm
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveProbeFromServerFarm(
			this IComputeApiClient client,
			string networkId,
			string serverFarmId,
			string probeId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemoveProbeFromServerFarm(networkId, serverFarmId, probeId);
		}


		/// <summary>
		/// Get persistence profile  from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<IEnumerable<PersistenceProfile>> GetPersistenceProfile(this IComputeApiClient client, 
			string networkId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetPersistenceProfile(networkId);
		}

		/// <summary>
		/// Create a IP Netmask persistence profile for network VIP.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="timeOutMinutes">
		/// The time out minutes.
		/// </param>
		/// <param name="direction">
		/// The direction.
		/// </param>
		/// <param name="netmask">
		/// The netmask.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreatePersistenceProfileIpNetmask(
			this IComputeApiClient client,
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			PersistenceProfileDirection direction,
			string netmask)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.CreatePersistenceProfileIpNetmask(
					networkId,
					name,
					serverFarmId,
					timeOutMinutes,
					direction,
					netmask);
		}

		/// <summary>
		/// The create persistence profile http cookie.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="timeOutMinutes">
		/// The time out minutes.
		/// </param>
		/// <param name="cookieName">
		/// The cookie name.
		/// </param>
		/// <param name="cookieType">
		/// The cookie type.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreatePersistenceProfileHttpCookie(
			this IComputeApiClient client,
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			string cookieName,
			PersistenceProfileCookieType cookieType)
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.CreatePersistenceProfileHttpCookie(
					networkId,
					name,
					serverFarmId,
					timeOutMinutes,
					cookieName,
					cookieType);
		}

		/// <summary>
		/// Get persistence profile  from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="persistenceProfileId">
		/// The pers Profile Id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemovePersistenceProfile(
			this IComputeApiClient client,
			string networkId,
			string persistenceProfileId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemovePersistenceProfile(networkId, persistenceProfileId);
		}


		/// <summary>
		/// Get VIPs from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<IEnumerable<Vip>> GetVips(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.NetworkVip.GetVips(networkId);
		}

		/// <summary>
		/// Create a VIPs from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="name">
		/// The name
		/// </param>
		/// <param name="port">
		/// The vip port
		/// </param>
		/// <param name="protocol">
		/// The vip protocol
		/// </param>
		/// <param name="targetType">
		/// The tartget type
		/// </param>
		/// <param name="targetId">
		/// The target id
		/// </param>
		/// <param name="replyToIcmp">
		/// Reply to icmp
		/// </param>
		/// <param name="inService">
		/// In service
		/// </param>
		/// <param name="ipAddress">
		/// Optional ip address
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> CreateVip(
			this IComputeApiClient client,
			string networkId,
			string name,
			int port,
			VipProtocol protocol,
			VipTargetType targetType,
			string targetId,
			bool replyToIcmp,
			bool inService,
			string ipAddress = "")
		{
			return
				await
				client.NetworkingLegacy.NetworkVip.CreateVip(
					networkId,
					name,
					port,
					protocol,
					targetType,
					targetId,
					replyToIcmp,
					inService,
					ipAddress);
		}


		/// <summary>
		/// Delete VIP  from network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="vipId">
		/// The vip id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> RemoveVip(this IComputeApiClient client, string networkId, string vipId)
		{
			return await client.NetworkingLegacy.NetworkVip.RemoveVip(networkId, vipId);
		}

		/// <summary>
		/// The modify vip.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="vipId">
		/// The vip id.
		/// </param>
		/// <param name="replyToIcmp">
		/// The reply to icmp.
		/// </param>
		/// <param name="inService">
		/// The in service.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.NetworkVip instead")]
		public static async Task<Status> ModifyVip(
			this IComputeApiClient client,
			string networkId,
			string vipId,
			bool replyToIcmp,
			bool inService)
		{
			return await client.NetworkingLegacy.NetworkVip.ModifyVip(networkId, vipId, replyToIcmp, inService);
		}
	}
}