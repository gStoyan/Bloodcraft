namespace Bloodcraft.Services.Users.Models
{
    using Bloodcraft.Core.Mapping;
    using Bloodcraft.Data.Models;
    using System.Collections.Generic;
    using AutoMapper;

    public class CastlesListingModel : IMapFrom<Castle> , IHaveCustomMapping
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int Gold { get; set; }

        public int Blood { get; set; }

        public int TotalGoldIncome { get; set; }

        public int TotalBloodIncome { get; set; }
        
        public List<Minion> Minions { get; set; }

        public List<Building> Buildings { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Castle, CastlesListingModel>()
                .ForMember(c => c.Username, cfg => cfg.MapFrom(c => c.User.UserName));
        }
    }
}

