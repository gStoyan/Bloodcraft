namespace Bloodcraft.Core.WorldMap
{
    using Bloodcraft.Core.Infrastructure;
    using Bloodcraft.Core.Infrastructure.WorldMap;

    public static class CreateMap
    {
        public static int[,] Create()
        {
            int[,] map = new int[CoreConstants.MapWidth, CoreConstants.MapHeight];

            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (Randoming.BanditSpawn())
                    {
                        map[i,j] = 1;
                    }
                }
            }

            return map;
        }
    }
}
