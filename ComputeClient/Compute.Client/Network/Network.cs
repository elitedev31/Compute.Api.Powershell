namespace DD.CBU.Compute.Api.Client.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Network;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network;

    /// <summary>
    /// The networking legacy.
    /// </summary>
    public class NetworkAccessor : INetworkAccessor
    {
        /// <summary>
        /// The Api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="NetworkAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public NetworkAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// The create network.
        /// </summary>
        /// <param name="networkName">
        /// The network name.
        /// </param>
        /// <param name="dataCentreLocation">
        /// The data centre location.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> CreateNetwork(string networkName, string dataCentreLocation, string description = null)
        {
            return
                await
                _apiClient.PostAsync<NewNetworkWithLocationType, Status>(
                    ApiUris.CreateNetwork(_apiClient.OrganizationId),
                    new NewNetworkWithLocationType
                    {
                        name = networkName,
                        location = dataCentreLocation,
                        description = description
                    });
        }

        /// <summary>
        /// The get networks task.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworks()
        {
            NetworkWithLocations networks =
                await _apiClient.GetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocations(_apiClient.OrganizationId));
            return networks.Items;
        }

        /// <summary>
        /// The get networks task.
        /// </summary>
        /// <param name="locationId">
        /// The identifier of the location to get the networks from.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworks(string locationId)
        {
            NetworkWithLocations networks =
                await _apiClient.GetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocation(_apiClient.OrganizationId, locationId));
            return networks.Items;
        }

        /// <summary>
        /// The delete network.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> DeleteNetwork(string networkId)
        {
            return
                await _apiClient.GetAsync<Status>(ApiUris.DeleteNetwork(_apiClient.OrganizationId, networkId));
        }

        /// <summary>
        /// The modify network.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> ModifyNetwork(string networkId, string name, string description)
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                parameters.Add("name", name);
            parameters.Add("description", description);

            // build the query string
            string poststring = parameters.ToQueryStringWithEmpty();

            return
                await
                    _apiClient.PostAsync<Status>(ApiUris.ModifyNetwork(_apiClient.OrganizationId, networkId), poststring);
        }

        /// <summary>
        /// The get network config.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<NetworkConfigurationType> GetNetworkConfig(string networkId)
        {
            return
                await
                    _apiClient.GetAsync<NetworkConfigurationType>(ApiUris.GetNetworkConfig(_apiClient.OrganizationId,
                        networkId));
        }

        /// <summary>
        /// The get nat rules.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<NatRuleType>> GetNatRules(string networkId)
        {
            NatRules natRules =
                await _apiClient.GetAsync<NatRules>(ApiUris.GetNatRules(_apiClient.OrganizationId, networkId));

            return natRules.NatRule;
        }

        /// <summary>
        /// The delete nat rule.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="natRuleId">
        /// The nat rule id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> DeleteNatRule(string networkId, string natRuleId)
        {
            return
                await
                    _apiClient.GetAsync<Status>(
                        ApiUris.DeleteNatRule(_apiClient.OrganizationId, networkId, natRuleId));
        }

        /// <summary>
        /// The create nat rule.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="natRuleName">
        /// The nat rule name.
        /// </param>
        /// <param name="sourceIp">
        /// The source ip.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<NatRuleType> CreateNatRule(string networkId, string natRuleName, IPAddress sourceIp)
        {
            return
                await
                _apiClient.PostAsync<NatRuleType, NatRuleType>(
                    ApiUris.CreateNatRule(_apiClient.OrganizationId, networkId),
                    new NatRuleType
                    {
                        name = natRuleName,
                        sourceIp = sourceIp.ToString()
                    });
        }

        /// <summary>
        /// The create acl rule.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="aclRuleName">
        /// The acl rule name.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="protocol">
        /// The protocol.
        /// </param>
        /// <param name="portRangeType">
        /// The port range type.
        /// </param>
        /// <param name="sourceIpAddress">
        /// The source ip address.
        /// </param>
        /// <param name="sourceNetmask">
        /// The source netmask.
        /// </param>
        /// <param name="destIpAddress">
        /// The dest ip address.
        /// </param>
        /// <param name="destNetmask">
        /// The dest netmask.
        /// </param>
        /// <param name="port1">
        /// The port 1.
        /// </param>
        /// <param name="port2">
        /// The port 2.
        /// </param>
        /// <param name="aclType">
        /// The acl type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public async Task<AclRuleType> CreateAclRule(
            string networkId,
            string aclRuleName,
            int position,
            AclActionType action,
            AclProtocolType protocol,
            PortRangeTypeType portRangeType,
            IPAddress sourceIpAddress = null,
            IPAddress sourceNetmask = null,
            IPAddress destIpAddress = null,
            IPAddress destNetmask = null,
            int port1 = 0,
            int port2 = 0,
            AclType aclType = AclType.OUTSIDE_ACL)
        {
            var portRange = new PortRangeType { type = portRangeType };

            // Validate that the ports are specified when needed
            switch (portRangeType)
            {
                case PortRangeTypeType.EQUAL_TO:
                case PortRangeTypeType.GREATER_THAN:
                case PortRangeTypeType.LESS_THAN:
                    {
                        if (port1 < 1 || port1 > 65535)
                            throw new ArgumentOutOfRangeException(
                                "port1",
                                port1,
                                string.Format(
                                    "Port1 must be between 1-65535 when the port range type is {0}",
                                    portRangeType));
                        portRange.port1 = port1;
                        portRange.port1Specified = true;
                        break;
                    }

                case PortRangeTypeType.RANGE:
                    {
                        if (port1 < 1 || port1 > 65535)
                            throw new ArgumentOutOfRangeException(
                                "port1",
                                port1,
                                string.Format(
                                    "Port1 must be between 1-65535 when the port range type is {0}",
                                    portRangeType));
                        if (port2 < 1 || port2 > 65535)
                            throw new ArgumentOutOfRangeException(
                                "port2",
                                port2,
                                string.Format(
                                    "Port2 must be between 1-65535 when the port range type is {0}",
                                    portRangeType));
                        portRange.port1 = port1;
                        portRange.port2 = port2;
                        portRange.port1Specified = portRange.port2Specified = true;
                        break;
                    }
            }

            // create the acl rule object
            var rule = new AclRuleType
            {
                name = aclRuleName,
                action = action,
                position = position,
                protocol = protocol.ToString(),
                portRange = portRange,
                type = aclType
            };
            if (sourceIpAddress != null)
            {
                rule.sourceIpRange = new IpRangeType { ipAddress = sourceIpAddress.ToString() };
                if (sourceNetmask != null) rule.sourceIpRange.netmask = sourceNetmask.ToString();
            }

            if (destIpAddress != null)
            {
                rule.destinationIpRange = new IpRangeType { ipAddress = destIpAddress.ToString() };
                if (destNetmask != null) rule.destinationIpRange.netmask = destNetmask.ToString();
            }

            return
                await
                    _apiClient.PostAsync<AclRuleType, AclRuleType>(
                        ApiUris.CreateAclRule(_apiClient.OrganizationId, networkId),
                        rule);
        }


        /// <summary>
        /// The get acl rules.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<AclRuleType>> GetAclRules(string networkId)
        {
            AclRuleListType aclRules =
                await
                    _apiClient.GetAsync<AclRuleListType>(
                        ApiUris.GetAclRules(_apiClient.OrganizationId, networkId));

            return aclRules.AclRule;
        }

        /// <summary>
        /// The delete acl rule.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="aclRuleId">
        /// The acl rule id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> DeleteAclRule(string networkId, string aclRuleId)
        {
            return
                await
                    _apiClient.GetAsync<Status>(
                        ApiUris.DeleteAclRule(_apiClient.OrganizationId, networkId, aclRuleId));
        }

        /// <summary>
        /// The reserve network public ip address block.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> ReserveNetworkPublicIpAddressBlock(string networkId)
        {
            return
                await
                    _apiClient.GetAsync<Status>(ApiUris.ReserveNetworkPublicIpAddressBlock(_apiClient.OrganizationId,
                        networkId));
        }

        /// <summary>
        /// The release network public ip address block.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="ipBlockId">
        /// The ip block id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> ReleaseNetworkPublicIpAddressBlock(string networkId, string ipBlockId)
        {
            return
                await
                _apiClient.GetAsync<Status>(
                    ApiUris.ReleaseNetworkPublicIpAddressBlock(_apiClient.OrganizationId, networkId, ipBlockId));
        }

        /// <summary>
        /// The get network public ip address block.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<IpBlockType>> GetNetworkPublicIpAddressBlock(string networkId)
        {
            NetworkConfigurationType ipblockp = await GetNetworkConfig(networkId);

            return ipblockp.publicIps;
        }

        /// <summary>
        /// The set serverto vip network public ip address block.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="ipBlockId">
        /// The ip block id.
        /// </param>
        /// <param name="enable">
        /// The enable.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> SetServertoVipNetworkPublicIpAddressBlock(string networkId, string ipBlockId, bool enable)
        {
            const string poststring = "serverToVipConnectivity={0}";
            return
                await
                    _apiClient.PostAsync<Status>(
                        ApiUris.SetServerToVipNetworkPublicIpAddressBlock(_apiClient.OrganizationId, networkId, ipBlockId),
                        string.Format(poststring, enable));
        }

        /// <summary>
        /// The set network multicast.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="enable">
        /// The enable.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> SetNetworkMulticast(string networkId, bool enable)
        {
            const string poststring = "enabled={0}";

            return
                await
                    _apiClient.PostAsync<Status>(ApiUris.SetNetworkMulticast(_apiClient.OrganizationId, networkId),
                        string.Format(poststring, enable));
        }
    }
}