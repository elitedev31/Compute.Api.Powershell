using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
    public static class Extensions
    {

        public static string ToQueryString(this NameValueCollection collection)
        {
            return string.Join("&", collection.AllKeys.Where(key => !string.IsNullOrWhiteSpace(collection[key])).Select(key => string.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(collection[key]))));
          
        
        }

    }
}
