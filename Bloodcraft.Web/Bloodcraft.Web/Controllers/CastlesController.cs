namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Users;
    using Bloodcraft.Web.Models.Castles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class CastlesController : Controller
    {
        private UserManager<User> userManager;
        private ICastlesService castles;

        public CastlesController(UserManager<User> userManager,ICastlesService castles)
        {
            this.userManager = userManager;
            this.castles = castles;
        }
        public IActionResult Index() => View();
               
        public async Task<IActionResult> List()
             => View(new CastlesListingViewModel
             {
                 Castles = await this.castles.ListAllAsync()
             });


        public async Task<IActionResult> Choose(string name)
        {
            var userId = this.userManager.GetUserId(User);

            await this.castles.ChooseAsync(userId, name);

            return View();
        }
    }
}
