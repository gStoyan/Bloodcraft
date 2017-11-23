namespace Bloodcraft.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        public UserRace Race { get; set; }
    }
}
