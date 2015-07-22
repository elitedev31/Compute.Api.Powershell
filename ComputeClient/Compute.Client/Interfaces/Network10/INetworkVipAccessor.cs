namespace DD.CBU.Compute.Api.Client.Interfaces.Network10
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Vip;

	/// <summary>
	/// The Vip interface.
	/// </summary>
	public interface INetworkVipAccessor
	{
		/// <summary>
		/// The get real servers.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<RealServer>> GetRealServers(string networkId);

		/// <summary>
		/// The create real server.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="inService">
		/// The in service.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> CreateRealServer(
			string networkId,
			string name,
			string serverId,
			bool inService);

		/// <summary>
		/// The remove real server.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="realServerId">
		/// The r server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveRealServer(string networkId, string realServerId);

		/// <summary>
		/// The modify real server.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="realServerId">
		/// The r server id.
		/// </param>
		/// <param name="inService">
		/// The in service.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ModifyRealServer(string networkId, string realServerId, bool inService);

		/// <summary>
		/// The get probes.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<Probe>> GetProbes(string networkId);

		/// <summary>
		/// The create probe.
		/// </summary>
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
		Task<Status> CreateProbe(
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
			string matchContent);

		/// <summary>
		/// The modify probe.
		/// </summary>
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
		Task<Status> ModifyProbe(
			string networkId,
			string probeId,
			int probeIntervalSeconds,
			int errorCountBeforeServerFail,
			int successCountBeforeServerEnable,
			int failedProbeIntervalSeconds,
			int maxReplyWaitSeconds);

		/// <summary>
		/// The remove probe.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="probeId">
		/// The probe id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveProbe(string networkId, string probeId);

		/// <summary>
		/// The get server farms.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<ServerFarm>> GetServerFarms(string networkId);

		/// <summary>
		/// The get server farm details.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<ServerFarmDetails> GetServerFarmDetails(string networkId, string serverFarmId);

		/// <summary>
		/// The create server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="predictor">
		/// The predictor.
		/// </param>
		/// <param name="realServerId">
		/// The r server id.
		/// </param>
		/// <param name="rServerPort">
		/// The r server port.
		/// </param>
		/// <param name="probeId">
		/// The probe id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> CreateServerFarm(
			string networkId,
			string name,
			ServerFarmPredictorType predictor,
			string realServerId,
			int rServerPort = 0,
			string probeId = null);

		/// <summary>
		/// The remove server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveServerFarm(string networkId, string serverFarmId);

		/// <summary>
		/// The modify server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="predictor">
		/// The predictor.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ModifyServerFarm(string networkId,
			string serverFarmId,
			ServerFarmPredictorType predictor);

		/// <summary>
		/// The add real server to server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="realServerId">
		/// The real server id.
		/// </param>
		/// <param name="realServerPort">
		/// The real server port.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> AddRealServerToServerFarm(
			string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0);

		/// <summary>
		/// The remove real server from server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="realServerId">
		/// The real server id.
		/// </param>
		/// <param name="realServerPort">
		/// The real server port.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveRealServerFromServerFarm(
			string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0);

		/// <summary>
		/// The add probe to server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="probeId">
		/// The probe id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> AddProbeToServerFarm(
			string networkId,
			string serverFarmId,
			string probeId);

		/// <summary>
		/// The remove probe from server farm.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="serverFarmId">
		/// The server farm id.
		/// </param>
		/// <param name="probeId">
		/// The probe id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveProbeFromServerFarm(string networkId, string serverFarmId, string probeId);

		/// <summary>
		/// The get persistence profile.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<PersistenceProfile>> GetPersistenceProfile(string networkId);

		/// <summary>
		/// The create persistence profile ip netmask.
		/// </summary>
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
		Task<Status> CreatePersistenceProfileIpNetmask(
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			PersistenceProfileDirection direction,
			string netmask);

		/// <summary>
		/// The create persistence profile http cookie.
		/// </summary>
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
		Task<Status> CreatePersistenceProfileHttpCookie(
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			string cookieName,
			PersistenceProfileCookieType cookieType);

		/// <summary>
		/// The remove persistence profile.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="persistenceProfileId">
		/// The pers profile id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemovePersistenceProfile(string networkId, string persistenceProfileId);

		/// <summary>
		/// The get vips.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<Vip>> GetVips(string networkId);

		/// <summary>
		/// The create vip.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="port">
		/// The port.
		/// </param>
		/// <param name="protocol">
		/// The protocol.
		/// </param>
		/// <param name="targetType">
		/// The target type.
		/// </param>
		/// <param name="targetId">
		/// The target id.
		/// </param>
		/// <param name="replyToIcmp">
		/// The reply to icmp.
		/// </param>
		/// <param name="inService">
		/// The in service.
		/// </param>
		/// <param name="ipAddress">
		/// The ip address.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> CreateVip(string networkId,
			string name,
			int port,
			VipProtocol protocol,
			VipTargetType targetType,
			string targetId,
			bool replyToIcmp,
			bool inService,
			string ipAddress = "");

		/// <summary>
		/// The remove vip.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="vipId">
		/// The vip id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveVip(string networkId, string vipId);

		/// <summary>
		/// The modify vip.
		/// </summary>
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
		Task<Status> ModifyVip(string networkId, string vipId, bool replyToIcmp, bool inService);
	}
}
