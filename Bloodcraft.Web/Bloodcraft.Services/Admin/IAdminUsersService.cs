namespace Bloodcraft.Services.Admin
{
    using Bloodcraft.Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUsersService
    {
       Task<IEnumerable<AdminUsersListingModel>> AllAsync(int page = 1);

        Task<int> TotalUsersAsync();

        Task<AdminUserDetailModel> DetailsAsync(string id);
        
    }
}
