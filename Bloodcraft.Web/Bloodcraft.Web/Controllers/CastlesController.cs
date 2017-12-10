namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Services.Users;
    using Bloodcraft.Web.Models.Castles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CastlesController : Controller
    {
        private ICastlesService castles;

        public CastlesController(ICastlesService castles)
        {
            this.castles = castles;
        }
        public IActionResult Index() => View();
               
        public async Task<IActionResult> List()
             => View(new CastlesListingViewModel
             {
                 Castles = await this.castles.ListAllAsync()
             });

    }
}
