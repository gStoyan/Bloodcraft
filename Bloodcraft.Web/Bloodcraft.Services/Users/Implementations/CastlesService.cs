namespace Bloodcraft.Services.Users.Implementations
{
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Data;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using Bloodcraft.Data.Models;

    public class CastlesService : ICastlesService
    {
        private BloodcraftDbContext db;
        public CastlesService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task ChooseAsync(string userId, string castleName)
        {
            var castle = this.db.Castles.FirstOrDefault(x => x.Name == castleName);

            var newCastle = new Castle()
            {
                Name = castle.Name,
                Gold = castle.Gold,
                Blood = castle.Blood,
                TotalBloodIncome = castle.TotalBloodIncome,
                TotalGoldIncome = castle.TotalGoldIncome,
                Buildings = castle.Buildings,
                Minions = castle.Minions
            };

            this.db.Users.FirstOrDefault(x => x.Id == userId).Castles.Add(newCastle);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CastlesListingModel>> ListAllAsync()
            => await
            this.db
            .Castles
            .ProjectTo<CastlesListingModel>()
            .ToListAsync();
    }
}
