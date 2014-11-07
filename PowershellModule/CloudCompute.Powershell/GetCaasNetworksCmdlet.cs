namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network;

    /// <summary>
    /// The get networks cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNetworks")]
    [OutputType(typeof(NetworkWithLocationsNetwork[]))]
    public class GetCaasNetworksCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position=1, HelpMessage = "Network name to filter")]
        public string Name { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                
                var networks = CaaS.ApiClient.GetNetworksTask().Result;
              

                if (networks.Any())
                {
                    if (string.IsNullOrEmpty(Name))
                        WriteObject(networks, true);
                    else
                        WriteObject(networks.Single(net => net.name.ToLower()==Name.ToLower()));
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