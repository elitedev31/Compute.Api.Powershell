// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasCustomerImageImportsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get Customer Image Imports cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Get Customer Image Imports cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasCustomerImageImports")]
	[OutputType(typeof (ServerImageWithStateType))]
	public class GetCaasCustomerImageImportsCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<ServerImageWithStateType> resultlist = GetCustomerImageImports();

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

		/// <summary>
		///     Gets the customer image imports
		/// </summary>
		/// <returns>
		///     The customer image imports in progress
		/// </returns>
		private IEnumerable<ServerImageWithStateType> GetCustomerImageImports()
		{
			return Connection.ApiClient.ImportExportCustomerImage.GetCustomerImagesImports().Result;
		}
	}
}