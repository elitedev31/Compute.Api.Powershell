// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasVlanCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual LAN cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	/// The new CaaS Virtual LAN cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasVlan")]
	[OutputType(typeof (VlanType[]))]
	public class GetCaasVlanCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, 
			HelpMessage = "The virtual lan name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the network domain.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, 
			HelpMessage = "The virtual lan domain")]
		public NetworkDomainType NetworkDomain { get; set; }

		/// <summary>
		/// Gets or sets the network domain.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, 
			HelpMessage = "The virtual lan domain")]
		public Guid VirtualLanId { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			IEnumerable<VlanType> vlans = new List<VlanType>();
			base.ProcessRecord();
			try
			{
				vlans = ParameterSetName.Equals("Filtered")
					? Connection.ApiClient.GetVlans(
						VirtualLanId, 
						Name, 
						(NetworkDomain != null) ? Guid.Parse(NetworkDomain.id) : Guid.Empty).Result
					: Connection.ApiClient.GetVlans().Result;
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						if (e is ComputeApiException)
						{
							WriteError(
								new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
						}
						else
						{
							ThrowTerminatingError(
								new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}

			if (vlans != null && vlans.Count() == 1)
			{
				WriteObject(vlans.First());
			}
			else
			{
				WriteObject(vlans);
			}
		}
	}
}