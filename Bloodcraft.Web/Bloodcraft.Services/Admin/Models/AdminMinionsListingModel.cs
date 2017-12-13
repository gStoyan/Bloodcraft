namespace Bloodcraft.Services.Admin.Models
{
    using AutoMapper;
    using Bloodcraft.Core.Mapping;
    using Bloodcraft.Data.Models;

    public class AdminMinionsListingModel: IMapFrom<Minion> , IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int AttackPoints { get; set; }

        public int DefencePoints { get; set; }

        public int BloodPoints { get; set; }

        public string Username { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Minion, AdminMinionsListingModel>()
                .ForMember(m => m.Username, cfg => cfg.MapFrom(m => m.Castle.User.UserName));
        }
    }
}
