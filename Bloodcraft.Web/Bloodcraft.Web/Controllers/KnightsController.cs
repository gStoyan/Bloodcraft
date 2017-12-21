namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class KnightsController : Controller
    {
        private IKnightsService knights;

        public KnightsController(IKnightsService knights)
        {
            this.knights = knights;
        }

        public async Task<IActionResult> Move(int id, int x, int y)
        {
            await this.knights.MoveAsync(id, x, y);

            return RedirectToAction("Index", "Map");
        }

        public async Task<IActionResult> AttackBantits(int id, int x, int y)
        {
            await this.knights.AttackBanditsAsync(id, x, y);

            return RedirectToAction("Index", "Map");
        }
    }
}
