// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasDataCentreCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get-CaasDataCentre cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Infrastructure;

    /// <summary>
    ///     The Get-CaasGeoRegions cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasGeoRegions")]
    [OutputType(typeof(GeographicRegionType))]
    public class GetCaasGeographicRegionsCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        /// Gets or sets the Name of the Geo.
        /// </summary>     
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Geo Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Geo Id.
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Geo Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Region .
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Get the home region")]
        public bool? IsHome { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The state")]
        public string State { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary> 
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var options = new ListGeographicRegionOptions()
                {
                    Name = Name,
                    Id = Id,
                    State = State,
                    IsHome = IsHome
                };

                this.WritePagedObject(Connection.ApiClient.Infrastructure.ListGeographicRegions(PageableRequest, options).Result);
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
                        else
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}