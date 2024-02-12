using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.DbContexts.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                    new Author()
                    {
                        AuthorId = new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                        FirstName = "Jaclyn",
                        LastName = "Goldis",
                        Biography = "Jaclyn Goldis is a graduate of the University of Michigan, Ann Arbor, and NYU Law. " +
                                    "She practiced estate planning law at a large Chicago firm for seven years before leaving her job " +
                                    "to travel the world and write novels. Follow her on Instagram and Twitter @jaclyngoldis.",
                        DateOfBirth = new DateTime(1979, 06, 16),
                        CountryOfBirth = "United States",
                        PlaceOfBirth = string.Empty,
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                        FirstName = "Anne",
                        LastName = "Rice",
                        Biography = "Anne Rice (born Howard Allen Frances O'Brien) was a best-selling American author of gothic, " +
                                    "supernatural, historical, erotica, and later religious themed books. Best known for The Vampire Chronicles, " +
                                    "her prevailing thematic focus is on love, death, immortality, existentialism, and the human condition. " +
                                    "She was married to poet Stan Rice for 41 years until his death in 2002. Her books have sold nearly 100 million " +
                                    "copies, making her one of the most widely read authors in modern history.\r\n\r\nAnne Rice passed on December 11, " +
                                    "2021 due to complications from a stroke. She was eighty years old at the time of her death.",
                        DateOfBirth = new DateTime(1941, 10, 04),
                        CountryOfBirth = "United States",
                        PlaceOfBirth = "New Orleans, Louisiana",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                        FirstName = "Cormac",
                        LastName = "McCarthy",
                        Biography = "Cormac McCarthy was an American novelist and playwright. He had written twelve novels in the Southern Gothic, " +
                                    "western, and post-apocalyptic genres and had also written plays and screenplays. He received the Pulitzer Prize " +
                                    "in 2007 for The Road, and his 2005 novel No Country for Old Men was adapted as a 2007 film of the same name, " +
                                    "which won four Academy Awards, including Best Picture. His earlier Blood Meridian (1985) was among Time Magazine's " +
                                    "poll of 100 best English-language books published between 1925 and 2005, and he placed joint runner-up for a similar " +
                                    "title in a poll taken in 2006 by The New York Times of the best American fiction published in the last 25 years. " +
                                    "Literary critic Harold Bloom named him one of the four major American novelists of his time, along with Thomas Pynchon, " +
                                    "Don DeLillo, and Philip Roth. He is frequently compared by modern reviewers to William Faulkner. In 2009, Cormac McCarthy " +
                                    "won the PEN/Saul Bellow Award, a lifetime achievement award given by the PEN American Center.",
                        DateOfBirth = new DateTime(1933, 06, 20),
                        CountryOfBirth = "United States",
                        PlaceOfBirth = "Providence, Rhode Island",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                        FirstName = "Yann",
                        LastName = "Martel",
                        Biography = "Yann Martel is the author of Life of Pi, the #1 international bestseller and winner of the 2002 Man Booker " +
                                    "(among many other prizes). He is also the award-winning author of The Facts Behind the Helsinki Roccamatios " +
                                    "(winner of the Journey Prize), Self, Beatrice & Virgil, and 101 Letters to a Prime Minister. Born in Spain in 1963, " +
                                    "Martel studied philosophy at Trent University, worked at odd jobs—tree planter, dishwasher, security guard—and traveled " +
                                    "widely before turning to writing. He lives in Saskatoon, Canada, with the writer Alice Kuipers and their four children.",
                        DateOfBirth = new DateTime(1963, 06, 25),
                        CountryOfBirth = "Spain",
                        PlaceOfBirth = "Salamanca",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                        FirstName = "Gillian",
                        LastName = "McAllister",
                        CountryOfBirth = "United Kingdom",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                        FirstName = "Emma",
                        LastName = "Rosenblum",
                        Biography = "Emma Rosenblum is chief content officer at Bustle Digital Group, overseeing content and strategy for BDG’s lifestyle, " +
                                    "parenting, and culture & innovation portfolios, including Bustle, Elite Daily, Romper, NYLON, The Zoe Report, Romper, " +
                                    "Scary Mommy, Fatherly, The Dad, Gawker, Inverse, and Mic. Prior to BDG, Emma served as the executive editor of ELLE. " +
                                    "Previously Rosenblum was a senior editor at Bloomberg Businessweek, and before that a senior editor at Glamour. " +
                                    "She began her career at New York magazine. She lives in New York City, with her husband and two sons. " +
                                    "Bad Summer People is her first novel.",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"),
                        FirstName = "Tracy",
                        LastName = "Wolff",
                        Biography = "New York Times and USA Today bestselling author Tracy Wolff is a lover of vampires, dragons, and all things that go bump " +
                                    "in the night. A onetime English professor, she now devotes all her time to writing dark and romantic stories with tortured " +
                                    "heroes and kick-butt heroines. She has written all her sixty-plus novels from her home in Austin, Texas, which she shares " +
                                    "with her family.",
                        DateCreated = DateTime.Now,
                    },

                    new Author()
                    {
                        AuthorId = new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"),
                        FirstName = "Charlaine",
                        LastName = "Harris",
                        Biography = "Charlaine Harris has been a published novelist for over thirty-five years. A native of the Mississippi Delta, she grew up in " +
                                    "the middle of a cotton field. Charlaine lives in Texas now, and all of her children and grandchildren are within easy driving " +
                                    "distance.\r\n\r\nThough her early output consisted largely of ghost stories, by the time she hit college (Rhodes, in Memphis) " +
                                    "Charlaine was writing poetry and plays. After holding down some low-level jobs, her husband Hal gave her the opportunity to stay " +
                                    "home and write. The resulting two stand-alones were published by Houghton Mifflin. After a child-producing sabbatical, Charlaine " +
                                    "latched on to the trend of series, and soon had her own traditional mystery books about a Georgia librarian, Aurora Teagarden. " +
                                    "Her first Teagarden, Real Murders, garnered an Agatha nomination.\r\n\r\nSoon Charlaine was looking for another challenge, and " +
                                    "the result was the much darker Lily Bard series. The books, set in Shakespeare, Arkansas, feature a heroine who has survived a " +
                                    "terrible attack and is learning to live with its consequences.\r\n\r\nWhen Charlaine began to realize that neither of those series " +
                                    "was ever going to set the literary world on fire, she regrouped and decided to write the book she’d always wanted to write. " +
                                    "Not a traditional mystery, nor yet pure science fiction or romance, Dead Until Dark broke genre boundaries to appeal to a wide audience " +
                                    "of people who simply enjoy a good adventure. Each subsequent book about Sookie Stackhouse, telepathic Louisiana barmaid and friend to vampires, " +
                                    "werewolves, and various other odd creatures, was very successful in many languages.\r\n\r\nThe Harper Connelly books were written concurrently " +
                                    "with the Sookie novels.\r\n\r\nFollowing the end of Sookie's recorded adventures, Charlaine wrote the \"Midnight, Texas\" books, which have " +
                                    "become a television series, also. The Aurora Teagarden books have been adapted by Hallmark Movie & Mystery.\r\n\r\nCharlaine is a member of " +
                                    "many professional organizations, an Episcopalian, and currently the lucky houseparent to two rescue dogs. She lives on a cliff overlooking the Brazos River.",
                        CountryOfBirth = "United States",
                        PlaceOfBirth = "Tunica, Mississippi",
                        DateCreated = DateTime.Now,
                    }
                );
        }
    }
}
