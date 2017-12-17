namespace Bloodcraft.Services.Users.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Bloodcraft.Data;
    using Bloodcraft.Services.Users.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class MinionsService : IMinionsService
    {
        private BloodcraftDbContext db;

        public MinionsService(BloodcraftDbContext db)
        {
            this.db = db;
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
