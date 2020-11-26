using RedfinFoodtruck.Services.Common;
using RedfinFoodtruck.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedfinFoodtruck.Services.Interfaces
{
    public interface IMobileFoodScheduleHttpClientService
    {
        Task<List<MobileFoodScheduleDTO>> GetMobileFoodSchedule();
    }
}
