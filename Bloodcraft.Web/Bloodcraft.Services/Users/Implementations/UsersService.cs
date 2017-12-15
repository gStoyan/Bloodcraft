namespace Bloodcraft.Services.Users.Implementations
{
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using Bloodcraft.Data;
    using Bloodcraft.Services.Users.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
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

