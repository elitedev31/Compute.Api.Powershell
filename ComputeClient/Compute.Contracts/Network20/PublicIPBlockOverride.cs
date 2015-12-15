using System;
using System.Linq;

namespace DD.CBU.Compute.Api.Contracts.Network20
{
    public partial class PublicIpBlockType
    {
        /// <summary>
        /// 	Gets or sets a value indicating whether the server to vip connectivity.
        /// </summary>
        /// <value>	true if server to vip connectivity, false if not. </value>
        public bool serverToVipConnectivity
        {
            get
            {
                var index = Array.IndexOf(ItemsElementName, NetworkDomainIdOrNetworkIdIpBlockChoiceType.serverToVipConnectivity);
                return (index > 0) && (bool) Items[index];
            }           
        }

        /// <summary>	Gets or sets the identifier of the network domain. </summary>
        /// <value>	The identifier of the network domain. </value>
        public string networkDomainId
        {
            get
            {
                var index = Array.IndexOf(ItemsElementName, NetworkDomainIdOrNetworkIdIpBlockChoiceType.networkDomainId);
                return (index > 0) ? (string)Items[index] : String.Empty;
            }
        }

        /// <summary>	Gets or sets the identifier of the network. </summary>
        /// <value>	The identifier of the network. </value>
        public string networkId
        {
            get
            {             
                var index = Array.IndexOf(ItemsElementName, NetworkDomainIdOrNetworkIdIpBlockChoiceType.networkId);
                return (index > 0) ? (string)Items[index] : String.Empty;
            }
        }

        /// <summary>	Gets or sets a value indicating whether the network default. </summary>
        /// <value>	true if network default, false if not. </value>
        public bool networkDefault
        {
            get
            {
                var index = Array.IndexOf(ItemsElementName, NetworkDomainIdOrNetworkIdIpBlockChoiceType.networkDefault);
                return (index > 0) && (bool)Items[index];              
            }
        }
    }


    public partial class AddPublicIpBlockType
    {
        /// <summary>
        /// Network Domain Id
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public string networkDomainId
        {
            get
            {
                return ItemElementName == NetworkDomainIdOrNetworkIdChoiceType.networkDomainId ? Item : string.Empty;
            }
            set
            {
                Item = value;
                ItemElementName = NetworkDomainIdOrNetworkIdChoiceType.networkDomainId;
            }
        }

        /// <summary>
        /// Network Id
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public string networkId
        {
            get
            {
                return ItemElementName == NetworkDomainIdOrNetworkIdChoiceType.networkId ? Item : string.Empty;
            }
            set
            {
                Item = value;
                ItemElementName = NetworkDomainIdOrNetworkIdChoiceType.networkId;
            }
        }
    }
}
