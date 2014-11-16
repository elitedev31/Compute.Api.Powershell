using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Contracts.Server;

    /// <summary>
    /// The get CaaS Customer Images cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasCustomerImages")]
    [OutputType(typeof(ImagesWithDiskSpeedImage[]))]
    public class GetCaasCustomerImagesCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// Get a customer image by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "Name to filter")]
        public string Name { get; set; }

        /// <summary>
        /// Get a customer image by location
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Location to filter")]
        public string Location { get; set; }

        /// <summary>
        /// Get a customer image by imageId
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "ImageId to filter")]
        public string ImageId { get; set; }

        /// <summary>
        /// Get a customer image by OS Id
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Operating System Id to filter")]
        public string OperatingSystemId { get; set; }

        /// <summary>
        /// Get a customer image by OS family
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Operating System family to filter")]
        public string OperatingSystemFamily { get; set; }



        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (Network != null && string.IsNullOrEmpty(Location))
                {
                    Location = Network.location;
                }

                var resultlist = GetCustomerImages();

                if (resultlist.Any())
                {
                  
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
        private IEnumerable<ImagesWithDiskSpeedImage> GetCustomerImages()
        {
            return CaaS.ApiClient.GetCustomerServerImages(ImageId, Name, Location, OperatingSystemId,OperatingSystemFamily).Result;
        }
    }
}