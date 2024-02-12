using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.DbContexts.Configuration
{
    public class FormatConfiguration : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {
            builder.HasData(
                new Format
                {
                    FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                    Name= "Paperback"
                },
                new Format
                {
                    FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                    Name = "HardCover"
                },
                new Format
                {
                    FormatId = new Guid("a8593958-90cc-4d9e-8785-82b100afdf15"),
                    Name = "Kindle Edition"
                },
                new Format
                {
                    FormatId = new Guid("488248a0-a751-4f92-b6c1-6509b2c97b2c"),
                    Name = "Audiobook"
                }
             );
        }
    }
}
