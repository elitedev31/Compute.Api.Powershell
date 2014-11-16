
using DD.CBU.Compute.Api.Contracts.Datacenter;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using Api.Client;

    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    ///	The "New-CaasNetwork" Cmdlet.
    /// </summary>
    /// <remarks>
    ///	Deploys a new network in a specified data centre location.
    /// </remarks>
    [Cmdlet(VerbsCommon.New, "CaasNetwork", SupportsShouldProcess = true)]
    public class NewCaasNetworkCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "A unique name for the new network to deploy")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The data centre location where the network will be deployed.", ValueFromPipeline = true)]
        public DatacenterWithMaintenanceStatusType Datacentre { get; set; }

        [Parameter(HelpMessage = "The description of the network")]
        public string Description { get; set; }

        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var status = CaaS.ApiClient.CreateNetwork(Name, Datacentre.location, Description).Result;
                if (status != null)
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));
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