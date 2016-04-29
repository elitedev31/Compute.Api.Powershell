namespace DD.CBU.Compute.Powershell.Mcp20.Model
{
    public enum NetworkIdOrVlanIdType
    {
        /// <summary>
        /// The network id.
        /// </summary>
        NetworkId = 0,

        /// <summary>
        /// The VLAN id.
        /// </summary>
        VlanId = 1
    }

    public class ReservePrivateIpv4Address
    {
        public string NetworkIdOrVlanId { get; set; }

        public NetworkIdOrVlanIdType NetworkIdOrVlanIdType { get; set; }
    }
}
