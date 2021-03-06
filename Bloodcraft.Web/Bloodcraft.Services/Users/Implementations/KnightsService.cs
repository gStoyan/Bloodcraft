﻿namespace Bloodcraft.Services.Users.Implementations
{
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class KnightsService : IKnightsService
    {
        private BloodcraftDbContext db;

        public KnightsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task  CreateAsync()
        {
            if (db.Knights.Count() != 0)
            {
                return;
            }

            var castles = this.db.Castles.ToList();
            foreach (var castle in castles)
            {
                if (castle.Y <9)
                {
                    var knight = new Knight
                    {
                        X = castle.X,
                        Y = castle.Y + 1,
                        Castle = castle,
                        CastleID = castle.Id
                    };
                    this.db.Knights.Add(knight);

                    await this.db.SaveChangesAsync();
                }
                else if (castle.Y ==9)
                {
                    var knight = new Knight
                    {
                        X = castle.X,
                        Y = castle.Y - 1,
                        Castle = castle,
                        CastleID = castle.Id
                    };
                    this.db.Knights.Add(knight);

                    await this.db.SaveChangesAsync();
                }               
            }
        }

        public async Task MoveAsync(int knightId, int x, int y)
        {
            var knight = this.db.Knights.FirstOrDefault(k => k.Id == knightId);

            knight.X = x;
            knight.Y = y;

            await this.db.SaveChangesAsync();

        }

        public async Task<bool> AttackBanditsAsync(int knightId, int x, int y)
        {
            var knight = this.db.Knights.FirstOrDefault(k => k.Id == knightId);

            var castle = this.db.Castles.Include(c=>c.Minions).FirstOrDefault(c =>c.Knight == knight);

            knight.X = x;
            knight.Y = y;

            var minions = castle.Minions;
            var totalAttackPoints = 0;
            foreach (var minion in minions)
            {
                totalAttackPoints += minion.AttackPoints;
            }

            if (totalAttackPoints > ServicesConstants.BandtitsDefencePoints)
            {
                castle.Blood += ServicesConstants.BanditsBloodBounty;
                castle.Gold += ServicesConstants.BanditsGoldBounty;

               
                await this.db.SaveChangesAsync();

                return true;
            }
            else
            {
                foreach (var minion in minions)
                {
                    this.db.Minions.Remove(minion);
                }
                await this.db.SaveChangesAsync();

                return false;
            }
        }
    }
}
