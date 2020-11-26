using RedfinFoodtruck.Services.Models;
using RedfinFoodtruck.Services.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedfinFoodtruck.Services
{
    public class GetCurrentOpenStores
    {
        public static async Task<List<MobileFoodScheduleDTO>> GetMobileFoodSchedule()
        {
            try
            {
                // For DI:
                // return await _mobileFoodScheduleHttpClientService.GetMobileFoodSchedule();

                // For Console:
                var serviceBase = new HttpClientServiceBase(new HttpClient());
                var service = new MobileFoodScheduleHttpClientService(serviceBase);
                return await service.GetMobileFoodSchedule();
            }
            catch (Exception ex)
            {
                // We can log error here
                Console.WriteLine("Error while getting mobile food schedule" + ex.Message + ex.StackTrace);
                return new List<MobileFoodScheduleDTO>(null);
            }
        }

        public static async Task<List<MobileFoodScheduleDTO>> GetCurrentOpenMobileFoods()
        {
            var timeNow = DateTime.Now;
            var dayOfWeekNow = DateTime.Now.DayOfWeek;
            var timeNow24 = timeNow.ToString("HH:mm:ss");
            var mobileFoodsSchedule = await GetMobileFoodSchedule();
            foreach(var element in mobileFoodsSchedule)
            {
                if (element.Start24 == "24:00")
                {
                    element.Start24 = "00:00";
                }
                if (element.End24 == "24:00")
                {
                    element.End24 = "00:00";
                }
            }
            var nowOpen = mobileFoodsSchedule.Where(x => x.Dayofweekstr == dayOfWeekNow.ToString()
                && DateTime.ParseExact(x.Start24, "HH:mm", CultureInfo.InvariantCulture) <= timeNow
                && (DateTime.ParseExact(x.End24, "HH:mm", CultureInfo.InvariantCulture) >= timeNow || x.End24 == "00:00")).ToList();
            return nowOpen;
        }
    }
}
