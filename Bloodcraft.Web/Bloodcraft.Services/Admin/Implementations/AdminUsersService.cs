namespace Bloodcraft.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using Bloodcraft.Services.Admin.Models;
    using Bloodcraft.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Bloodcraft.Services.Infrastructure;
    using System.Collections;

    public class AdminUsersService : IAdminUsersService
    {
        private BloodcraftDbContext db;

        public AdminUsersService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task<int> TotalUsersAsync()
            => await this.db.Users.CountAsync();

        public async Task<IEnumerable<AdminUsersListingModel>> AllAsync(int page = 1)
             => await
                this.db
                    .Users
                    .ProjectTo<AdminUsersListingModel>()
                    .OrderByDescending(u => u.DateRegistered)
                    .Skip((page - 1) * ServicesConstants.SkipUsersCount)
                    .Take(ServicesConstants.SkipUsersCount)
                    .ToListAsync();

        public async Task<AdminUserDetailModel> DetailsAsync(string id)
            => await
                this.db
                .Users
                .ProjectTo<AdminUserDetailModel>()
                .FirstOrDefaultAsync();
    }
}
