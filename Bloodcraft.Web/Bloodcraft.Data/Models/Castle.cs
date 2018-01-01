namespace Bloodcraft.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Castle
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string ImgUrl { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Gold { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Blood { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalGoldIncome { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalBloodIncome { get; set; }

        public List<Building> Buildings { get; set; } = new List<Building>();

        public List<Minion> Minions { get; set; } = new List<Minion>();
        
        public int X { get; set; }

        public int Y { get; set; }

        public Knight Knight { get; set; }
    }
}
