namespace HouseRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Common;
    using Web.ViewModels.House;

    public class HouseController : Controller
    {
        public IActionResult All()
        {
            AllHousesViewModel allHouses = new AllHousesViewModel()
            {
                Houses = RawData.GetHouses()
            };

            return View(allHouses);
        }

        public IActionResult Details() 
        { 
            HouseDetailsViewModel? houseDetails = 
                RawData.GetHouses().FirstOrDefault();

            return View(houseDetails);
        }
    }
}
