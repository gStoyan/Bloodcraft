namespace Bloodcraft.Services.Admin
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAdminMinionsService
    {

        Task CreateAsync(
                string name,
                string imgUrl,
                int goldCost,
                int bloodCost,
                int attackPoints,
                int defencePoints,
                int bloodPoints
                );
        Task EditAsync(
              Minion minion,
              string name,
              string imgUrl,
              int goldCost,
              int bloodCost,
              int attackPoints,
              int defencePoints,
              int bloodPoints
              );

        Task<Minion> GetById(int id);

        Task<IEnumerable<AdminMinionsListingModel>> AllAsync(int page = 1);

        Task<int> TotalMinionsAsync();

        Task Delete(int minionId);
    }
}
