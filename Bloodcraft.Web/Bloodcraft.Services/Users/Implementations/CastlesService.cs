namespace Bloodcraft.Services.Users.Implementations
{
    using System.Threading.Tasks;
    using Bloodcraft.Services.Users.Models;
    using Bloodcraft.Data;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public class CastlesService : ICastlesService
    {
        private BloodcraftDbContext db;
        public CastlesService(BloodcraftDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<CastlesListingModel>> ListAllAsync()
            => await
            this.db
            .Castles
            .ProjectTo<CastlesListingModel>()
            .ToListAsync();
    }
}
