using WebMvc.Data.DataTableMapper;

namespace WebMvc.ViewModels.SampleData
{
    public class SampleDataIndexViewModel
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string ColDefs_WeatherForecastList
        {
            get
            {
                return new Mapper().GetColumnsJson(typeof(WeatherHourlyDataListViewModel));
            }
        }

    }
}