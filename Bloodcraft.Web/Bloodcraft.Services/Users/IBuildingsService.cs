namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Threading.Tasks;

    public interface IBuildingsService
    {
        Task<BuildingsListingModel> DetailsAsync(string name);

        Task CreateAsync(int castleId, string minionName);
    }
}
