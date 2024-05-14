namespace HouseRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Security.Claims;

    using Data;
    using Data.Models;
    using Web.ViewModels.House;

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

        public IActionResult Details(int id) 
        { 
            House? house = _dbContext.Houses
                .FirstOrDefault(h => h.Id == id);

            if (house is null)
            {
                return BadRequest();
            }

            HouseDetailsViewModel houseDetails = new HouseDetailsViewModel()
            {
                Title = house.Title,
                ImageUrl = house.ImageUrl,
                Address = house.Address,
            };

            return View(houseDetails);
        }
    }
}
