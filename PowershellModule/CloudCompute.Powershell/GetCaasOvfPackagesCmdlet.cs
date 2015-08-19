// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasOvfPackagesCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get OVF Packages cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Get OVF Packages cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasOvfPackages")]
	[OutputType(typeof (OvfPackageType[]))]
	public class GetCaasOvfPackagesCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<OvfPackageType> packages = GetOvfPackages();

				if (packages != null && packages.Any())
				{
					WriteObject(packages, true);
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
		///     Gets the OVF Packages
		/// </summary>
		/// <returns>
		///     The packages
		/// </returns>
		private IEnumerable<OvfPackageType> GetOvfPackages()
		{
			OvfPackages packages = Connection.ApiClient.ImportExportCustomerImage.GetOvfPackages().Result;
			return packages.ovfPackage;
		}
	}
}