namespace DD.CBU.Compute.Api.Contracts.Network20
{
    /// <remarks/>
    public partial class IpAndPortFilterType
    {
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public IpAndPortFilterTypeIP IpAddress
        {
            get { return ip as IpAndPortFilterTypeIP; }
            set { ip = value; }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public IpAddressListSummaryType IpAddressList
        {
            get { return ip as IpAddressListSummaryType; }
            set { ip = value; }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public PortRangeType PortRange
        {
            get { return port as PortRangeType; }
            set { port = value; }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public PortListSummaryType PortList
        {
            get { return port as PortListSummaryType; }
            set { port = value; }
        }
    }
}