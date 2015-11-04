using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasDefaultPresistenceProfiles")]
    [OutputType(typeof(DefaultPersistenceProfileType[]))]
    public class GetCaasDefaultPresistenceProfilesCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the Persistence Profile name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The Persistence profile name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets Persistence Profile id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The Persistence profile id")]
        public Guid ProfileId { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<DefaultPersistenceProfileType> persistenceProfiles = new List<DefaultPersistenceProfileType>();
            base.ProcessRecord();

            try
            {
                persistenceProfiles = Connection.ApiClient.Networking.VipSupport.GetDefaultPersistenceProfiles(NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                                                                            (ParameterSetName.Equals("Filtered") ? new DefaultPersistenceProfileListOptions
                                                                                {
                                                                                    Id = ProfileId != Guid.Empty ? ProfileId : (Guid?)null,
                                                                                    Name = Name,
                                                                                } : null)).Result;
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

            if (persistenceProfiles != null && persistenceProfiles.Count() == 1)
            {
                WriteObject(persistenceProfiles.First());
            }
            else
            {
                WriteObject(persistenceProfiles);
            }
        }
    }
}
