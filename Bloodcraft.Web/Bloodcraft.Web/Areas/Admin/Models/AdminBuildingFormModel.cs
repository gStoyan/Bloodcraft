namespace Bloodcraft.Web.Areas.Admin.Models
{
    public class AdminBuildingFormModel
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldIncome { get; set; }

        public int BloodIncome { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int BuildTime { get; set; }   // in seconds
        
    }
}
