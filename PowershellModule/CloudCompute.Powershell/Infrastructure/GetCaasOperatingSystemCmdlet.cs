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
using DD.CBU.Compute.Api.Contracts.Requests.Infrastructure;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Get-CaasOsImage cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOperatingSystem")]
	[OutputType(typeof (OperatingSystemType))]
	public class GetCaasOperatingSystemCmdlet : PsCmdletCaasPagedWithConnectionBase
    {   
        /// <summary>
        /// Gets or sets the Name of the OS Image.
        /// </summary>     
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os image name")]   
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Operating SystemId filter like REDHAT664.
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os id, eg : CENTOS5/32")]
        public string OperatingSystemId { get; set; }

        /// <summary>
        /// Gets or sets the Operating System Family filter. eg : UNIX
        /// </summary>        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The Os family like : Unix")]
        public string OperatingSystemFamily { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The data center Id")]
        public string DatacenterId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary> 
        protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                OperatingSystemListOptions options = null;
			    if (ParameterSetName == "Filtered")
			        options = new OperatingSystemListOptions()
			        {			          
			            Name = Name,
			            Id = OperatingSystemId,
			            Family = OperatingSystemFamily
			        };

			    this.WritePagedObject(Connection.ApiClient.Infrastructure.GetOperatingSystems(DatacenterId, PageableRequest, options).Result);
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