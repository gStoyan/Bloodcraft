namespace Bloodcraft.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        public UserRace Race { get; set; }
        
        public DateTime DateRegistered { get; set; }

        public List<Castle> Castles { get; set; } = new List<Castle>();
    }
}
