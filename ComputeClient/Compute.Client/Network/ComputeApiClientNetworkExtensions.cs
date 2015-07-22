namespace DD.CBU.Compute.Api.Client.Network
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Threading.Tasks;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Network;

	/// <summary>
	/// Extension methods for the Network section of the CaaS API.
	/// </summary>
	public static class ComputeApiClientNetworkExtensions
	{
		/// <summary>
		/// Deploys a new network in a designated data center location.
		///     The designated data center must be chosen from your available data centers list (See "List Data Centers (With
		///     Parameters)").
		///     The "location" property of the data center is used to identify it for network creation.
		///     The "name" property must be unique within your organization.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkName">
		/// A unique network name for the new network.
		/// </param>
		/// <param name="dataCentreLocation">
		/// The data centre location.
		/// </param>
		/// <param name="description">
		/// Optional. A decription for the network.
		/// </param>
		/// <returns>
		/// A status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> CreateNetwork(
			this IComputeApiClient client, 
			string networkName, 
			string dataCentreLocation, 
			string description = null)
		{
			return await client.NetworkingLegacy.Network.CreateNetwork(networkName, dataCentreLocation, description);
		}

		/// <summary>
		/// Gets the networks with locations
		/// </summary>
		/// <param name="client">
		/// The <see cref="IComputeApiClient"/> object.
		/// </param>
		/// <returns>
		/// The networks
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworksTask(this IComputeApiClient client)
		{
			return await client.NetworkingLegacy.Network.GetNetworks();
		}

		/// <summary>
		/// Retrieves the details of a specific network owned by a customer.
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to delete.
		/// </param>
		/// <returns>
		/// A status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> DeleteNetwork(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.Network.DeleteNetwork(networkId);
		}


		/// <summary>
		/// Modify the details of a specific network owned by a customer.
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to modify.
		/// </param>
		/// <param name="name">
		/// The new network name.
		/// </param>
		/// <param name="description">
		/// The new network description.
		/// </param>
		/// <returns>
		/// A status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> ModifyNetwork(
			this IComputeApiClient client,
			string networkId,
			string name,
			string description)
		{
			return await client.NetworkingLegacy.Network.ModifyNetwork(networkId, name, description);
		}

		/// <summary>
		/// Retrieves the details of a specific network owned by a customer.
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to delete.
		/// </param>
		/// <returns>
		/// A NetworkConfigurationType of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<NetworkConfigurationType> GetNetworkConfig(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.Network.GetNetworkConfig(networkId);
		}

		/// <summary>
		/// Retrieves a list of NAT rules for a specified network.
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The target network id.
		/// </param>
		/// <returns>
		/// The status of the operation.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<IEnumerable<NatRuleType>> GetNatRules(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.Network.GetNatRules(networkId);
		}

		/// <summary>
		/// Deletes an existing NAT rule for a specified network.
		///     This API requires your organization ID, the ID of the target network and the ID of the NAT rule to be deleted.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The target network id.
		/// </param>
		/// <param name="natRuleId">
		/// The NAT rule id to delete.
		/// </param>
		/// <returns>
		/// The status of the operation.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> DeleteNatRule(this IComputeApiClient client, string networkId, string natRuleId)
		{
			return await client.NetworkingLegacy.Network.DeleteNatRule(networkId, natRuleId);
		}

		/// <summary>
		/// The create nat rule.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
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
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<NatRuleType> CreateNatRule(
			this IComputeApiClient client,
			string networkId,
			string natRuleName,
			IPAddress sourceIp)
		{
			return await client.NetworkingLegacy.Network.CreateNatRule(networkId, natRuleName, sourceIp);
		}

		/// <summary>
		/// Retrieves the list of ACL rules associated with a network.
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="networkId">
		/// The target network id
		/// </param>
		/// <returns>
		/// The ACL rules.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<IEnumerable<AclRuleType>> GetAclRules(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.Network.GetAclRules(networkId);
		}

		/// <summary>
		/// Deletes a specified ACL rule.
		///     This API requires your organization ID, the ID of the target network and the ID of the rule.
		///     <remarks>
		/// Note: If the Cisco hardware is under heavy load when a Delete ACL Rule request is processed it is possible for
		///         a timeout to occur.
		///         In this situation the ACL rule deletion usually completes successfully but an error code REASON_292 will be
		///         returned to indicate that
		///         the ACL rule is in a pending state and a support case should be opened for it to be removed.
		///     </remarks>
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The target network id.
		/// </param>
		/// <param name="aclRuleId">
		/// The ACL rule to delete.
		/// </param>
		/// <returns>
		/// The status of the operation.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> DeleteAclRule(this IComputeApiClient client, string networkId, string aclRuleId)
		{
			return await client.NetworkingLegacy.Network.DeleteAclRule(networkId, aclRuleId);
		}

		/// <summary>
		/// The create acl rule.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
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
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
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
			return
				await
				client.NetworkingLegacy.Network.CreateAclRule(
					networkId,
					aclRuleName,
					position,
					action,
					protocol,
					portRangeType,
					sourceIpAddress,
					sourceNetmask,
					destIpAddress,
					destNetmask,
					port1,
					port2,
					aclType);
		}

		/// <summary>
		/// Reserves a public Ip address block for the network
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to delete.
		/// </param>
		/// <returns>
		/// A Status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> ReserveNetworkPublicIpAddressBlock(this IComputeApiClient client, string networkId)
		{
			return await client.NetworkingLegacy.Network.ReserveNetworkPublicIpAddressBlock(networkId);		
		}

		/// <summary>
		/// Releases a public Ip address block for the network
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to add the block.
		/// </param>
		/// <param name="ipBlockId">
		/// The public ip address block id 
		/// </param>
		/// <returns>
		/// A Status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> ReleaseNetworkPublicIpAddressBlock(
			this IComputeApiClient client,
			string networkId,
			string ipBlockId)
		{
			return await client.NetworkingLegacy.Network.ReleaseNetworkPublicIpAddressBlock(networkId, ipBlockId);		
		}


		/// <summary>
		/// List the public Ip address blocks from a network
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to add the block.
		/// </param>
		/// <returns>
		/// A Status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<IEnumerable<IpBlockType>> GetNetworkPublicIpAddressBlock(this IComputeApiClient client, 
			string networkId)
		{
			return await client.NetworkingLegacy.Network.GetNetworkPublicIpAddressBlock(networkId);		
		}

		/// <summary>
		/// Set the server to VIP connectivity on a public Ip address block for the network
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id to add the block.
		/// </param>
		/// <param name="ipBlockId">
		/// The public ip address block id 
		/// </param>
		/// <param name="enable">
		/// The setting of the Server to VIP on ip address block
		/// </param>
		/// <returns>
		/// A Status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> SetServertoVipNetworkPublicIpAddressBlock(
			this IComputeApiClient client,
			string networkId,
			string ipBlockId,
			bool enable)
		{
			return await client.NetworkingLegacy.Network.SetServertoVipNetworkPublicIpAddressBlock(networkId, ipBlockId, enable);				
		}


		/// <summary>
		/// Set Multicast for the network
		///     This API requires your organization ID and the ID of the target network.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object.
		/// </param>
		/// <param name="networkId">
		/// The network id 
		/// </param>
		/// <param name="enable">
		/// The setting for multicast on network
		/// </param>
		/// <returns>
		/// A Status of the response.
		/// </returns>
		[Obsolete("Use IComputeApiClient.NetworkingLegacy.Network instead")]
		public static async Task<Status> SetNetworkMulticast(this IComputeApiClient client, string networkId, bool enable)
		{
			return await client.NetworkingLegacy.Network.SetNetworkMulticast(networkId, enable);				
		}
	}
}