using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set server state command let.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasServerState")]
	public class SetCaasServerActionCmdlet : PsCmdletCaasServerBase
	{
		/// <summary>
		///     The server action.
		/// </summary>
		public enum ServerAction
		{
			/// <summary>
			///     The power off.
			/// </summary>
			PowerOff, 

			/// <summary>
			///     The power on.
			/// </summary>
			PowerOn, 

			/// <summary>
			///     The restart.
			/// </summary>
			Restart, 

			/// <summary>	
			/// An constant representing the reset option. 
			/// </summary>
			Reset,

			/// <summary>
			///     The shutdown.
			/// </summary>
			Shutdown
		}

		/// <summary>
		///     Gets or sets the action.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server action to take")]
		public ServerAction Action { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			SetServerActionTask();
			base.ProcessRecord();
		}

		/// <summary>
		///     Sets the state of the server
		/// </summary>
		private void SetServerActionTask()
		{
			try
			{
				ResponseType status = null;
				Guid serverId = Guid.Parse(Server.id);
				switch (Action)
				{
					case ServerAction.PowerOff:
						status = Connection.ApiClient.ServerManagement.Server.PowerOffServer(serverId).Result;
						break;
					case ServerAction.PowerOn:
						status = Connection.ApiClient.ServerManagement.Server.StartServer(serverId).Result;
						break;
					case ServerAction.Restart:
						status = Connection.ApiClient.ServerManagement.Server.RebootServer(serverId).Result;
						break;
					case ServerAction.Reset:
						status = Connection.ApiClient.ServerManagement.Server.ResetServer(serverId).Result;
						break;
					case ServerAction.Shutdown:
						status = Connection.ApiClient.ServerManagement.Server.ShutdownServer(serverId).Result;
						break;
					default:
						ThrowTerminatingError(
							new ErrorRecord(
								new NotImplementedException(), 
								"-1", 
								ErrorCategory.InvalidOperation, 
								Action));
						break;
				}

				if (status != null)
				{
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}",
							status.operation,
							status.message,
							status.responseCode,
							status.error));
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