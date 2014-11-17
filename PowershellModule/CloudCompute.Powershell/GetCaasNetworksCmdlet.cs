namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    /// The get networks cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNetworks")]
    [OutputType(typeof(NetworkWithLocationsNetwork[]))]
    public class GetCaasNetworksCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position=1, HelpMessage = "Network name to filter")]
        public string Name { get; set; }


        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, HelpMessage = "Location to filter")]
        public string Location { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                
                var resultlist = CaaS.ApiClient.GetNetworksTask().Result;

                if (resultlist.Any())
                {
                     if (!string.IsNullOrEmpty(Location))
                         resultlist = resultlist.Where(item => item.location.ToLower() == Location.ToLower());
                    
                     if (!string.IsNullOrEmpty(Name))
                             resultlist = resultlist.Where(net => net.name.ToLower()==Name.ToLower());

                     switch (resultlist.Count())
                   {
                       case 0:
                           WriteDebug("Object(s) not found");
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