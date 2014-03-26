using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client.Interfaces
{
    internal class HttpClientAdapter : IHttpClient
    {
        private HttpClient _client;

        public HttpClientAdapter(HttpClient client)
        {
            _client = client;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return _client.GetAsync(uri);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri uri)
        {
            return _client.DeleteAsync(uri);
        }

        public Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content)
        {
            return _client.PutAsync(uri, content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return _client.PostAsync(uri, content);
        }
    }
}
