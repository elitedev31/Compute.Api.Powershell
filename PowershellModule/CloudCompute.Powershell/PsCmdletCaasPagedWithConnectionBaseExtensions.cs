using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// Handles Paging extensions for the Paged commandlet
    /// </summary>
    public static class PsCmdletCaasPagedWithConnectionBaseExtensions
    {

        /// <summary>
        /// Handles Showing up warnings for 
        /// </summary>
        /// <typeparam name="T">Type of the Item</typeparam>
        /// <param name="cmdLet">Paged CommandLet</param>
        /// <param name="pagedResponse">Paged Response</param>        
        public static void WritePagedObject<T>(this PsCmdletCaasPagedWithConnectionBase cmdLet, PagedResponse<T> pagedResponse)
        {
            if (cmdLet == null)
                return;

            if (pagedResponse == null || pagedResponse.items == null || !pagedResponse.items.Any())
            {
                cmdLet.WriteWarning("No items found with the specified criteria");
                return;
            }

            cmdLet.WriteObject(pagedResponse.items, true);

            // Add warning after writing out the results, else the warning is lost
            decimal pageCount = pagedResponse.pageCount.HasValue ? (decimal)pagedResponse.pageCount : 1;
            decimal pageNumber = pagedResponse.pageNumber.HasValue ? (decimal)pagedResponse.pageNumber : 1;
            decimal totalCount = pagedResponse.totalCount.HasValue ? (decimal)pagedResponse.totalCount : 1;
            decimal pageSize = pagedResponse.pageSize.HasValue ? (decimal)pagedResponse.pageSize : 1;
            var numberOfPages = (int)Math.Ceiling(totalCount/pageSize);
            var currentPageNumber = pagedResponse.pageNumber.HasValue ? pagedResponse.pageNumber : 1;
            if (currentPageNumber < numberOfPages)
                cmdLet.WriteWarning(string.Format("There are more items in the results(total items:{0}, total items on this page: {1}, page number: {2}), please provide PageNumber or PageSize to get more results", totalCount, pageCount, pageNumber));            
        }
    }
}
