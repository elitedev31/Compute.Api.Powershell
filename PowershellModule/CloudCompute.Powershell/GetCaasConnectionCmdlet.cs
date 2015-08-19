// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasConnectionCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas connection cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get caas connection cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasConnection")]
	[OutputType(typeof (KeyValuePair<string, ComputeServiceConnection>[]))]
	public class GetCaasConnectionCmdlet : PSCmdlet
	{
		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			WriteObject(SessionState.GetComputeServiceConnections(), true);
		}
	}
}