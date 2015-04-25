// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasMultiGeoRegionsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas multi geo regions cmdlet.
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
	/// The get caas multi geo regions cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasMultiGeoRegions")]
	[OutputType(typeof (Geo[]))]
	public class GetCaasMultiGeoRegionsCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<Geo> resultlist = Connection.ApiClient.GetListOfMultiGeographyRegions().Result;
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
						case 1:
							WriteObject(resultlist.First());
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