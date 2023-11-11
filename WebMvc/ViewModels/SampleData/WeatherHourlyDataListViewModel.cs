using WebMvc.Data.DataTableMapper;

namespace WebMvc.ViewModels.SampleData
{
    public class WeatherHourlyDataListViewModel
    {
        [DataTableColumn(0, "Time")]
        public string Time { get; set; }
        [DataTableColumn(1, "Temperature")]
        public double Temperature { get; set; }
        [DataTableColumn(2, "Humidity")]
        public double Humidity { get; set; }
        [DataTableColumn(3, "Wind Speed")]
        public double WindSpeed { get; set; }
    }
}