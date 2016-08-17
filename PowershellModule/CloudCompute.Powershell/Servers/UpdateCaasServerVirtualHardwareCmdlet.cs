// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCaasServerVMwareToolsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The set server state cmdlet.
	/// </summary>
	[Cmdlet("Update", "CaasServerVirtualHardware")]
	public class UpdateCaasServerVirtualHardwareCmdlet : PsCmdletCaasServerBase
	{
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				ResponseType response = Connection.ApiClient.ServerManagement.Server.UpgradeVirtualHardware(Guid.Parse(Server.id)).Result;
				if (response != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} :{2}", 
							response.operation, 
							response.responseCode, 
							response.message));
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

			base.ProcessRecord();
		}
	}
}