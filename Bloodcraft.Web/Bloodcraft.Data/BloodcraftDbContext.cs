namespace Bloodcraft.Data
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
