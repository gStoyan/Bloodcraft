namespace Bloodcraft.Services.Admin.Implementations
{
    using Bloodcraft.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    public class AdminKnightsService : IAdminKnightsService
    {
        private BloodcraftDbContext db;

        public AdminKnightsService(BloodcraftDbContext db)
        {
            this.db = db;
        }

        public async Task ResetAsync()
        {
            var knights = this.db.Knights.ToList();

            foreach (var knight in knights)
            {
                this.db.Knights.Remove(knight);
            }

            await this.db.SaveChangesAsync();
        }
    }
}
