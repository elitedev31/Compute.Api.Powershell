namespace DD.CBU.Compute.Api.Client.Interfaces
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Directory;

    public interface IWebApi : IDisposable
    {
        Task<TResult> ApiGetAsync<TResult>(Uri relativeOperationUri);

        Task<TResult> ApiPostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content);

        Task<IAccount> LoginAsync(ICredentials accountCredentials);

        void Logout();

        IAccount Account { get; }
    }
}
