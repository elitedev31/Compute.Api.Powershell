// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnownApiUri.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the KnownApiRegion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CBU.Compute.Api.Client
{
	using DD.CBU.Compute.Api.Client.Exceptions;

	/// <summary>	Values that represent known API regions. </summary> 
	/// <remarks>GeoKey represents the geokey value returned by multigeo call</remarks>	   
    public enum KnownApiRegion
    {
        /// <summary>
		/// Africa (AF), GeoKey = africa
		/// </summary>
        Africa_AF,

        /// <summary>
        /// Asia Pacific (AP) , GeoKey = asiapacific
        /// </summary>
        AsiaPacific_AP,

        /// <summary>
		/// Australia (AU), GeoKey = australia
		/// </summary>
        Australia_AU,

        /// <summary>
        /// Canada (CA), GeoKey = canada
        /// </summary>
        Canada_CA,

        /// <summary>
        /// Europe (EU), GeoKey = europe
        /// </summary>
        Europe_EU,

        /// <summary>
        /// India, GeoKey = india
        /// </summary>
        India_IN,

        /// <summary>
        /// Indonesia, GeoKey = indonesia
        /// </summary>
        Indonesia_ID,

        /// <summary>
        /// Israel, GeoKey = israel
        /// </summary>
        Israel_IL,

        /// <summary>
        /// North America (NA), GeoKey = northamerica
        /// </summary>
        NorthAmerica_NA,

        /// <summary>
        /// South America (LATAM), GeoKey = southamerica
        /// </summary>
        SouthAmerica_SA,
    }

    /// <summary>
    /// The known API vendor.
    /// </summary>
    public enum KnownApiVendor
    {
		/// <summary>
		/// Dimension Data
		/// </summary>
        DimensionData,

        /// <summary>
        /// Dimension Data Governament
        /// </summary>
        DimensionData_Government,

		/// <summary>
		/// NTT-America (part of NTT communications).
		/// </summary>
        NTTA,

		/// <summary>
		/// The cisco.
		/// </summary>
        Cisco,

		/// <summary>
		/// Internet Solutions, a subsidiary of Dimension Data.
		/// </summary>
        InternetSolutions,

		/// <summary>
		/// Indosat indonesia
		/// </summary>
        Indosat,

		/// <summary>
		/// BNSL Vendor indosat.
		/// </summary>
        BSNL,

        /// <summary>
        /// RootAxcess Vendor (NA).
		/// </summary>
        RootAxcess,

        /// <summary>
        /// RootAxcess Vendor (NA).
        /// </summary>
        Tenzing_Everest,

        /// <summary>
        /// PWW Cloud Connect Vendor (NA).
        /// </summary>
        PWW_Cloud_Connect,

        /// <summary>
        /// Med1
        /// </summary>
        Med_One
    }

    /// <summary>
    /// Static class to 
    /// </summary>
    public class KnownApiUri
    {
        /// <summary>
        /// Singleton implementation of the known API class
        /// </summary>
        private static KnownApiUri _instance;

        /// <summary> Prevents a default instance of the DD.CBU.Compute.Api.Client.KnownApiUri class from
        /// 	being created. </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
        private KnownApiUri()
        {
            KnownApiHostNames = new Dictionary<string, string>();
			KnownFtpHostNames = new Dictionary<string, string>();
            KnownVpnHostNames = new Dictionary<string, string>();
            KnownMonitoringHostNames = new Dictionary<string, string>();
            KnownVendorEndPointPairs = new List<KeyValuePair<KnownApiVendor, KnownApiRegion>>();
            CreateKnownApiHostNames();
        }

        /// <summary>
		/// Gets the instance.
		/// </summary>
		public static KnownApiUri Instance
		{
			get { return _instance ?? (_instance = new KnownApiUri()); }
			private set { _instance = value; }
		}

		/// <summary>
		/// Private Dictionary to host all endpoints
        /// </summary>
		private Dictionary<string, string> KnownApiHostNames { get; set; }

		/// <summary>
		/// Private Dictionary to host all endpoints
		/// </summary>
		private Dictionary<string, string> KnownFtpHostNames { get; set; }

        /// <summary>
		/// Private Dictionary to host all regional vpn endpoints
		/// </summary>
		private Dictionary<string, string> KnownVpnHostNames { get; set; }

        /// <summary>
        /// Private Dictionary to host all regional monitoring endpoints
        /// </summary>
        private Dictionary<string, string> KnownMonitoringHostNames { get; set; }

        /// <summary>
        /// Mapping between Vendor and applicable regions
        /// </summary>
        private List<KeyValuePair<KnownApiVendor, KnownApiRegion>> KnownVendorEndPointPairs { get; set; }   
        
        /// <summary>
        /// Return an known CaaS URI based on vendor and region
        /// </summary>
		/// <param name="vendor">
		/// The vendor
		/// </param>
		/// <param name="region">
		/// The region
		/// </param>
		/// <returns>
		/// The <see cref="Uri"/>.
		/// </returns>
        public Uri GetBaseUri(KnownApiVendor vendor, KnownApiRegion region)
        {
            const string urltemplate = "https://{0}/";
            string key = string.Concat(vendor.ToString(), '-', region.ToString());
	        if (!KnownApiHostNames.ContainsKey(key))
		        throw new ApiHostNotFoundException(vendor, region);

            string apiurl = string.Format(urltemplate, KnownApiHostNames[key]);
            return new Uri(apiurl);
        }

		/// <summary>
		/// The get ftp host.
		/// </summary>
		/// <param name="vendor">
		/// The vendor.
		/// </param>
		/// <param name="region">
		/// The region.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		/// <exception cref="ComputeApiException">
		/// </exception>
	    public string GetFtpHost(KnownApiVendor vendor, KnownApiRegion region)
	    {
			string key = string.Concat(vendor.ToString(), '-', region.ToString());
			if (!KnownFtpHostNames.ContainsKey(key))
				throw new ApiHostNotFoundException(vendor, region);
			return KnownFtpHostNames[key];
	    }

        /// <summary>
		/// The get vpn host.
		/// </summary>
		/// <param name="vendor">
		/// The vendor.
		/// </param>
		/// <param name="region">
		/// The region.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		/// <exception cref="ComputeApiException">
		/// </exception>
        public Uri GetVpnUrl(KnownApiVendor vendor, KnownApiRegion region)
        {
            const string urltemplate = "https://{0}/";
            string key = region.ToString();
            if (!KnownVpnHostNames.ContainsKey(key))
                throw new ApiHostNotFoundException(vendor, region);            
            string apiurl = string.Format(urltemplate, KnownVpnHostNames[key]);
            return new Uri(apiurl);
        }

        /// <summary>
        /// The get Monitoring url.
        /// </summary>
        /// <param name="vendor">
        /// The vendor.
        /// </param>
        /// <param name="region">
        /// The region.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ComputeApiException">
        /// </exception>
        public Uri GetMonitoringUrl(KnownApiVendor vendor, KnownApiRegion region)
        {
            const string urltemplate = "https://{0}/";
            string key = region.ToString();
            if (!KnownMonitoringHostNames.ContainsKey(key))
                throw new ApiHostNotFoundException(vendor, region);
            string apiurl = string.Format(urltemplate, KnownMonitoringHostNames[key]);
            return new Uri(apiurl);
        }

        /// <summary>	List of Known Regions that are valid for the particular Vendor. </summary>        
        /// <param name="vendor">	The Vendor. </param>
        /// <returns>	The list of known regions. </returns>
        public IEnumerable<KnownApiRegion> GetKnownRegionList(KnownApiVendor vendor)
        {
            return KnownVendorEndPointPairs.Where(pair => pair.Key == vendor).Select(pair => pair.Value);
        }

        /// <summary>
        /// Return the geokey for a known region
        /// </summary>
        /// <param name="region">Known Api Region</param>
        /// <returns>Geo Key</returns>
        public string GetKnownRegionGeoKey(KnownApiRegion region)
        {
            var regionName = region.ToString().ToLowerInvariant();
            int index = regionName.IndexOf("_", StringComparison.Ordinal);
            return regionName.Substring(0, index);
        }

        /// <summary>
        /// Returns the KnownRegion from geoKey
        /// </summary>
        /// <param name="geoKey">Geo Key</param>
        /// <returns>Known Region</returns>
        public static KnownApiRegion GetKnownRegionFromGeoKey(string geoKey)
        {
            if (String.IsNullOrWhiteSpace(geoKey))
                throw new ArgumentNullException("geoKey");

            foreach (var knownApiRegion in Enum.GetValues(typeof(KnownApiRegion)).Cast<KnownApiRegion>())
            {
                var region = knownApiRegion.ToString().ToLowerInvariant();
                if (region.StartsWith(geoKey.ToLowerInvariant() + "_"))
                {
                    return knownApiRegion;
                }
            }

            throw new ArgumentException("Unknown geoKey '" + geoKey + "'.");
        }
        /// <summary>
        /// Creates the collection of known URLs per vendor according to Cloud API Documentation
        /// </summary>
        private void CreateKnownApiHostNames()
        {
            // Africa
            AddVpnHostName(KnownApiRegion.Africa_AF, "af1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Africa_AF, "af-monitoring.mcp-services.net");
            // Asia
            AddVpnHostName(KnownApiRegion.AsiaPacific_AP, "ap1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.AsiaPacific_AP, "ap-monitoring.mcp-services.net");
            // Australia
            AddVpnHostName(KnownApiRegion.Australia_AU, "au1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Australia_AU, "au-monitoring.mcp-services.net");
            // Canada
            AddVpnHostName(KnownApiRegion.Canada_CA, "ca1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Canada_CA, "ca-monitoring.mcp-services.net");
            // Europe
            AddVpnHostName(KnownApiRegion.Europe_EU, "eu1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Europe_EU, "eu-monitoring.mcp-services.net");
            // India
            AddVpnHostName(KnownApiRegion.India_IN, "in1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.India_IN, "in-monitoring.mcp-services.net");
            // Indonesia
            AddVpnHostName(KnownApiRegion.Indonesia_ID, "id1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Indonesia_ID, "id-monitoring.mcp-services.net");
            // Israel
            AddVpnHostName(KnownApiRegion.Israel_IL, "il1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.Israel_IL, "il-monitoring.mcp-services.net");
            // North America
            AddVpnHostName(KnownApiRegion.NorthAmerica_NA, "na1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.NorthAmerica_NA, "na-monitoring.mcp-services.net");
            // South America
            AddVpnHostName(KnownApiRegion.SouthAmerica_SA, "sa1.cloud-vpn.net");
            AddMonitoringHostName(KnownApiRegion.SouthAmerica_SA, "sa-monitoring.mcp-services.net");

            #region DimensionData
            // Africa
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Africa_AF, "api-mea.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.AsiaPacific_AP, "api-ap.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            // Australia
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Australia_AU, "api-au.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Canada_CA, "api-canada.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");
            // Europe
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Europe_EU, "api-eu.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // India
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.India_IN, "inapi.opsourcecloud.net");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.India_IN, "ftps-in.cloud-vpn.net");
            // Indonesia
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Indonesia_ID, "idapi.opsourcecloud.net");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Indonesia_ID, "ftps-id.cloud-vpn.net");
            // Israel
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Israel_IL, "ilapi.opsourcecloud.net");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Israel_IL, "ftps-med-1.cloud-vpn.net");
            // North America
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.NorthAmerica_NA, "api-na.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            // South America
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.SouthAmerica_SA, "api-latam.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.SouthAmerica_SA, "ftps-latam.cloud-vpn.net");
            #endregion

            #region DimensionData_Government
            AddHostName(KnownApiVendor.DimensionData_Government, KnownApiRegion.Australia_AU, "api-canberra.dimensiondata.com");
            AddFtpHostName(KnownApiVendor.DimensionData_Government, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            #endregion

            #region NTTA
            // Africa
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Africa_AF, "sacloudapi.nttamerica.com");
            AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");

            // Asia Pacific
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.AsiaPacific_AP, "hkcloudapi.nttamerica.com");
            AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");

            // Asutralia
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Australia_AU, "aucloudapi.nttamerica.com");
            AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");

            // Europe
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Europe_EU, "eucloudapi.nttamerica.com");
            AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");

            // North America
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.NorthAmerica_NA, "cloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            #endregion

            #region Cisco
            // Africa
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Africa_AF, "iaas-api-mea.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.AsiaPacific_AP, "iaas-api-ap.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            // Australia
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Australia_AU, "iaas-api-au.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Canada_CA, "iaas-api-ca.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");
            // Europe
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Europe_EU, "iaas-api-eu.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // North America            
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.NorthAmerica_NA, "iaas-api-na.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            #endregion

            #region InternetSolutions
            // Africa
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Africa_AF, "meaapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.AsiaPacific_AP, "apapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            // Australia
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Australia_AU, "auapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Canada_CA, "canadaapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");
            // Europe
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Europe_EU, "euapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // India
            // Indonesia
            // Israel
            // North America
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.NorthAmerica_NA, "usapi.cloud.is.co.za");
            AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            // South America
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.SouthAmerica_SA, "latamapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.SouthAmerica_SA, "ftps-latam.cloud-vpn.net");
            #endregion

            #region Indosat
            // Africa
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Africa_AF, "iaas-afapi.indosat.com");
            AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            // Australia
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Australia_AU, "iaas-auapi.indosat.com");
            AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            // Europe
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Europe_EU, "iaas-euapi.indosat.com");
            AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // India
            // Indonesia
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Indonesia_ID, "iaas-api.indosat.com");
            AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Indonesia_ID, "ftps-in.cloud-vpn.net");
            // Israel
            // North America
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.NorthAmerica_NA, "iaas-usapi.indosat.com");
            AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            // South America
            #endregion

            #region BSNL
            // Africa
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Africa_AF, "afapi.bsnlcloud.com");
            AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            // Australia
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Australia_AU, "auapi.bsnlcloud.com");
            AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            // Europe
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Europe_EU, "euapi.bsnlcloud.com");
            AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // India
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.India_IN, "api.bsnlcloud.com");
            AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.India_IN, "ftps-in.cloud-vpn.net");
            // Indonesia
            // Israel
            // North America
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.NorthAmerica_NA, "usapi.bsnlcloud.com");
            AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            // South America
            #endregion

            #region RootAxcess
            AddHostName(KnownApiVendor.RootAxcess, KnownApiRegion.NorthAmerica_NA, "api.rootaxcesscloud.com");
            AddFtpHostName(KnownApiVendor.RootAxcess, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            #endregion

            #region Tenzing_Everest
            AddHostName(KnownApiVendor.Tenzing_Everest, KnownApiRegion.NorthAmerica_NA, "api.cloud.tenzing.com");
            AddFtpHostName(KnownApiVendor.Tenzing_Everest, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            #endregion

            #region PWW_Cloud_Connect
            AddHostName(KnownApiVendor.PWW_Cloud_Connect, KnownApiRegion.NorthAmerica_NA, "api.pwwcloudconnect.net");
            AddFtpHostName(KnownApiVendor.PWW_Cloud_Connect, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            #endregion

            #region Med_One
            // Africa
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.Africa_AF, "api-af.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            // Asia
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.AsiaPacific_AP, "api-ap.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            // Australia
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.Australia_AU, "api-au.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            // Canada
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.Canada_CA, "api-ca.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");
            // Europe
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.Europe_EU, "api-eu.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            // India
            // Indonesia
            // Israel
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.Israel_IL, "api.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.Israel_IL, "ftps-med-1.cloud-vpn.net");
            // North America
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.NorthAmerica_NA, "api-na.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            // South America
            AddHostName(KnownApiVendor.Med_One, KnownApiRegion.SouthAmerica_SA, "api-sa.cloud.med-1.com");
            AddFtpHostName(KnownApiVendor.Med_One, KnownApiRegion.SouthAmerica_SA, "ftps-latam.cloud-vpn.net");      
            #endregion
        }

        /// <summary>	Add host name to the known endpoints. </summary>        
        /// <param name="vendor">	The Vendor. </param>
        /// <param name="region">	The Region. </param>
        /// <param name="apiUrl">	The API URL. </param>
        private void AddHostName(KnownApiVendor vendor, KnownApiRegion region, string apiUrl)
        {
            string key = string.Concat(vendor.ToString(), '-', region.ToString());
            KnownApiHostNames.Add(key, apiUrl);
            KnownVendorEndPointPairs.Add(new KeyValuePair<KnownApiVendor, KnownApiRegion>(vendor, region));
        }

		/// <summary>	The add ftp host name. </summary>	
		/// <param name="vendor">	The vendor. </param>
		/// <param name="region">	The region. </param>
		/// <param name="apiUrl">	The API url. </param>
		private void AddFtpHostName(KnownApiVendor vendor, KnownApiRegion region, string apiUrl)
		{
			string key = string.Concat(vendor.ToString(), '-', region.ToString());
			KnownFtpHostNames.Add(key, apiUrl);
		}

        /// <summary>	The add vpn host name. </summary>		
		/// <param name="region">	The region. </param>
		/// <param name="apiUrl">	The API url. </param>
		private void AddVpnHostName(KnownApiRegion region, string apiUrl)
        {            
            KnownVpnHostNames.Add(region.ToString(), apiUrl);
        }

        /// <summary>	The add monitoring host name. </summary>		
        /// <param name="region">	The region. </param>
        /// <param name="apiUrl">	The API url. </param>
        private void AddMonitoringHostName(KnownApiRegion region, string apiUrl)
        {            
            KnownMonitoringHostNames.Add(region.ToString(), apiUrl);
        }
    }
}
