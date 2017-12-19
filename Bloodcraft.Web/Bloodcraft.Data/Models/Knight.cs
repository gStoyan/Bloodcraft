namespace Bloodcraft.Data.Models
{
    public class Knight
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        
        public int CastleID { get; set; }

        public Castle Castle { get; set; }

    }
}
