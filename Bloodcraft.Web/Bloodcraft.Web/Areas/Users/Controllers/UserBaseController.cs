namespace Bloodcraft.Web.Areas.Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Users")]
    [Authorize]
    public class UserBaseController : Controller
    {
    }
}
