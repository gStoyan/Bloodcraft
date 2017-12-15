namespace Bloodcraft.Services.Users.Models
{
    using AutoMapper;
    using Bloodcraft.Core.Mapping;
    using Bloodcraft.Data.Models;
    public class UserModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Id { get; set; }
        public int CastlesCount {get;set;}

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<User, UserModel>()
                .ForMember(u => u.CastlesCount, cfg => cfg.MapFrom(u => u.Castles.Count));
        }
    }
}
