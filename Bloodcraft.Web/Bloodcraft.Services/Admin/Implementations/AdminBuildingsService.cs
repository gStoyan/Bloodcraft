namespace Bloodcraft.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Models;
    using Bloodcraft.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Bloodcraft.Services.Infrastructure;
    using AutoMapper.QueryableExtensions;

    public class AdminBuildingsService : IAdminBuildingsService
    {
        private BloodcraftDbContext db;

        public AdminBuildingsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        
        public async Task CreateAsync(int castleId,
            string name,
            string imgUrl,
            int goldIcnome,
            int bloodIncome,
            int goldCost,
            int bloodCost,
            int buildTime)
        {
            var building = new Building
            {
                CastleId = castleId,
                Name = name,
                ImgUrl = imgUrl,
                GoldIncome = goldIcnome,
                BloodIncome = bloodIncome,
                GoldCost = goldCost,
                BloodCost = bloodCost,
                BuildTime = buildTime
            };

            this.db.Buldings.Add(building);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(Building building, string name, string imgUrl, int goldIcnome, int bloodIncome, int goldCost, int bloodCost, int buildTime)
        {
            building.Name = name;
            building.ImgUrl = imgUrl;
            building.GoldIncome = goldIcnome;
            building.BloodIncome = bloodIncome;
            building.GoldCost = goldCost;
            building.BloodCost = bloodCost;
            building.BuildTime = buildTime;

            await this.db.SaveChangesAsync();
        }

        public async Task<Building> GetById(int id)
         =>   await this.db.Buldings.FirstOrDefaultAsync(b => b.Id == id);
     

        public async Task<IEnumerable<AdminBuildingsListingModel>> AllAsync(int page = 1)
             => await
                this.db
                    .Buldings
                    .ProjectTo<AdminBuildingsListingModel>()
                    .OrderBy(m => m.Id)
                    .Skip((page - 1) * ServicesConstants.SkipBuildingsCount)
                    .Take(ServicesConstants.SkipBuildingsCount)
                    .ToListAsync();
        
        public async Task<int> TotalBuildingsAsync()
         => await this.db.Buldings.CountAsync();

        public int GetCastleIdAsync(string userId)
        {
            var castle = this.db.Castles.FirstOrDefault(c => c.UserId == userId);
            return castle.Id;
        }

        public async Task DeleteAsync(int Id)
        {
            var building = this.db.Buldings.FirstOrDefault(b => b.Id == Id);

            this.db.Buldings.Remove(building);

            await this.db.SaveChangesAsync();
        }
    }
}
