namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The get CaaS Customer Images cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasCustomerImages")]
    [OutputType(typeof(DeployedImageWithSoftwareLabelsType[]))]
    public class GetCaasCustomerImagesCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork NetworkWithLocations { get; set; }

        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "Name to filter")]
        public string Name { get; set; }



        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "Location to filter")]
        public string Location { get; set; }


        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var resultlist = GetCustomerImages();

                if (resultlist.Any())
                {
                    if (!string.IsNullOrEmpty(Location))
                        resultlist = resultlist.Where(item => item.location.ToLower() == Location.ToLower());

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
        /// Gets the customer images in the network
        /// </summary>
        /// <returns>The images</returns>
        private IEnumerable<DeployedImageWithSoftwareLabelsType> GetCustomerImages()
        {
            return CaaS.ApiClient.GetCustomerServerImages(NetworkWithLocations.location).Result;
        }
    }
}