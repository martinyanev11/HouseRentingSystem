namespace HouseRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Common;
    using Web.ViewModels.House;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;

    public class HouseController : Controller
    {
        private readonly HouseRentingDbContext _dbContext;

        public HouseController(HouseRentingDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult All()
        {
            AllHousesViewModel allHouses = new AllHousesViewModel()
            {
                Houses = _dbContext.Houses
                    .Select(h => new HouseDetailsViewModel()
                    {
                        Address = h.Address,
                        Title = h.Title,
                        ImageUrl = h.ImageUrl,
                    })
            };

            return View(allHouses);
        }

        [Authorize]
        public IActionResult Mine()
        {
            string? currentUserId = this.User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            AllHousesViewModel allHouses = new AllHousesViewModel()
            {
                Houses = _dbContext.Houses
                    .Where(h => h.Agent.UserId ==  currentUserId)
                    .Select(h => new HouseDetailsViewModel()
                    {
                        Address = h.Address,
                        Title = h.Title,
                        ImageUrl = h.ImageUrl,
                    })
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
