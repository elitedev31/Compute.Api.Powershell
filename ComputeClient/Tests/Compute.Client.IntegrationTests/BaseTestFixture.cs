using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Client.IntegrationTests
{
    public abstract class BaseTestFixture
    {
        /// <summary>
        ///		Get CaaS account credentials for use during integration tests.
        /// </summary>
        /// <returns>
        ///		An <see cref="ICredentials"/> implementation representing the credentials to use when authenticating to the API.
        /// </returns>
        /// <remarks>
        ///		Since this is no longer an open-source project, we *will* use valid credentials as part of the source code.
        /// </remarks>
        protected ICredentials GetIntegrationTestCredentials()
        {
            var userName = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            return new NetworkCredential(userName, password);
        }
    }
}
