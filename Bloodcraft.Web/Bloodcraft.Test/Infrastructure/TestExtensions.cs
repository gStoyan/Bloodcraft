namespace Bloodcraft.Test.Infrastructure
{
    using Bloodcraft.Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class TestExtensions
    {
        public static BloodcraftDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BloodcraftDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BloodcraftDbContext(dbOptions);
        }
    }
}
