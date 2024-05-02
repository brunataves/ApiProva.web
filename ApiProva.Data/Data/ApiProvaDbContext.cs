using ApiProva.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProva.Data.Data
{
    public class ApiProvaDbContext : IdentityDbContext
    {
        public ApiProvaDbContext(DbContextOptions option) : base(option)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
