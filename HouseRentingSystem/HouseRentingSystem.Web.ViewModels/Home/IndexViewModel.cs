namespace HouseRentingSystem.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public int TotalHouses { get; set; }

        public int TotalRents { get; set; }

        public IEnumerable<HouseIndexViewModel> Houses { get; set; }
            = new List<HouseIndexViewModel>();
    }
}
