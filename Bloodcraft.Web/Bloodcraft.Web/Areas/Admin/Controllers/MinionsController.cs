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

        public async Task<IActionResult> Index(int page = 1)
      =>
        View(new AdminMinionsListingViewModel
        {
            AllMinions = await this.minions.AllAsync(page),
            TotalMinions = await this.minions.TotalMinionsAsync(),
            CurrentPage = page,
        });

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

        public IActionResult Edit() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(AdminMinionFormModel minionModel,int id)
        {
            var minion = await this.minions.GetById(id);
            await this.minions.EditAsync(
                minion,
                minionModel.Name,
                minionModel.ImgUrl,
                minionModel.GoldCost,
                minionModel.BloodCost,
                minionModel.AttackPoints,
                minionModel.DefencePoints,
                minionModel.BloodPoints);

            return RedirectToAction(nameof(Index));
        }
    }
}
