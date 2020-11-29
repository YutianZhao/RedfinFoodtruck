using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedfinFoodtruck.Services.Models
{
    public class CountryAndDateDTO
    {
        [JsonProperty("United States")]
        public List<DateTime> UnitedStates { get; set; }

        public List<DateTime> India { get; set; }

        public List<DateTime> Canada { get; set; }
    }
}
