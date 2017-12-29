﻿namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Web.Models.Castles;
    using Bloodcraft.Web.Models.Minions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MinionsController : Controller
    {
        private ICastlesService castlesService;
        private IMinionsService minionsService;

        public MinionsController(ICastlesService castles, IMinionsService minions)
        {
            this.castlesService = castles;
            this.minionsService = minions;
        }

        public async Task<IActionResult> NotEnoughResources() => View();

        public async Task<IActionResult> Details(int id,string name) =>
            View(
                new MinionsDetailsViewModel
                {
                    AdminCastle = await this.castlesService.GetAdminCastleAsync(),
                    UserCastle = await this.castlesService.GetUsersCastleAsync(id),
                    Minion = await this.minionsService.DetailsAsync(name)
                });
        
        public async Task<IActionResult> Create(int id, string name)
        {
            try
            {
                await this.minionsService.CreateAsync(id, name);
                ViewData["name"] = name;
                return View();

            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(NotEnoughResources));
            } 
        }
    }
}
