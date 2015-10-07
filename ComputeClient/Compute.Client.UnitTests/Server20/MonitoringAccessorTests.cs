using System;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Server20;
using DD.CBU.Compute.Api.Contracts.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.Server20
{
	[TestClass]
	public class MonitoringAccessorTests : BaseApiClientTestFixture
	{
        [TestMethod]
        public async Task EnableServerMonitoring_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EnableServerMonitoring(accountId), RequestFileResponseType.AsGoodResponse("EnableServerMonitoringResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new MonitoringAccessor(client);
            var response = await accessor.EnableServerMonitoring(new EnableServerMonitoringType
            {
                id = Guid.NewGuid().ToString(),
                servicePlan = "My plan"
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("ENABLE_SERVER_MONITORING", response.operation);
            Assert.AreEqual("OK", response.responseCode);
        }

        [TestMethod]
        public async Task ChangeServerMonitoringPlan_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.ChangeServerMonitoringPlan(accountId), RequestFileResponseType.AsGoodResponse("ChangeServerMonitoringPlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new MonitoringAccessor(client);
            var response = await accessor.ChangeServerMonitoringPlan(new ChangeServerMonitoringPlanType
            {
                id = Guid.NewGuid().ToString(),
                servicePlan = "My plan"
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("CHANGE_SERVER_MONITORING_PLAN", response.operation);
            Assert.AreEqual("OK", response.responseCode);
        }

        [TestMethod]
        public async Task DisableServerMonitoring_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DisableServerMonitoring(accountId), RequestFileResponseType.AsGoodResponse("DisableServerMonitoringResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new MonitoringAccessor(client);
            var response = await accessor.DisableServerMonitoring(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("DISABLE_SERVER_MONITORING", response.operation);
            Assert.AreEqual("OK", response.responseCode);
        }

        [TestMethod]
        public async Task GetMonitoringUsageReport_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetMonitoringUsageReport(accountId, DateTime.Today, null), RequestFileResponseType.AsGoodResponse("GetMonitoringUsageReportResponse.csv"));

            var client = GetWebApiClient();
            var accessor = new MonitoringAccessor(client);
            var response = await accessor.GetMonitoringUsageReport(DateTime.Today, null);

            Assert.IsNotNull(response);
        }
    }
}
