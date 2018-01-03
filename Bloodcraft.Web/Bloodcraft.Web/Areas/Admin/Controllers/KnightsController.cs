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
        private IMapsService mapsService;

        public KnightsController(IAdminKnightsService knightsService, IKnightsService userKnights, IMapsService mapsService)
        {
            this.knightsService = knightsService;
            this.userKnights = userKnights;
            this.mapsService = mapsService;
        }

    
        public async Task<IActionResult> Index()
        {
            await this.mapsService.CreateAsync();

            await this.knightsService.ResetAsync();

            await this.userKnights.CreateAsync();

            return View();
        }
    }
}
