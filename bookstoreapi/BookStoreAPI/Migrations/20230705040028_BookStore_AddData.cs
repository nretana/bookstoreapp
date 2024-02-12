using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class BookStore_AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2e795e-ded2-47fe-b0a2-643872d9ac74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d396a7e7-0d1d-49a9-9e23-ae1b85629a92");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "014c5767-8c57-4e06-a6d0-27b4e0537ab2", "5f82ac62-ea16-46f9-a89e-d1bddd522d94", "Role", "Visitor", "VISITOR" },
                    { "1cb60b05-4a0b-4bc7-a5ef-8ee28601fc30", "41d2ac23-bc90-4120-a52d-d9f48c6c9ad1", "Role", "Administrator", "ADMNISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7575), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                columns: new[] { "CountryOfBirth", "DateCreated", "PlaceOfBirth" },
                values: new object[] { "", new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7584), new TimeSpan(0, -6, 0, 0, 0)), "" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7559), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "CountryOfBirth", "DateCreated", "DateOfBirth", "FirstName", "LastName", "PlaceOfBirth" },
                values: new object[,]
                {
                    { new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"), "Charlaine Harris has been a published novelist for over thirty-five years. A native of the Mississippi Delta, she grew up in the middle of a cotton field. Charlaine lives in Texas now, and all of her children and grandchildren are within easy driving distance.\r\n\r\nThough her early output consisted largely of ghost stories, by the time she hit college (Rhodes, in Memphis) Charlaine was writing poetry and plays. After holding down some low-level jobs, her husband Hal gave her the opportunity to stay home and write. The resulting two stand-alones were published by Houghton Mifflin. After a child-producing sabbatical, Charlaine latched on to the trend of series, and soon had her own traditional mystery books about a Georgia librarian, Aurora Teagarden. Her first Teagarden, Real Murders, garnered an Agatha nomination.\r\n\r\nSoon Charlaine was looking for another challenge, and the result was the much darker Lily Bard series. The books, set in Shakespeare, Arkansas, feature a heroine who has survived a terrible attack and is learning to live with its consequences.\r\n\r\nWhen Charlaine began to realize that neither of those series was ever going to set the literary world on fire, she regrouped and decided to write the book she’d always wanted to write. Not a traditional mystery, nor yet pure science fiction or romance, Dead Until Dark broke genre boundaries to appeal to a wide audience of people who simply enjoy a good adventure. Each subsequent book about Sookie Stackhouse, telepathic Louisiana barmaid and friend to vampires, werewolves, and various other odd creatures, was very successful in many languages.\r\n\r\nThe Harper Connelly books were written concurrently with the Sookie novels.\r\n\r\nFollowing the end of Sookie's recorded adventures, Charlaine wrote the \"Midnight, Texas\" books, which have become a television series, also. The Aurora Teagarden books have been adapted by Hallmark Movie & Mystery.\r\n\r\nCharlaine is a member of many professional organizations, an Episcopalian, and currently the lucky houseparent to two rescue dogs. She lives on a cliff overlooking the Brazos River.", "United States", new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7590), new TimeSpan(0, -6, 0, 0, 0)), null, "Charlaine", "Harris", "Tunica, Mississippi" },
                    { new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"), "New York Times and USA Today bestselling author Tracy Wolff is a lover of vampires, dragons, and all things that go bump in the night. A onetime English professor, she now devotes all her time to writing dark and romantic stories with tortured heroes and kick-butt heroines. She has written all her sixty-plus novels from her home in Austin, Texas, which she shares with her family.", "", new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, -6, 0, 0, 0)), null, "Tracy", "Wolff", "" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "FormatId", "ImageUrl", "Isbn", "Pages", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"), "A whip-smart, propulsive debut about infidelity, backstabbing, and murderous intrigue, set against an exclusive summer haven on Fire Island\r\nNone of them would claim to be a particularly good person. But who among them is actually capable of murder?\r\nJen Weinstein and Lauren Parker rule the town of Salcombe, Fire Island every summer. They hold sway on the beach and the tennis court, and are adept at manipulating people to get what they want. Their husbands, Sam and Jason, have summered together on the island since childhood, despite lifelong grudges and numerous secrets. Their one single friend, Rachel Woolf, is looking to meet her match, whether he's the tennis pro-or someone else's husband. But even with plenty to gossip about, this season starts out as quietly as any other.\r\nUntil a body is discovered, face down off the side of the boardwalk.\r\nStylish, subversive and darkly comedic, this is a story of what's lurking under the surface of picture-perfect lives in a place where everyone has something to hide.", new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1675084836i/61884844.jpg", "9781250887009", 272, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bad Summer People" },
                    { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"), "A searing, postapocalyptic novel destined to become Cormac McCarthy’s masterpiece.\r\n\r\nA father and his son walk alone through burned America. Nothing moves in the ravaged landscape save the ash on the wind. It is cold enough to crack stones, and when the snow falls it is gray. The sky is dark. Their destination is the coast, although they don’t know what, if anything, awaits them there. They have nothing; just a pistol to defend themselves against the lawless bands that stalk the road, the clothes they are wearing, a cart of scavenged food—and each other.\r\n\r\nThe Road is the profoundly moving story of a journey. It boldly imagines a future in which no hope remains, but in which the father and his son, “each the other’s world entire,” are sustained by love. Awesome in the totality of its vision, it is an unflinching meditation on the worst and the best that we are capable of: ultimate destructiveness, desperate tenacity, and the tenderness that keeps two people alive in the face of total devastation.", new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1600241424i/6288.jpg", "9780307265432", 241, new DateTime(2006, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Road" },
                    { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "The Talamasca, documenters of paranormal activity, is on the hunt for the newly born Lasher. Mayfair women are dying from hemorrhages and a strange genetic anomaly has been found in Rowan and Michael. Lasher, born from Rowan, is another species altogether and now in the corporeal body, represents an incalcuable threat to the Mayfairs. Rowan and Lasher travel together to Houston and she becomes pregnant with another creature like him, a Taltos. Lasher seeks to reproduce his race in other women, but they cannot withstand it. Rowan escapes and becomes comatose as her fully-grown Taltos daughter is born. The Mayfairs declare all-out war on Lasher and try to nurse Rowan back to heatlth.\r\n\r\nMichael remains entwined in the Mayfair family and learns how he comes by his strange powers. Michael's ghostly visiting from a long-dead Mayfair reveals the importance of destroying Lasher. In the investigation, Lasher's origins are revealed, the new Taltos Emaleth returns, and the climax of death and life engulfs the family.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1386924775i/31340.jpg", "9780099471431", 400, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lasher" },
                    { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "In the latest installment of The Vampire Chronicles, Anne Rice summons up dazzling worlds to bring us the story of Armand - eternally young, with the face of a Botticelli angel. Armand, who first appeared in all his dark glory more than twenty years ago in the now-classic Interview with the Vampire, the first of The Vampire Chronicles, the novel that established its author worldwide as a magnificent storyteller and creator of magical realms.\r\n\r\nNow, we go with Armand across the centuries to the Kiev Rus of his boyhood - a ruined city under Mongol dominion - and to ancient Constantinople, where Tartar raiders sell him into slavery. And in a magnificent palazzo in the Venice of the Renaissance we see him emotionally and intellectually in thrall to the great vampire Marius, who masquerades among humankind as a mysterious, reclusive painter and who will bestow upon Armand the gift of vampiric blood. As the novel races to its climax, moving through scenes of luxury and elegance, of ambush, fire, and devil worship to nineteenth-century Paris and today's New Orleans, we see its eternally vulnerable and romantic hero forced to choose between his twilight immortality and the salvation of his immortal soul.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1388355184i/31332.jpg", "9780345434807", 457, new DateTime(2000, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Vampire Armand" },
                    { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "Lestat. The vampire hero of Anne Rice's enthralling new novel is a creature of the darkest and richest imagination. Once an aristocrat in the heady days of pre-revolutionary France, now a rock star in the demonic, shimmering 1980s, he rushes through the centuries in search of others like him, seeking answers to the mystery of his eternal, terrifying existence. His is a mesmerizing story --- passionate, complex, and thrilling.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347515742i/43814.jpg", "9780345476883", 481, new DateTime(2004, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Vampire Lestat" },
                    { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"), "Rice's new novel continues the epic occult saga that began with The Witching Hour and Lasher. Taltos takes readers back through the centuries to a civilization part human and part of wholly mysterious origins, at odds with mortality and immortality, justice and guilt.", new Guid("a8593958-90cc-4d9e-8785-82b100afdf15"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1328364916i/9804779.jpg", null, 533, new DateTime(2010, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taltos" },
                    { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"), "The sensational conclusion to the massive #1 New York Times bestselling series…\r\n\r\nIt’s been over three months since my friends and I took down Cyrus. Three months where my biggest fear was what paper was due next... But I should have known it was too good to last. Now everything is falling apart.", new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1642442027i/60136526.jpg", "9781649373168", 592, new DateTime(2006, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cherish" },
                    { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"), "What will she do ?\r\nThere’s a man out there. His weapon isn’t a gun, or a knife. It’s a secret.\r\n\r\n22 years old. No history of running away. Last seen on CCTV, entering a dead-end alley. And not coming back out again. Missing for one day and counting...\r\n\r\nJULIA; The detective heading up the case. She knows what to expect. A desperate family, a ticking clock, and long hours away from her daughter. But Julia has no idea how close to home this case is going to get. Because her family’s safety depends on one Julia must not find out what happened to Olivia and must frame somebody else for her murder . . . What would you do?", new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1683574174i/62292411.jpg", "9780063252394", 460, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Just Another Missing Person" },
                    { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"), "Life of Pi is a fantasy adventure novel by Yann Martel published in 2001. The protagonist, Piscine Molitor \"Pi\" Patel, a Tamil boy from Pondicherry, explores issues of spirituality and practicality from an early age. He survives 227 days after a shipwreck while stranded on a boat in the Pacific Ocean with a Bengal tiger named Richard Parker.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1631251689i/4214.jpg", "9780770430078", 460, new DateTime(2006, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life of Pi" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { new Guid("d53fa392-9639-489f-b173-33d6d910487f"), "Adult" },
                    { new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098"), "Paranormal" }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksBookId", "GenresGenreId" },
                values: new object[,]
                {
                    { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },
                    { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") },
                    { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") },
                    { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("430b7e5f-6377-45d2-bea6-9bae61d77dba") },
                    { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") },
                    { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), new Guid("d53fa392-9639-489f-b173-33d6d910487f") },
                    { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") },
                    { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("1afef2ca-1224-485c-9bf1-a5af28bfc265") },
                    { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") },
                    { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") },
                    { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },
                    { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") },
                    { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") },
                    { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "FormatId", "ImageUrl", "Isbn", "Pages", "PublishedDate", "Title" },
                values: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"), "Sookie Stackhouse is just a small-time cocktail waitress in small-town Louisiana. Until the vampire of her dreams walks into her life-and one of her coworkers checks out....\r\nMaybe having a vampire for a boyfriend isn't such a bright idea.", new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"), "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1468560853i/301082.jpg", "9780441008537", 292, new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dead Until Dark" });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksBookId", "GenresGenreId" },
                values: new object[,]
                {
                    { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") },
                    { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") },
                    { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") },
                    { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") },
                    { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014c5767-8c57-4e06-a6d0-27b4e0537ab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cb60b05-4a0b-4bc7-a5ef-8ee28601fc30");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"));

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("0998a158-8df5-43a0-813e-4ec518f325be"), new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("430b7e5f-6377-45d2-bea6-9bae61d77dba") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"), new Guid("d53fa392-9639-489f-b173-33d6d910487f") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("51e3ddad-c7a2-4445-898c-609bc77e67a7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("1afef2ca-1224-485c-9bf1-a5af28bfc265") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"), new Guid("acbe4b25-87f6-4496-ada0-5aebfb7add46") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("4f3dce22-a7af-4c9f-93b8-61040ecfa1c7") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("27e7179f-f788-4035-8a0f-52dab8a6c942") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("7394fd93-e44d-448f-a44c-b23fcfee228b") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("740f0608-bbb1-4c32-8dec-f1dc8ae63077") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("ceb0472e-7f5e-472c-9d20-ad5e4cbcb6ef") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksBookId", "GenresGenreId" },
                keyValues: new object[] { new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"), new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0998a158-8df5-43a0-813e-4ec518f325be"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("d53fa392-9639-489f-b173-33d6d910487f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("fc2b9d9e-0d6a-4ce8-a6f3-c9c46c956098"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"));

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2e795e-ded2-47fe-b0a2-643872d9ac74", "5465b7ef-4993-4948-b1d7-89e63aabb19d", "Role", "Visitor", "VISITOR" },
                    { "d396a7e7-0d1d-49a9-9e23-ae1b85629a92", "d806d2cb-f27c-4087-a6ad-afc6d092ff4c", "Role", "Administrator", "ADMNISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8878), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                columns: new[] { "CountryOfBirth", "DateCreated", "PlaceOfBirth" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, -6, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8871), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 6, 17, 14, 13, 11, 125, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, -6, 0, 0, 0)));
        }
    }
}
