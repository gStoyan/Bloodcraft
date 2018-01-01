namespace Bloodcraft.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AdminBuildingFormModel
    {
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
        public int GoldIncome { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodIncome { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int GoldCost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodCost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BuildTime { get; set; }   // in seconds
        
    }
}
