namespace Bloodcraft.Core.Infrastructure.WorldMap
{
    using System;
    public static class Randoming
    {
        public static bool BanditSpawn()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 15);
            return result == 1;
        }

        public static bool CastleSpawn()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 100); 
            return result == 1;
        }
    }
}
