namespace Bloodcraft.Services.Admin
{
    using Bloodcraft.Services.Admin.Models;
    using System.Collections.Generic;
    public interface IAdminUsersService
    {
        IEnumerable<AdminUsersListingModel> All();
    }
}
