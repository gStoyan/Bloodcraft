namespace Bloodcraft.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AdminCastleFormModel
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
    }
}
