namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The Get-CaasDataCentre cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDataCentre")]
    [OutputType(typeof(DatacenterWithMaintenanceStatusType[]))]
    public class GetCaasDataCentreCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var dcs = CaaS.ApiClient.GetDataCentersWithMaintenanceStatuses().Result;

                if (dcs.Any())
                {
                    WriteObject(dcs, true);
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
    }
}