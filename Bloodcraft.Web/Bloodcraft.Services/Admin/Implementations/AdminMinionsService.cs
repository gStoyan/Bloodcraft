namespace Bloodcraft.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Models;
    using Bloodcraft.Services.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
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
                Name = name,
                ImgUrl = imgUrl,
                GoldCost = goldCost,
                BloodCost = bloodCost,
                AttackPoints = attackPoints,
                DefencePoints = defencePoints,
                BloodPoints = bloodPoints,
                CastleId = 13
            };

            this.db.Minions.Add(minion);

            await this.db.SaveChangesAsync();
        }
        public async Task EditAsync(Minion minion,
            string name,
            string imgUrl,
            int goldCost,
            int bloodCost,
            int attackPoints,
            int defencePoints,
            int bloodPoints)
        {

            minion.Name = name;
            minion.ImgUrl = imgUrl;
            minion.GoldCost = goldCost;
            minion.BloodCost = bloodCost;
            minion.BloodPoints = bloodPoints;
            minion.DefencePoints = defencePoints;
            minion.AttackPoints = attackPoints;

            await this.db.SaveChangesAsync();
        }

        public async Task<Minion> GetById(int id)
            =>
            await this.db.Minions.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<int> TotalMinionsAsync()
 => await this.db.Minions.CountAsync();

        public async Task<IEnumerable<AdminMinionsListingModel>> AllAsync(int page = 1)
             => await
                this.db
                    .Minions
                    .ProjectTo<AdminMinionsListingModel>()
                    .OrderBy(m => m.Id)
                    .Skip((page - 1) * ServicesConstants.SkipMinionsCount)
                    .Take(ServicesConstants.SkipMinionsCount)
                    .ToListAsync();

        public async Task Delete(int minionId)
        {
            var minion = this.db.Minions.FirstOrDefault(m => m.Id == minionId);

            this.db.Remove(minion);

            await this.db.SaveChangesAsync();
        }
    }
}
