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
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Server20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Get-CaasOsImage cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOsImage")]
	[OutputType(typeof (DatacenterType))]
	public class GetCaasOsImageCmdlet : PSCmdletCaasWithConnectionBase
	{
        /// <summary>
        /// Gets or sets the id.        
        /// </summary>                
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os Image Id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the Datacenter Id.        
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Data center Id")]
        public string DatacenterId { get; set; }

        /// <summary>
        /// Gets or sets the Name of the OS Image.
        /// </summary>     
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os image name")]   
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the State.        
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os image State")]   
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Operating SystemId filter like REDHAT664.
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os id")]
        public string OperatingSystemId { get; set; }

        /// <summary>
        /// Gets or sets the Operating System Family filter. eg : UNIX
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os family like : Unix")]
        public string OperatingSystemFamily { get; set; }
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
			    ServerOsImageListOptions options = null;
			    if (ParameterSetName == "Filtered")
			        options = new ServerOsImageListOptions()
			        {
			            Ids = Id.HasValue ? new Guid[] {Id.Value} : null,
			            DatacenterId = DatacenterId,
			            Name = Name,
			            State = State,
			            OperatingSystemId = OperatingSystemId,
			            OperatingSystemFamily = OperatingSystemFamily
			        };			      
			   
			    IEnumerable<OsImageType> resultlist = Connection.ApiClient.ServerManagement.ServerImage.GetOsImages(options).Result.items;

			    if (resultlist == null || !resultlist.Any())
			    {
			        if (ParameterSetName == "Filtered")
			            WriteError(
			                new ErrorRecord(
			                    new ItemNotFoundException(
			                        "This command cannot find a matching object with the given parameters."
			                        ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
			    }

			    WriteObject(resultlist, true);
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