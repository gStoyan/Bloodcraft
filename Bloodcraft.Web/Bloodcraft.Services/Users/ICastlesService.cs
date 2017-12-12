namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICastlesService
    {
        Task<IEnumerable<CastlesListingModel>> ListAllAsync();

        Task ChooseAsync(string userId, string castleName);
    }
}
