using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.VIP;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Get,"CaasServerFarm")]
    [OutputType(typeof(ServerFarm[]))]
    public class GetCaasServerFarmCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The name for the real server
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The name for the server farm")]
        public string Name { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var resultlist = Connection.ApiClient.GetServerFarms(Network.id).Result;
                if (resultlist!=null && resultlist.Any())
                {


                    if (!string.IsNullOrEmpty(Name))
                        resultlist = resultlist.Where(farm => String.Equals(farm.name, Name, StringComparison.CurrentCultureIgnoreCase));


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
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }

        }
    }
}
