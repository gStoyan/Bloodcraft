namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class AdminBaseController : Controller
    {
       
    }
}
