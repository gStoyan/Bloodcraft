﻿namespace Bloodcraft.Web.Areas.Users.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using Bloodcraft.Web.Areas.Users.Models.Castles;

    public class CastlesController : UserBaseController
    {
        private UserManager<User> userManager;
        private ICastlesService castlesService;

        public CastlesController(UserManager<User> userManager, ICastlesService castlesService)
        {
            this.userManager = userManager;
            this.castlesService = castlesService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(User);
            return View(new CastlesListingViewModel
            {
                Castles = await this.castlesService.ListUsersCastleAsync(userId)
            });
        }

        public async Task<IActionResult> List()
             => View(new CastlesListingViewModel
             {
                 Castles = await this.castlesService.ListAllAsync()
             });

        public async Task<IActionResult> Details(int id)
        => View(new CastleDetailsViewModel
        {
            AdminCastle = await this.castlesService.GetAdminCastleAsync(),
            UserCastle = await this.castlesService.GetUsersCastleAsync(id)
        });


        public async Task<IActionResult> Choose(string name)
        {
            var userId = this.userManager.GetUserId(User);

            await this.castlesService.ChooseAsync(userId, name);

            return RedirectToAction(nameof(Index));
        }
    }
}
