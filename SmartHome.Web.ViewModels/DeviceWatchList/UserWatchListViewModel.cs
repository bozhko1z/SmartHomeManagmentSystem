
namespace SmartHome.Web.ViewModels.DeviceWatchList
{
    public class UserWatchListViewModel
    {
        public string DeviceId { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string Type { get; set; } = null!;

        public bool Status { get; set; }
    }
}
