namespace Bloodcraft.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Bloodcraft.Web.Models;
    using Microsoft.AspNetCore.Identity;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Users;
    using System.Threading.Tasks;
    using Bloodcraft.Web.Models.Home;

    public class HomeController : Controller
    {
        private IUsersService usersService;
        private UserManager<User> userManager;
        public HomeController(IUsersService usersService, UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var id = this.userManager.GetUserId(User);

            var users = await this.usersService.GetUsersAsync();

            var model = new HomeViewModel();
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    {
                        model.CastlesCount = user.CastlesCount;
                    }
                }
            }
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
