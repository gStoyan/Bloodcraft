namespace Bloodcraft.Services.Admin.Models
{
    using AutoMapper;
    using Bloodcraft.Core.Mapping;
    using Bloodcraft.Data.Models;
    public class AdminBuildingsListingModel : IMapFrom<Building>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldIncome { get; set; }

        public int BloodIncome { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int BuildTime { get; set; }   // in seconds

        public string Username { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Building, AdminBuildingsListingModel>()
                .ForMember(b => b.Username, cfg => cfg.MapFrom(b => b.Castle.User.UserName));
        }
    }
}
