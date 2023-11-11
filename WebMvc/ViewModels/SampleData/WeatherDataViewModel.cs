using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebMvc.ViewModels.SampleData
{
    public class WeatherDataViewModel
    {
        public HourlyData Hourly { get; set; }
        

        public class HourlyData
        {
            [JsonProperty("time")]
            public List<string> Time { get; set; }
            [JsonProperty("temperature_2m")]
            public List<double> Temperature2m { get; set; }
            [JsonProperty("relative_humidity_2m")]
            public List<double> RelativeHumidity2m { get; set; }
            [JsonProperty("wind_speed_10m")]
            public List<double> WindSpeed10m { get; set; }
        }

    }
}