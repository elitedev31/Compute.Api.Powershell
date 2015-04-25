// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasBackupClientsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get backup client types cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Backup;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The get backup client types cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasBackupClients")]
	[OutputType(typeof (BackupClientDetailsType[]))]
	public class GetCaasBackupClientsCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server associated with the backup client types", 
			ValueFromPipeline = true)]
		public ServerWithBackupType Server { get; set; }


		/// <summary>
		/// Name to filter
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "Name to filter")]
		public string Name { get; set; }


		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<BackupClientDetailsType> resultlist = GetBackupClients();

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

		/// <summary>
		/// Gets the backup clients
		/// </summary>
		/// <returns>
		/// The backup clients
		/// </returns>
		private IEnumerable<BackupClientDetailsType> GetBackupClients()
		{
			return Connection.ApiClient.GetBackupClients(Server.id).Result;
		}
	}
}