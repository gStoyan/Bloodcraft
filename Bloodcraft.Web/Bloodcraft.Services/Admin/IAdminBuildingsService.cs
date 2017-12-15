namespace Bloodcraft.Services.Admin
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAdminBuildingsService
    {
      
        Task CreateAsync(int castleId,
            string name,
            string imgUrl,
            int goldIcnome,
            int bloodIncome,
            int goldCost,
            int bloodCost,
            int buildTime
            );
        Task EditAsync(Building building,
            string name,
            string imgUrl,
            int goldIcnome,
            int bloodIncome,
            int goldCost,
            int bloodCost,
            int buildTime
              );

        Task<Building> GetById(int id);

        Task<IEnumerable<AdminBuildingsListingModel>> AllAsync(int page = 1);

        Task<int> TotalBuildingsAsync();

        int GetCastleIdAsync(string userId);

        Task DeleteAsync(int Id);
    }
}
