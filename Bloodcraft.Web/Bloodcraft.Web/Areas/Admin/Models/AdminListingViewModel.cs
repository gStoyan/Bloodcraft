namespace Bloodcraft.Web.Areas.Admin.Models
{
    using Bloodcraft.Services.Infrastructure;
    using Services.Admin.Models;
    using System;
    using System.Collections.Generic;

    public class AdminListingViewModel
    {
        public IEnumerable<AdminUsersListingModel> AllUsers { get; set; }

        public int TotalUsers { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalUsers / ServicesConstants.SkipUsersCount);

        public int CurrentPage { get; set; }

        public int PrviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1; 
    }
}
