// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasConnectionCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The remove caas connection cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The remove caas connection cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasConnection")]
	public class RemoveCaasConnectionCmdlet : PSCmdlet
	{
		/// <summary>
		/// Name for this connection
		/// </summary>
		[Parameter(Mandatory = true, Position = 0, HelpMessage = "Connection name to be removed from session.")]
		public string Name { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				SessionState.RemoveComputeServiceConnection(Name);
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