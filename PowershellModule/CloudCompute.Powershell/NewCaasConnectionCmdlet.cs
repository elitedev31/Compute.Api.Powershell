namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    ///		The "New-CaasConnection" Cmdlet.
    /// </summary>
    /// <remarks>
    ///		Used to create a new connection to the CaaS API.
    /// </remarks>
    [Cmdlet(VerbsCommon.New, "CaasConnection", SupportsShouldProcess = true)]
    public class NewCaasConnectionCmdlet : PSCmdlet
    {
		/// <summary>
		///		The name of the PowerShell variable in which active cloud-compute sessions are stored.
		/// </summary>
		const string SessionsVariableName = "_CloudComputeSessions";

        /// <summary>
        ///		The credentials used to connect to the CaaS API.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential ApiCredentials { get; set; }

        /// <summary>
        /// The base uri of the REST API
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The base URI of the REST API")]
        public Uri ApiBaseUri { get; set; }

        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
			WriteDebug("Trying to login to the REST API");
			ComputeServiceConnection newCloudComputeConnection = LoginTask().Result;
            if (newCloudComputeConnection != null)
            {
                WriteDebug(
					String.Format(
						"CaaS connection created successfully: {0}",
						newCloudComputeConnection
					)
				);

	            AddToSession(newCloudComputeConnection);
                WriteObject(newCloudComputeConnection);
            }
        }

        /// <summary>
        /// Try to login into the account using the credentials.
        /// If succeed, it will return the account details.
        /// </summary>
        /// <returns>The CaaS connection</returns>
        private async Task<ComputeServiceConnection> LoginTask()
        {
            // Login to the CaaS REST API
            var caas = new ComputeServiceConnection(new ComputeApiClient(ApiBaseUri));
            WriteDebug("CaaS object created");

            await caas.ApiClient.LoginAsync(ApiCredentials.GetNetworkCredential());

            return caas;
        }

		/// <summary>
		///		Add the specified CaaS connection to the '_CloudComputeSessions' variable in the current session.
		/// </summary>
		/// <param name="connection">
		///		A <see cref="ComputeServiceConnection"/> representing the CaaS connection.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="connection"/> is <c>null</c>.
		/// </exception>
	    void AddToSession(ComputeServiceConnection connection)
	    {
		    if (connection == null)
			    throw new ArgumentNullException("connection");

			// Store in session variable.
			List<ComputeServiceConnection> connections;

			PSVariable connectionsVariable = SessionState.PSVariable.Get(SessionsVariableName);
			if (connectionsVariable == null)
			{
				connectionsVariable = new PSVariable(
					SessionsVariableName,
					value:
						connections = new List<ComputeServiceConnection>()
					);
				SessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
			}
			else
			{
				connections = (List<ComputeServiceConnection>)connectionsVariable.Value;
				if (connections == null)
				{
					connectionsVariable.Value = connections = new List<ComputeServiceConnection>();
					SessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
				}
			}

			connections.Add(connection);
	    }
    }
}