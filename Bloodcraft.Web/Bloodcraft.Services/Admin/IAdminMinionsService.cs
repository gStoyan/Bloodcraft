namespace Bloodcraft.Services.Admin
{
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
    }
}
