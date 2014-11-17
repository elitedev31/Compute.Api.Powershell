using System.Runtime.CompilerServices;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Api.Client.Network
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using System.Collections.Specialized;

    /// <summary>
    /// Extension methods for the Network section of the CaaS API.
    /// </summary>
    public static class ComputeApiClientNetworkExtensions
    {
        /// <summary>
        /// Deploys a new network in a designated data center location.
        /// The designated data center must be chosen from your available data centers list (See "List Data Centers (With Parameters)").
        /// The "location" property of the data center is used to identify it for network creation.
        /// The "name" property must be unique within your organization. 
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkName">A unique network name for the new network.</param>
        /// <param name="dataCentreLocation">The data centre location.</param>
        /// <param name="description">Optional. A decription for the network.</param>
        /// <returns>A status of the response.</returns>
        public static async Task<Status> CreateNetwork(
            this IComputeApiClient client,
            string networkName,
            string dataCentreLocation,
            string description = null)
        {
            return
                await
                client.WebApi.ApiPostAsync<NewNetworkWithLocationType, Status>(
                    ApiUris.CreateNetwork(client.Account.OrganizationId),
                    new NewNetworkWithLocationType
                        {
                            name = networkName,
                            location = dataCentreLocation,
                            description = description
                        });
        }

        /// <summary>
        /// Gets the networks with locations
        /// </summary>
        /// <param name="client">The <see cref="IComputeApiClient"/> object.</param>
        /// <returns>The networks</returns>
        public static async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworksTask(this IComputeApiClient client)
        {
            var networks = await client.WebApi.ApiGetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocations(client.Account.OrganizationId));
            return networks.Items;
        }

        /// <summary>
        /// Retrieves the details of a specific network owned by a customer.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to delete.</param>
        /// <returns>A status of the response.</returns>
        public static async Task<Status> DeleteNetwork(this IComputeApiClient client, string networkId)
        {
            return
                await client.WebApi.ApiGetAsync<Status>(ApiUris.DeleteNetwork(client.Account.OrganizationId, networkId));
        }


        /// <summary>
        /// Modify the details of a specific network owned by a customer.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to modify.</param>
        /// <param name="name">The new network name.</param>     
        /// <param name="description">The new network description.</param>
        /// 
        /// <returns>A status of the response.</returns>
        public static async Task<Status> ModifyNetwork(this IComputeApiClient client, string networkId,string name, string description)
        {
            var parameters = new NameValueCollection();
            if (!string.IsNullOrEmpty(name))
                parameters.Add("name", name);
            if (!string.IsNullOrEmpty(description))
                parameters.Add("description", description);

            // build the query string
            string poststring = parameters.ToQueryString();

            return
                await client.WebApi.ApiPostAsync<Status>(ApiUris.ModifyNetwork(client.Account.OrganizationId, networkId),poststring);
        }

        /// <summary>
        /// Retrieves the details of a specific network owned by a customer.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to delete.</param>
        /// <returns>A NetworkConfigurationType of the response.</returns>
        public static async Task<NetworkConfigurationType> GetNetworkConfig(this IComputeApiClient client, string networkId)
        {
            return
                await client.WebApi.ApiGetAsync<NetworkConfigurationType>(ApiUris.GetNetworkConfig(client.Account.OrganizationId, networkId));
        }

        /// <summary>
        /// Retrieves a list of NAT rules for a specified network.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The target network id.</param>
        /// <returns>The status of the operation.</returns>
        public static async Task<IEnumerable<NatRuleType>> GetNatRules(this IComputeApiClient client, string networkId)
        {
            var natRules =
                await client.WebApi.ApiGetAsync<NatRules>(ApiUris.GetNatRules(client.Account.OrganizationId, networkId));

            return natRules.NatRule;
        }

        /// <summary>
        /// Deletes an existing NAT rule for a specified network.
        /// This API requires your organization ID, the ID of the target network and the ID of the NAT rule to be deleted.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The target network id.</param>
        /// <param name="natRuleId">The NAT rule id to delete.</param>
        /// <returns>The status of the operation.</returns>
        public static async Task<Status> DeleteNatRule(this IComputeApiClient client, string networkId, string natRuleId)
        {
            return
                await
                client.WebApi.ApiGetAsync<Status>(
                    ApiUris.DeleteNatRule(client.Account.OrganizationId, networkId, natRuleId));
        }

        /// <summary>
        /// Creates a new NAT rule for a specified network.
        /// This API requires your organization ID and the ID of the target network.
        /// The XML structured request requires a <paramref name="natRuleName"/> element describing the NAT Rule and a <paramref name="sourceIp"/> which is the 
        /// underlying private IP address that the public IP address (natIp) returned in the response will be assigned to.
        /// Note that IP addresses *.0 through  *.10 are reserved and cannot be used as <paramref name="sourceIp"/> values.
        /// The available range is *.11 to *.254. For example “10.147.15.11” in the sample request below.
        /// An attempt to specify one of the reserved addresses as the <paramref name="sourceIp"/> will result in a REASON_240 reason code being returned.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The target network id.</param>
        /// <param name="natRuleName"></param>
        /// <param name="sourceIp"></param>
        /// <returns></returns>
        public static async Task<NatRuleType> CreateNatRule(this IComputeApiClient client, string networkId, string natRuleName, IPAddress sourceIp)
        {
            Contract.Requires(!string.IsNullOrEmpty(networkId), "Network id cannot be null or empty");
            Contract.Requires(!string.IsNullOrEmpty(natRuleName), "NAT rule name cannot be null or empty");
            Contract.Requires(sourceIp != null, "Source IP cannot be null");

            return
                await
                client.WebApi.ApiPostAsync<NatRuleType, NatRuleType>(
                    ApiUris.CreateNatRule(client.Account.OrganizationId, networkId),
                    new NatRuleType { name = natRuleName, sourceIp = sourceIp.ToString() });
        }

        /// <summary>
        /// Retrieves the list of ACL rules associated with a network.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object</param>
        /// <param name="networkId">The target network id</param>
        /// <returns>The ACL rules.</returns>
        public static async Task<IEnumerable<AclRuleType>> GetAclRules(this IComputeApiClient client, string networkId)
        {
            var aclRules =
                await
                client.WebApi.ApiGetAsync<AclRuleListType>(
                    ApiUris.GetAclRules(client.Account.OrganizationId, networkId));

            return aclRules.AclRule;
        }

        /// <summary>
        /// Deletes a specified ACL rule. 
        /// This API requires your organization ID, the ID of the target network and the ID of the rule. 
        /// <remarks>Note: If the Cisco hardware is under heavy load when a Delete ACL Rule request is processed it is possible for a timeout to occur.
        /// In this situation the ACL rule deletion usually completes successfully but an error code REASON_292 will be returned to indicate that 
        /// the ACL rule is in a pending state and a support case should be opened for it to be removed.</remarks>
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The target network id.</param>
        /// <param name="aclRuleId">The ACL rule to delete.</param>
        /// <returns>The status of the operation.</returns>
        public static async Task<Status> DeleteAclRule(this IComputeApiClient client, string networkId, string aclRuleId)
        {
            return
                await
                client.WebApi.ApiGetAsync<Status>(
                    ApiUris.DeleteAclRule(client.Account.OrganizationId, networkId, aclRuleId));
        }

        /// <summary>
        /// All the ACL Protocol types.
        /// </summary>
        public enum AclProtocolType
        {
            /// <summary>
            /// IP type
            /// </summary>
            IP,

            /// <summary>
            /// ICMP type
            /// </summary>
            ICMP,

            /// <summary>
            /// TCP type
            /// </summary>
            TCP,

            /// <summary>
            /// UDP type
            /// </summary>
            UDP
        }

        /// <summary>
        /// Creates a new ACL rule at a specified line using your organization ID and the ID of the target network.
        /// It is possible to create both inbound (OUTSIDE_ACL) and outbound (INSIDE_ACL) rule types.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The target network id.</param>
        /// <param name="aclRuleName">The name of the ACL rule.</param>
        /// <param name="position">The position of the rule between 100-500 inclusive.</param>
        /// <param name="action">The action (Permit/deny) of the ACL rule.</param>
        /// <param name="protocol">The protocol to use (IP, ICMP, TCP, UDP).</param>
        /// <param name="portRangeType">The port range type (ALL, EQUAL_TO, RANGE, GREATER_THAN, LESS_THAN).</param>
        /// <param name="sourceIpAddress">
        /// Optional. If no source IP Address is supplied, the assumption is that any source IP address is allowed.
        /// If a source IP address is supplied without the <paramref name="sourceNetmask"/>, source IP Address represent a single host.
        /// </param>
        /// <param name="sourceNetmask">
        /// Optional. When specified, the <paramref name="sourceIpAddress"/> must be the CIDR boundary for the network.
        /// </param>
        /// <param name="destIpAddress">
        /// Optional. If no destination IP Address is supplied, the assumption is that any destination IP address is allowed.
        /// If a destination IP address is supplied without the <paramref name="destNetmask"/>, source IP Address represent a single host.
        /// </param>
        /// <param name="destNetmask">
        /// Optional. When specified, the <paramref name="destIpAddress"/> must be the CIDR boundary for the network.
        /// </param>
        /// <param name="port1">Optional depending on <paramref name="portRangeType"/>. Value within a range of 1-65535.</param>
        /// <param name="port2">Optional depending on <paramref name="portRangeType"/>. Value within a range of 1-65535.</param>
        /// <param name="aclType">Optional. One of (OUTSIDE_ACL, INSIDE_ACL). Default if not specified is OUTSIDE_ACL.</param>
        /// <returns>The ACL rules.</returns>
        public static async Task<AclRuleType> CreateAclRule(
            this IComputeApiClient client,
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
            Contract.Requires(!string.IsNullOrEmpty(aclRuleName), "The ACL rule name must NOT be empty or null!");
            Contract.Requires(aclRuleName.Length < 60, "ACL rule name cannot exceed 60 chars");
            Contract.Requires(position >= 100 && position <= 500, "Position must be between 100 and 500 inclusive");
            Contract.Requires(aclType == AclType.INSIDE_ACL || aclType == AclType.OUTSIDE_ACL, "ACL Type must be one of (OUTSIDE_ACL, INSIDE_ACL)");

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
                client.WebApi.ApiPostAsync<AclRuleType, AclRuleType>(
                    ApiUris.CreateAclRule(client.Account.OrganizationId, networkId),
                    rule);
        }

        /// <summary>
        /// Reserves a public Ip address block for the network
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to delete.</param>
        /// <returns>A Status of the response.</returns>
        public static async Task<Status> ReserveNetworkPublicIpAddressBlock(this IComputeApiClient client, string networkId)
        {
            return
                await client.WebApi.ApiGetAsync<Status>(ApiUris.ReserveNetworkPublicIpAddressBlock(client.Account.OrganizationId, networkId));
        }

        /// <summary>
        /// Releases a public Ip address block for the network
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to add the block.</param>
        /// <param name="ipBlockId">The public ip address block id </param>
        /// <returns>A Status of the response.</returns>
        public static async Task<Status> ReleaseNetworkPublicIpAddressBlock(this IComputeApiClient client, string networkId,string ipBlockId)
        {
            return
                await client.WebApi.ApiGetAsync<Status>(ApiUris.ReleaseNetworkPublicIpAddressBlock(client.Account.OrganizationId, networkId,ipBlockId));
        }


        /// <summary>
        /// List the public Ip address blocks from a network
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to add the block.</param>
        /// <returns>A Status of the response.</returns>
        public static async Task<IEnumerable<IpBlockType>> GetNetworkPublicIpAddressBlock(this IComputeApiClient client, string networkId)
        {
            var ipblockp = await client.GetNetworkConfig(networkId);

            return ipblockp.publicIps;

        }

        /// <summary>
        /// Set the server to VIP connectivity on a public Ip address block for the network
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id to add the block.</param>
        /// <param name="ipBlockId">The public ip address block id </param>
        /// <param name="enable">The setting of the Server to VIP on ip address block</param>
        /// <returns>A Status of the response.</returns>
        public static async Task<Status> SetServertoVipNetworkPublicIpAddressBlock(this IComputeApiClient client, string networkId, string ipBlockId,bool enable)
        {
            string poststring = "serverToVipConnectivity={0}";
            
            return
                await client.WebApi.ApiPostAsync<Status>(ApiUris.SetServerToVipNetworkPublicIpAddressBlock(client.Account.OrganizationId, networkId, ipBlockId), string.Format(poststring, enable.ToString()));
            ;
        }


        /// <summary>
        /// Set Multicast for the network
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object.</param>
        /// <param name="networkId">The network id </param>
     /// <param name="enable">The setting for multicast on network</param>
        /// <returns>A Status of the response.</returns>
        public static async Task<Status> SetNetworkMulticast(this IComputeApiClient client, string networkId, bool enable)
        {
            string poststring = "enabled={0}";

            return
                await client.WebApi.ApiPostAsync<Status>(ApiUris.SetNetworkMulticast(client.Account.OrganizationId, networkId), string.Format(poststring, enable.ToString()));
            
        }

    }
}
