using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections;
using System.Diagnostics;

namespace BookStore.API.DbContexts.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var genreList = new List<Genre>()
            {
                new Genre { GenreId = new Guid("d53fa392-9639-489f-b173-33d6d910487f"), Name = "Adult"},
                new Genre { GenreId = new Guid("cd0b243c-6e41-4679-9927-1ef02b4266a0"), Name = "Art"},
                new Genre { GenreId = new Guid("7887326a-0311-49ad-981b-d4eeb1d4276c"), Name = "Biography"},
                new Genre { GenreId = new Guid("7e9aa445-a907-478d-9cbf-02b0529ec7d7"), Name = "Business"},
                new Genre { GenreId = new Guid("45d82cc5-9791-45af-996d-6218736976e3"), Name = "Children's"},
                new Genre { GenreId = new Guid("7ff5475d-9987-469e-95d9-d3dd6599be08"), Name = "Christian"},
                new Genre { GenreId = new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7"), Name = "Classics"},
                new Genre { GenreId = new Guid("512c94b1-7359-4543-81bc-1fcdde6c2b44"), Name = "Comics"},
                new Genre { GenreId = new Guid("9aee9159-a769-4fbd-bd14-482f8c6e1254"), Name = "Cookbooks"},
                new Genre { GenreId = new Guid("911a64fc-a281-4d9a-b8a4-15efae46c94a"), Name = "Ebooks"},
                new Genre { GenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef"), Name = "Fantasy"},
                new Genre { GenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077"), Name = "Fiction" },
                new Genre { GenreId = new Guid("3918d2a0-be77-4715-8bb6-b2a2e5f1511e"), Name = "Graphic Novels"},
                new Genre { GenreId = new Guid("2b8bdb32-41bd-4676-a90a-ec4e25d05ee4"), Name = "Historical Fiction"},
                new Genre { GenreId = new Guid("b0dc77e8-a8ff-40ef-af0a-bce938563b6a"), Name = "History"},
                new Genre { GenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7"), Name = "Horror"},
                new Genre { GenreId = new Guid("0b3c4168-076b-4d83-b04b-fee33486bfc0"), Name = "Memoir"},
                new Genre { GenreId = new Guid("4d4149e9-be14-496d-862e-2b7e9e54853d"), Name = "Music"},
                new Genre { GenreId = new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942"), Name = "Mystery"},
                new Genre { GenreId = new Guid("0efea100-4bf0-4d0f-b8c5-606394928d01"), Name = "Nonfiction"},
                new Genre { GenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098"), Name = "Paranormal"},
                new Genre { GenreId = new Guid("56034d8f-51b9-401e-9de5-b85752a72546"), Name = "Poetry"},
                new Genre { GenreId = new Guid("494c6f99-3679-48b3-971b-88e81e5e6496"), Name = "Psychology"},
                new Genre { GenreId = new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b"), Name = "Romance"},
                new Genre { GenreId = new Guid("97738f30-4f54-4f0b-8da4-a16af8665451"), Name = "Science"},
                new Genre { GenreId = new Guid("430b7e5f-6377-45d2-bea6-9bae61d77dba"), Name = "Science Fiction"},
                new Genre { GenreId = new Guid("5ee9dcda-0818-4e1a-9356-e9ab7530285e"), Name = "Self Help"},
                new Genre { GenreId = new Guid("3481994c-e202-460b-bc34-c9f6b5a29ad6"), Name = "Sports"},
                new Genre { GenreId = new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46"), Name = "Thriller" },
                new Genre { GenreId = new Guid("9f750916-994c-45e0-affe-c37a8c760acf"), Name = "Travel"},
                new Genre { GenreId = new Guid("1afef2ca-1224-485c-9bf1-a5af28bfc265"), Name = "Young Adult"}
            };

            builder.HasData(genreList);
        }
    }
}
