namespace Bloodcraft.Services.Admin.Implementations
{
    using System.Threading.Tasks;
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class AdminCastlesService : IAdminCastlesService
    {
        private BloodcraftDbContext db;
        public AdminCastlesService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string userId,string name,string imgUrl, int blood, int gold, int totalBloodIncome, int totalGoldIncome)
        {

            var castle = new Castle
            {
                UserId = userId,
                Name = name,
                ImgUrl = imgUrl,
                Blood = blood,
                Gold = gold,
                TotalBloodIncome = totalBloodIncome,
                TotalGoldIncome = totalGoldIncome,
            };
            
            this.db.Castles.Add(castle);

            await this.db.SaveChangesAsync();
        }
    }
}
