namespace Bloodcraft.Services.Admin.Implementations
{
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using System.Threading.Tasks;

    public class AdminMinionsService : IAdminMinionsService
    {
        private BloodcraftDbContext db;

        public AdminMinionsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name, 
            string imgUrl, 
            int goldCost, 
            int bloodCost, 
            int attackPoints, 
            int defencePoints, 
            int bloodPoints)
        {
            var minion = new Minion
            {
                Name= name,
                ImgUrl = imgUrl,
                GoldCost = goldCost,
                BloodCost = bloodCost,
                AttackPoints = attackPoints,
                DefencePoints = defencePoints,
                BloodPoints = bloodPoints,
                CastleId = 10
            };

            this.db.Minions.Add(minion);

            await this.db.SaveChangesAsync();
        }
    }
}
