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


        public async Task<string> GetAll()
        {
            WeatherMeasurement weatherMeasurement = null;
            using(var client = new HttpClient())
            {
                var jsonResponse = await client.GetStringAsync("http://weatherapi2dashboard.azurewebsites.net/api/WeatherMeasurement/2018-03-06T14");
                if (jsonResponse != null)
                    weatherMeasurement = JsonConvert.DeserializeObject<WeatherMeasurement>(jsonResponse);
                return weatherMeasurement.Id.ToString() + weatherMeasurement.Temperature.ToString() + weatherMeasurement.UpdateTime;
            }

        }

       
    }
}
