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
        private IAdminCastlesService castlesService;
        private UserManager<User> userManager;

        public CastlesController(IAdminCastlesService castlesService,UserManager<User> userManager)
        {
            this.castlesService = castlesService;
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(AdminCastleFormModel castle)
        {
            var userId = this.userManager.GetUserId(User);

            await this.castlesService.CreateAsync(userId,castle.Name,castle.ImgUrl, castle.Blood, castle.Gold, castle.TotalBloodIncome, castle.TotalGoldIncome);

            return RedirectToAction("Index","Panel");
        }
    }
}
