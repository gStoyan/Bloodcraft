﻿namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController
    {
        private IAdminUsersService users;

        public UsersController(IAdminUsersService users)
        {
            this.users = users;
        }
        
        public async Task<IActionResult> Index(int page = 1)
          => 
            View(new AdminListingViewModel
            {
                AllUsers = await this.users.AllAsync(page),
                TotalUsers = await this.users.TotalUsersAsync(),
                CurrentPage = page,
            });
    }
}
