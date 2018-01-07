namespace Bloodcraft.Test.Services.Admin
{

    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    using Bloodcraft.Services.Admin.Implementations;
    using Bloodcraft.Data.Models;
    using Bloodcraft.Test.Infrastructure;

    public class BuildingsServiceTest
    {
        private const int id = 1;
        private const string name = "TestBuildings";
        private const string changedName = "NewName";
        private const string img = "TestImg";
        private const int resourceNumber = 1;
        [Fact]
        public async Task CreateBuildingsShouldSucceed()
        {
            // Arrange
            var db = TestExtensions.GetDatabase();
            var buildingsService = new AdminBuildingsService(db);

            //Act
            await buildingsService.CreateAsync(id,
                name,
                img, 
                resourceNumber, 
                resourceNumber, 
                resourceNumber, 
                resourceNumber, 
                resourceNumber);

            var savedEntry = db.Buildings.FirstOrDefault();

            //Assert
            savedEntry
                .Should()
                .NotBeNull();
        }
        [Fact]
        public async Task EditBuildingTest()
        {
            //Arrange
            var db = TestExtensions.GetDatabase();
            var buildingsService = new AdminBuildingsService(db);

            //Act
            var building = new Building
            {
                Id = id,
                Name = name
            };

            await buildingsService.EditAsync(building, changedName, img, resourceNumber, resourceNumber, resourceNumber, resourceNumber, resourceNumber);
            //Assert
            building.Name
                .Should()
                .Match(changedName);
        }

        [Fact]
        public async Task BuildingDeleteTest()
        {
            //Arrange
            var db = TestExtensions.GetDatabase();            
            var buildingsService = new AdminBuildingsService(db);

            //Act
            var building = new Building
            {
                Id = id,
                Name = name
            };

            db.Buildings.Add(building);
            await db.SaveChangesAsync();

            await buildingsService.DeleteAsync(id);
            var buildingsCount = db.Buildings.Count();

            //Assert
            buildingsCount
                .Should()
                .Be(0);
        }

       
    }
}
