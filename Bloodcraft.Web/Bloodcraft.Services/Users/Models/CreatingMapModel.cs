namespace Bloodcraft.Services.Users.Models
{
    using Bloodcraft.Data.Models;
    using System.Collections.Generic;
    public class CreatingMapModel
    {
        
        public IEnumerable<CastlesListingModel> Castles { get; set; }

        public IEnumerable<CastlesListingModel> UserCastles { get; set; }

        public int[,] Map { get; set; }

        public string UserId { get; set; }
        
    }
}
