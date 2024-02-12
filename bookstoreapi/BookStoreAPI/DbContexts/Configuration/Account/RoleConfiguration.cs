using BookStore.API.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.DbContexts.Configuration.Account
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Visitor",
                    NormalizedName = "VISITOR",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrator",
                    NormalizedName = "ADMNISTRATOR",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
        }
    }
}
