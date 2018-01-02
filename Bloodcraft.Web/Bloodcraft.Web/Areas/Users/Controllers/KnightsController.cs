namespace Bloodcraft.Web.Areas.Users.Controllers
{
    using Bloodcraft.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class KnightsController : UserBaseController
    {
        private IKnightsService knightsService;

        public KnightsController(IKnightsService knightsService)
        {
            this.knightsService = knightsService;
        }

        public async Task<IActionResult> Move(int id, int x, int y)
        {
            await this.knightsService.MoveAsync(id, x, y);

            return RedirectToAction("Index", "Map", new { area = "" });
        }

        public async Task<IActionResult> AttackBandits(int id, int x, int y)
        {
            if (await this.knightsService.AttackBanditsAsync(id, x, y))
            {
                return RedirectToAction("Index", "Map", new { area = "" });
            }
            else
            {
                return View();
            }
        }
    }
}
