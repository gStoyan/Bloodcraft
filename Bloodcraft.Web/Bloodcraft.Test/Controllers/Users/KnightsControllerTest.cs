namespace Bloodcraft.Test.Controllers.Users
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Users.Implementations;
    using Bloodcraft.Test.Infrastructure;
    using Bloodcraft.Web.Areas.Users.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Xunit;
    public class KnightsControllerTest
    {
        private const int Id = 1;
        private const int AttackPoints = 10;
        private const int X = 1;
        private const int Y = 1;

        [Fact]
        public async Task AttackBanditsShoultReturnDefeatViewIfNotSuccessfull()
        {
            //Arrange
            var db = TestExtensions.GetDatabase();
            var knightsService = new KnightsService(db);
            var knightsController = new KnightsController(knightsService);

            //Act
            var castle = new Castle {Id = Id };
            var minion = new Minion {AttackPoints = AttackPoints ,CastleId = Id};
            var knight = new Knight {Id = Id, CastleID = Id, X = X, Y = Y };

            db.Add(castle);
            db.Add(minion);
            db.Add(knight);
            await db.SaveChangesAsync();

            var result = await knightsController.AttackBandits(Id,X,Y);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }
    }
}
