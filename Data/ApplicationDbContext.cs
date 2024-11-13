using FIAP_PROJETO_CSHARP.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAP_PROJETO_CSHARP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }

}
