using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Api.Client.VIP
{
    public static class ComputeApiVipExtensions
    {
        /// <summary>
        /// Gets the list of Real Servers from network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <returns>The networks</returns>
        public static async Task<IEnumerable<RealServer>> GetRealServers(this IComputeApiClient client,
            string networkId)
        {
            var realservers =
                await
                    client.WebApi.ApiGetAsync<RealServers>(
                        ApiUris.CreateOrGetVipRealServers(client.Account.OrganizationId, networkId));
            return realservers.Items ?? null; 
        }

        /// <summary>
        /// Gets the list of Real Servers from network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="name">the real server name</param>
        /// <param name="serverId">the server id</param>
        /// <param name="inService">in service</param>
        /// <returns></returns>
        public static async Task<Status> CreateRealServer(this IComputeApiClient client, string networkId,
            string name, string serverId, bool inService)
        {
            var status =
                await
                    client.WebApi.ApiPostAsync<NewRealServer, Status>(
                        ApiUris.CreateOrGetVipRealServers(client.Account.OrganizationId, networkId),
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
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="rServerId">the real server id</param>
        /// <returns>The networks</returns>
        public static async Task<Status> RemoveRealServer(this IComputeApiClient client,
           string networkId, string rServerId)
        {
            var status =
                await
                    client.WebApi.ApiGetAsync<Status>(
                        ApiUris.DeleteVipRealServers(client.Account.OrganizationId, networkId,rServerId));
            return status;
        }

        /// <summary>
        /// Modify a of Real Server on network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="rServerId">the real server id</param>
        /// <param name="inService">in service</param>
        /// <returns>The networks</returns>
        public static async Task<Status> ModifyRealServer(this IComputeApiClient client,
           string networkId, string rServerId,bool inService)
        {
             string poststring = "inService={0}";

            var status =
                await
                    client.WebApi.ApiPostAsync<Status>(
                        ApiUris.ModifyVipRealServers(client.Account.OrganizationId, networkId, rServerId), string.Format(poststring,inService.ToString()));
            return status;
        }

        /// <summary>
        /// Gets the list of Probes from network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <returns>The networks</returns>
        public static async Task<IEnumerable<Probe>> GetProbes(this IComputeApiClient client,
            string networkId)
        {
            var probes =
                await
                    client.WebApi.ApiGetAsync<Probes>(
                        ApiUris.CreateOrGetVipProbes(client.Account.OrganizationId, networkId));
            return probes.Items ?? null;
        }


        /// <summary>
        /// Create a probe on the network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="name">the real server name</param>
        /// <param name="failedProbeIntervalSeconds"></param>
        /// <param name="maxReplyWaitSeconds"></param>
        /// <param name="port"></param>
        /// <param name="probeIntervalSeconds"></param>
        /// <param name="type"></param>
        /// <param name="errorCountBeforeServerFail"></param>
        /// <param name="successCountBeforeServerEnable"></param>
        /// <param name="statusCodeLowerBound"></param>
        /// <param name="statusCodeUpperBound"></param>
        /// <param name="requestMethod"></param>
        /// <param name="requestUrl"></param>
        /// <param name="matchContent"></param>
        /// <returns></returns>
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


            var probe = new NewProbe()
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
                probe.statusCodeRange = new ProbeStatusCodeRange[] {new ProbeStatusCodeRange{ lowerBound = statusCodeLowerBound,upperBound = statusCodeUpperBound}};
                probe.requestMethod = requestMethod;
                probe.requestUrl = requestUrl;
                probe.matchContent = matchContent;

            }
            if (!port.Equals(0))
                probe.port = port.ToString(CultureInfo.InvariantCulture);


            var status =
                await
                    client.WebApi.ApiPostAsync<NewProbe, Status>(
                        ApiUris.CreateOrGetVipProbes(client.Account.OrganizationId, networkId),probe);

            return status;

        }

        /// <summary>
        /// Modify a Probe on network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="probeId"></param>
        /// <param name="probeIntervalSeconds"></param>
        /// <param name="errorCountBeforeServerFail"></param>
        /// <param name="successCountBeforeServerEnable"></param>
        /// <param name="failedProbeIntervalSeconds"></param>
        /// <param name="maxReplyWaitSeconds"></param>
        /// <returns>The networks</returns>
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
            var parameters = new NameValueCollection();
            if (probeIntervalSeconds>0)
                parameters.Add("probeIntervalSeconds", probeIntervalSeconds.ToString(CultureInfo.InvariantCulture));
            if (errorCountBeforeServerFail > 0)
                parameters.Add("errorCountBeforeServerFail", errorCountBeforeServerFail.ToString(CultureInfo.InvariantCulture));
            if (successCountBeforeServerEnable > 0)
                parameters.Add("successCountBeforeServerEnable", successCountBeforeServerEnable.ToString(CultureInfo.InvariantCulture));
            if (failedProbeIntervalSeconds > 0)
                parameters.Add("failedProbeIntervalSeconds", failedProbeIntervalSeconds.ToString(CultureInfo.InvariantCulture));
            if (maxReplyWaitSeconds > 0)
                parameters.Add("maxReplyWaitSeconds", maxReplyWaitSeconds.ToString(CultureInfo.InvariantCulture));

            // build the query string
            string poststring = parameters.ToQueryString();

            var status =
                await
                    client.WebApi.ApiPostAsync<Status>(
                        ApiUris.ModifyVipProbes(client.Account.OrganizationId, networkId, probeId), poststring);
            return status;
        }


        /// <summary>
        /// Delete a Probe from network VIP
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <param name="networkId">the network id</param>
        /// <param name="probeId">the probe id</param>
        /// <returns></returns>
        public static async Task<Status> RemoveProbe(this IComputeApiClient client,
           string networkId, string probeId)
        {
            var status =
                await
                    client.WebApi.ApiGetAsync<Status>(
                        ApiUris.DeleteVipProbes(client.Account.OrganizationId, networkId, probeId));
            return status;
        }

    }
}
