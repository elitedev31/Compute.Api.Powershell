// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasDataCentreCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get-CaasDataCentre cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Get-CaasSnapshotWindows cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasSnapshotWindows")]
	[OutputType(typeof (SnapshotWindowType))]
	public class GetCaasSnapshotWindowsCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", HelpMessage = "The data center Id")]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Filtered", HelpMessage = "The Service Plan")]
        public string ServicePlan { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                this.WritePagedObject<SnapshotWindowType>(Connection.ApiClient.Infrastructure.GetSnapshotWindowPaginated(Id, ServicePlan, null, PageableRequest).Result);								
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