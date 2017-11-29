namespace Bloodcraft.Services.Admin.Models
{
    using Core.Mapping;
    using Data.Models;
    using System;

    public class AdminUsersListingModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime DateRegistered { get; set; }

        public string Password { get; set; }
    }
}
