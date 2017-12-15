namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IUsersService
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}
