namespace Bloodcraft.Data.Models
{
    using System.Collections.Generic;

    public class Castle
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int Gold { get; set; }

        public int Blood { get; set; }

        public int TotalGoldIncome { get; set; }

        public int TotalBloodIncome { get; set; }

        public List<Building> Buildings { get; set; } = new List<Building>();

        public List<Minion> Minions { get; set; } = new List<Minion>();

        public int X { get; set; }

        public int Y { get; set; }

        public Knight Knight { get; set; }
    }
}
