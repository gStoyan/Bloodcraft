namespace Bloodcraft.Test.Services.Admin
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Implementations;
    using Bloodcraft.Test.Infrastructure;
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public class UsersServiceTest
    {
        private const string Id1 = "Id1";
        private const string Id2 = "Id2";
        public UsersServiceTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task ListUsersShouldReturnOrderedList()
        {
            //Arrange
            var db = TestExtensions.GetDatabase();
            var usersService = new AdminUsersService(db);

            //Act
            var user1 = new User
            {
                Id = Id1,
                DateRegistered = DateTime.MinValue
            };
            var user2 = new User
            {
                Id = Id2,
                DateRegistered = DateTime.MaxValue
            };

            db.AddRange(user1, user2);
            await db.SaveChangesAsync();

            var result = await usersService.AllAsync();

            //Assert
            result.First().Id.Should().Be(Id2);
        }
    }
}
