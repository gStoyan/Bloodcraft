namespace Bloodcraft.Services.Users.Models
{
    using Bloodcraft.Core.Mapping;
    using Bloodcraft.Data.Models;

    public class MinionsListingModel : IMapFrom<Minion>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int AttackPoints { get; set; }

        public int DefencePoints { get; set; }

        public int BloodPoints { get; set; }

    }
}
