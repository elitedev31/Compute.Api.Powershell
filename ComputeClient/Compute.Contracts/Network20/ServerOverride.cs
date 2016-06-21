namespace DD.CBU.Compute.Api.Contracts.Network20
{
    public partial class VlanIdOrPrivateIpType
    {
        private string networkAdapterField;

        /// Note Only PrivaleIpv4 Or VlanId is valid,  dont specify both
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string vlanId
        {
            get { return ItemElementName == PrivateIpv4OrVlanIdChoiceType.vlanId ? Item : string.Empty; }
            set
            {
                // value not null or its vlan id
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == PrivateIpv4OrVlanIdChoiceType.vlanId)
                {
                    Item = value;
                    ItemElementName = PrivateIpv4OrVlanIdChoiceType.vlanId;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string privateIpv4
        {
            get { return ItemElementName == PrivateIpv4OrVlanIdChoiceType.privateIpv4 ? Item : string.Empty; }
            set
            {
                // value not null or its private ipv4
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == PrivateIpv4OrVlanIdChoiceType.privateIpv4)
                {
                    Item = value;
                    ItemElementName = PrivateIpv4OrVlanIdChoiceType.privateIpv4;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string networkAdapter
        {
            get { return this.networkAdapterField; }
            set { this.networkAdapterField = value; }
        }
    }

    public partial class NewNicType
    {
        /// Note Only PrivaleIpv4 Or VlanId is valid,  dont specify both
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string vlanId
        {
            get { return ItemElementName == PrivateIpv4OrVlanIdChoiceType.vlanId ? Item : string.Empty; }
            set
            {
                // value not null or its vlan id
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == PrivateIpv4OrVlanIdChoiceType.vlanId)
                {
                    Item = value;
                    ItemElementName = PrivateIpv4OrVlanIdChoiceType.vlanId;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string privateIpv4
        {
            get { return ItemElementName == PrivateIpv4OrVlanIdChoiceType.privateIpv4 ? Item : string.Empty; }
            set
            {
                // value not null or its private ipv4
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == PrivateIpv4OrVlanIdChoiceType.privateIpv4)
                {
                    Item = value;
                    ItemElementName = PrivateIpv4OrVlanIdChoiceType.privateIpv4;
                }
            }
        }
    }

    public partial class ServerType
    {
        /// Note, server will have either nic or NetworkInfo
        /// <summary>	Gets or sets the NIC. </summary>
        /// <value>	The NIC. </value>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ServerTypeNic nic
        {
            get { return Item as ServerTypeNic; }
            set { Item = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ServerTypeNetworkInfo networkInfo
        {
            get { return Item as ServerTypeNetworkInfo; }
            set { Item = value; }
        }

    }

    public partial class DeployServerType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public DeployServerTypeNetwork network
        {
            get { return Item as DeployServerTypeNetwork; }
            set
            {
                if (value != null || Item is DeployServerTypeNetwork)
                    Item = value;
            }
        }

        /// <summary>	Gets or sets information describing the network. </summary>
        /// <value>	Information describing the network. </value>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public DeployServerTypeNetworkInfo networkInfo
        {
            get { return Item as DeployServerTypeNetworkInfo; }
            set
            {
                if (value != null || Item is DeployServerTypeNetworkInfo)
                    Item = value;
            }
        }
    }


    public partial class DeployServerTypeNetwork
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string networkId
        {
            get
            {
                return ItemElementName == NetworkIdOrPrivateIpv4ChoiceType.networkId ? Item : string.Empty;
            }
            set
            {
                // value not null or its networkId
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == NetworkIdOrPrivateIpv4ChoiceType.networkId)
                {
                    Item = value;
                    ItemElementName = NetworkIdOrPrivateIpv4ChoiceType.networkId;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string privateIpv4
        {
            get
            {
                return ItemElementName == NetworkIdOrPrivateIpv4ChoiceType.privateIpv4 ? Item : string.Empty;
            }
            set
            {
                // value not null or its private ipv4
                if (!string.IsNullOrWhiteSpace(value) || ItemElementName == NetworkIdOrPrivateIpv4ChoiceType.privateIpv4)
                {
                    Item = value;
                    ItemElementName = NetworkIdOrPrivateIpv4ChoiceType.privateIpv4;
                }
            }
        }
    }
}