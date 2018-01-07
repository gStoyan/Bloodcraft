namespace Bloodcraft.Test.Controllers.Users
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Implementations;
    using Bloodcraft.Services.Users.Implementations;
    using Bloodcraft.Test.Infrastructure;
    using Bloodcraft.Web.Areas.Users.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Xunit;
    public class MinionsControllerTest
    {
        [Fact]
        public async Task CreateShouldReturnRedirectToNotEnoughResources()
        {
            //Assert
            var db = TestExtensions.GetDatabase();
            var buildingsService = new AdminBuildingsService(db);
            var castlesService = new CastlesService(db,buildingsService);
            var minionsService = new MinionsService(db);
            var minionsController = new MinionsController(castlesService, minionsService);
            //Act
            var castle = new Castle
            {
                Id = 1,
                Gold = 10,
                Blood = 10,
            };

            var minion = new Minion
            {
                Id = 1,
                Name = "TestMinion",
                GoldCost = 15,
                BloodCost = 15,
                CastleId= 1
            };

            db.Add(castle);
            db.Add(minion);
            await db.SaveChangesAsync();

            //Act
            var result = await minionsController.Create(minion.Id, minion.Name);

            //Assert
            result.Should().BeOfType<RedirectToActionResult>();
            result.As<RedirectToActionResult>().ActionName.Should().Be("NotEnoughResources");
        }
    }
}
