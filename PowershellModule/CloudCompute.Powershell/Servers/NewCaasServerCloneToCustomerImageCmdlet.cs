// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerCloneToCustomerImageCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set server state cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasServerCloneToCustomerImage")]
	public class NewCaasServerCloneToCustomerImageCmdlet : PsCmdletCaasServerBase
    {
        ///// <summary>
        ///// ID for Customer Image to clone
        ///// </summary>
        //[Parameter(Mandatory = true, HelpMessage = "Identifies the Server to be cloned")]
        //public string Id { get; set; }

        /// <summary>
        ///     Customer Image name
        /// </summary>
        [Parameter(Mandatory = true, 
			HelpMessage =
				"Set the customer image name. Note that the Customer Image name is required to be unique in a given data center.")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the customer image description")]
		public string Description { get; set; }

        /// <summary>
        /// For multiple cluster environments, it is possible to set a destination
        /// cluster for the new Customer Image.Note that performance of this
        /// function is optimal when either the Server cluster and destination
        /// are the same or when shared data storage is in place for the
        /// multiple clusters.See List Data Centers for cluster and shared
        /// datastore information for the Data Center where the Server
        /// resides.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the destination cluster for the new customer image")]
        public string ClusterId { get; set; }

        /// <summary>
        /// Will default to true if not supplied. If set to false this property tells
        /// CloudControl that Servers deployed from the resulting Customer
        /// Image should NOT utilize Guest OS Customization.
        /// The source Server must be stopped if false is provided for
        /// guestOsCustomization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "If set to false this property tells CloudControl that Servers deployed from the resulting Customer Image should NOT utilize Guest OS Customization")]
        public bool? GuestOsCustomization { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			try
			{
                var cloneServerType = new CloneServerType()
                {
                    id = Server.id,
                    imageName = Name,
                    description = Description,
                    clusterId = ClusterId,
                    guestOsCustomization = GuestOsCustomization.HasValue?GuestOsCustomization.Value:true,
                    guestOsCustomizationSpecified = GuestOsCustomization.HasValue
                };

                var status = Connection.ApiClient.ServerManagement.Server.CloneServer(cloneServerType).Result;
                if (status != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.error, 
							status.responseCode, 
							status.message));
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
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}

			base.ProcessRecord();
		}
	}
}