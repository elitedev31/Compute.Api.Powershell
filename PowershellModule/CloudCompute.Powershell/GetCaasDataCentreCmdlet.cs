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
using DD.CBU.Compute.Api.Contracts.Datacenter;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Get-CaasDataCentre cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasDataCentre")]
	[OutputType(typeof (DatacenterWithMaintenanceStatusType))]
	public class GetCaasDataCentreCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<DatacenterWithMaintenanceStatusType> resultlist =
					Connection.ApiClient.Account.GetDataCentersWithMaintenanceStatuses().Result;

				if (resultlist != null && resultlist.Any())
				{
					switch (resultlist.Count())
					{
						case 0:
							WriteError(
								new ErrorRecord(
									new ItemNotFoundException(
										"This command cannot find a matching object with the given parameters."
										), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
							break;						
						default:
							WriteObject(resultlist, true);
							break;
					}
				}
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