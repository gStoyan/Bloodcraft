namespace Bloodcraft.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using Bloodcraft.Services.Admin.Models;
    using Bloodcraft.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class AdminUsersService : IAdminUsersService
    {
        private BloodcraftDbContext db;

        public AdminUsersService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUsersListingModel> All()
             =>
                this.db
                .Users
                .ProjectTo<AdminUsersListingModel>()
                .ToList();
    }
}
