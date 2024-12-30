using Microsoft.EntityFrameworkCore;
using passagens_backend.Models;

namespace passagens_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
