namespace Bloodcraft.Services.Users.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Data;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    public class BuildingsService : IBuildingsService
    {
        private BloodcraftDbContext db;
        public BuildingsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(int castleId, string buildingName)
        {
            var building = this.db.Buldings.FirstOrDefault(b => b.Name == buildingName && b.CastleId == 13);
            var castle = this.db.Castles.FirstOrDefault(c => c.Id == castleId);

            var newBuildings = new Building
            {
                Name = building.Name,
                BloodCost = building.BloodCost,
                GoldCost = building.GoldCost,
                GoldIncome = building.GoldIncome,
                BloodIncome = building.BloodIncome,
                BuildTime = building.BuildTime,
                ImgUrl = building.ImgUrl,
                CastleId = castleId
            };

            //if (castle.Gold > building.GoldCost && castle.Blood > building.BloodCost)
            //{
                castle.Gold -= building.GoldCost;
                castle.Blood -= building.BloodCost;

                this.db.Buldings.Add(newBuildings);
                await this.db.SaveChangesAsync();
            //}
            //else
            //{
            //    throw new Exception();
            //}
        }

        public async Task<BuildingsListingModel> DetailsAsync(string name)
        => await
                this.db
                .Buldings
                .Where(m => m.Name == name && m.CastleId == 13)
                .ProjectTo<BuildingsListingModel>()
                .FirstOrDefaultAsync();
    }
}
