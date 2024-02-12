using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class BookStore_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "FormatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresGenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksBookId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2e795e-ded2-47fe-b0a2-643872d9ac74", "5465b7ef-4993-4948-b1d7-89e63aabb19d", "Role", "Visitor", "VISITOR" },
                    { "d396a7e7-0d1d-49a9-9e23-ae1b85629a92", "d806d2cb-f27c-4087-a6ad-afc6d092ff4c", "Role", "Administrator", "ADMNISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "CountryOfBirth", "DateCreated", "DateOfBirth", "FirstName", "LastName", "PlaceOfBirth" },
                values: new object[,]
                {
                    { new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"), "Cormac McCarthy was an American novelist and playwright. He had written twelve novels in the Southern Gothic, western, and post-apocalyptic genres and had also written plays and screenplays. He received the Pulitzer Prize in 2007 for The Road, and his 2005 novel No Country for Old Men was adapted as a 2007 film of the same name, which won four Academy Awards, including Best Picture. His earlier Blood Meridian (1985) was among Time Magazine's poll of 100 best English-language books published between 1925 and 2005, and he placed joint runner-up for a similar title in a poll taken in 2006 by The New York Times of the best American fiction published in the last 25 years. Literary critic Harold Bloom named him one of the four major American novelists of his time, along with Thomas Pynchon, Don DeLillo, and Philip Roth. He is frequently compared by modern reviewers to William Faulkner. In 2009, Cormac McCarthy won the PEN/Saul Bellow Award, a lifetime achievement award given by the PEN American Center.", "United States", new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(1933, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Cormac", "McCarthy", "Providence, Rhode Island" },
                    { new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"), "Yann Martel is the author of Life of Pi, the #1 international bestseller and winner of the 2002 Man Booker (among many other prizes). He is also the award-winning author of The Facts Behind the Helsinki Roccamatios (winner of the Journey Prize), Self, Beatrice & Virgil, and 101 Letters to a Prime Minister. Born in Spain in 1963, Martel studied philosophy at Trent University, worked at odd jobs—tree planter, dishwasher, security guard—and traveled widely before turning to writing. He lives in Saskatoon, Canada, with the writer Alice Kuipers and their four children.", "Spain", new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8878), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(1963, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Yann", "Martel", "Salamanca" },
                    { new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"), "", "United Kingdom", new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, -6, 0, 0, 0)), null, "Gillian", "McAllister", "" },
                    { new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"), "Emma Rosenblum is chief content officer at Bustle Digital Group, overseeing content and strategy for BDG’s lifestyle, parenting, and culture & innovation portfolios, including Bustle, Elite Daily, Romper, NYLON, The Zoe Report, Romper, Scary Mommy, Fatherly, The Dad, Gawker, Inverse, and Mic. Prior to BDG, Emma served as the executive editor of ELLE. Previously Rosenblum was a senior editor at Bloomberg Businessweek, and before that a senior editor at Glamour. She began her career at New York magazine. She lives in New York City, with her husband and two sons. Bad Summer People is her first novel.", null, new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, -6, 0, 0, 0)), null, "Emma", "Rosenblum", null },
                    { new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"), "Anne Rice (born Howard Allen Frances O'Brien) was a best-selling American author of gothic, supernatural, historical, erotica, and later religious themed books. Best known for The Vampire Chronicles, her prevailing thematic focus is on love, death, immortality, existentialism, and the human condition. She was married to poet Stan Rice for 41 years until his death in 2002. Her books have sold nearly 100 million copies, making her one of the most widely read authors in modern history.\r\n\r\nAnne Rice passed on December 11, 2021 due to complications from a stroke. She was eighty years old at the time of her death.", "United States", new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(1941, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Anne", "Rice", "New Orleans, Louisiana" },
                    { new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "Jaclyn Goldis is a graduate of the University of Michigan, Ann Arbor, and NYU Law. She practiced estate planning law at a large Chicago firm for seven years before leaving her job to travel the world and write novels. Follow her on Instagram and Twitter @jaclyngoldis.", "United States", new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, -6, 0, 0, 0)), new DateTimeOffset(new DateTime(1979, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Jaclyn", "Goldis", "" }
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "FormatId", "Name" },
                values: new object[,]
                {
                    { new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "HardCover" },
                    { new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "Paperback" },
                    { new Guid("488248a0-a751-4f92-b6c1-6509b2c97b2c"), "Audiobook" },
                    { new Guid("a8593958-90cc-4d9e-8785-82b100afdf15"), "Kindle Edition" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { new Guid("0b3c4168-076b-4d83-b04b-fee33486bfc0"), "Memoir" },
                    { new Guid("0efea100-4bf0-4d0f-b8c5-606394928d01"), "Nonfiction" },
                    { new Guid("1afef2ca-1224-485c-9bf1-a5af28bfc265"), "Young Adult" },
                    { new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942"), "Mystery" },
                    { new Guid("2b8bdb32-41bd-4676-a90a-ec4e25d05ee4"), "Historical Fiction" },
                    { new Guid("3481994c-e202-460b-bc34-c9f6b5a29ad6"), "Sports" },
                    { new Guid("3918d2a0-be77-4715-8bb6-b2a2e5f1511e"), "Graphic Novels" },
                    { new Guid("430b7e5f-6377-45d2-bea6-9bae61d77dba"), "Science Fiction" },
                    { new Guid("45d82cc5-9791-45af-996d-6218736976e3"), "Children's" },
                    { new Guid("494c6f99-3679-48b3-971b-88e81e5e6496"), "Psychology" },
                    { new Guid("4d4149e9-be14-496d-862e-2b7e9e54853d"), "Music" },
                    { new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7"), "Classics" },
                    { new Guid("512c94b1-7359-4543-81bc-1fcdde6c2b44"), "Comics" },
                    { new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7"), "Horror" },
                    { new Guid("56034d8f-51b9-401e-9de5-b85752a72546"), "Poetry" },
                    { new Guid("5ee9dcda-0818-4e1a-9356-e9ab7530285e"), "Self Help" },
                    { new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b"), "Romance" },
                    { new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077"), "Fiction" },
                    { new Guid("7887326a-0311-49ad-981b-d4eeb1d4276c"), "Biography" },
                    { new Guid("7e9aa445-a907-478d-9cbf-02b0529ec7d7"), "Business" },
                    { new Guid("7ff5475d-9987-469e-95d9-d3dd6599be08"), "Christian" },
                    { new Guid("911a64fc-a281-4d9a-b8a4-15efae46c94a"), "Ebooks" },
                    { new Guid("97738f30-4f54-4f0b-8da4-a16af8665451"), "Science" },
                    { new Guid("9aee9159-a769-4fbd-bd14-482f8c6e1254"), "Cookbooks" },
                    { new Guid("9f750916-994c-45e0-affe-c37a8c760acf"), "Travel" },
                    { new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46"), "Thriller" },
                    { new Guid("b0dc77e8-a8ff-40ef-af0a-bce938563b6a"), "History" },
                    { new Guid("cd0b243c-6e41-4679-9927-1ef02b4266a0"), "Art" },
                    { new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef"), "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "FormatId", "ImageUrl", "Isbn", "Pages", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("04da94f3-1422-4997-b81e-88c87891abc8"), new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"), "From the author of the extraordinary Vampire Chronicles comes a huge, hypnotic novel of witchcraft and the occult through four centuries.\r\n\r\nDemonstrating, once again, her gift for spellbinding storytelling and the creation of legend, Anne Rice makes real for us a great dynasty of witches—a family given to poetry and to incest, to murder and to philosophy; a family that, over the ages, is itself haunted by a powerful, dangerous, and seductive being.\r\n\r\nOn the veranda of a great New Orleans house, now faded, a mute and fragile woman sits rocking... and The Witching Hour begins.\r\n\r\nIt begins in our time with a rescue at sea.  Rowan Mayfair, a beautiful woman, a brilliant practitioner of neurosurgery—aware that she has special powers but unaware that she comes from an ancient line of witches—finds the drowned body of a man off the coast of California and brings him to life. He is Michael Curry, who was born in New Orleans and orphaned in childhood by fire on Christmas Eve, who pulled himself up from poverty, and who now, in his brief interval of death, has acquired a sensory power that mystifies and frightens him.\r\n\r\nAs these two, fiercely drawn to each other, fall in love and—in passionate alliance—set out to solve the mystery of her past and his unwelcome gift, the novel moves backward and forward in time from today's New Orleans and San Francisco to long-ago Amsterdam and a château in the France of Louis XIV.  An intricate tale of evil unfolds—an evil unleashed in seventeenth-century Scotland, where the first \"witch,\" Suzanne of the Mayfair, conjures up the spirit she names Lasher... a creation that spells her own destruction and torments each of her descendants in turn.\r\n\r\nFrom the coffee plantations of Port au Prince, where the great Mayfair fortune is made and the legacy of their dark power is almost destroyed, to Civil War New Orleans, as Julien—the clan's only male to be endowed with occult powers—provides for the dynasty its foothold in America, the dark, luminous story encompasses dramas of seduction and death, episodes of tenderness and healing.  And always—through peril and escape, tension and release—there swirl around us the echoes of eternal war: innocence versus the corruption of the spirit, sanity against madness, life against death. With a dreamlike power, the novel draws us, through circuitous, twilight paths, to the present and Rowan's increasingly inspired and risky moves in the merciless game that binds her to her heritage. And in New Orleans, on Christmas Eve, this strangest of family sagas is brought to its startling climax.", new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327289387i/11901.jpg", "9780345373946", 400, new DateTime(2004, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witching Hour" },
                    { new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "A dream girls trip to a luxurious French chateau devolves into a deadly nightmare of secrets and murder in this stylish, twisty thriller for fans of Lucy Foley, Ruth Ware, and Lisa Jewell.\r\n\r\nWelcome to picturesque Provence, where the Lady of the Chateau, Séraphine Demargelasse, has opened its elegant doors to her granddaughter Darcy and three friends. Twenty years earlier, the four girlfriends studied abroad together in France and visited the old woman on the weekends, creating the group’s deep bond. But why this sudden invitation?\r\n\r\nAmid winery tours, market visits, and fancy dinners overlooking olive groves and lavender fields, it becomes clear that each woman has a hidden reason for accepting the invitation. Then, after a wild evening’s celebration, Séraphine is found brutally murdered.\r\n\r\nAs the women search for answers to this shocking crime, fingers begin pointing and a sinister Instagram account pops up, exposing snapshots from the friends’ intimate moments at the chateau, while threatening to reveal more.\r\n\r\nAs they race to uncover who murdered Séraphine and is now stalking them, they learn the chateau houses many secrets…several worth killing for.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1682527923i/62919401.jpg", "9781668013014", 336, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chateau" }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksBookId", "GenresGenreId" },
                values: new object[,]
                {
                    { new Guid("04da94f3-1422-4997-b81e-88c87891abc8"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGenreId",
                table: "BookGenre",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_FormatId",
                table: "Books",
                column: "FormatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Formats");
        }
    }
}
