namespace DD.CBU.Compute.Api.Client.Network
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Network;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Vip;

	/// <summary>
	/// The vip.
	/// </summary>
	public class NetworkVipAccessor : INetworkVipAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="NetworkVipAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public NetworkVipAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

		/// <summary>
		/// The get real servers.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<RealServer>> GetRealServers(string networkId)
		{
			RealServers realservers =
				await
					this._apiClient.GetAsync<RealServers>(
						ApiUris.CreateOrGetVipRealServers(this._apiClient.OrganizationId, networkId));
			return realservers.Items ?? null;
		}

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
		public async Task<Status> CreateRealServer(string networkId, string name, string serverId, bool inService)
		{
			Status status =
				await
				this._apiClient.PostAsync<NewRealServer, Status>(
					ApiUris.CreateOrGetVipRealServers(this._apiClient.OrganizationId, networkId),
					new NewRealServer
						{
							name = name,
							serverId = serverId,
							inService = inService.ToString()
												.ToLower()
						});

			return status;
		}

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
		public async Task<Status> RemoveRealServer(string networkId, string realServerId)
		{
			Status status =
				await
					this._apiClient.GetAsync<Status>(
						ApiUris.DeleteVipRealServers(this._apiClient.OrganizationId, networkId, realServerId));
			return status;
		}

		/// <summary>
		/// The modify real server.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <param name="rServerId">
		/// The r server id.
		/// </param>
		/// <param name="inService">
		/// The in service.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> ModifyRealServer(string networkId, string rServerId, bool inService)
		{
			const string poststring = "inService={0}";

			Status status =
				await
					this._apiClient.PostAsync<Status>(
						ApiUris.ModifyVipRealServers(this._apiClient.OrganizationId, networkId, rServerId),
						string.Format(poststring, inService));
			return status;
		}

		/// <summary>
		/// The get probes.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<Probe>> GetProbes(string networkId)
		{
			Probes probes =
				await
					this._apiClient.GetAsync<Probes>(
						ApiUris.CreateOrGetVipProbes(this._apiClient.OrganizationId, networkId));
			return probes.Items ?? null;
		}

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
		public async Task<Status> CreateProbe(string networkId,
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
			var probe = new NewProbe
			{
				name = name,
				type = type,
				probeIntervalSeconds = probeIntervalSeconds.ToString(CultureInfo.InvariantCulture),
				errorCountBeforeServerFail = errorCountBeforeServerFail.ToString(CultureInfo.InvariantCulture),
				successCountBeforeServerEnable = successCountBeforeServerEnable.ToString(CultureInfo.InvariantCulture),
				failedProbeIntervalSeconds = failedProbeIntervalSeconds.ToString(CultureInfo.InvariantCulture),
				maxReplyWaitSeconds = maxReplyWaitSeconds.ToString(CultureInfo.InvariantCulture),
			};
			if (type.Equals(ProbeType.HTTP) || type.Equals(ProbeType.HTTPS))
			{
				probe.statusCodeRange = new[]
											{
												new ProbeStatusCodeRange
													{
														lowerBound = statusCodeLowerBound,
														upperBound = statusCodeUpperBound
													}
											};
				probe.requestMethod = requestMethod;
				probe.requestUrl = requestUrl;
				probe.matchContent = matchContent;
			}

			if (!port.Equals(0))
				probe.port = port.ToString(CultureInfo.InvariantCulture);


			Status status =
				await
					this._apiClient.PostAsync<NewProbe, Status>(
						ApiUris.CreateOrGetVipProbes(this._apiClient.OrganizationId, networkId), probe);

			return status;
		}

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
		public async Task<Status> ModifyProbe(string networkId,
			string probeId,
			int probeIntervalSeconds,
			int errorCountBeforeServerFail,
			int successCountBeforeServerEnable,
			int failedProbeIntervalSeconds,
			int maxReplyWaitSeconds
			)
		{
			var parameters = new Dictionary<string, string>();
			if (probeIntervalSeconds > 0)
				parameters.Add("probeIntervalSeconds", probeIntervalSeconds.ToString(CultureInfo.InvariantCulture));
			if (errorCountBeforeServerFail > 0)
				parameters.Add("errorCountBeforeServerFail", errorCountBeforeServerFail.ToString(CultureInfo.InvariantCulture));
			if (successCountBeforeServerEnable > 0)
				parameters.Add("successCountBeforeServerEnable",
					successCountBeforeServerEnable.ToString(CultureInfo.InvariantCulture));
			if (failedProbeIntervalSeconds > 0)
				parameters.Add("failedProbeIntervalSeconds", failedProbeIntervalSeconds.ToString(CultureInfo.InvariantCulture));
			if (maxReplyWaitSeconds > 0)
				parameters.Add("maxReplyWaitSeconds", maxReplyWaitSeconds.ToString(CultureInfo.InvariantCulture));

			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
					this._apiClient.PostAsync<Status>(
						ApiUris.ModifyVipProbes(this._apiClient.OrganizationId, networkId, probeId), poststring);
			return status;
		}

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
		public async Task<Status> RemoveProbe(string networkId, string probeId)
		{
			Status status =
				await
					this._apiClient.GetAsync<Status>(
						ApiUris.DeleteVipProbes(this._apiClient.OrganizationId, networkId, probeId));
			return status;
		}

		/// <summary>
		/// The get server farms.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<ServerFarm>> GetServerFarms(string networkId)
		{
			ServerFarms serverfarms =
				await
					this._apiClient.GetAsync<ServerFarms>(
						ApiUris.CreateOrGetVipServerFarm(this._apiClient.OrganizationId, networkId));
			return serverfarms.Items ?? null;
		}

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
		public async Task<ServerFarmDetails> GetServerFarmDetails(string networkId,
			string serverFarmId)
		{
			ServerFarmDetails serverfarm =
				await
					this._apiClient.GetAsync<ServerFarmDetails>(
						ApiUris.GetVipServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId));
			return serverfarm ?? null;
		}

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
		/// <param name="rServerId">
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
		public async Task<Status> CreateServerFarm(
			string networkId,
			string name,
			ServerFarmPredictorType predictor,
			string rServerId,
			int rServerPort = 0,
			string probeId = null)
		{
			var newserverfarm = new NewServerFarm
			{
				name = name,
				predictor = predictor,
			};
			var realserver = new NewServerFarmRealServer { id = rServerId };
			if (rServerPort > 0)
				realserver.port = rServerPort.ToString(CultureInfo.InvariantCulture);

			newserverfarm.realServer = new[] { realserver };
			if (!string.IsNullOrEmpty(probeId))
				newserverfarm.probeId = probeId;


			Status status =
				await
					this._apiClient.PostAsync<NewServerFarm, Status>(
						ApiUris.CreateOrGetVipServerFarm(this._apiClient.OrganizationId, networkId), newserverfarm);

			return status;
		}

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
		public async Task<Status> RemoveServerFarm(string networkId, string serverFarmId)
		{
			Status status =
				await
					this._apiClient.GetAsync<Status>(
						ApiUris.DeleteVipServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId));
			return status;
		}

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
		public async Task<Status> ModifyServerFarm(string networkId, string serverFarmId, ServerFarmPredictorType predictor)
		{
			var parameters = new Dictionary<string, string>
								{
									{
										"predictor", predictor.ToString()
									}
								};

			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
				this._apiClient.PostAsync<Status>(
					ApiUris.GetVipServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId),
					poststring);
			return status;
		}

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
		public async Task<Status> AddRealServerToServerFarm(string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0
			)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(realServerId))
				parameters.Add("realServerId", realServerId);
			if (realServerPort > 0)
				parameters.Add("realServerPort", realServerPort.ToString(CultureInfo.InvariantCulture));


			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
					this._apiClient.PostAsync<Status>(
						ApiUris.AddVipRealServerToServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId), poststring);
			return status;
		}

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
		public async Task<Status> RemoveRealServerFromServerFarm(
			string networkId,
			string serverFarmId,
			string realServerId,
			int realServerPort = 0)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(realServerId))
				parameters.Add("realServerId", realServerId);
			if (realServerPort > 0)
				parameters.Add("realServerPort", realServerPort.ToString(CultureInfo.InvariantCulture));


			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
				this._apiClient.PostAsync<Status>(
					ApiUris.RemoveVipRealServerFromServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId),
					poststring);
			return status;
		}

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
		public async Task<Status> AddProbeToServerFarm(string networkId, string serverFarmId, string probeId)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(probeId))
				parameters.Add("probeId", probeId);

			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
				this._apiClient.PostAsync<Status>(
					ApiUris.AddVipProbeToServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId),
					poststring);
			return status;
		}

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
		public async Task<Status> RemoveProbeFromServerFarm(string networkId, string serverFarmId, string probeId)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(probeId))
				parameters.Add("probeId", probeId);

			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
				this._apiClient.PostAsync<Status>(
					ApiUris.RemoveVipProbeFromServerFarm(this._apiClient.OrganizationId, networkId, serverFarmId),
					poststring);
			return status;
		}

		/// <summary>
		/// The get persistence profile.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<PersistenceProfile>> GetPersistenceProfile(string networkId)
		{
			PersistenceProfiles persprofile =
				await
					this._apiClient.GetAsync<PersistenceProfiles>(
						ApiUris.CreateOrGetVipPersistenceProfile(this._apiClient.OrganizationId, networkId));
			return persprofile.Items ?? null;
		}

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
		public async Task<Status> CreatePersistenceProfileIpNetmask(
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			PersistenceProfileDirection direction,
			string netmask)
		{
			var persProfile = new NewPersistenceProfile
								{
									name = name,
									serverFarmId = serverFarmId,
									timeoutMinutes = timeOutMinutes.ToString(CultureInfo.InvariantCulture),
									type = PersistenceProfileType.IP_NETMASK,
									direction = direction.ToString(),
									netmask = netmask
								};


			Status status =
				await
				this._apiClient.PostAsync<NewPersistenceProfile, Status>(
					ApiUris.CreateOrGetVipPersistenceProfile(this._apiClient.OrganizationId, networkId),
					persProfile);
			return status;
		}

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
		public async Task<Status> CreatePersistenceProfileHttpCookie(
			string networkId,
			string name,
			string serverFarmId,
			int timeOutMinutes,
			string cookieName,
			PersistenceProfileCookieType cookieType)
		{
			var persProfile = new NewPersistenceProfile
								{
									name = name,
									serverFarmId = serverFarmId,
									timeoutMinutes = timeOutMinutes.ToString(CultureInfo.InvariantCulture),
									type = PersistenceProfileType.HTTP_COOKIE,
									cookieName = cookieName,
									cookieType = cookieType.ToString()
								};


			Status status =
				await
				this._apiClient.PostAsync<NewPersistenceProfile, Status>(
					ApiUris.CreateOrGetVipPersistenceProfile(this._apiClient.OrganizationId, networkId),
					persProfile);
			return status;
		}

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
		public async Task<Status> RemovePersistenceProfile(string networkId, string persistenceProfileId)
		{
			Status status =
				await
					this._apiClient.GetAsync<Status>(
						ApiUris.DeleteVipPersistenceProfile(this._apiClient.OrganizationId, networkId, persistenceProfileId));
			return status;
		}

		/// <summary>
		/// The get vips.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<Contracts.Vip.Vip>> GetVips(string networkId)
		{
			Vips vips =
				await
					this._apiClient.GetAsync<Vips>(
						ApiUris.CreateOrGetVip(this._apiClient.OrganizationId, networkId));
			return vips.Items ?? null;
		}

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
		public async Task<Status> CreateVip(
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
			var vip = new NewVip
			{
				name = name,
				port = port.ToString(CultureInfo.InvariantCulture),
				protocol = protocol.ToString(),
				vipTargetType = targetType.ToString(),
				vipTargetId = targetId,
				replyToIcmp = replyToIcmp.ToString(CultureInfo.InvariantCulture).ToLower(),
				inService = inService.ToString(CultureInfo.InvariantCulture).ToLower(),
			};
			if (!string.IsNullOrEmpty(ipAddress))
				vip.ipAddress = ipAddress;

			Status status =
				await
					this._apiClient.PostAsync<NewVip, Status>(
						ApiUris.CreateOrGetVip(this._apiClient.OrganizationId, networkId), vip);
			return status;
		}

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
		public async Task<Status> RemoveVip(string networkId, string vipId)
		{
			Status status =
				await
					this._apiClient.GetAsync<Status>(
						ApiUris.DeleteVip(this._apiClient.OrganizationId, networkId, vipId));
			return status;
		}

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
		public async Task<Status> ModifyVip(string networkId, string vipId, bool replyToIcmp, bool inService)
		{
			var parameters = new Dictionary<string, string>
								{
									{
										"inService", inService.ToString(CultureInfo.InvariantCulture)
															.ToLower()
									},
									{
										"replyToIcmp", replyToIcmp.ToString(CultureInfo.InvariantCulture)
																.ToLower()
									}
								};
			string poststring = parameters.ToQueryString();

			Status status =
				await
					this._apiClient.PostAsync<Status>(
						ApiUris.ModifyVip(this._apiClient.OrganizationId, networkId, vipId), poststring);
			return status;
		}
	}
}
