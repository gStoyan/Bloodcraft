namespace Bloodcraft.Test.Services.Admin
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin.Implementations;
    using Bloodcraft.Test.Infrastructure;
    using FluentAssertions;
    using System.Threading.Tasks;
    using Xunit;
    public class CastlesServiceTest
    {
        private const int Id = 1;
        private const int Gold = 10;
        private const int Blood = 10;
        private const int BloodIncome = 5;
        private const int GoldIncome = 5;
        private const int ChangedGold = 15;
        private const int ChangedBlood = 15;

        [Fact]
        public async Task GenerateIncomeShouldIncreaseGoldAndBlood()
        {
            //Arrane
            var db = TestExtensions.GetDatabase();
            var castlesService = new AdminCastlesService(db);

            //Act
            var castle = new Castle
            {
                Id = Id,
                Gold = Gold,
                Blood = Blood,
                TotalBloodIncome = BloodIncome,
                TotalGoldIncome = GoldIncome
            };

            db.Castles.Add(castle);
            await db.SaveChangesAsync();
            await castlesService.GenerateIncome();

            //Assert
            castle.Gold.Should().Be(ChangedGold);
            castle.Blood.Should().Be(ChangedBlood);

        }
    }
}
