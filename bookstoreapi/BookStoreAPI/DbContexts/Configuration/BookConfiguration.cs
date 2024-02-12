using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.DbContexts.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            var genres = new Dictionary<string, Genre>()
            {
                { "Art", new Genre { GenreId = new Guid("61e7d757-f27f-463f-8483-af49d0664192"), Name = "Art"} },
                { "Biography", new Genre { GenreId = new Guid("3777d639-31e9-4249-966c-621b6b7c0bd6"), Name = "Biography"} },
                { "Business", new Genre { GenreId = new Guid("93b4c764-727e-4fe0-a11c-09bb3f4e118d"), Name = "Business"} },
                { "Children's", new Genre { GenreId = new Guid("9f455910-90d7-4c20-8f6d-0ef1b0e81a8f"), Name = "Children's"} },
                { "Christian", new Genre { GenreId = new Guid("6674a802-98f0-41d1-9008-0717040ea719"), Name = "Christian"} },
                { "Classics", new Genre { GenreId = new Guid("046601ec-9fac-42e4-b174-8a6c7c69baea"), Name = "Classics"} },
                { "Comics", new Genre { GenreId = new Guid("b9de2dfc-065c-4d90-85d9-a1fcda22d86d"), Name = "Comics"} },
                { "Cookbooks", new Genre { GenreId = new Guid("8b7fbc94-69ea-48cd-9e79-b887801903e7"), Name = "Cookbooks"} },
                { "Ebooks", new Genre { GenreId = new Guid("7303b0c4-99c4-4932-9cef-dd302c843c07"), Name = "Ebooks"} },
                { "Fantasy", new Genre { GenreId = new Guid("144065aa-d5df-4d9b-a87a-5941391f9684"), Name = "Fantasy"} },
                { "Fiction", new Genre { GenreId = new Guid("f337cae4-6739-4090-b230-b8b29cb80bab"), Name = "Fiction"} },
                { "Graphic Novels", new Genre { GenreId = new Guid("344ac7ff-dc8f-4260-b369-2f0f16703dc9"), Name = "Graphic Novels"} },
                { "Historical Fiction", new Genre { GenreId = new Guid("b19b8920-2795-4791-80ba-db13421bfcb9"), Name = "Historical Fiction"} },
                { "History", new Genre { GenreId = new Guid("9e3aff06-7465-4cb3-a2a1-08a3121cb651"), Name = "History"} },
                { "Horror", new Genre { GenreId = new Guid("f094aef7-6013-4479-a3b5-d31b3771f90d"), Name = "Horror"} },
                { "Memoir", new Genre { GenreId = new Guid("9e08ba8b-4e7b-413c-996d-8dd729718874"), Name = "Memoir"} },
                { "Music", new Genre { GenreId = new Guid("13efdd5d-f23d-4bee-983d-8a37dd2a2a01"), Name = "Music"} },
                { "Mystery", new Genre { GenreId = new Guid("3245ee35-f8bc-4721-b1a8-511f81a0ce2f"), Name = "Mystery"} },
                { "Nonfiction", new Genre { GenreId = new Guid("7aaf3e4c-344e-4e70-b0c5-ab270efed705"), Name = "Nonfiction"} },
                { "Poetry", new Genre { GenreId = new Guid("8dc64f42-f181-4413-825d-dd4cc716f74b"), Name = "Poetry"} },
                { "Psychology", new Genre { GenreId = new Guid("bfec8cea-0e6d-489d-8a5f-30fee9fc2656"), Name = "Psychology"} },
                { "Romance", new Genre { GenreId = new Guid("5c58bbf4-b188-4bae-b43e-404cefe3c315"), Name = "Romance"} },
                { "Science", new Genre { GenreId = new Guid("91fa9485-fc45-4c80-93e0-e3f93c330c0c"), Name = "Science"} },
                { "Science Fiction", new Genre { GenreId = new Guid("c1f29902-f3ee-4d94-8dff-8641ad675255"), Name = "Science Fiction"} },
                { "Self Help", new Genre { GenreId = new Guid("ef9535fd-8d72-479c-a39c-d1b9b37ba455"), Name = "Self Help"} },
                { "Sports", new Genre { GenreId = new Guid("fe2234cf-47df-486c-a40f-dc5eea9cf00d"), Name = "Sports"} },
                { "Thriller", new Genre { GenreId = new Guid("a3d9b51d-1ccc-4417-b594-332307a28f7d"), Name = "Thriller"} },
                { "Travel", new Genre { GenreId = new Guid("727f2b40-99f5-4c28-a5c9-124b1203b482"), Name = "Travel"} },
                { "Young Adult", new Genre { GenreId = new Guid("238c833b-72f8-457b-87b6-6a59a66fbf1e"), Name = "Young Adult"} }
            };

            builder.HasData(
                    new Book
                    {
                        BookId = new Guid("04da94f3-1422-4997-b81e-88c87891abc8"),
                        Title= "The Witching Hour",
                        Description= "From the author of the extraordinary Vampire Chronicles comes a huge, hypnotic novel of witchcraft and " +
                                        "the occult through four centuries.\r\n\r\nDemonstrating, once again, her gift for spellbinding storytelling " +
                                        "and the creation of legend, Anne Rice makes real for us a great dynasty of witches—a family given to poetry " +
                                        "and to incest, to murder and to philosophy; a family that, over the ages, is itself haunted by a powerful, " +
                                        "dangerous, and seductive being.\r\n\r\nOn the veranda of a great New Orleans house, now faded, a mute and fragile " +
                                        "woman sits rocking... and The Witching Hour begins.\r\n\r\nIt begins in our time with a rescue at sea.  Rowan Mayfair, " +
                                        "a beautiful woman, a brilliant practitioner of neurosurgery—aware that she has special powers but unaware that she comes " +
                                        "from an ancient line of witches—finds the drowned body of a man off the coast of California and brings him to life. " +
                                        "He is Michael Curry, who was born in New Orleans and orphaned in childhood by fire on Christmas Eve, who pulled himself " +
                                        "up from poverty, and who now, in his brief interval of death, has acquired a sensory power that mystifies and frightens " +
                                        "him.\r\n\r\nAs these two, fiercely drawn to each other, fall in love and—in passionate alliance—set out to solve the mystery " +
                                        "of her past and his unwelcome gift, the novel moves backward and forward in time from today's New Orleans and San Francisco " +
                                        "to long-ago Amsterdam and a château in the France of Louis XIV.  An intricate tale of evil unfolds—an evil unleashed in " +
                                        "seventeenth-century Scotland, where the first \"witch,\" Suzanne of the Mayfair, conjures up the spirit she " +
                                        "names Lasher... a creation that spells her own destruction and torments each of her descendants in turn.\r\n\r\nFrom " +
                                        "the coffee plantations of Port au Prince, where the great Mayfair fortune is made and the legacy of their dark power " +
                                        "is almost destroyed, to Civil War New Orleans, as Julien—the clan's only male to be endowed with occult powers—provides " +
                                        "for the dynasty its foothold in America, the dark, luminous story encompasses dramas of seduction and death, episodes of " +
                                        "tenderness and healing.  And always—through peril and escape, tension and release—there swirl around us the echoes of " +
                                        "eternal war: innocence versus the corruption of the spirit, sanity against madness, life against death. " +
                                        "With a dreamlike power, the novel draws us, through circuitous, twilight paths, to the present and Rowan's increasingly " +
                                        "inspired and risky moves in the merciless game that binds her to her heritage. And in New Orleans, on Christmas Eve, " +
                                        "this strangest of family sagas is brought to its startling climax.",
                        Isbn = "9780345373946",
                        PublishedDate = new DateTime(2004, 11, 4),
                        Pages = 400,
                        FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                        AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327289387i/11901.jpg"
                    },

                    new Book
                     {
                        BookId = new Guid("58006cde-fd5c-4dda-a9b8-293b2dea9116"),
                        Title = "The Chateau",
                        Description = "A dream girls trip to a luxurious French chateau devolves into a deadly nightmare of secrets and murder in this stylish, " +
                                      "twisty thriller for fans of Lucy Foley, Ruth Ware, and Lisa Jewell.\r\n\r\nWelcome to picturesque Provence, where the Lady " +
                                      "of the Chateau, Séraphine Demargelasse, has opened its elegant doors to her granddaughter Darcy and three friends. Twenty " +
                                      "years earlier, the four girlfriends studied abroad together in France and visited the old woman on the weekends, creating " +
                                      "the group’s deep bond. But why this sudden invitation?\r\n\r\nAmid winery tours, market visits, and fancy dinners overlooking " +
                                      "olive groves and lavender fields, it becomes clear that each woman has a hidden reason for accepting the invitation. " +
                                      "Then, after a wild evening’s celebration, Séraphine is found brutally murdered.\r\n\r\nAs the women search for answers to " +
                                      "this shocking crime, fingers begin pointing and a sinister Instagram account pops up, exposing snapshots from the friends’ " +
                                      "intimate moments at the chateau, while threatening to reveal more.\r\n\r\nAs they race to uncover who murdered Séraphine and " +
                                      "is now stalking them, they learn the chateau houses many secrets…several worth killing for.",
                        Isbn = "9781668013014",
                        PublishedDate = new DateTime(2023, 05, 23),
                        Pages = 336,
                        FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                        AuthorId = new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1682527923i/62919401.jpg"
                    },
                    new Book
                      {
                          BookId = new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"),
                          Title = "Lasher",
                          Description = "The Talamasca, documenters of paranormal activity, is on the hunt for the newly born Lasher. Mayfair women are dying from " +
                                        "hemorrhages and a strange genetic anomaly has been found in Rowan and Michael. Lasher, born from Rowan, is another species " +
                                        "altogether and now in the corporeal body, represents an incalcuable threat to the Mayfairs. Rowan and Lasher travel together " +
                                        "to Houston and she becomes pregnant with another creature like him, a Taltos. Lasher seeks to reproduce his race in other " +
                                        "women, but they cannot withstand it. Rowan escapes and becomes comatose as her fully-grown Taltos daughter is born. " +
                                        "The Mayfairs declare all-out war on Lasher and try to nurse Rowan back to heatlth.\r\n\r\nMichael remains entwined in the Mayfair " +
                                        "family and learns how he comes by his strange powers. Michael's ghostly visiting from a long-dead Mayfair reveals the importance " +
                                        "of destroying Lasher. In the investigation, Lasher's origins are revealed, the new Taltos Emaleth returns, and the climax of " +
                                        "death and life engulfs the family.",
                          Isbn = "9780099471431",
                          PublishedDate = new DateTime(2004, 01, 01),
                          Pages = 400,
                          FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                          AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                          ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1386924775i/31340.jpg"
                    },
                    new Book
                       {
                        BookId = new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"),
                        Title = "Taltos",
                        Description = "Rice's new novel continues the epic occult saga that began with The Witching Hour and Lasher. " +
                                      "Taltos takes readers back through the centuries to a civilization part human and part of wholly " +
                                      "mysterious origins, at odds with mortality and immortality, justice and guilt.",
                        PublishedDate = new DateTime(2010, 11, 17),
                        Pages = 533,
                        FormatId = new Guid("a8593958-90cc-4d9e-8785-82b100afdf15"),
                        AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1328364916i/9804779.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"),
                        Title = "The Vampire Lestat",
                        Description = "Lestat. The vampire hero of Anne Rice's enthralling new novel is a creature of the darkest and richest " +
                                      "imagination. Once an aristocrat in the heady days of pre-revolutionary France, now a rock star in the " +
                                      "demonic, shimmering 1980s, he rushes through the centuries in search of others like him, seeking answers " +
                                      "to the mystery of his eternal, terrifying existence. His is a mesmerizing story --- passionate, complex, and thrilling.",
                        Isbn = "9780345476883",
                        PublishedDate = new DateTime(2004, 09, 30),
                        Pages = 481,
                        FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                        AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347515742i/43814.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"),
                        Title = "The Vampire Armand",
                        Description = "In the latest installment of The Vampire Chronicles, Anne Rice summons up dazzling worlds to bring us the story " +
                                      "of Armand - eternally young, with the face of a Botticelli angel. Armand, who first appeared in all his dark glory " +
                                      "more than twenty years ago in the now-classic Interview with the Vampire, the first of The Vampire Chronicles, the " +
                                      "novel that established its author worldwide as a magnificent storyteller and creator of magical realms.\r\n\r\nNow, " +
                                      "we go with Armand across the centuries to the Kiev Rus of his boyhood - a ruined city under Mongol dominion - and " +
                                      "to ancient Constantinople, where Tartar raiders sell him into slavery. And in a magnificent palazzo in the Venice " +
                                      "of the Renaissance we see him emotionally and intellectually in thrall to the great vampire Marius, who masquerades " +
                                      "among humankind as a mysterious, reclusive painter and who will bestow upon Armand the gift of vampiric blood. " +
                                      "As the novel races to its climax, moving through scenes of luxury and elegance, of ambush, fire, and devil worship " +
                                      "to nineteenth-century Paris and today's New Orleans, we see its eternally vulnerable and romantic hero forced to choose " +
                                      "between his twilight immortality and the salvation of his immortal soul.",
                        Isbn = "9780345434807",
                        PublishedDate = new DateTime(2000, 10, 03),
                        Pages = 457,
                        FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                        AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1388355184i/31332.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("ee6a9999-8a7c-4c75-96e4-fcbe87fb1f39"),
                        Title = "Life of Pi",
                        Description = "Life of Pi is a fantasy adventure novel by Yann Martel published in 2001. The protagonist, Piscine Molitor \"Pi\" Patel, " +
                                      "a Tamil boy from Pondicherry, explores issues of spirituality and practicality from an early age. He survives 227 days after " +
                                      "a shipwreck while stranded on a boat in the Pacific Ocean with a Bengal tiger named Richard Parker.",
                        Isbn = "9780770430078",
                        PublishedDate = new DateTime(2006, 09, 29),
                        Pages = 460,
                        FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                        AuthorId = new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1631251689i/4214.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("ca5f480b-a731-422f-a66b-0f2d90bce100"),
                        Title = "Just Another Missing Person",
                        Description = "What will she do ?\r\nThere’s a man out there. His weapon isn’t a gun, or a knife. It’s a secret.\r\n\r\n22 years old. " +
                                      "No history of running away. Last seen on CCTV, entering a dead-end alley. And not coming back out again. Missing for " +
                                      "one day and counting...\r\n\r\nJULIA; The detective heading up the case. She knows what to expect. A desperate family, " +
                                      "a ticking clock, and long hours away from her daughter. But Julia has no idea how close to home this case is going to get. " +
                                      "Because her family’s safety depends on one Julia must not find out what happened to Olivia and must frame somebody else " +
                                      "for her murder . . . What would you do?",
                        Isbn = "9780063252394",
                        PublishedDate = new DateTime(2023, 09, 01),
                        Pages = 460,
                        FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                        AuthorId = new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1683574174i/62292411.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("0998a158-8df5-43a0-813e-4ec518f325be"),
                        Title = "Bad Summer People",
                        Description = "A whip-smart, propulsive debut about infidelity, backstabbing, and murderous intrigue, set against an exclusive " +
                                      "summer haven on Fire Island\r\nNone of them would claim to be a particularly good person. But who among them is actually " +
                                      "capable of murder?\r\nJen Weinstein and Lauren Parker rule the town of Salcombe, Fire Island every summer. They hold sway " +
                                      "on the beach and the tennis court, and are adept at manipulating people to get what they want. Their husbands, Sam and Jason, " +
                                      "have summered together on the island since childhood, despite lifelong grudges and numerous secrets. Their one single friend, " +
                                      "Rachel Woolf, is looking to meet her match, whether he's the tennis pro-or someone else's husband. But even with plenty to gossip " +
                                      "about, this season starts out as quietly as any other.\r\nUntil a body is discovered, face down off the side of the boardwalk.\r\nStylish, " +
                                      "subversive and darkly comedic, this is a story of what's lurking under the surface of picture-perfect lives in a place where everyone " +
                                      "has something to hide.",
                        Isbn = "9781250887009",
                        PublishedDate = new DateTime(2023, 05, 23),
                        Pages = 272,
                        FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                        AuthorId = new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1675084836i/61884844.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("416289b8-98b7-43ee-97e4-f9b73b866cc3"),
                        Title = "The Road",
                        Description = "A searing, postapocalyptic novel destined to become Cormac McCarthy’s masterpiece.\r\n\r\nA father and his son walk alone through " +
                                      "burned America. Nothing moves in the ravaged landscape save the ash on the wind. It is cold enough to crack stones, and when the " +
                                      "snow falls it is gray. The sky is dark. Their destination is the coast, although they don’t know what, if anything, awaits them " +
                                      "there. They have nothing; just a pistol to defend themselves against the lawless bands that stalk the road, the clothes they are " +
                                      "wearing, a cart of scavenged food—and each other.\r\n\r\nThe Road is the profoundly moving story of a journey. It boldly imagines " +
                                      "a future in which no hope remains, but in which the father and his son, “each the other’s world entire,” are sustained by love. " +
                                      "Awesome in the totality of its vision, it is an unflinching meditation on the worst and the best that we are capable of: ultimate " +
                                      "destructiveness, desperate tenacity, and the tenderness that keeps two people alive in the face of total devastation.",
                        Isbn = "9780307265432",
                        PublishedDate = new DateTime(2006, 10, 02),
                        Pages = 241,
                        FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                        AuthorId = new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1600241424i/6288.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"),
                        Title = "Cherish",
                        Description = "The sensational conclusion to the massive #1 New York Times bestselling series…\r\n\r\nIt’s been over three months since my " +
                                      "friends and I took down Cyrus. Three months where my biggest fear was what paper was due next... But I should have known it " +
                                      "was too good to last. Now everything is falling apart.",
                        Isbn = "9781649373168",
                        PublishedDate = new DateTime(2006, 10, 02),
                        Pages = 592,
                        FormatId = new Guid("292959d7-5b31-49ef-ba4f-e1cf307ab6f2"),
                        AuthorId = new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1642442027i/60136526.jpg"
                    },
                    new Book
                    {
                        BookId = new Guid("f912327d-945d-4cfc-b48b-f18cd4be3ad1"),
                        Title = "Dead Until Dark",
                        Description = "Sookie Stackhouse is just a small-time cocktail waitress in small-town Louisiana. Until the vampire of her " +
                                      "dreams walks into her life-and one of her coworkers checks out....\r\nMaybe having a vampire for a boyfriend " +
                                      "isn't such a bright idea.",
                        Isbn = "9780441008537",
                        PublishedDate = new DateTime(2001, 05, 01),
                        Pages = 292,
                        FormatId = new Guid("2c537441-6150-45b1-bc7f-57050edf5dda"),
                        AuthorId = new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"),
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1468560853i/301082.jpg"
                    }
                );
        }
    }
}
