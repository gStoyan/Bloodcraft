namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdminBaseController
    {
        private IAdminUsersService users;

        public UsersController(IAdminUsersService users)
        {
            this.users = users;
        }
        

        public IActionResult Index() => View(this.users.All());
    }
}
