namespace Bloodcraft.Web.Controllers
{
    using Bloodcraft.Core.WorldMap;
    using Bloodcraft.Web.Models.Map;
    using Microsoft.AspNetCore.Mvc;
    using Bloodcraft.Core.Infrastructure.WorldMap;
    public class MapController : Controller
    {
        public IActionResult Index() => View(new CreatingMap { Map = CreateMap.Create() });

    }
}
