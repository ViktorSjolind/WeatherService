using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        

        // /weather/getall?time=2018-03-06T14
        public async Task<string> Get(string time)
        {
            WeatherMeasurement weatherMeasurement = null;

            using(var client = new HttpClient())
            {
                var jsonResponse = await client.GetStringAsync("http://weatherapi2dashboard.azurewebsites.net/api/WeatherMeasurement/" + time);
                if (jsonResponse != null)
                    weatherMeasurement = JsonConvert.DeserializeObject<WeatherMeasurement>(jsonResponse);
                return weatherMeasurement.Temperature.ToString();
                //return time;
            }

        }

        // /weather/getlastten
        public async Task<ViewResult> GetLastTen()
        {
            List<WeatherMeasurement> weatherMeasurementList = new List<WeatherMeasurement>();
            WeatherMeasurement weatherMeasurement = null;

            using (var client = new HttpClient())
            {
                               

                for (int i = 9; i >= 0; i--)
                {
                    DateTime upperBound = DateTime.UtcNow.AddHours(-1 * i);
                    string dateTimeUrl = upperBound.ToString("yyyy-MM-ddTHH");

                    var jsonResponse = await client.GetStringAsync("http://weatherapi2dashboard.azurewebsites.net/api/WeatherMeasurement/" + dateTimeUrl);
                    if (jsonResponse != null)
                    {
                        weatherMeasurement = JsonConvert.DeserializeObject<WeatherMeasurement>(jsonResponse);
                        weatherMeasurementList.Add(weatherMeasurement);
                    }
                }

                string result = "";
                foreach(WeatherMeasurement wm in weatherMeasurementList)
                {
                    result += wm.Temperature + " ";
                }
                //return result;
                ViewBag.One = weatherMeasurementList[0];
                return View("Index");
            }

            
            

        }

       
    }
}
