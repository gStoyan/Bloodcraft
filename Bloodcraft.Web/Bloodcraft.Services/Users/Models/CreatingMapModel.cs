namespace Bloodcraft.Services.Users.Models
{
    using System.Collections.Generic;
    public class CreatingMapModel
    {
        
        public IEnumerable<CastlesListingModel> Castles { get; set; }

        public int[,] Map { get; set; }

        public string UserId { get; set; }
    }
}
