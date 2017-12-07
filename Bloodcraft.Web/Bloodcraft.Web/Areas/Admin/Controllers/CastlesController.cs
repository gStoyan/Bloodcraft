namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Bloodcraft.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CastlesController : AdminBaseController
    {
        private IAdminCastlesService castles;
        private UserManager<User> userManager;

        public CastlesController(
            IAdminCastlesService castles,
            UserManager<User> userManager)
        {
            this.castles = castles;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index() => View();

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(AdminCastleFormModel castle)
        {
            var userId = this.userManager.GetUserId(User);

            await this.castles.CreateAsync(userId,castle.Name, castle.Blood, castle.Gold, castle.TotalBloodIncome, castle.TotalGoldIncome);

            return RedirectToAction(nameof(Index));
        }
    }
}
