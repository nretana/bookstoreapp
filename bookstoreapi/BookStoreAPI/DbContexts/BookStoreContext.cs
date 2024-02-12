using BookStore.API.Entities;
using BookStore.API.Entities.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Reflection;

namespace BookStore.API.DbContexts
{
    public class BookStoreContext : IdentityDbContext<User>
    {
        public BookStoreContext(DbContextOptions options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity("BookGenre").HasData(
                    new { BooksBookId = new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    new { BooksBookId = new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), GenresGenreId = new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") },
                    new { BooksBookId = new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), GenresGenreId = new Guid("d53fa392-9639-489f-b173-33d6d910487f") },

                    new { BooksBookId = new Guid("04da94f3-1422-4997-b81e-88c87891abc8"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },

                    new { BooksBookId = new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), GenresGenreId = new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") },
                    new { BooksBookId = new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    new { BooksBookId = new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), GenresGenreId = new Guid("1afef2ca-1224-485c-9bf1-a5af28bfc265") },

                    new { BooksBookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    new { BooksBookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), GenresGenreId = new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") },
                    new { BooksBookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), GenresGenreId = new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },

                    new { BooksBookId = new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), GenresGenreId = new Guid("430b7e5f-6377-45d2-bea6-9bae61d77dba") },
                    new { BooksBookId = new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), GenresGenreId = new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") },
                    new { BooksBookId = new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },

                    new { BooksBookId = new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), GenresGenreId = new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") },
                    new { BooksBookId = new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), GenresGenreId = new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },
                    new { BooksBookId = new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },

                    new { BooksBookId = new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), GenresGenreId = new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") },

                    new { BooksBookId = new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    new { BooksBookId = new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },

                    new { BooksBookId = new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    new { BooksBookId = new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },

                    new { BooksBookId = new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    new { BooksBookId = new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },

                    new { BooksBookId = new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), GenresGenreId = new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    new { BooksBookId = new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), GenresGenreId = new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    new { BooksBookId = new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), GenresGenreId = new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },

                    new { BooksBookId = new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), GenresGenreId = new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },
                    new { BooksBookId = new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), GenresGenreId = new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    new { BooksBookId = new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), GenresGenreId = new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") },
                    new { BooksBookId = new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), GenresGenreId = new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") }

                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Format> Formats { get; set; }

    }
}
