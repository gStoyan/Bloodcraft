﻿using System.ComponentModel.DataAnnotations;

namespace Bloodcraft.Data.Models
{
    public class Minion
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string ImgUrl { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int GoldCost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodCost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AttackPoints { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int DefencePoints { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodPoints { get; set; }

        public int CastleId { get; set; }

        public Castle Castle { get; set; }
        
    }
}
