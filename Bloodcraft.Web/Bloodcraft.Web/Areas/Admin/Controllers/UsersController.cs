namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController
    {
        private IAdminUsersService usersService;

        public UsersController(IAdminUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index(int page = 1)
          =>
            View(new AdminListingViewModel
            {
                AllUsers = await this.usersService.AllAsync(page),
                TotalUsers = await this.usersService.TotalUsersAsync(),
                CurrentPage = page,
            });

        [Route("admin/users/details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var result = await this.usersService.DetailsAsync(id);

            return View(new AdminUserDetailsViewModel
            {
                Username = result.Username,
                Castles = result.Castles
            });
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.usersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
