namespace Bloodcraft.Services.Users.Implementations
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Bloodcraft.Data;
    using Bloodcraft.Services.Users.Models;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;
    public class UsersService : IUsersService
    {
        private BloodcraftDbContext db;

        public UsersService(BloodcraftDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<UserModel>> GetUsersAsync()
           =>await this.db.Users.ProjectTo<UserModel>().ToListAsync();

    }
}

