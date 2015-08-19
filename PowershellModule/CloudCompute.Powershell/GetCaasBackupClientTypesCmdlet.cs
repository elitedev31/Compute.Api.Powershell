// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasBackupClientTypesCmdlet.cs" company="">
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
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get backup client types cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasBackupClientTypes")]
	[OutputType(typeof (BackupClientType[]))]
	public class GetCaasBackupClientTypesCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server associated with the backup client types", 
			ValueFromPipeline = true)]
		public ServerType Server { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<BackupClientType> resultlist = GetBackupClientTypes();
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
		///     Gets the network servers from the CaaS
		/// </summary>
		/// <returns>
		///     The images
		/// </returns>
		private IEnumerable<BackupClientType> GetBackupClientTypes()
		{
			return Connection.ApiClient.Backup.GetBackupClientTypes(Server.id).Result;
		}
	}
}