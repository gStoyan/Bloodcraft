namespace Bloodcraft.Data.Models
{
    using System.Collections.Generic;
    public class Minion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int GoldCost { get; set; }

        public int BloodCost { get; set; }

        public int AttackPoints { get; set; }

        public int DefencePoints { get; set; }

        public int BloodPoints { get; set; }

        public int CastleId { get; set; }

        public Castle Castle { get; set; }
        
    }
}
