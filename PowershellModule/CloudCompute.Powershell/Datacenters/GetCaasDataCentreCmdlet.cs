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
	///     The Get-CaasDataCentre cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasDataCentre")]
	[OutputType(typeof (DatacenterType))]
	public class GetCaasDataCentreCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The data center Id")]
        public string Id { get; set; }
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                this.WritePagedObject(Connection.ApiClient.Infrastructure.GetDataCentersPaginated(PageableRequest, new DataCenterListOptions {Id = Id}).Result);								
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