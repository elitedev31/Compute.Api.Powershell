using System;
namespace DD.CBU.Compute.Api.Contracts.Network20
{   
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
