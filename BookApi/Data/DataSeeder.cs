//using Microsoft.EntityFrameworkCore;
//using BookAPI.Models;
//using System;
//using System.Collections.Generic;

//namespace BookAPI.Data
//{
//    public static class DataSeeder
//    {
//        public static void Seed(ModelBuilder modelBuilder)
//        {
//            // Додавання категорій
//            var categories = new List<Category>
//            {
//                new Category { Id = Guid.NewGuid(), Name = "Фантастика" },
//                new Category { Id = Guid.NewGuid(), Name = "Детектив" },
//                new Category { Id = Guid.NewGuid(), Name = "Наукова література" },
//                new Category { Id = Guid.NewGuid(), Name = "Історія" },
//                new Category { Id = Guid.NewGuid(), Name = "Психологія" },
//                new Category { Id = Guid.NewGuid(), Name = "Філософія" },
//                new Category { Id = Guid.NewGuid(), Name = "Економіка" },
//                new Category { Id = Guid.NewGuid(), Name = "Мистецтво" },
//                new Category { Id = Guid.NewGuid(), Name = "Подорожі" },
//                new Category { Id = Guid.NewGuid(), Name = "Кулінарія" }
//            };
//            modelBuilder.Entity<Category>().HasData(categories);

//            // Додавання підкатегорій
//            var subCategories = new List<SubCategory>
//            {
//                // Підкатегорії для "Фантастика"
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[0].Id, Name = "Космічна фантастика" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[0].Id, Name = "Фентезі" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[0].Id, Name = "Альтернативна історія" },

//                // Підкатегорії для "Детектив"
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[1].Id, Name = "Кримінальний детектив" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[1].Id, Name = "Трилер" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[1].Id, Name = "Поліцейський детектив" },

//                // Підкатегорії для "Наукова література"
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[2].Id, Name = "Фізика" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[2].Id, Name = "Біологія" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[2].Id, Name = "Астрономія" },

//                // Підкатегорії для "Історія"
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[3].Id, Name = "Стародавній світ" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[3].Id, Name = "Середньовіччя" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[3].Id, Name = "Нова історія" },

//                // Підкатегорії для "Психологія"
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[4].Id, Name = "Емоційний інтелект" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[4].Id, Name = "Саморозвиток" },
//                new SubCategory { Id = Guid.NewGuid(), CategoryId = categories[4].Id, Name = "Психологія стосунків" }
//            };
//            modelBuilder.Entity<SubCategory>().HasData(subCategories);

//            // Додавання видавництв
//            var publishers = new List<Publisher>
//            {
//                new Publisher { Id = Guid.NewGuid(), Name = "Видавництво А", Description = "Видавництво, що спеціалізується на науковій літературі." },
//                new Publisher { Id = Guid.NewGuid(), Name = "Видавництво Б", Description = "Видавництво, відоме своїми детективами та трилерами." },
//                new Publisher { Id = Guid.NewGuid(), Name = "Видавництво В", Description = "Видавництво, що видає книги з фантастики та фентезі." },
//                new Publisher { Id = Guid.NewGuid(), Name = "Видавництво Г", Description = "Видавництво, що спеціалізується на історичних книгах." },
//                new Publisher { Id = Guid.NewGuid(), Name = "Видавництво Д", Description = "Видавництво, що видає книги з психології та саморозвитку." }
//            };
//            modelBuilder.Entity<Publisher>().HasData(publishers);

//            // Додавання авторів
//            var authors = new List<Author>
//            {
//                new Author { Id = Guid.NewGuid(), Name = "Джон Сміт", Biography = "Відомий письменник у жанрі фантастики, автор бестселерів." },
//                new Author { Id = Guid.NewGuid(), Name = "Анна Браун", Biography = "Авторка детективних романів, відома своїми захоплюючими сюжетами." },
//                new Author { Id = Guid.NewGuid(), Name = "Марія Коваль", Biography = "Психологиня, авторка книг про емоційний інтелект та стрес." },
//                new Author { Id = Guid.NewGuid(), Name = "Петро Іванов", Biography = "Історик, автор книг про середньовічну Європу." },
//                new Author { Id = Guid.NewGuid(), Name = "Олександр Мельник", Biography = "Філософ, автор книг про етику та мораль." }
//            };
//            modelBuilder.Entity<Author>().HasData(authors);

//            // Додавання книг
//            var books = new List<Book>
//            {
//                new Book
//                {
//                    Id = Guid.NewGuid(),
//                    Title = "Місто зі скла",
//                    AuthorId = authors[0].Id,
//                    PublisherId = publishers[2].Id,
//                    CategoryId = categories[0].Id,
//                    Price = 350.99f,
//                    Language = Language.UKRAINIAN,
//                    Year = new DateTime(2023, 1, 1),
//                    Description = "Фантастичний роман про місто, побудоване зі скла.",
//                    Cover = CoverType.HARDCOVER,
//                    IsAvaliable = true
//                },
//                new Book
//                {
//                    Id = Guid.NewGuid(),
//                    Title = "Тіні минулого",
//                    AuthorId = authors[1].Id,
//                    PublisherId = publishers[1].Id,
//                    CategoryId = categories[1].Id,
//                    Price = 250.99f,
//                    Language = Language.UKRAINIAN,
//                    Year = new DateTime(2022, 1, 1),
//                    Description = "Детективний роман з несподіваною розв'язкою.",
//                    Cover = CoverType.SOFT_COVER,
//                    IsAvaliable = true
//                },
//                new Book
//                {
//                    Id = Guid.NewGuid(),
//                    Title = "Емоційний інтелект",
//                    AuthorId = authors[2].Id,
//                    PublisherId = publishers[4].Id,
//                    CategoryId = categories[4].Id,
//                    Price = 400.99f,
//                    Language = Language.UKRAINIAN,
//                    Year = new DateTime(2021, 1, 1),
//                    Description = "Книга про те, як розвивати емоційний інтелект.",
//                    Cover = CoverType.HARDCOVER,
//                    IsAvaliable = true
//                }
//            };
//            modelBuilder.Entity<Book>().HasData(books);

//            // Додавання зв'язків між книгами та підкатегоріями
//            modelBuilder.Entity("BookSubCategory").HasData(
//                new { BookId = books[0].Id, SubCategoryId = subCategories[0].Id }, // Місто зі скла -> Космічна фантастика
//                new { BookId = books[1].Id, SubCategoryId = subCategories[3].Id }, // Тіні минулого -> Кримінальний детектив
//                new { BookId = books[2].Id, SubCategoryId = subCategories[12].Id } // Емоційний інтелект -> Емоційний інтелект
//            );

//            // Додавання відгуків
//            var feedbacks = new List<Feedback>
//            {
//                new Feedback
//                {
//                    Id = Guid.NewGuid(),
//                    ReviewerName = "Іван",
//                    Comment = "Чудова книга! Захоплюючий сюжет.",
//                    Rating = 5,
//                    Date = DateTime.UtcNow,
//                    IsPurchased = true,
//                    BookId = books[0].Id
//                },
//                new Feedback
//                {
//                    Id = Guid.NewGuid(),
//                    ReviewerName = "Ольга",
//                    Comment = "Цікава книга, але кінець трохи розчарував.",
//                    Rating = 4,
//                    Date = DateTime.UtcNow,
//                    IsPurchased = true,
//                    BookId = books[1].Id
//                },
//                new Feedback
//                {
//                    Id = Guid.NewGuid(),
//                    ReviewerName = "Марія",
//                    Comment = "Дуже корисна книга для саморозвитку.",
//                    Rating = 5,
//                    Date = DateTime.UtcNow,
//                    IsPurchased = true,
//                    BookId = books[2].Id
//                }
//            };
//            modelBuilder.Entity<Feedback>().HasData(feedbacks);
//        }
//    }
//}


using Microsoft.EntityFrameworkCore;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Library.AWS;
using Amazon.Runtime.Internal.Transform;
using Library.Interfaces;

namespace BookAPI.Data
{
    public static class DataSeeder
    {
        public static async Task Seed(ModelBuilder modelBuilder, S3StorageService storageService)
        {
            var imagePaths = new Dictionary<string, string>
            {
                { "Місто зі скла", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJSVPcBg9gdzf2mit382PYIbFkkDbn-JB7jA&s" },
                { "Тіні минулого", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJSVPcBg9gdzf2mit382PYIbFkkDbn-JB7jA&s" },
                { "Емоційний інтелект", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJSVPcBg9gdzf2mit382PYIbFkkDbn-JB7jA&s" }
            };
            var audios = new List<string>
            {
                "https://commondatastorage.googleapis.com/codeskulptor-assets/jump.ogg" ,
            };
            // ============ CATEGORY ============


            var categoryData = new[]
            {
                ("Computer Science Literature"),
                ("Beauty, Image & Style"),
                ("Cooking. Food & Drinks"),
                ("Science & Technology"),
                ("Fiction"),
                ("Business, Finance & Economics"),
                ("Self-Development & Motivation"),
                ("Children's Literature"),
                ("Parenting & Childcare Books"),
                ("Educational Literature & Pedagogy"),
                ("Society. Government & Philosophy"),
                ("History"),
                ("Biographies & Memoirs"),
                ("Health. Fitness & Nutrition"),
                ("Language Learning"),
                ("Art, Culture & Photography"),
                ("Comics & Graphic Novels"),
                ("Law & Jurisprudence"),
                ("Psychology & Relationship"),
                ("Travel & Tourism"),
                ("World Religions"),
                ("Sports & Outdoor Activities"),
                ("Hobbies & Leisure"),
                ("Esotericism & Occultism"),
                ("Medical Literature"),
            };

            var categories = new List<Category>();

            foreach (var name in categoryData)
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
                categories.Add(category);
            }

            modelBuilder.Entity<Category>().HasData(categories);

            // ============ SUBCATEGORY ============

            var subcategoryData = new[]
            {
                // Computer Science Literature
                (categories[0].Id, "Graphics & Design"),
                (categories[0].Id, "Multimedia. Digital photos & videos"),
                (categories[0].Id, "Hardware. Modernization and repair"),
                (categories[0].Id, "Cybersecurity"),
                (categories[0].Id, "DBMS. Databases"),
                (categories[0].Id, "Programming"),
                (categories[0].Id, "Design systems (CAD/CAM)"),
                (categories[0].Id, "Internet & Web-culture"),
                (categories[0].Id, "Videogames"),
                (categories[0].Id, "Portable devices. Smartphones & tablets"),

                // Beauty, Image & Style
                (categories[1].Id, "Cosmetics & Perfumes"),
                (categories[1].Id, "Makeup & Manicure"),
                (categories[1].Id, "Hairstyles. Hair care"),
                (categories[1].Id, "Men Style"),
                (categories[1].Id, "Skincare"),
                (categories[1].Id, "Style. Clothes. Decoration"),
                (categories[1].Id, "Tattoo. Piercing"),
                (categories[1].Id, "Etiquette. Image"),
                
                // Cooking. Food & Drinks
                (categories[2].Id, "Bakery"),
                (categories[2].Id, "Beverages & Wine"),
                (categories[2].Id, "History of cooking & Culinary dictionaries"),
                (categories[2].Id, "Preservation and storage"),
                (categories[2].Id, "Celebrity recipes"),
                (categories[2].Id, "Cooking Methods"),
                (categories[2].Id, "Cooking by ingredients"),
                (categories[2].Id, "Desserts"),
                (categories[2].Id, "Main & Side dishes"),
                (categories[2].Id, "Professional cooking"),

                // Science & Technology
                (categories[3].Id, "Physics"),
                (categories[3].Id, "Chemistry"),
                (categories[3].Id, "Biology"),
                (categories[3].Id, "Astronomy. Space"),
                (categories[3].Id, "Theory of Evolution"),
                (categories[3].Id, "Industry"),
                (categories[3].Id, "Experiments, Tools & Measurements"),
                (categories[3].Id, "Mechanics"),
                (categories[3].Id, "Science"),
                (categories[3].Id, "Math"),
                (categories[3].Id, "Construction & Engineering"),

                // Fiction
                (categories[4].Id, "Detective Books"),
                (categories[4].Id, "Thriller"),
                (categories[4].Id, "Plays"),
                (categories[4].Id, "Prose Books"),
                (categories[4].Id, "Classical Prose"),
                (categories[4].Id, "Books of Aphorisms & Quotes"),
                (categories[4].Id, "Comedy & Satire"),
                (categories[4].Id, "Poetry. Collections of poems"),
                (categories[4].Id, "Modern Prose"),
                (categories[4].Id, "Action"),
                (categories[4].Id, "Fairy tales, Myths & Folklore"),
                (categories[4].Id, "Fantasy & Science Fiction"),
                (categories[4].Id, "Erotic books & literature"),

                // Business, Finance & Economics
                (categories[5].Id, "Accounting, Taxes, Audit"),
                (categories[5].Id, "Business History"),
                (categories[5].Id, "Economics"),
                (categories[5].Id, "Finance. Banking. Investments"),
                (categories[5].Id, "Industries & Professions"),
                (categories[5].Id, "Marketting & Advertisement"),
                (categories[5].Id, "Manegement & Leadership"),
                (categories[5].Id, "Career. Skills & Competencies"),
                (categories[5].Id, "Entrepreneurship. Small business"),

                // Self-Development & Motivation
                (categories[6].Id, "Time Management"),
                (categories[6].Id, "Antistress"),
                (categories[6].Id, "Fears & Phobias"),
                (categories[6].Id, "Death"),
                (categories[6].Id, "Creativity & Ingenuity"),
                (categories[6].Id, "Relationship"),
                (categories[6].Id, "Motivation"),
                (categories[6].Id, "Memory & Sight Improvement"),
                (categories[6].Id, "Goals & Dreams"),
                (categories[6].Id, "Dignity & Self respect"),
                (categories[6].Id, "Success"),
                (categories[6].Id, "Career"),

                // Children's Literature
                (categories[7].Id, "Children Adventure Books"),
                (categories[7].Id, "Art & Hobbies for Children"),
                (categories[7].Id, "Horror stories for Children"),
                (categories[7].Id, "Encyclopedias for Children"),
                (categories[7].Id, "Comics & Graphical novels for Children"),
                (categories[7].Id, "Computers & Technologies for Children"),
                (categories[7].Id, "Fairy tales & Myths"),
                (categories[7].Id, "Educational Literature for Children"),
                (categories[7].Id, "Art & Music for Children"),
                (categories[7].Id, "Books about Nature for Children"),

                // Parenting & Childcare Books
                (categories[8].Id, "Baby Album"),
                (categories[8].Id, "Children's Leisure & Creativity"),
                (categories[8].Id, "Discipline & Pedagogy. Psychology for parents"),
                (categories[8].Id, "Child's name"),
                (categories[8].Id, "Pregnancy & childbirth"),
                (categories[8].Id, "Early development"),

                // Educational Literature & Pedagogy
                (categories[9].Id, "Books for Preschoolers"),
                (categories[9].Id, "Books for Scholars & Applicants"),
                (categories[9].Id, "Books for Scholars & Applicants"),
                (categories[9].Id, "Books for Students & Graduates"),
                (categories[9].Id, "Books for Arts & Music schools"),
                (categories[9].Id, "Workbooks"),

                // Society. Government & Philosophy
                (categories[10].Id, "Philosophy"),
                (categories[10].Id, "Politics. State"),
                (categories[10].Id, "Sociology"),
                (categories[10].Id, "Gender Research. Feminism"),
                (categories[10].Id, "Military affairs. Weapons & Special services"),
                (categories[10].Id, "Literary Studies. Myths & Folklore"),
                (categories[10].Id, "Statistics & Demographics"),
                (categories[10].Id, "Rhetoric & Oratory"),
                (categories[10].Id, "Linguistics. Philological sciences"),
                (categories[10].Id, "Media. Book business"),
                
                // History
                (categories[11].Id, "Africa"),
                (categories[11].Id, "South America"),
                (categories[11].Id, "North America"),
                (categories[11].Id, "Asia"),
                (categories[11].Id, "Australia & Oceania"),
                (categories[11].Id, "Europe"),
                (categories[11].Id, "Middle Ages"),
                (categories[11].Id, "Ukraine"),
                (categories[11].Id, "russia"),
                (categories[11].Id, "Middle East"),
                (categories[11].Id, "Ancient Civilizations. Primitive Society"),
                (categories[11].Id, "World History"),
                (categories[11].Id, "Archeology"),

                // Biographies & Memoirs
                (categories[12].Id, "Architectors, Artists, Photographers"),
                (categories[12].Id, "Business Sharks, Entrepreneurs & Economists"),
                (categories[12].Id, "Celebrities of Cinema, Television & Music"),
                (categories[12].Id, "Political Figures"),
                (categories[12].Id, "Religious Figures"),
                (categories[12].Id, "Historical Figures"),
                (categories[12].Id, "Scientists, Mathematicians & Technicians"),
                (categories[12].Id, "Sportmen"),
                (categories[12].Id, "War & Espionage"),
                (categories[12].Id, "Writers, Poets & Screenwriters"),
                (categories[12].Id, "World War II. Holocaust"),

                // Health. Fitness & Nutrition
                (categories[13].Id, "Bad Habits"),
                (categories[13].Id, "Aging & Longevity"),
                (categories[13].Id, "Alternative Medicine"),
                (categories[13].Id, "Diets"),
                (categories[13].Id, "Diets"),
                (categories[13].Id, "Fitness & Exercise"),
                (categories[13].Id, "Safety. First Aid"),
                (categories[13].Id, "Psychology & Mental Health"),
                (categories[13].Id, "Men's Health"),
                (categories[13].Id, "Women's Health"),

                // Language Learning
                (categories[14].Id, "Home Reading"),
                (categories[14].Id, "Phrasebooks"),
                (categories[14].Id, "Dictionaries"),
                (categories[14].Id, "Theory & History of Language"),
                (categories[14].Id, "Self-teaching"),
                (categories[14].Id, "Textbooks & Manuals"),

                // Art, Culture & Photography
                (categories[15].Id, "Architecture"),
                (categories[15].Id, "Business in Art"),
                (categories[15].Id, "Museums & Exhibitions"),
                (categories[15].Id, "Design & Decoration"),
                (categories[15].Id, "Collections"),
                (categories[15].Id, "Arts"),
                (categories[15].Id, "Fashion"),
                (categories[15].Id, "Graphical Design"),
                (categories[15].Id, "Music"),
                (categories[15].Id, "Cinema"),
                (categories[15].Id, "Media"),
                (categories[15].Id, "Other types of Art"),
                (categories[15].Id, "Dance. Ballet & Choreography"),
                (categories[15].Id, "Theatre"),

                // Comics & Graphic Novels
                (categories[16].Id, "Manga"),
                (categories[16].Id, "Comics"),
                (categories[16].Id, "Graphical Novels"),
                (categories[16].Id, "Super Heroes"),

                // Law & Jurisprudence
                (categories[17].Id, "History & Theory of law"),
                (categories[17].Id, "Regulatory Legal Acts"),
                (categories[17].Id, "Justice Bodies"),
                (categories[17].Id, "Forensic science. Crimonology & Forensic examination"),
                (categories[17].Id, "Administrative law"),
                (categories[17].Id, "Civil law"),
                (categories[17].Id, "Land & Enviromental law"),
                (categories[17].Id, "Constitutional & Public Law"),
                (categories[17].Id, "Internatinal Law"),
                (categories[17].Id, "Financial law"),

                // Psychology & Relationship
                (categories[18].Id, "Children Psychology"),
                (categories[18].Id, "Preschoolers & scholars psychology"),
                (categories[18].Id, "Teenager Psychology"),
                (categories[18].Id, "Foundations of Age Psychology"),
                (categories[18].Id, "Clasic Psychology"),
                (categories[18].Id, "Personality Psychology"),
                (categories[18].Id, "Psychoanalysis"),
                (categories[18].Id, "Psychotherapy. Hypnosis"),
                (categories[18].Id, "Tests & Testing"),
                (categories[18].Id, "Psychology. General Works"),
                (categories[18].Id, "History of Psychology"),
                (categories[18].Id, "Mass Psychology & Socionics"),

                // Travel & Tourism
                (categories[19].Id, "Adventure Tourism"),
                (categories[19].Id, "Photo albums"),
                (categories[19].Id, "Travelers notebooks"),
                (categories[19].Id, "Africa"),
                (categories[19].Id, "Asia"),
                (categories[19].Id, "Australia & Oceania"),
                (categories[19].Id, "South America"),
                (categories[19].Id, "North America"),
                (categories[19].Id, "Central America"),
                (categories[19].Id, "Europe"),
                (categories[19].Id, "Middle East"),

                // World Religions
                (categories[20].Id, "Christianity. Bible"),
                (categories[20].Id, "Atheism"),
                (categories[20].Id, "Buddhism"),
                (categories[20].Id, "Hinduism"),
                (categories[20].Id, "Ancient religions"),
                (categories[20].Id, "Judaism"),
                (categories[20].Id, "Islam"),
                (categories[20].Id, "Taoism, Confucianism & Shintoism"),
                (categories[20].Id, "Religious Studies. History of Religion"),
                (categories[20].Id, "Modern Religious Movements"),

                // Sports & Outdoor Activities
                (categories[21].Id, "History of Sports"),
                (categories[21].Id, "General Physical Education"),
                (categories[21].Id, "General Sports Work"),
                (categories[21].Id, "Martial Arts"),
                (categories[21].Id, "Basketball"),
                (categories[21].Id, "Run"),
                (categories[21].Id, "Hiking"),
                (categories[21].Id, "Hockey"),
                (categories[21].Id, "Sport Hunting & Fishing"),
                (categories[21].Id, "Individual Sports"),
                (categories[21].Id, "Other Team Sports"),

                // Hobbies & Leisure
                (categories[22].Id, "Collecting"),
                (categories[22].Id, "Handicrafts & Creativity"),
                (categories[22].Id, "Pets Care & Training"),
                (categories[22].Id, "Construction & Renovation. Design"),
                (categories[22].Id, "Entertainment, Holidays, Games"),
                (categories[22].Id, "Love & Erotica"),
                (categories[22].Id, "Wedding"),
                (categories[22].Id, "Hunting"),
                (categories[22].Id, "Fishing"),
                (categories[22].Id, "Mushrooms"),
                (categories[22].Id, "Gardening"),

                // Esotericism & Occultism
                (categories[23].Id, "Astrology, Horoscope, Lunar Rhythms"),
                (categories[23].Id, "Fortune Telling. Tarot Cards"),
                (categories[23].Id, "Palmistry"),
                (categories[23].Id, "Numerology"),
                (categories[23].Id, "Magic & Spells. Prophecies"),
                (categories[23].Id, "Dream Interpretations"),
                (categories[23].Id, "Parapsychology"),
                (categories[23].Id, "Spiritism"),
                (categories[23].Id, "Feng Shui"),
                (categories[23].Id, "Secret organizations. Masons. Templars"),
                (categories[23].Id, "Practical Esoteric"),

                // Medical Literature
                (categories[24].Id, "Veterinary medicine"),
                (categories[24].Id, "Internal diseases"),
                (categories[24].Id, "Infectious diseases"),
                (categories[24].Id, "Skin & Venereal diseases"),
                (categories[24].Id, "Gynecology. Obstetrics"),
                (categories[24].Id, "Diagnostics. Methods and types"),
                (categories[24].Id, "History of Medicine"),
                (categories[24].Id, "Narcology"),
                (categories[24].Id, "Ophthalmology"),
                (categories[24].Id, "Otorhinolaryngology"),
                (categories[24].Id, "Oncology"),
                (categories[24].Id, "Pediatrics"),
                (categories[24].Id, "Emergency care. Therapies"),
            };


            var subCategories = new List<SubCategory>(); 
            
            foreach (var (categoryId, name) in subcategoryData)
            {
                var subCategory = new SubCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    CategoryId = categoryId,
                };
                subCategories.Add(subCategory);
            }

            modelBuilder.Entity<SubCategory>().HasData(subCategories);

            // ============ Publishers ============

            var publisherData = new[] 
            {
                ("BIMBA","BIMBA specializes in publishing Eastern fiction and Japanese manga in Ukraine."),
                ("BookChef","BOOKCHEF - shapes personality through quality literature and language - the main sources of our national unity and the development of our mentality and culture. These principles are the basis of the company's corporate social responsibility strategy."),
                ("Komubook","The project is aimed primarily at publishing works of art by famous foreign authors that should have been published in Ukrainian long ago, but for one reason or another, none of the traditional Ukrainian publishers have done so or previous editions have long been sold out."),
                ("A-ba-ba-ha-la-ma-ha","the first private children's publishing house of independent Ukraine, founded in Kyiv in 1992. Since 2008, it has been publishing books for all age groups."),
                ("Discursus","The publishing house specializes in contemporary fiction and non-fiction."),
                ("ArtHuss","To develop a creative professional community, to talk about complex things in an easy way, to broaden readers' worldviews, and to fill life with beauty and aesthetics"),
                ("Astrolabe","The publishing house publishes literature of various genres, namely: fiction, poetry, books on philosophy, psychology, history, religion, political science, law, economics, art, etc."),
                ("Vivat","The main areas of activity of the publishing house are non-fiction, fiction, children's and teenage literature."),
                ("Vydavnytstvo","The publishing house \"Vydavnytsvo\" is engaged in the search and printing of literature that highlights complex issues that, in the opinion of its team, are not reflected qualitatively in the assortment of Ukrainian bookstores: death, teenage adulthood, self-awareness"),
                ("Academvydav","It publishes textbooks, study guides for students, secondary school students, as well as scientific, reference and encyclopedic books. The main disciplines are literary studies, linguistics, philosophy, logic, ethics, religious studies, political science, psychology, sociology, history, pedagogy, business communications, economics, management, geography, ecology, mathematics, etc."),
                ("Academia","publishes textbooks, manuals for universities and secondary schools, scientific, reference and encyclopedic, and fiction literature."),
                ("Veselka","Ukrainian publishing house of literature for children."),
                ("Henesa","One of the largest publishing houses in modern Ukraine. The main area of ​​activity is educational book publishing. The director of the publishing house is Mykola Vasylovych Chayun."),
                ("Aston","Ukrainian publishing house located in Ternopil. Specializes in publishing textbooks for secondary educational institutions throughout Ukraine."),
                ("AMSA","Ukrainian publishing house specializing in the production of children's fiction, school and educational literature."),
            };

            var publishers = new List<Publisher>();

            foreach (var (name, desciption) in publisherData)
            {
                var publisher = new Publisher()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = desciption
                };
                publishers.Add(publisher);
            }

            modelBuilder.Entity<Publisher>().HasData(publishers);

            // Додавання авторів
            var authors = new List<Author>
            {
                new Author { Id = Guid.NewGuid(), Name = "Джон Сміт", Biography = "Відомий письменник у жанрі фантастики, автор бестселерів." },
                new Author { Id = Guid.NewGuid(), Name = "Анна Браун", Biography = "Авторка детективних романів, відома своїми захоплюючими сюжетами." },
                new Author { Id = Guid.NewGuid(), Name = "Марія Коваль", Biography = "Психологиня, авторка книг про емоційний інтелект та стрес." },
                new Author { Id = Guid.NewGuid(), Name = "Петро Іванов", Biography = "Історик, автор книг про середньовічну Європу." },
                new Author { Id = Guid.NewGuid(), Name = "Олександр Мельник", Biography = "Філософ, автор книг про етику та мораль." }
            };
            modelBuilder.Entity<Author>().HasData(authors);
            var bookIds = new List<Guid>
            {
                Guid.NewGuid(), // Id для "Місто зі скла"
                Guid.NewGuid(), // Id для "Тіні минулого"
                Guid.NewGuid()  // Id для "Емоційний інтелект"
            };
            var books = new List<Book>
            {
                new Book
                {
                    Id = bookIds[0],
                    Title = "Місто зі скла",
                    AuthorId = authors[0].Id,
                    PublisherId = publishers[2].Id,
                    CategoryId = categories[0].Id,
                    Price = 350.99f,
                    Language = Language.UKRAINIAN,
                    Year = new DateTime(2023, 1, 1),
                    Description = "Фантастичний роман про місто, побудоване зі скла.",
                    Cover = CoverType.HARDCOVER,
                    IsAvaliable = true,
                    AudioFileUrl = await UploadAudioAsync(storageService, audios[0], bookIds[0]), 
                    ImageUrl = await UploadImageAsync(storageService, imagePaths["Місто зі скла"], bookIds[0])
                },
                new Book
                {
                    Id = bookIds[1],
                    Title = "Тіні минулого",
                    AuthorId = authors[1].Id,
                    PublisherId = publishers[1].Id,
                    CategoryId = categories[1].Id,
                    Price = 250.99f,
                    Language = Language.UKRAINIAN,
                    Year = new DateTime(2022, 1, 1),
                    Description = "Детективний роман з несподіваною розв'язкою.",
                    Cover = CoverType.SOFT_COVER,
                    IsAvaliable = true,
                    ImageUrl = await UploadImageAsync(storageService, imagePaths["Тіні минулого"], bookIds[1]) 
                },
                new Book
                {
                    Id = bookIds[2], 
                    Title = "Емоційний інтелект",
                    AuthorId = authors[2].Id,
                    PublisherId = publishers[4].Id,
                    CategoryId = categories[4].Id,
                    Price = 400.99f,
                    Language = Language.UKRAINIAN,
                    Year = new DateTime(2021, 1, 1),
                    Description = "Книга про те, як розвивати емоційний інтелект.",
                    Cover = CoverType.HARDCOVER,
                    IsAvaliable = true,
                    ImageUrl = await UploadImageAsync(storageService, imagePaths["Емоційний інтелект"], bookIds[2]) 
                }
            };
            modelBuilder.Entity<Book>().HasData(books);

            modelBuilder.Entity("BookSubCategory").HasData(
                new { BookId = books[0].Id, SubCategoryId = subCategories[0].Id }, 
                new { BookId = books[1].Id, SubCategoryId = subCategories[3].Id }, 
                new { BookId = books[2].Id, SubCategoryId = subCategories[12].Id }
            );

            // Додавання відгуків
            var feedbacks = new List<Feedback>
            {
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ReviewerName = "Іван",
                    Comment = "Чудова книга! Захоплюючий сюжет.",
                    Rating = 5,
                    Date = DateTime.UtcNow,
                    IsPurchased = true,
                    BookId = books[0].Id
                },
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ReviewerName = "Ольга",
                    Comment = "Цікава книга, але кінець трохи розчарував.",
                    Rating = 4,
                    Date = DateTime.UtcNow,
                    IsPurchased = true,
                    BookId = books[1].Id
                },
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ReviewerName = "Марія",
                    Comment = "Дуже корисна книга для саморозвитку.",
                    Rating = 5,
                    Date = DateTime.UtcNow,
                    IsPurchased = true,
                    BookId = books[2].Id
                }
            };


            modelBuilder.Entity<Feedback>().HasData(feedbacks);
        }



        private static async Task<string> UploadImageAsync(S3StorageService storageService, string imageUrl, Guid bookId)
        {
            using var httpClient = new HttpClient();

            try
            {
                // Завантажуємо зображення з інтернету
                var response = await httpClient.GetAsync(imageUrl);

                // Перевіряємо, чи успішно завантажено
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to download image from {imageUrl}. Status code: {response.StatusCode}");
                }

                // Отримуємо потік даних зображення
                var stream = await response.Content.ReadAsStreamAsync();

                // Створюємо об'єкт IFormFile для завантаження на S3
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(imageUrl))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = response.Content.Headers.ContentType?.ToString() ?? "image/jpeg"
                };

                // Завантажуємо на S3
                return await storageService.UploadAsync(file, bookId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to upload image from URL: {imageUrl}", ex);
            }
        }

        public static async Task<string> UploadAudioAsync(IS3StorageService storageService, string audioUrl, Guid bookId)
        {
            using var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(audioUrl);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to download audio from {audioUrl}. Status code: {response.StatusCode}");
                }

                var stream = await response.Content.ReadAsStreamAsync();

                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(audioUrl))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = response.Content.Headers.ContentType?.ToString() ?? "audio/mpeg"
                };

                return await storageService.UploadAsync(file, bookId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to upload audio from URL: {audioUrl}", ex);
            }
        }

    }
}