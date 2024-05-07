namespace HouseRentingSystem.Web.ViewModels.House
{
    using System.Collections.Generic;

    public class AllHousesViewModel
    {
        public IEnumerable<HouseDetailsViewModel> Houses { get; set; } 
            = new List<HouseDetailsViewModel>();
    }
}
