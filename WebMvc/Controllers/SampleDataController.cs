using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMvc.Filters;
using WebMvc.ViewModels.SampleData;

namespace WebMvc.Controllers
{
    [RoutePrefix("SampleData")]
    public class SampleDataController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint = "https://api.open-meteo.com/v1/forecast";

        public SampleDataController()
        {
            _httpClient = new HttpClient(); 
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SampleDataIndexViewModel();

            //model.Latitude = 999;
            //model.Longitude = -948;

            return View(model);
        }

        [HttpGet]
        [AjaxOnly]
        [Route("WeatherForecastListTableJson")]
        public async Task<ActionResult> WeatherForecastListTableJson(double latitude, double longitude)
        {
            string url = $"{_apiEndpoint}?latitude={latitude}&longitude={longitude}&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
            string result = string.Empty;
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherDataViewModel>(content);

                    List<WeatherHourlyDataListViewModel> records = new List<WeatherHourlyDataListViewModel>();

                    for (int i = 0; i < weatherData.Hourly.Time.Count; i++)
                    {
                        var record = new WeatherHourlyDataListViewModel()
                        {
                            Time = weatherData.Hourly.Time[i],
                            Temperature = weatherData.Hourly.Temperature2m[i],
                            Humidity = weatherData.Hourly.RelativeHumidity2m[i],
                            WindSpeed = weatherData.Hourly.WindSpeed10m[i],
                        };
                        records.Add(record);
                    }

                    result = JsonConvert.SerializeObject(new { data = records });
                }
            } catch (Exception ex)
            {
                return RedirectToAction("InternalServer", "Error", new { errorMessage = ex.Message });
            }            

            return Content(result, "application/json");
        }

    }
}