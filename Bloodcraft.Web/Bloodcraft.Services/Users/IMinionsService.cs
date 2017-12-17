namespace Bloodcraft.Services.Users
{
    using Bloodcraft.Services.Users.Models;
    using System.Threading.Tasks;
    public interface  IMinionsService
    {
        Task<MinionsListingModel> DetailsAsync(string name);
    }
}
