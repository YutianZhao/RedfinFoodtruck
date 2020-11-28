using RedfinFoodtruck.Services;
using RedfinFoodtruck.Services.Common;
using RedfinFoodtruck.Services.Interfaces;
using RedfinFoodtruck.Services.Models;
using RedfinFoodtruck.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedfinFoodtruck
{
    public class Program
    {
        private readonly IMobileFoodScheduleHttpClientService _mobileFoodScheduleHttpClientService;

        public Program(IMobileFoodScheduleHttpClientService mobileFoodScheduleHttpClientService)
        {
            _mobileFoodScheduleHttpClientService = mobileFoodScheduleHttpClientService;
        }
        static async Task Main(string[] args)
        {
            var nowOpenTask = await GetCurrentOpenStores.GetCurrentOpenMobileFoods();
            var nowOpen = nowOpenTask.OrderBy(x => x.Applicant).ToList();
            //foreach(var food in nowOpen)
            //{
            //    Console.WriteLine(food.Applicant + " ------ " + food.Starttime + " - " + food.Endtime + " ------ " + food.Location);
            //}
            int nowOpenCount = nowOpen.Count;
            int pages = nowOpenCount / 10;
            int nowPage = 0;
            for (int i = 0; i < pages; i++)
            {
                for (int j = 0 + 10 * nowPage; j < 10 + 10 * nowPage; j++)
                {
                    Console.WriteLine(nowOpen[j].Applicant + " ------ " + nowOpen[j].Starttime + " - " + nowOpen[j].Endtime + " ------ " + nowOpen[j].Location);
                }
                if (pages > 0)
                {
                    Console.WriteLine("Click any button to contine");
                    Console.ReadLine();
                }
                if (pages <= 0 || (nowOpenCount % 10 == 0 && i == pages - 1))
                {
                    Console.WriteLine("List end");
                }
                nowPage += 1;
            }

            if (nowOpenCount % 10 != 0 && pages >= 1)
            {
                int remained = nowOpenCount % 10;
                for (int k = 0 + 10 * pages; k < remained + 10 * pages; k++)
                {
                    Console.WriteLine(nowOpen[k].Applicant + " ------ " + nowOpen[k].Starttime + " - " + nowOpen[k].Endtime + " ------ " + nowOpen[k].Location);
                }
                Console.WriteLine("List end");
            }
            Console.ReadLine();
        }
    }
}
