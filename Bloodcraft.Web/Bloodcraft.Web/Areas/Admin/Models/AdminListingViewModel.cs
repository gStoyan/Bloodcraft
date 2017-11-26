namespace Bloodcraft.Web.Areas.Admin.Models
{
    using Services.Admin.Models;
    using System.Collections.Generic;
    public class AdminListingViewModel
    {
        public IEnumerable<AdminUsersListingModel> Users { get; set; }
    }
}
