﻿namespace Bloodcraft.Web.Models.Castles
{
    using Bloodcraft.Services.Users.Models;
    using System.Collections.Generic;
    public class CastlesListingViewModel
    {
        public IEnumerable<CastlesListingModel> Castles { get; set; }
    }
}
