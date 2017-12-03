namespace Bloodcraft.Web.Infrastructure.WorldMap
{
    using System;
    public static class Randoming
    {
        public static bool BanditSpawn()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 6);
            return result == 1;
        }
    }
}
