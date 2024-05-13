namespace HouseRentingSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using DataGenerator;

    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasOne(h => h.Category)
                    .WithMany(c => c.Houses)
                    .HasForeignKey(h => h.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Agent)
                .WithMany(a => a.ManagedHouses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(DataGenerator.SeedHouse());
        }
    }
}
