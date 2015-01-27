    using System;
    using System.Management.Automation;
    using DD.CBU.Compute.Api.Contracts.Image;
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
    [Cmdlet(VerbsCommon.New, "CaasExportCustomerImage")]
    [OutputType(typeof(ImageExportRecord))]
    public class NewCaasExportCustomerImageCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Customer Image.")]
        public ServerImageWithStateType CustomerImage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "A prefix for this export. Must not contain spaces.")]
        public string OvfPrefix { get; set; }
        
        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
				var record = ExportCustomerImage();

                if (record != null)
                {
                    WriteObject(record);
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

        ImageExportRecord ExportCustomerImage()
        {
			return Connection.ApiClient.ExportCustomerImage(CustomerImage, OvfPrefix).Result;
        }
    }
}