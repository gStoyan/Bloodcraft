namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Bloodcraft.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MinionsController : AdminBaseController
    {
        private IAdminMinionsService minions;

        public MinionsController(IAdminMinionsService minions)
        {
            this.minions = minions;
        }

        public IActionResult Index() => View();

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(AdminMinionFormModel minion)
        {
            await this.minions.CreateAsync(minion.Name,
                minion.ImgUrl,
                minion.GoldCost,
                minion.BloodCost,
                minion.AttackPoints,
                minion.DefencePoints,
                minion.BloodPoints);

            return RedirectToAction(nameof(Index));
        }
    }
}
