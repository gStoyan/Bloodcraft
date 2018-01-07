namespace Bloodcraft.Services.Admin
{
    using System.Threading.Tasks;
    public interface IAdminCastlesService
    {
        Task CreateAsync
            (string userId,
            string name,
            string imgUrl,
            int blood,
            int gold,
            int totalBloodIncome,
            int totalGoldIncome
            );

        Task GenerateIncome();
    }
}
