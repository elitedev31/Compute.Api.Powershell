using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Api.Client.VIP
{
	/// <summary>
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
		public static async Task<IEnumerable<RealServer>> GetRealServers(this IComputeApiClient client, 
			string networkId)
		{
			RealServers realservers =
				await
					client.WebApi.GetAsync<RealServers>(
						ApiUris.CreateOrGetVipRealServers(client.WebApi.OrganizationId, networkId));
			return realservers.Items ?? null;
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
		public static async Task<Status> CreateRealServer(this IComputeApiClient client, string networkId, 
			string name, string serverId, bool inService)
		{
			Status status =
				await
					client.WebApi.PostAsync<NewRealServer, Status>(
						ApiUris.CreateOrGetVipRealServers(client.WebApi.OrganizationId, networkId), 
						new NewRealServer
						{
							name = name, 
							serverId = serverId, 
							inService = inService.ToString().ToLower()
						}
						);

			return status;
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
		/// <param name="rServerId">
		/// The real server id
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		public static async Task<Status> RemoveRealServer(this IComputeApiClient client, 
			string networkId, string rServerId)
		{
			Status status =
				await
					client.WebApi.GetAsync<Status>(
						ApiUris.DeleteVipRealServers(client.WebApi.OrganizationId, networkId, rServerId));
			return status;
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
		/// <param name="rServerId">
		/// The real server id
		/// </param>
		/// <param name="inService">
		/// In service
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		public static async Task<Status> ModifyRealServer(this IComputeApiClient client, 
			string networkId, string rServerId, bool inService)
		{
			const string poststring = "inService={0}";

			Status status =
				await
					client.WebApi.PostAsync<Status>(
						ApiUris.ModifyVipRealServers(client.WebApi.OrganizationId, networkId, rServerId), 
						string.Format(poststring, inService));
			return status;
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
		public static async Task<IEnumerable<Probe>> GetProbes(this IComputeApiClient client, 
			string networkId)
		{
			Probes probes =
				await
					client.WebApi.GetAsync<Probes>(
						ApiUris.CreateOrGetVipProbes(client.WebApi.OrganizationId, networkId));
			return probes.Items ?? null;
		}


		/// <summary>
		/// Create a probe on the network VIP
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
		/// <param name="type">
		/// </param>
		/// <param name="port">
		/// </param>
		/// <param name="probeIntervalSeconds">
		/// </param>
		/// <param name="errorCountBeforeServerFail">
		/// </param>
		/// <param name="successCountBeforeServerEnable">
		/// </param>
		/// <param name="failedProbeIntervalSeconds">
		/// </param>
		/// <param name="maxReplyWaitSeconds">
		/// </param>
		/// <param name="statusCodeLowerBound">
		/// </param>
		/// <param name="statusCodeUpperBound">
		/// </param>
		/// <param name="requestMethod">
		/// </param>
		/// <param name="requestUrl">
		/// </param>
		/// <param name="matchContent">
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
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
       new ProbeStatusCodeRange {lowerBound = statusCodeLowerBound, upperBound = statusCodeUpperBound}
    };
				probe.requestMethod = requestMethod;
				probe.requestUrl = requestUrl;
				probe.matchContent = matchContent;
			}

			if (!port.Equals(0))
				probe.port = port.ToString(CultureInfo.InvariantCulture);


			Status status =
				await
					client.WebApi.PostAsync<NewProbe, Status>(
						ApiUris.CreateOrGetVipProbes(client.WebApi.OrganizationId, networkId), probe);

			return status;
		}

		/// <summary>
		/// Modify a Probe on network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="probeId">
		/// </param>
		/// <param name="probeIntervalSeconds">
		/// </param>
		/// <param name="errorCountBeforeServerFail">
		/// </param>
		/// <param name="successCountBeforeServerEnable">
		/// </param>
		/// <param name="failedProbeIntervalSeconds">
		/// </param>
		/// <param name="maxReplyWaitSeconds">
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
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
					client.WebApi.PostAsync<Status>(
						ApiUris.ModifyVipProbes(client.WebApi.OrganizationId, networkId, probeId), poststring);
			return status;
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
		public static async Task<Status> RemoveProbe(this IComputeApiClient client, 
			string networkId, string probeId)
		{
			Status status =
				await
					client.WebApi.GetAsync<Status>(
						ApiUris.DeleteVipProbes(client.WebApi.OrganizationId, networkId, probeId));
			return status;
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
		public static async Task<IEnumerable<ServerFarm>> GetServerFarms(this IComputeApiClient client, string networkId)
		{
			ServerFarms serverfarms =
				await
					client.WebApi.GetAsync<ServerFarms>(
						ApiUris.CreateOrGetVipServerFarm(client.WebApi.OrganizationId, networkId));
			return serverfarms.Items ?? null;
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
		public static async Task<ServerFarmDetails> GetServerFarmDetails(this IComputeApiClient client, string networkId, 
			string serverFarmId)
		{
			ServerFarmDetails serverfarm =
				await
					client.WebApi.GetAsync<ServerFarmDetails>(
						ApiUris.GetVipServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId));
			return serverfarm ?? null;
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
		/// <param name="rServerId">
		/// The first real server Id
		/// </param>
		/// <param name="rServerPort">
		/// The first real server port 
		/// </param>
		/// <param name="probeId">
		/// The probe id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task<Status> CreateServerFarm(this IComputeApiClient client, string networkId, string name, 
			ServerFarmPredictorType predictor, string rServerId, int rServerPort = 0, string probeId = null)
		{
			var newserverfarm = new NewServerFarm
			{
				name = name, 
				predictor = predictor, 
			};
			var realserver = new NewServerFarmRealServer {id = rServerId};
			if (rServerPort > 0)
				realserver.port = rServerPort.ToString(CultureInfo.InvariantCulture);

			newserverfarm.realServer = new[] {realserver};
			if (!string.IsNullOrEmpty(probeId))
				newserverfarm.probeId = probeId;


			Status status =
				await
					client.WebApi.PostAsync<NewServerFarm, Status>(
						ApiUris.CreateOrGetVipServerFarm(client.WebApi.OrganizationId, networkId), newserverfarm);


			return status;
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
		public static async Task<Status> RemoveServerFarm(this IComputeApiClient client, 
			string networkId, string serverFarmId)
		{
			Status status =
				await
					client.WebApi.GetAsync<Status>(
						ApiUris.DeleteVipServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId));
			return status;
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
		public static async Task<Status> ModifyServerFarm(this IComputeApiClient client, 
			string networkId, 
			string serverFarmId, 
			ServerFarmPredictorType predictor
			)
		{
			var parameters = new Dictionary<string, string> {{"predictor", predictor.ToString()}};


			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
					client.WebApi.PostAsync<Status>(
						ApiUris.GetVipServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId), poststring);
			return status;
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
		public static async Task<Status> AddRealServerToServerFarm(this IComputeApiClient client, 
			string networkId, 
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
					client.WebApi.PostAsync<Status>(
						ApiUris.AddVipRealServerToServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId), poststring);
			return status;
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
		public static async Task<Status> RemoveRealServerFromServerFarm(this IComputeApiClient client, 
			string networkId, 
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
					client.WebApi.PostAsync<Status>(
						ApiUris.RemoveVipRealServerFromServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId), poststring);
			return status;
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
		public static async Task<Status> AddProbeToServerFarm(this IComputeApiClient client, 
			string networkId, 
			string serverFarmId, 
			string probeId
			)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(probeId))
				parameters.Add("probeId", probeId);


			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
					client.WebApi.PostAsync<Status>(
						ApiUris.AddVipProbeToServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId), poststring);
			return status;
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
		public static async Task<Status> RemoveProbeFromServerFarm(this IComputeApiClient client, 
			string networkId, 
			string serverFarmId, 
			string probeId
			)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(probeId))
				parameters.Add("probeId", probeId);


			// build the query string
			string poststring = parameters.ToQueryString();

			Status status =
				await
					client.WebApi.PostAsync<Status>(
						ApiUris.RemoveVipProbeFromServerFarm(client.WebApi.OrganizationId, networkId, serverFarmId), poststring);
			return status;
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
		public static async Task<IEnumerable<PersistenceProfile>> GetPersistenceProfile(this IComputeApiClient client, 
			string networkId)
		{
			PersistenceProfiles persprofile =
				await
					client.WebApi.GetAsync<PersistenceProfiles>(
						ApiUris.CreateOrGetVipPersistenceProfile(client.WebApi.OrganizationId, networkId));
			return persprofile.Items ?? null;
		}


		/// <summary>
		/// Create a IP Netmask persistence profile for network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="name">
		/// </param>
		/// <param name="serverFarmId">
		/// </param>
		/// <param name="timeOutMinutes">
		/// </param>
		/// <param name="direction">
		/// </param>
		/// <param name="netmask">
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task<Status> CreatePersistenceProfileIpNetmask(this IComputeApiClient client, string networkId, 
			string name, string serverFarmId, int timeOutMinutes, PersistenceProfileDirection direction, string netmask)
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
					client.WebApi.PostAsync<NewPersistenceProfile, Status>(
						ApiUris.CreateOrGetVipPersistenceProfile(client.WebApi.OrganizationId, networkId), persProfile);
			return status;
		}


		/// <summary>
		/// Create a HttpCookie persistence profile for network VIP
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id
		/// </param>
		/// <param name="name">
		/// </param>
		/// <param name="serverFarmId">
		/// </param>
		/// <param name="timeOutMinutes">
		/// </param>
		/// <param name="cookieName">
		/// </param>
		/// <param name="cookieType">
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task<Status> CreatePersistenceProfileHttpCookie(this IComputeApiClient client, string networkId, 
			string name, string serverFarmId, int timeOutMinutes, string cookieName, PersistenceProfileCookieType cookieType)
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
					client.WebApi.PostAsync<NewPersistenceProfile, Status>(
						ApiUris.CreateOrGetVipPersistenceProfile(client.WebApi.OrganizationId, networkId), persProfile);
			return status;
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
		/// <param name="persProfileId">
		/// The pers Profile Id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task<Status> RemovePersistenceProfile(this IComputeApiClient client, string networkId, 
			string persProfileId)
		{
			Status status =
				await
					client.WebApi.GetAsync<Status>(
						ApiUris.DeleteVipPersistenceProfile(client.WebApi.OrganizationId, networkId, persProfileId));
			return status;
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
		public static async Task<IEnumerable<Vip>> GetVips(this IComputeApiClient client, string networkId)
		{
			Vips vips =
				await
					client.WebApi.GetAsync<Vips>(
						ApiUris.CreateOrGetVip(client.WebApi.OrganizationId, networkId));
			return vips.Items ?? null;
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
		public static async Task<Status> CreateVip(this IComputeApiClient client, string networkId, string name, int port, 
			VipProtocol protocol, VipTargetType targetType, string targetId, bool replyToIcmp, bool inService, 
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
					client.WebApi.PostAsync<NewVip, Status>(
						ApiUris.CreateOrGetVip(client.WebApi.OrganizationId, networkId), vip);
			return status;
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
		public static async Task<Status> RemoveVip(this IComputeApiClient client, string networkId, string vipId)
		{
			Status status =
				await
					client.WebApi.GetAsync<Status>(
						ApiUris.DeleteVip(client.WebApi.OrganizationId, networkId, vipId));
			return status;
		}

		/// <summary>
		/// Set VIP from network VIP
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
		/// <param name="replyToIcmp">
		/// </param>
		/// <param name="inService">
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task<Status> ModifyVip(this IComputeApiClient client, string networkId, string vipId, 
			bool replyToIcmp, bool inService)
		{
			var parameters = new Dictionary<string, string>
			{
				{"inService", inService.ToString(CultureInfo.InvariantCulture).ToLower()}, 
				{"replyToIcmp", replyToIcmp.ToString(CultureInfo.InvariantCulture).ToLower()}
			};
			string poststring = parameters.ToQueryString();


			Status status =
				await
					client.WebApi.PostAsync<Status>(
						ApiUris.ModifyVip(client.WebApi.OrganizationId, networkId, vipId), poststring);
			return status;
		}
	}
}