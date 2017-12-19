namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICastlesService
    {
        Task<IEnumerable<CastlesListingModel>> ListAllAsync();

        Task<IEnumerable<CastlesListingModel>> GetAllCastlesAsync();

        Task ChooseAsync(string userId, string castleName);

        Task<IEnumerable<CastlesListingModel>> ListUsersCastleAsync(string userId);

        Task<CastlesListingModel> GetAdminCastleAsync();

        Task<CastlesListingModel> GetUsersCastleAsync(int castleId);
    }
}
