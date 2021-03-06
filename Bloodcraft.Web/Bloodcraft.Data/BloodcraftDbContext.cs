﻿namespace Bloodcraft.Data
{
    using Bloodcraft.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class BloodcraftDbContext : IdentityDbContext<User>
    {       

        public BloodcraftDbContext(DbContextOptions<BloodcraftDbContext> options)
                : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Minion> Minions { get; set; }

        public DbSet<Castle> Castles { get; set; }     
        
        public DbSet<Knight> Knights { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(c => c.Castles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Castle>()
                .HasMany(c => c.Buildings)
                .WithOne(c => c.Castle)
                .HasForeignKey(c => c.CastleId);

            builder.Entity<Castle>()
                .HasMany(c => c.Minions)
                .WithOne(c => c.Castle)
                .HasForeignKey(c => c.CastleId);

            builder.Entity<Castle>()
                .HasOne(c => c.Knight)
                .WithOne(k => k.Castle);
        
        }
    }
}
