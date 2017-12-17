namespace Bloodcraft.Web.Models.Minions
{
    using Bloodcraft.Services.Users.Models;
    public class MinionsDetailsViewModel
    {
        public CastlesListingModel AdminCastle { get; set; }

        public CastlesListingModel UserCastle { get; set; }

        public MinionsListingModel Minion { get; set; }
    }
}
