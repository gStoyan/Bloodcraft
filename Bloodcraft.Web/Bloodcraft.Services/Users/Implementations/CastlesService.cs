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
    using System;
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Services.Infrastructure;

    public class CastlesService : ICastlesService
    {
        private BloodcraftDbContext db;

        public CastlesService(BloodcraftDbContext db, IAdminBuildingsService buildings)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CastlesListingModel>> ListAllAsync()
        {
            var adminId = this.db.Users.FirstOrDefault(u => u.UserName == ServicesConstants.AdminName).Id;

            return await
             this.db
             .Castles.Where(c => c.UserId == adminId)
             .ProjectTo<CastlesListingModel>()
             .ToListAsync();
        }
        public async Task<IEnumerable<CastlesListingModel>> ListUsersCastleAsync(string userId)
        {
            var castles = this.db.Castles.Where(u => u.UserId == userId).Include(c => c.Buildings).ToList();
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
            foreach (var castle in castles)
            {
                var buildings = castle.Buildings;

                int totalGoldIncome = 0;
                int totalBloodIncome = 0;

                foreach (var building in buildings)
                {
                    totalGoldIncome += building.GoldIncome;
                    totalBloodIncome += building.BloodIncome;
                };

                castle.TotalBloodIncome = totalBloodIncome;
                castle.TotalGoldIncome = totalGoldIncome;

                await this.db.SaveChangesAsync();
            }

            return await this.db
                .Castles.Where(c => c.UserId == userId)
                .ProjectTo<CastlesListingModel>()
                .ToListAsync();
        }

        public async Task ChooseAsync(string userId, string castleName)
        {
            var castle = this.db.Castles.Include(c => c.Buildings).Include(c => c.Minions).FirstOrDefault(x => x.Name == castleName);
            var buildings = new List<Building>();
            var minions = new List<Minion>();

            foreach (var minion in castle.Minions)
            {
                var newMinion = new Minion
                {
                    BloodCost = minion.BloodCost,
                    AttackPoints = minion.AttackPoints,
                    DefencePoints = minion.DefencePoints,
                    GoldCost = minion.GoldCost,
                    ImgUrl = minion.ImgUrl,
                    Name = minion.Name,
                    BloodPoints = minion.BloodPoints,
                };
                minions.Add(newMinion);
            }
            foreach (var building in castle.Buildings)
            {
                var newBuildings = new Building
                {
                    BloodCost = building.BloodCost,
                    BloodIncome = building.BloodIncome,
                    GoldCost = building.GoldCost,
                    GoldIncome = building.GoldIncome,
                    BuildTime = building.BuildTime,
                    ImgUrl = building.ImgUrl,
                    Name = building.Name
                };
                buildings.Add(newBuildings);
            }

            var newCastle = new Castle()
            {
                Name = castle.Name,
                Gold = castle.Gold,
                Blood = castle.Blood,
                TotalBloodIncome = castle.TotalBloodIncome,
                TotalGoldIncome = castle.TotalGoldIncome,
                Buildings = buildings,
                Minions = minions,
                ImgUrl = castle.ImgUrl,
            };

            this.db.Users.FirstOrDefault(x => x.Id == userId).Castles.Add(newCastle);

            await this.db.SaveChangesAsync();
        }
       

        public async Task<CastlesListingModel> GetAdminCastleAsync()
        => await
            this.db
            .Castles.Where(c => c.Id == ServicesConstants.AdminCastleId)
            .ProjectTo<CastlesListingModel>()
            .FirstOrDefaultAsync();

        public async Task<CastlesListingModel> GetUsersCastleAsync(int castleId)
        => await
            this.db
            .Castles.Where(c => c.Id == castleId)
            .ProjectTo<CastlesListingModel>()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<CastlesListingModel>> GetAllUsersCastlesAsync(string userId)
        => await
            this.db
            .Castles.Where(c => c.UserId == userId)
            .ProjectTo<CastlesListingModel>()
            .ToListAsync();

        public async Task<IEnumerable<CastlesListingModel>> GetAllCastlesAsync()
            => await
            this.db
            .Castles
            .ProjectTo<CastlesListingModel>()
            .ToListAsync();

       

       
    }
}
