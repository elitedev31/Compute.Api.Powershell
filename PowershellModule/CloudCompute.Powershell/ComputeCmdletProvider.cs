// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeCmdletProvider.cs" company="">
//   
// </copyright>
// <summary>
//   Cmdlet provider for CaaS Powershell.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Management.Automation.Provider;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// Cmdlet provider for CaaS Powershell.
	/// </summary>
	[CmdletProvider("ComputePowershellProvider", ProviderCapabilities.Credentials | ProviderCapabilities.ShouldProcess)]
	public class ComputeCmdletProvider
	{
	}
}