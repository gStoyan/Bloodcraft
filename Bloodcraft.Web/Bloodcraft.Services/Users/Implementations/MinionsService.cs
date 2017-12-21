﻿namespace Bloodcraft.Services.Users.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Users.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class MinionsService : IMinionsService
    {
        private BloodcraftDbContext db;

        public MinionsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(int castleId, string minionName)
        {
            var minion = this.db.Minions.FirstOrDefault(m => m.Name == minionName && m.CastleId == 13);
            var castle = this.db.Castles.FirstOrDefault(c => c.Id == castleId);

            var newMinion = new Minion
            {
                AttackPoints = minion.AttackPoints,
                DefencePoints = minion.DefencePoints,
                Name = minion.Name,
                ImgUrl = minion.ImgUrl,
                BloodCost = minion.BloodCost,
                BloodPoints = minion.BloodPoints,
                GoldCost = minion.GoldCost,
                CastleId = castleId
            };

            //if (castle.Gold > newMinion.GoldCost && castle.Blood > newMinion.BloodCost)
            //{
                castle.Gold -= newMinion.GoldCost;
                castle.Blood -= newMinion.BloodCost;

                this.db.Minions.Add(newMinion);
                await this.db.SaveChangesAsync();
            //}
            //else
            //{
            //    throw new Exception();
            //}
        }

        public async Task<MinionsListingModel> DetailsAsync(string name)
            => await
                this.db
                .Minions
                .Where(m => m.Name == name && m.CastleId == 13)
                .ProjectTo<MinionsListingModel>()
                .FirstOrDefaultAsync();
    }
}
