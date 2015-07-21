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
    /// <summary>	Values that represent known API regions. </summary>
    /// <remarks>	Anthony, 4/24/2015. </remarks>
    public enum KnownApiRegion
    {
		/// <summary>
		/// North America (NA)
		/// </summary>
        NorthAmerica_NA,

		/// <summary>
		/// Europe (EU)
		/// </summary>
        Europe_EU,

		/// <summary>
		/// Australia (AU)
		/// </summary>
        Australia_AU,

		/// <summary>
		/// Africa (AF)
		/// </summary>
        Africa_AF,

		/// <summary>
		/// Asia Pacific (AP)
		/// </summary>
        AsiaPacific_AP,

		/// <summary>
		/// South America (LATAM)
		/// </summary>
        SouthAmerica_SA,

		/// <summary>
		/// Canada (CA)
		/// </summary>
        Canada_CA,

		/// <summary>
		/// Indonesia
		/// </summary>
        Indonesia_ID,

		/// <summary>
		/// India
		/// </summary>
        India_IN
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
        PWW_Cloud_Connect
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
				throw new ComputeApiException (
					ComputeApiError.BadRequest, 
					"Known Cloud API hostname not found with this vendor and region combination.", 
					string.Empty, 
					null, 
					string.Empty);


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
			if (!KnownApiHostNames.ContainsKey(key))
				throw new ComputeApiException(
					ComputeApiError.BadRequest, 
					"Known Cloud API hostname not found with this vendor and region combination.", 
					string.Empty, 
					null, 
					string.Empty);
			return KnownFtpHostNames[key];
	    }

        /// <summary>	List of Known Regions that are valid for the particular Vendor. </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
        /// <param name="vendor">	The Vendor. </param>
        /// <returns>	The list of known regions. </returns>
        public IEnumerable<KnownApiRegion> GetKnownRegionList(KnownApiVendor vendor)
        {
            return KnownVendorEndPointPairs.Where(pair => pair.Key == vendor).Select(pair => pair.Value);
        } 

        /// <summary>
        /// Creates the collection of known URLs per vendor according to Cloud API Documentation
        /// </summary>
        private void CreateKnownApiHostNames()
        {
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.NorthAmerica_NA, "api-na.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Europe_EU, "api-eu.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Australia_AU, "api-au.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Africa_AF, "api-mea.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.AsiaPacific_AP, "api-ap.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.SouthAmerica_SA, "api-latam.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.SouthAmerica_SA, "ftps-latam.cloud-vpn.net");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Canada_CA, "api-canada.dimensiondata.com");
			AddFtpHostName(KnownApiVendor.DimensionData, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");

            AddHostName(KnownApiVendor.DimensionData_Government, KnownApiRegion.Australia_AU, "api-canberra.dimensiondata.com");

            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.NorthAmerica_NA, "cloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Europe_EU, "eucloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Australia_AU, "aucloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Africa_AF, "sacloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.AsiaPacific_AP, "hkcloudapi.nttamerica.com");
			AddFtpHostName(KnownApiVendor.NTTA, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");

            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.NorthAmerica_NA, "iaas-api-na.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Europe_EU, "iaas-api-eu.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Australia_AU, "iaas-api-au.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Africa_AF, "iaas-api-mea.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.AsiaPacific_AP, "iaas-api-ap.cisco-ccs.com");
			AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Canada_CA, "iaas-api-ca.cisco-ccs.com");
            AddFtpHostName(KnownApiVendor.Cisco, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");


            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.NorthAmerica_NA, "usapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Europe_EU, "euapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Australia_AU, "auapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Africa_AF, "meaapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.AsiaPacific_AP, "apapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.AsiaPacific_AP, "ftps-ap.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.SouthAmerica_SA, "latamapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.SouthAmerica_SA, "ftps-latam.cloud-vpn.net");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Canada_CA, "canadaapi.cloud.is.co.za");
			AddFtpHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Canada_CA, "ftps-canada.cloud-vpn.net");

            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.NorthAmerica_NA, "iaas-usapi.indosat.com");
			AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Europe_EU, "iaas-euapi.indosat.com");
			AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Australia_AU, "iaas-auapi.indosat.com");
			AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Africa_AF, "iaas-afapi.indosat.com");
			AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Indonesia_ID, "iaas-api.indosat.com");
			AddFtpHostName(KnownApiVendor.Indosat, KnownApiRegion.Indonesia_ID, "ftps-in.cloud-vpn.net");


            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.NorthAmerica_NA, "usapi.bsnlcloud.com");
			AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Europe_EU, "euapi.bsnlcloud.com");
			AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Europe_EU, "ftps-eu.cloud-vpn.net");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Australia_AU, "auapi.bsnlcloud.com");
			AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Australia_AU, "ftps-au.cloud-vpn.net");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Africa_AF, "afapi.bsnlcloud.com");
			AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.Africa_AF, "ftps-af.cloud-vpn.net");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.India_IN, "api.bsnlcloud.com");
			AddFtpHostName(KnownApiVendor.BSNL, KnownApiRegion.India_IN, "ftps-in.cloud-vpn.net");

            AddHostName(KnownApiVendor.RootAxcess, KnownApiRegion.NorthAmerica_NA, "api.rootaxcesscloud.com");
            AddFtpHostName(KnownApiVendor.RootAxcess, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");

            AddHostName(KnownApiVendor.Tenzing_Everest, KnownApiRegion.NorthAmerica_NA, "api.cloud.tenzing.com");
            AddFtpHostName(KnownApiVendor.Tenzing_Everest, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");

            AddHostName(KnownApiVendor.PWW_Cloud_Connect, KnownApiRegion.NorthAmerica_NA, "api.pwwcloudconnect.net");
            AddFtpHostName(KnownApiVendor.PWW_Cloud_Connect, KnownApiRegion.NorthAmerica_NA, "ftps-na.cloud-vpn.net");
        }

        /// <summary>	Add host name to the known endpoints. </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
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
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		/// <param name="vendor">	The vendor. </param>
		/// <param name="region">	The region. </param>
		/// <param name="apiUrl">	The API url. </param>
		private void AddFtpHostName(KnownApiVendor vendor, KnownApiRegion region, string apiUrl)
		{
			string key = string.Concat(vendor.ToString(), '-', region.ToString());
			KnownFtpHostNames.Add(key, apiUrl);
		}
    }
}
