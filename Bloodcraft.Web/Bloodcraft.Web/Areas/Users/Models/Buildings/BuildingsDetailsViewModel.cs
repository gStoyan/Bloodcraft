namespace Bloodcraft.Web.Areas.Users.Models.Buildings
{
    using Bloodcraft.Services.Users.Models;
    public class BuildingsDetailsViewModel
    {
        public CastlesListingModel AdminCastle { get; set; }

        public CastlesListingModel UserCastle { get; set; }

        public BuildingsListingModel Building { get; set; }
    }
}
