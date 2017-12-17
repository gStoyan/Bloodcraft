namespace Bloodcraft.Web.Models.Castles
{
    using Bloodcraft.Services.Users.Models;
    public class CastleDetailsViewModel
    {
        public CastlesListingModel AdminCastle { get; set; }

        public CastlesListingModel UserCastle { get; set; }
    }
}
