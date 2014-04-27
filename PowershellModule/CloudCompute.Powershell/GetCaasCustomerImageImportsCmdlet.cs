namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.ImportExportImages;

    /// <summary>
    /// The Get Customer Image Imports cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasCustomerImageImports")]
    [OutputType(typeof(ServerImageWithStateType[]))]
    public class GetCaasCustomerImageImportsCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var imports = GetCustomerImageImports();

                if (imports != null && imports.Any())
                {
                    WriteObject(imports, true);
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
        /// Gets the customer image imports
        /// </summary>
        /// <returns>The customer image imports in progress</returns>
        private IEnumerable<ServerImageWithStateType> GetCustomerImageImports()
        {
            return CaaS.ApiClient.GetCustomerImagesImports().Result;
        }
    }
}