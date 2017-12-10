namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MinionsController : AdminBaseController
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Create() => View();
    }
}
