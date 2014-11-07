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
        public NetworkWithLocationsNetwork NetworkWithLocations { get; set; }

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
                var servers = GetOsImagesTask().Result;
                if (servers.Any())
                {
                    if(string.IsNullOrEmpty(Name))
                        WriteObject(servers, true);
                    else
                        WriteObject(servers.Single(os => os.name.ToLower() == Name.ToLower()));
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
            return await CaaS.ApiClient.GetImages(NetworkWithLocations.location);
        }
    }
}