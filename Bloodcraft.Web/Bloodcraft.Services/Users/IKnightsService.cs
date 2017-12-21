namespace Bloodcraft.Services.Users
{
    using System.Threading.Tasks;
    public interface IKnightsService
    {
        Task CreateAsync();

        Task MoveAsync(int knightId, int x, int y);

        Task AttackBanditsAsync(int knightId, int x, int y);
    }
}
