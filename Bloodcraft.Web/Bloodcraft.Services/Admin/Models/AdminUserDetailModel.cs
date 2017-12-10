
using AutoMapper;
using Bloodcraft.Core.Mapping;
using Bloodcraft.Data.Models;
using System.Collections.Generic;

namespace Bloodcraft.Services.Admin.Models
{
    public class AdminUserDetailModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public List<Castle> Castles { get; set; }
 
    }
}
