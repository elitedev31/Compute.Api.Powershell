namespace DD.CBU.Compute.Api.Client.Customers
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts.Provisioning;

    /// <summary>
    /// Api calls to apis defined in Customers Api category
    /// </summary>
    public static class ComputeApiClientCustomersExtensions
    {
        /// <summary>
        /// Provision Net Terms Customer
        /// </summary>
        /// <param name="computeApiClient">Compute Api Client</param>
        /// <param name="organizationId">
        /// Organization Id
        /// </param>
        /// <param name="customerProvision">
        /// The custom Provisioning.
        /// </param>
        /// <returns>
        /// Provision Status
        /// </returns>
        public async static Task<Status> ProvisionCustomerInHomeGeo(this IComputeApiClient computeApiClient, Guid organizationId, CustomerProvision customerProvision)
        {
            return
                await
                computeApiClient.WebApi.ApiPostAsync<CustomerProvision, Status>(
                    ApiUris.GetUriForProvisioning(organizationId),
                    customerProvision);
        }

        /// <summary>
        /// Provision Customer on a multi-geography data center
        /// </summary>
        /// <param name="computeApiClient">
        /// The compute Api Client.
        /// </param>
        /// <param name="organizationId">
        /// The customer Id.
        /// </param>
        /// <param name="geographyId">
        /// The geography Id.
        /// </param>
        /// <param name="customerPricingPlanKey">
        /// The pricing Plan Key.
        /// </param>
        /// <returns>
        /// Statuc
        /// </returns>
        public static async Task<Status> ProvisionCustomerInGeo(this IComputeApiClient computeApiClient, Guid organizationId, Guid geographyId, string customerPricingPlanKey)
        {
            return await
                    computeApiClient.WebApi.ApiPostAsync<CustomerGeoSignUp, Status>(
                        ApiUris.GetUriForProvisionOnGeo(organizationId),
                        new CustomerGeoSignUp { geoId = geographyId, pricingPlanKey = customerPricingPlanKey });
        }
    }
}
