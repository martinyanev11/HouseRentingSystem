namespace HouseRentingSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HouseRentingDbContext : IdentityDbContext
    {
        public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<House> Houses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<House>(entity =>
            {
                entity.HasOne(h => h.Category)
                    .WithMany(c => c.Houses)
                    .HasForeignKey(h => h.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(h => h.Agent)
                    .WithMany(a => a.ManagedHouses)
                    .HasForeignKey(h => h.AgentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
