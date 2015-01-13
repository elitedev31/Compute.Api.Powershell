using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
    /// <summary>
    /// 
    /// </summary>
    public enum KnownApiRegion
    {

        NorthAmerica_NA,
        Europe_EU,
        Australia_AU,
        Africa_AF,
        AsiaPacific_AP,
        SouthAmerica_SA,
        Canada_CA,
        Indonesia_ID,
        India_IN
        
    }

    public enum KnownApiVendor
    {
        DimensionData,
        NTTA,
        Cisco,
        InternetSolutions,
        Indosat,
        BSNL


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
        public static KnownApiUri Instance
        {
            get { return _instance ?? (_instance = new KnownApiUri()); }
            private set { _instance = value; }
        }

        /// <summary>
        /// Contructor
        /// </summary>
        private KnownApiUri()
        {
            KnownApiHostNames = new Dictionary<string, string>();
            KnownVendorEndPointPairs = new List<KeyValuePair<KnownApiVendor, KnownApiRegion>>();
            CreateKnownApiHostNames();
        }

        /// <summary>
        /// private Dictionary to host all endpoints 
        /// </summary>
        private Dictionary<string,string> KnownApiHostNames { get; set; }

        /// <summary>
        /// Mapping between Vendor and applicable regions
        /// </summary>
        private List<KeyValuePair<KnownApiVendor, KnownApiRegion>> KnownVendorEndPointPairs { get; set; }   
        
        /// <summary>
        /// Return an known CaaS URI based on vendor and region
        /// </summary>
        /// <param name="vendor">the vendor</param>
        /// <param name="region">the region</param>
        /// <returns></returns>
        public Uri GetBaseUri(KnownApiVendor vendor, KnownApiRegion region)
        {
            const string urltemplate = "https://{0}/oec/0.9/";
            string key = string.Concat(vendor.ToString(), '-', region.ToString());
            if(!KnownApiHostNames.ContainsKey(key))
                throw new ComputeApiException(ComputeApiError.BadRequest,"Known Cloud API hostname not found with this vendor and region combination.","",null,"");


            string apiurl = string.Format(urltemplate, KnownApiHostNames[key]);
            return new Uri(apiurl);      
        }

        /// <summary>
        /// List of Known Regions that are valid for the particular Vendor.
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
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
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Europe_EU, "api-eu.dimensiondata.com");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Australia_AU, "api-au.dimensiondata.com");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Africa_AF, "api-mea.dimensiondata.com");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.AsiaPacific_AP, "api-ap.dimensiondata.com");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.SouthAmerica_SA, "api-latam.dimensiondata.com");
            AddHostName(KnownApiVendor.DimensionData, KnownApiRegion.Canada_CA, "api-canada.dimensiondata.com");


            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.NorthAmerica_NA, "cloudapi.nttamerica.com");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Europe_EU, "eucloudapi.nttamerica.com");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Australia_AU, "aucloudapi.nttamerica.com");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.Africa_AF, "sacloudapi.nttamerica.com");
            AddHostName(KnownApiVendor.NTTA, KnownApiRegion.AsiaPacific_AP, "hkcloudapi.nttamerica.com");

            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.NorthAmerica_NA, "iaas-api-na.cisco-ccs.com");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Europe_EU, "iaas-api-eu.cisco-ccs.com");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Australia_AU, "iaas-api-au.cisco-ccs.com");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.Africa_AF, "iaas-api-mea.cisco-ccs.com");
            AddHostName(KnownApiVendor.Cisco, KnownApiRegion.AsiaPacific_AP, "iaas-api-ap.cisco-ccs.com");

            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.NorthAmerica_NA, "usapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Europe_EU, "euapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Australia_AU, "auapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Africa_AF, "meaapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.AsiaPacific_AP, "apapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.SouthAmerica_SA, "latamapi.cloud.is.co.za");
            AddHostName(KnownApiVendor.InternetSolutions, KnownApiRegion.Canada_CA, "canadaapi.cloud.is.co.za");

            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.NorthAmerica_NA, "iaas-usapi.indosat.com");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Europe_EU, "iaas-euapi.indosat.com");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Australia_AU, "iaas-auapi.indosat.com");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Africa_AF, "iaas-afapi.indosat.com");
            AddHostName(KnownApiVendor.Indosat, KnownApiRegion.Indonesia_ID, "iaas-api.indosat.com");

            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.NorthAmerica_NA, "usapi.bsnlcloud.com");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Europe_EU, "euapi.bsnlcloud.com");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Australia_AU, "auapi.bsnlcloud.com");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.Africa_AF, "afapi.bsnlcloud.com");
            AddHostName(KnownApiVendor.BSNL, KnownApiRegion.India_IN, "api.bsnlcloud.com");
      
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="region"></param>
        /// <param name="apiUrl"></param>
        private void AddHostName(KnownApiVendor vendor, KnownApiRegion region, string apiUrl)
        {
            string key = string.Concat(vendor.ToString(), '-', region.ToString());
            KnownApiHostNames.Add(key, apiUrl);
            KnownVendorEndPointPairs.Add(new KeyValuePair<KnownApiVendor, KnownApiRegion>(vendor, region));
        }

    }

}
