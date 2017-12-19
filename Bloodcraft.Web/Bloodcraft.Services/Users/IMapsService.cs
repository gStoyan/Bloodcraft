namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Threading.Tasks;
    public interface IMapsService
    {
        Task<CreatingMapModel> CreateAsync();
    }
}
