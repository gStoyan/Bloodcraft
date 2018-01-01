
namespace Bloodcraft.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AdminMinionFormModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
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
    }
}
