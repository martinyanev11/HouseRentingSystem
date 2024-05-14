namespace HouseRentingSystem.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using ViewModels.Error;
    using HouseRentingSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly HouseRentingDbContext _dBcontext;

        public HomeController(HouseRentingDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel()
            {
                TotalHouses = _dBcontext.Houses.Count(),
                TotalRents = _dBcontext.Houses
                    .Where(h => h.RenterId != null)
                    .Count(),
                Houses = _dBcontext.Houses
                    .Select(h => new HouseIndexViewModel()
                    {
                        Title = h.Title,
                        ImageUrl = h.ImageUrl,
                    }),
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
