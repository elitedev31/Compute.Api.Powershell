using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using CaaSAPI.XmlModel;
using CaaSAPI.Utils;
using CaaSAPI.Model;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace CaaSAPI
{
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Xml;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class CaaSProxy
    {
        protected RestClient rClient;
        protected string Username;
        protected string Password;

        // cotr' -using the settings configuration we'll assign the url, user, and password
        public CaaSProxy(ServiceCredential settings)
        {
            string rc_url = settings.Host + "/oec/0.9/";
            this.rClient = new RestClient(rc_url);
            this.rClient.Authenticator = new HttpBasicAuthenticator(settings.Username, settings.Password);

            this.Username = settings.Username;
            this.Password = settings.Password;
        }

        //this method is based on: https://github.com/restsharp/RestSharp/wiki/Recommended-Usage
        public T Execute<T>(RestRequest request) where T : new() 
       {
            // this part is implemented already in the cotr'
           //var client = new RestClient(); 
           //client.BaseUrl = BaseUrl;
           //client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
           request.AddParameter("AccountSid",this.Username, ParameterType.UrlSegment); // used on every request
           var response = rClient.Execute<T>(request);

           if (response.ErrorException != null)
           {
               const string message = "Error retrieving response.  Check inner details for more info.";
               var opsourceException = new OpSourceProxyException(this.GetType(), message);
               throw opsourceException;
           }
           return response.Data;
       }

       public string GetAccountID()
        {
            RestRequest rr = new RestRequest("myaccount", Method.GET);
            var resp =  rClient.Execute(rr);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Account acct = XmlApiObject.FromXmlString<Account>(resp.Content).ProjectFromXmlApiObject<Account>();
                return acct.orgId;
            }
            else
            {
                throw new OpSourceProxyException(this.GetType(), "Unable to get AccountID.");
            }

        }
        protected static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        protected static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;
                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }




    }

    public class CaasCustomerProxy : CaaSProxy
    {
        public CaasCustomerProxy(ServiceCredential settings)
            : base(settings)
        {
        }
        public NetworkWithLocationsNetwork[] NetworkWithLocations(Guid OrgID)
        {
            string relURL = string.Format("{0}/networkWithLocation", OrgID.ToString());
            RestRequest rr = new RestRequest(relURL, Method.GET);
            var resp = rClient.Execute(rr);

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                NetworkWithLocations root = XmlApiObject.FromXmlString<NetworkWithLocations>(resp.Content).ProjectFromXmlApiObject<NetworkWithLocations>();
                return root.Items;
            }
            else
            {
                Status status = XmlApiObject.FromXmlString<Status>(RemoveAllNamespaces(resp.Content)).ProjectFromXmlApiObject<Status>();
                throw new OpSourceProxyException(this.GetType(), status.resultDetail);
            }
        }

        public NetworkServer[] GetNetworkServers(Guid OrgID)
        {
                //using the following API https://api-au.dimensiondata.com/oec/0.9/{org-id}/serverWithBackup? for example: https://api-au.dimensiondata.com/oec/0.9/3433176c-a280-45e5-8ba2-cde4c8473439/serverWithBackup
                string relURL = string.Format("{0}/serverWithBackup?", OrgID.ToString());
                RestRequest rr = new RestRequest(relURL, Method.GET);
                var resp = rClient.Execute(rr);
                try
                {
                    // get the servers list in the network using the org-id which is storred in the account-id using the following REST API:
                    if (resp.StatusCode == HttpStatusCode.OK) //parsing the xml content and returning data object out of it
                    {
                        // step1: convert the XML node into a JSON string   
                        XmlDocument mydoc = new XmlDocument();
                        mydoc.LoadXml(resp.Content);
                        string jsonText = JsonConvert.SerializeXmlNode(mydoc);

                        //step2: desirialize the complete json string to a dictionary
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        var dict = jss.Deserialize<Dictionary<string, dynamic>>(jsonText);

                        // step3 extract only the relevant data (listOfservers) out of the dictionary into a sub-json string
                        // problem with this string is that it contains fields with "@" which will break the desirialization later...
                        string listOfserversJsonString = jss.Serialize(dict["ServersWithBackup"]["server"]);

                        //step4 to work around the invalid json field names - we'll remove invalid chars from the json string, 
                        //and finally we can deserialize it to a list of servers out of a legal json string
                        listOfserversJsonString = Regex.Replace(listOfserversJsonString, @"@", "");
                        NetworkServer[] listOfservers = jss.Deserialize<NetworkServer[]>(listOfserversJsonString);

                        return listOfservers;
                    }
            }

            catch (Exception)
            {

                Status status =
                    XmlApiObject.FromXmlString<Status>(RemoveAllNamespaces(resp.Content))
                        .ProjectFromXmlApiObject<Status>();
                throw new OpSourceProxyException(this.GetType(), status.resultDetail);
            }
            // if something bad happened and we got here:
            Status badstatus = XmlApiObject.FromXmlString<Status>(RemoveAllNamespaces(resp.Content)).ProjectFromXmlApiObject<Status>();
            throw new OpSourceProxyException(this.GetType(), badstatus.resultDetail);
        }
    }

}
