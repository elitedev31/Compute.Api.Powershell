namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The get CaaS OS Images cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOsImages")]
    [OutputType(typeof(DeployedImageWithSoftwareLabelsType[]))]
    public class GetCaasOsImagesCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// Get a image OS by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "OS name to filter")]
        public string Name { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var resultlist = GetOsImagesTask().Result;
                if (resultlist.Any())
                {
                   if (!string.IsNullOrEmpty(Name))
                        resultlist = resultlist.Where(net => net.name.ToLower() == Name.ToLower());

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

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<IEnumerable<DeployedImageWithSoftwareLabelsType>> GetOsImagesTask()
        {
            return await CaaS.ApiClient.GetImages(Network.location);
        }
    }
}