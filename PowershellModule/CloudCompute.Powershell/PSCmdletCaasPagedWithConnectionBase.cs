// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCmdletCaasWithConnectionBase.cs" company="">
//   
// </copyright>
// <summary>
//   This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using DD.CBU.Compute.Api.Contracts.Requests;

namespace DD.CBU.Compute.Powershell
{
	using System.Management.Automation;

    /// <summary>
	///     This base Command is used for authenticating command that requires an active CaaS Connection.
	/// </summary>
	public abstract class PsCmdletCaasPagedWithConnectionBase: PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The CaaS connection created by <see cref="NewCaasConnectionCmdlet" />
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The Page Number of the result page, only supported for MCP2")]
		public int? PageNumber { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Page Size of the result page, only supported for MCP2")]
        public int? PageSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Order By of the results, only supported for MCP2")]
        public string OrderBy { get; set; }


	    public PageableRequest PageableRequest
	    {
	        get
	        {
	            return new PageableRequest()
	            {
	                PageNumber = PageNumber,
	                PageSize = PageSize,
	                Order = OrderBy
	            };
	        }
	    }
	}
}