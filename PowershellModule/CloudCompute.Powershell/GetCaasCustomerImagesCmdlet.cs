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
    public class GetCaasCustomerImagesCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork NetworkWithLocations { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var images = GetCustomerImages();
                if (images != null && images.Any())
                {
                    WriteObject(images, true);
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
            var customerImages = CaaS.ApiClient.GetCustomerServerImages(NetworkWithLocations.location).Result;
            return customerImages;
        }
    }
}