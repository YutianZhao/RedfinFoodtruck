using System;
using System.Collections.Generic;
using System.Text;

namespace RedfinFoodtruck.Services.Models
{
    public class MobileFoodScheduleDTO
    {
        public string Dayorder { get; set; }

        public string Dayofweekstr { get; set; }

        public string Starttime { get; set; }

        public string Endtime { get; set; }

        public string Permit { get; set; }

        public string Location { get; set; }

        public string Locationdesc { get; set; }

        public string Optionaltext { get; set; }

        public string Locationid { get; set; }

        public string Start24 { get; set; }

        public string End24 { get; set; }

        public string Cnn { get; set; }

        public string Addr_date_create { get; set; }

        public string Addr_date_modified { get; set; }

        public string Block { get; set; }

        public string Lot { get; set; }

        public string Coldtruck { get; set; }

        public string Applicant { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Location2DTO Location_2 { get; set; }

    }
}
