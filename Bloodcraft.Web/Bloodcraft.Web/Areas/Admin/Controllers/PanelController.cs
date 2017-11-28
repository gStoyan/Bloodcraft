namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PanelController : AdminBaseController
    {
        public IActionResult Index() => View();
    }
}
