namespace CrowdExpress.Models.ViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel(string[] locations, string[] destinations)
        {
            Locations = locations;
            Destinations = destinations;
        }
        public string[] Locations { get; set; }
        public string[] Destinations { get; set; }
    }
}
