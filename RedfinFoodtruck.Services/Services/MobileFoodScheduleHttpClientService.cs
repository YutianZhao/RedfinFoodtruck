using Newtonsoft.Json;
using RedfinFoodtruck.Services.Common;
using RedfinFoodtruck.Services.Interfaces;
using RedfinFoodtruck.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedfinFoodtruck.Services.Services
{
    public class MobileFoodScheduleHttpClientService : IMobileFoodScheduleHttpClientService
    {
        private readonly IHttpClientServiceBase _serviceBase;
        private string GetMobileFoodScheduleUrl;

        public MobileFoodScheduleHttpClientService(IHttpClientServiceBase serviceBase)
        {
            GetMobileFoodScheduleUrl = "https://data.sfgov.org/resource/jjew-r69b.json";
            _serviceBase = serviceBase;
        }

        public async Task<string> MakeRequest(string url, HttpMethod method, object body = null, JsonSerializerSettings customSettings = null)
        {
            using (var requestMessage = new HttpRequestMessage(method, new Uri(url)))
            using (var content = body != null ? new StringContent(JsonConvert.SerializeObject(body, customSettings ?? JsonExtension.Settings()), Encoding.UTF8, "application/json") : null)
            {
                if (content != null)
                {
                    requestMessage.Content = content;
                }
                // Not sure about header, check later. May have bearer token, will define in Configuration Service:
                // requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token)
                var response = await _serviceBase.SendAsync(requestMessage);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<List<MobileFoodScheduleDTO>> GetMobileFoodSchedule()
        {
            var response = await MakeRequest(GetMobileFoodScheduleUrl, HttpMethod.Get);
            return JsonConvert.DeserializeObject<List<MobileFoodScheduleDTO>>(response, JsonExtension.Settings());
        }
    }
}
