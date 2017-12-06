namespace Bloodcraft.Web.Areas.Admin.Models
{
    using Bloodcraft.Data.Models;
    using System.Collections.Generic;

    public class AdminUserDetailsViewModel
    {
        public string Username { get; set; }

        public List<Castle> Castles { get; set; }

    }
}
