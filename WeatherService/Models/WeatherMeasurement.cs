using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Models
{
    public class WeatherMeasurement
    {
        public long Id { get; set; }
        public decimal Temperature { get; set; }
        public string UpdateTime { get; set; }




        public WeatherMeasurement(long id, decimal temperature, string updateTime)
        {
            this.Id = id;
            this.Temperature = temperature;
            this.UpdateTime = updateTime;
        }

    }
}
