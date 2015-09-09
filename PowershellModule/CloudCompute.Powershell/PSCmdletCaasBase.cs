// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCmdletCaasBase.cs" company="">
//   
// </copyright>
// <summary>
//   This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
	using System;
	using System.IO;
	using System.Management.Automation;
	using System.Reflection;

	/// <summary>
	///     This base command is used for loading private CaaS dlls.
	/// </summary>
	public abstract class PSCmdletCaasBase : PSCmdlet
	{
		static PSCmdletCaasBase()
		{
			var currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += LoadFromSameFolder;	
		}
	
		private static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
		{
			string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string assemblyPath = Path.Combine(folderPath ?? string.Empty, new AssemblyName(args.Name).Name + ".dll");

			if (File.Exists(assemblyPath) == false)
				return null;

			Assembly assembly = Assembly.LoadFrom(assemblyPath);
			return assembly;
		}
	}
}