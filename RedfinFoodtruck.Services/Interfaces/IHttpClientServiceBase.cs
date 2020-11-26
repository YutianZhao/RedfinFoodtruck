using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedfinFoodtruck.Services.Interfaces
{
    public interface IHttpClientServiceBase
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);

        Task<HttpResponseMessage> GetAsync(Uri requestUri);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
