namespace Bloodcraft.Web.Areas.Admin.Models
{
    using Bloodcraft.Services.Admin.Models;
    using Bloodcraft.Services.Infrastructure;
    using System;
    using System.Collections.Generic;
    public class AdminBuildingsListingViewModel
    {
        public IEnumerable<AdminBuildingsListingModel> AllBuildings { get; set; }

        public int TotalBuildings { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalBuildings / ServicesConstants.SkipBuildingsCount);

        public int CurrentPage { get; set; }

        public int PrviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
