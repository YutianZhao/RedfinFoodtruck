using RedfinFoodtruck.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedfinFoodtruck.Services.Services
{
    public class HttpClientServiceBase : IHttpClientServiceBase
    {
        protected readonly HttpClient Client;

        public virtual HttpRequestHeaders DefaultRequestHeaders => throw new NotImplementedException();

        public HttpClientServiceBase(HttpClient client)
        {
            Client = client;
        }
        
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return Client.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return Client.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return Client.SendAsync(request);
        }
    }
}
