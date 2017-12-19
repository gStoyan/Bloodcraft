namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public class KnightsController : AdminBaseController
    {
        private IAdminKnightsService knights;
        private IKnightsService userKnights;

        public KnightsController(IAdminKnightsService knights, IKnightsService userKnights)
        {
            this.knights = knights;
            this.userKnights = userKnights;
        }

    
        public async Task<IActionResult> Index()
        {
            await this.knights.ResetAsync();

            await this.userKnights.CreateAsync();

            return View();
        }
    }
}
