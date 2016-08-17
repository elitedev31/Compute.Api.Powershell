// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasBackupClientCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Set backup client cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Set backup client cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasServerBackup")]
	[OutputType(typeof (ServerType))]
	public class DiasbleCaasServerBackupCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to modify the backup client", ValueFromPipeline = true)]
		public ServerType Server { get; set; }

		
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                Status status = Connection.ApiClient.Backup.DisableBackup(Server.id).Result;
                if (status != null)
                {
                    WriteDebug(
                        string.Format(CultureInfo.CurrentCulture,
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));
                }
                WriteObject(Server);
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