namespace Bloodcraft.Web.Areas.Admin.Models
{
    public class AdminMinionFormModel
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int AttackPoints { get; set; }

        public int DefencePoints { get; set; }

        public int BloodPoints { get; set; }
    }
}
