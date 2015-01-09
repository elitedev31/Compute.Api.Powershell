using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Datacenter;
using DD.CBU.Compute.Api.Contracts.Vendor;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Get, "CaasMultiGeoRegions")]
    [OutputType(typeof(Geo[]))]
   public class GetCaasMultiGeoRegionsCmdlet:PsCmdletCaasBase
   { /// <summary>
       /// The process record method.
       /// </summary>
       protected override void ProcessRecord()
       {
           base.ProcessRecord();

           try
           {
               var resultlist = CaaS.ApiClient.GetListOfMultiGeographyRegions().Result;
               if (resultlist != null && resultlist.Any())
               {

                 switch (resultlist.Count())
                   {
                       case 0:
                           WriteError(
                                 new ErrorRecord(
                                     new ItemNotFoundException(
                                         "This command cannot find a matching object with the given parameters."
                                         ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                           break;
                       case 1:
                           WriteObject(resultlist.First());
                           break;
                       default:
                           WriteObject(resultlist, true);
                           break;
                   }
               }
           }
           catch (AggregateException ae)
           {
               ae.Handle(
                   e =>
                   {
                       if (e is ComputeApiException)
                       {
                           WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                       }
                       else //if (e is HttpRequestException)
                       {
                           ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                       }
                       return true;
                   });
           }
       }
    }
}
