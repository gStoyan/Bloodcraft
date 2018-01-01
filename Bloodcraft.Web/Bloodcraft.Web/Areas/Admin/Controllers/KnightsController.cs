namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public class KnightsController : AdminBaseController
    {
        private IAdminKnightsService knightsService;
        private IKnightsService userKnights;

        public KnightsController(IAdminKnightsService knightsService, IKnightsService userKnights)
        {
            this.knightsService = knightsService;
            this.userKnights = userKnights;
        }

    
        public async Task<IActionResult> Index()
        {
            await this.knightsService.ResetAsync();

            await this.userKnights.CreateAsync();

            return View();
        }
    }
}
