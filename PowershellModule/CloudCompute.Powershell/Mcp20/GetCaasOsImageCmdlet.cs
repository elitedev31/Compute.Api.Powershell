// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasDataCentreCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get-CaasDataCentre cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Server20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Get-CaasOsImage cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOsImage")]
	[OutputType(typeof (DatacenterType))]
    [OutputType(typeof(ImagesWithDiskSpeedImage), ParameterSetName = new string[] { "Mcp1"})]
    public class GetCaasOsImageCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        ///     The network to show the images from
        /// </summary>
        [Obsolete("Use DataCenterId instead")]
        [Parameter(Mandatory = false, ParameterSetName = "MCP10", HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// Gets or sets the id.        
        /// </summary>    
        [Alias("ImageId")]            
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Os Image Id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the Datacenter Id.        
        /// </summary>        
        [Alias("Location")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Data center Id")]
        public string DataCenterId { get; set; }

        /// <summary>
        /// Gets or sets the Name of the OS Image.
        /// </summary>     
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Os image name")]   
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the State.        
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Os image State")]   
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Operating SystemId filter like REDHAT664.
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Os id")]
        public string OperatingSystemId { get; set; }

        /// <summary>
        /// Gets or sets the Operating System Family filter. eg : UNIX
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Os family like : Unix")]
        public string OperatingSystemFamily { get; set; }


        /// <summary>
        /// Specifies if MCP 1.0 contracts should be returned
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "MCP10", HelpMessage = "Explicitly calling MCP 1.0 Api")]
        public SwitchParameter Mcp1 { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                if (Mcp1.IsPresent)
                {
                    if (Network != null && string.IsNullOrEmpty(DataCenterId))
                    {
                        DataCenterId = Network.location;
                    }

                    IEnumerable<ImagesWithDiskSpeedImage> resultlist = Connection.ApiClient.ServerManagementLegacy.ServerImage.GetImages(
                            Id.HasValue ? Id.ToString() : null, Name, DataCenterId, OperatingSystemId,
                            OperatingSystemFamily).Result;
                                        
                    WriteObject(resultlist, true);
                }

                ServerOsImageListOptions options = null;
			    if (ParameterSetName == "Filtered")
			        options = new ServerOsImageListOptions()
			        {
			            Ids = Id.HasValue ? new Guid[] {Id.Value} : null,
			            DatacenterId = DataCenterId,
			            Name = Name,
			            State = State,
			            OperatingSystemId = OperatingSystemId,
			            OperatingSystemFamily = OperatingSystemFamily
			        };

			    this.WritePagedObject(Connection.ApiClient.ServerManagement.ServerImage.GetOsImages(options, PageableRequest).Result);
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
// if (e is HttpRequestException)
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}
	}
}