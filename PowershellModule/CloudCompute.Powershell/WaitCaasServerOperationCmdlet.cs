// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitCaasServerOperationCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Monitor CaaS provisioning progress
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     Monitor CaaS provisioning progress
	/// </summary>
	[Cmdlet(VerbsLifecycle.Wait, "CaasServerOperation")]
	[OutputType(typeof (ServerType))]
	public class WaitCaasServerOperationCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     The _operationprogress record.
		/// </summary>
		private ProgressRecord _operationprogressRecord;

		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
		public ServerType Server { get; set; }

		/// <summary>
		///     Gets the operation progress record.
		/// </summary>
		private ProgressRecord OperationProgressRecord
		{
			get
			{
				if (_operationprogressRecord == null)
					_operationprogressRecord = new ProgressRecord(0, "Waiting...", "Waiting..");
				return _operationprogressRecord;
			}
		}

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			DateTime starttime = DateTime.Now;
			try
			{
				bool operationInProgress = false;
				bool waitingToStart = true;
				ServerType server = null;

				// initial loop to cover for any delay on the CaaS API, do while state of the server is normal (max 5 min)
				do
				{
					server = GetCaasServer(Server.id).Result;
					if (server != null)
					{
						waitingToStart = server.state.Equals("normal", StringComparison.InvariantCultureIgnoreCase);
						OperationProgressRecord.Activity = "Waiting CaaS to start the operation...CaaS server state still NORMAL";
						OperationProgressRecord.StatusDescription =
							string.Format(
								"If your operation does not change the server state do not use this cmdlet. Waiting another {0} minutes", 
								(starttime.AddMinutes(5) - DateTime.Now).Minutes);
						OperationProgressRecord.RecordType = ProgressRecordType.Processing;

						WriteProgress(OperationProgressRecord);
					}

					if (waitingToStart)
						Thread.Sleep(3000);
					if (starttime.AddMinutes(5) <= DateTime.Now)
						WriteError(
							new ErrorRecord(
								new TimeoutException("The wait operation timeout, as CaaS did not change not start in 5 minutes"), "-1", 
								ErrorCategory.OperationTimeout, Connection));
				}
 while (waitingToStart);
				OperationProgressRecord.RecordType = ProgressRecordType.Completed;
				OperationProgressRecord.PercentComplete = 100;
				WriteProgress(OperationProgressRecord);


// do while state of the server contains pending
				operationInProgress = true;
				do
				{
					// query the API to get the server progress
					server = GetCaasServer(Server.id).Result;
					if (server != null)
					{
						if (server.progress != null)
						{
							string activity = server.progress.action.Replace('_', ' ').ToTitleCase();
							string stepname = string.Empty;
							string activitytemplate = string.Empty;
							string activitydescription = "Provisioning...";
							int activityPercentComplete = 0;
							if (server.progress.step != null)
							{
								activity = server.progress.action.Replace('_', ' ').ToTitleCase();
								stepname = server.progress.step.name.Replace('_', ' ').ToTitleCase();
								activitytemplate = "{0} - Step {1} of {2}";
								activitydescription = string.Format(activitytemplate, stepname, server.progress.step.number, 
									server.progress.numberOfSteps);
								activityPercentComplete = server.progress.step.percentComplete;
							}

							OperationProgressRecord.Activity = activity;
							OperationProgressRecord.StatusDescription = activitydescription;
							OperationProgressRecord.PercentComplete = activityPercentComplete;
							OperationProgressRecord.RecordType = ProgressRecordType.Processing;
							WriteProgress(OperationProgressRecord);
						}

						operationInProgress = server.state.ToLower().Contains("pending");
						if (operationInProgress)
							Thread.Sleep(7000);
					}
				}
 while (operationInProgress);
				OperationProgressRecord.PercentComplete = 100;
				OperationProgressRecord.RecordType = ProgressRecordType.Completed;
				WriteProgress(OperationProgressRecord);


				WriteObject(server);
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


		/// <summary>
		/// The get deploye servers.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		private async Task<ServerType> GetCaasServer(string serverId)
		{
			return await Connection.ApiClient.ServerManagement.Server.GetMcp2DeployedServer(Guid.Parse(serverId));
		}
	}
}