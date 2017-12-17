namespace Bloodcraft.Core.WorldMap
{
    using Bloodcraft.Core.Infrastructure;
    using Bloodcraft.Core.Infrastructure.WorldMap;

    public static class CreateMap
    {
        
        public static int[,] Create(int castlesCount)
        {
            int[,] map = new int[CoreConstants.MapHeight, CoreConstants.MapWidth];

            while (castlesCount > 0)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i,j] !=0)
                        {
                            continue;
                        }
                        if (Randoming.CastleSpawn() && castlesCount > 0)
                        {
                            map[i, j] = CoreConstants.CastleSpawnValue;
                            castlesCount--;
                            continue;
                        }
                        if (Randoming.BanditSpawn())
                        {
                            map[i, j] = CoreConstants.BanditsSpawnValue;
                        }
                    }
                }
            }
            return map;
        }
    }
}
