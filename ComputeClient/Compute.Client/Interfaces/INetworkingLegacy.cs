namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System.Collections.Generic;
	using System.Net;

	using DD.CBU.Compute.Api.Contracts.General;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Network;

	/// <summary>
	/// The NetworkingLegacy interface.
	/// </summary>
	public interface INetworkingLegacy
	{
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
		Task<Status> CreateNetwork(
			string networkName,
			string dataCentreLocation,
			string description = null);

		/// <summary>
		/// The get networks task.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworks();

		/// <summary>
		/// The delete network.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> DeleteNetwork(string networkId);

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
		Task<Status> ModifyNetwork(string networkId, string name, string description);

		/// <summary>
		/// The get network config.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<NetworkConfigurationType> GetNetworkConfig(string networkId);

		/// <summary>
		/// The get nat rules.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<NatRuleType>> GetNatRules(string networkId);

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
		Task<Status> DeleteNatRule(string networkId, string natRuleId);

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
		Task<NatRuleType> CreateNatRule(string networkId, string natRuleName, IPAddress sourceIp);

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
		Task<AclRuleType> CreateAclRule(
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
			AclType aclType = AclType.OUTSIDE_ACL);

		/// <summary>
		/// The get acl rules.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<AclRuleType>> GetAclRules(string networkId);

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
		Task<Status> DeleteAclRule(string networkId, string aclRuleId);

		/// <summary>
		/// The reserve network public ip address block.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ReserveNetworkPublicIpAddressBlock(string networkId);

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
		Task<Status> ReleaseNetworkPublicIpAddressBlock(string networkId, string ipBlockId);

		/// <summary>
		/// The get network public ip address block.
		/// </summary>
		/// <param name="networkId">
		/// The network id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<IpBlockType>> GetNetworkPublicIpAddressBlock(string networkId);

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
		Task<Status> SetServertoVipNetworkPublicIpAddressBlock(string networkId,
			string ipBlockId,
			bool enable);

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
		Task<Status> SetNetworkMulticast(string networkId, bool enable);
	}
}
