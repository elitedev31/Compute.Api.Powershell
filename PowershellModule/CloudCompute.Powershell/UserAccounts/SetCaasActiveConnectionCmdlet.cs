// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasActiveConnectionCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set caas active connection cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set caas active connection cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasActiveConnection")]
	[OutputType(typeof (ComputeServiceConnection))]
	public class SetCaasActiveConnectionCmdlet : PSCmdlet
	{
		/// <summary>
		///     Name for this connection
		/// </summary>
		[Parameter(Mandatory = true, Position = 0, HelpMessage = "Connection name to be set as active.")]
		public string Name { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				SessionState.SetDefaultComputeServiceConnection(Name);
				WriteObject(SessionState.GetDefaultComputeServiceConnection(), false);
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Name));
						return true;
					});
			}
		}
	}
}