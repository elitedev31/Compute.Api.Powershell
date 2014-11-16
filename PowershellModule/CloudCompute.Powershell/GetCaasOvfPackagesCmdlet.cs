using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.ImportExportImages;

    /// <summary>
    /// The Get OVF Packages cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOvfPackages")]
    [OutputType(typeof(OvfPackageType[]))]
    public class GetCaasOvfPackagesCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var packages = GetOvfPackages();

                if (packages != null && packages.Any())
                {
                    WriteObject(packages, true);
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
        /// Gets the OVF Packages
        /// </summary>
        /// <returns>The packages</returns>
        private IEnumerable<OvfPackageType> GetOvfPackages()
        {
            var packages = CaaS.ApiClient.GetOvfPackages().Result;
            return packages.ovfPackage;
        }
    }
}