    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using DD.CBU.Compute.Api.Contracts.Image;
    using DD.CBU.Compute.Api.Contracts.Network;
    using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    using Api.Client;

    using DD.CBU.Compute.Api.Client.ImportExportImages;

    /// <summary>
    ///	The "New-CaasImportCustomerImage" Cmdlet.
    /// </summary>
    /// <remarks>
    ///	Imports a new customer image.
    /// </remarks>
    [Cmdlet(VerbsCommon.New, "CaasImportCustomerImage", SupportsShouldProcess = true)]
    [OutputType(typeof(ServerImageWithStateType))]
    public class NewCaasImportCustomerImageCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Customer Image name.")]
        public string CustomerImageName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "An OVF Package on the organization’s FTPS account")]
        public OvfPackageType OvfPackage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target data centre location for the customer image.")]
        public NetworkWithLocationsNetwork Network { get; set; }

        [Parameter(HelpMessage = "The description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var serverImage = ImportCustomerImage();

                if (serverImage != null)
                {
                    WriteObject(serverImage);
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

        ServerImageWithStateType ImportCustomerImage()
        {
            return CaaS.ApiClient.ImportCustomerImage(CustomerImageName, OvfPackage.name, Network.location, Description).Result;
        }
    }
}