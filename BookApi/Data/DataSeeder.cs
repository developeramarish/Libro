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
            var audios = new List<string>
            {
                "https://commondatastorage.googleapis.com/codeskulptor-assets/jump.ogg" ,
            };

            var random = new Random();

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

            // ============ PUBLISHER ============

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

            // ============ AUTHOR ============ 
            // WILL BE FILLED AS THE BOOKS ARE FILLED
            var authorData = new[]
            {
                (Guid.NewGuid(), "Ellen Lupton","Ellen Lupton is a designer, writer, and educator. Her books include Design Is Storytelling, Graphic Design Thinking, Health Design Thinking, and Extra Bold: A Feminist, Inclusive, Anti-Racist, Nonbinary Field Guide for Graphic Designers.", new DateTime(1963, 1, 1)),
                (Guid.NewGuid(), "Adrian Shaughnessy","Adrian Shaughnessy is a graphic designer, writer, and senior tutor at the Royal College of Art, London.", new DateTime(1953, 6, 17)),
                (Guid.NewGuid(), "Robin Williams","Robin Patricia Williams (born October 9, 1953) is an American educator who has authored many computer-related books, as well as the book Sweet Swan of Avon: Did a Woman Write Shakespeare?. Among her computer books are manuals of style The Mac is Not a Typewriter and numerous manuals for various macOS operating systems and applications, including The Little Mac Book.", new DateTime(1953,10,9)),
                (Guid.NewGuid(), "Josef Müller-Brockmann","Josef Müller-Brockmann was a Swiss graphic designer, author, and educator, he was a Principal at Muller-Brockmann & Co. design firm.",new DateTime(1914, 5, 9)),
                (Guid.NewGuid(), "David Airey","Designer of enduring logos and visual identities, David Airey runs an independent graphic design studio in Northern Ireland, collaborating with clients worldwide to grow their businesses through distinctive, meaningful, and emotive design.", new DateTime(1979, 1, 1)),
                (Guid.NewGuid(), "Robert Bringhurst","Robert Bringhurst OC is a Canadian poet, typographer and author. He has translated substantial works from Haida and Navajo and from classical Greek and Arabic", new DateTime(1946, 10, 16)),
                (Guid.NewGuid(), "Alina Wheeler","Alina Wheeler engages enterprises in a dynamic process to build their brands and embrace best practices. Wheeler inspires the whole branding team to seize every opportunity to design compelling customer experiences at every touchpoint.", new DateTime(2023,12,5)),
                (Guid.NewGuid(), "Alan Fletcher","Alan Gerard Fletcher (27 September 1931 – 21 September 2006) was a British graphic designer. In his obituary, he was described by The Daily Telegraph as \"the most highly regarded graphic designer of his generation, and probably one of the most prolific\".", new DateTime(1957, 3, 30)),
                (Guid.NewGuid(), "","", new DateTime()),
            };


            var authors = new List<Author>();

            foreach(var (id, name, biography, dateOfBirth) in authorData)
            {
                var author = new Author()
                {
                    Id = id,
                    Name = name,
                    Biography = biography,
                    DateOfBirth = dateOfBirth
                };
                authors.Add(author);
            }
            modelBuilder.Entity<Author>().HasData(authors);

            // ============ BOOK ============ 
            // (id, title, authorId, publisherId, categoryId, price, language, year, descriptionm cover,  true, imageUrl)
   

            var bookData = new[]
            {
                // Graphics & Design
                new[]{
                (Guid.NewGuid(),"Graphic Design: The New Basics", authors[0].Id, publishers[random.Next(publishers.Count)].Id,categories[0].Id, 350.00f, Language.ENGLISH, new DateTime(2015, 7, 14), "Ellen Lupton and Jennifer Cole Phillips's celebrated introduction to graphic design, available in a revised and updated edition.", CoverType.SOFT_COVER, true, "https://m.media-amazon.com/images/I/71D97M+c59L._SL1200_.jpg"),
                (Guid.NewGuid(),"Thinking with Type", authors[0].Id,publishers[random.Next(publishers.Count)].Id, categories[0].Id, 250.99f, Language.ENGLISH, new DateTime(2010, 11,3), "The best-selling Thinking with Type in a revised and expanded second edition:Thinking with Type is the definitive guide to using typography in visual communication. Ellen Lupton provides clear and focused guidance on how letters, words, and paragraphs should be aligned, spaced, ordered, and shaped.", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/71ZO6EyOZ3L._SL1500_.jpg"),
                (Guid.NewGuid(),"How to be a Graphic Designer Without Losing Your Soul", authors[1].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 350.00f, Language.ENGLISH, new DateTime(2010, 8, 30), "Graphic designers constantly complain that there is no career manual to guide them through the profession. Adrian Shaughnessy draws on a wealth of experience to provide just such a handbook. Aimed at the independent-minded, it addresses the concerns of young designers who want to earn a living by doing expressive and meaningful work and avoid becoming a hired drone working on soulless projects. It offers straight-talking advice on how to establish your design career and suggestions - that you won’t have been taught at college - for running a successful business. ", CoverType.SOFT_COVER, true, "https://m.media-amazon.com/images/I/81PLuztRoPS._SL1500_.jpg"),
                (Guid.NewGuid(),"Non-Designer's Design Book", authors[2].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 375.49f, Language.ENGLISH, new DateTime(2014, 11, 19), "For nearly 20 years, designers and non-designers alike have been introduced to the fundamental principles of great design by author Robin Williams. Through her straightforward and light-hearted style, Robin has taught hundreds of thousands of people how to make their designs look professional using four surprisingly simple principles.", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/81PB4SmcLVL._SL1500_.jpg"),
                (Guid.NewGuid(),"Grid systems in graphic design", authors[3].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 150.99f, Language.GERMAN, new DateTime(1996, 10, 1), "A grid system is a rigid framework that is supposed to help graphic designers in the meaningful, logical and consistent organization of information on a page. It is an established tool that is used by print and web designers to create well-structured, balanced designs.", CoverType.SOFT_COVER, true, "https://m.media-amazon.com/images/I/71xVgz2a-qL._SL1500_.jpg"),
                (Guid.NewGuid(),"Logo Design Love", authors[4].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 299.49f, Language.ENGLISH, new DateTime(2014, 8, 20), "Completely updated and expanded, the second edition of David Airey's Logo Design Love contains more of just about everything that made the first edition so great: more case studies, more sketches, more logos, more tips for working with clients, more insider stories, and more practical information for getting the job and getting it done right.", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/5176ZejmyrL._SL1360_.jpg"),
                (Guid.NewGuid(),"Identity Designed", authors[4].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 200.00f, Language.ENGLISH, new DateTime(2019, 1, 22), "Ideal for students of design, independent designers, and entrepreneurs who want to expand their understanding of effective design in business, Identity Designed is the definitive guide to visual branding.\r\n", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/615DcJOIL-L._SL1500_.jpg"),
                (Guid.NewGuid(),"The Elements of Typographic Style", publishers[random.Next(publishers.Count)].Id, authors[5].Id, categories[0].Id, 350.00f, Language.ENGLISH, new DateTime(2004, 9, 27), "Renowned typographer and poet Robert Bringhurst brings clarity to the art of typography with this masterful style guide. Combining practical, theoretical, and historical, this book is a must for graphic artists, editors, or anyone working with the printed page using digital or traditional methods.", CoverType.SOFT_COVER, true, "https://m.media-amazon.com/images/I/51I-bty6iSL._SL1113_.jpg"),
                (Guid.NewGuid(),"Designing Brand Identity", authors[6].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 449.99f, Language.ENGLISH, new DateTime(2024, 3, 6), "It’s harder than ever to be the brand of choice―in many markets, technology has lowered barriers to entry, increasing competition. Everything is digital and the need for fresh content is relentless. Decisions that used to be straightforward are now complicated by rapid advances in technology, the pandemic, political polarization, and numerous social and cultural changes. ", CoverType.SOFT_COVER, true, "https://m.media-amazon.com/images/I/91vZAsZTQZL._SL1500_.jpg"),
                (Guid.NewGuid(),"Design De Identidade Da Marca", authors[6].Id,publishers[random.Next(publishers.Count)].Id,  categories[0].Id, 350.00f, Language.OTHER, new DateTime(2024, 3, 6), "", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/81Qfj7i31HL._SL1500_.jpg"),
                (Guid.NewGuid(),"The Art of Looking Sideways", authors[7].Id, publishers[random.Next(publishers.Count)].Id, categories[0].Id, 350.00f, Language.ENGLISH, new DateTime(2001, 8, 20), "The Art of Looking Sideways is a primer in visual intelligence, an exploration of the workings of the eye, the hand, the brain and the imagination. It is an inexhaustible mine of anecdotes, quotations, images, curious facts and useless information, oddities, serious science, jokes and memories, all concerned with the interplay between the verbal and the visual, and the limitless resources of the human mind.", CoverType.HARDCOVER, true, "https://m.media-amazon.com/images/I/81NNjU3Kh+L._SL1500_.jpg"),
                }
            };

            var books = new List<Book>();
            var subcategoryBookData = new Dictionary<Guid, Guid>();
            int subcategoryId = 0;
            foreach (var subcategoryBooks in bookData)
            {
                foreach (var (id,title,authorId,publisherId, categoryId, price, language, year, description, cover, isAvailable, imageUrl) in subcategoryBooks)
                {
                    var book = new Book()
                    {
                        Id = id,
                        Title = title,
                        AuthorId = authorId,
                        PublisherId = publisherId,
                        CategoryId = categoryId,
                        Price = price,
                        Language = language,
                        Year = year,
                        Description = description,
                        Cover = cover,
                        IsAvaliable = isAvailable,
                        ImageUrl = await UploadImageAsync(storageService, imageUrl, id),
                    };

                    subcategoryBookData.Add(id, subCategories[subcategoryId].Id);
                }
                subcategoryId++;
            }
            modelBuilder.Entity<Book>().HasData(books);

            // ============ BOOK-SUBCATEGORY ============ 

            modelBuilder.Entity("BookSubCategory").HasData(
                subcategoryBookData.Select(kvp => new {BookId = kvp.Key, SubCategoryId = kvp.Value}).ToArray()    
            );

            // ============ FEEDBACK ============ 

            var feedbackNames = new List<string>
            {
                "Ivan",
                "Mykola",
                "Yaroslav",
                "Yaroslava",
                "Iryna",
                "Viktor",
                "Volodymyr",
                "Andrii",
                "Maria",
                "Andriana",
                "Viktoria",
                "Yura",
                "Bohdan",
                "Vasiliy",
                "Anatoliy",
                "Vyacheslav",
                "Nazariy",
            };

            var feedbackCombination = new[]
            {
                    ("Terrible experience, would not recommend.", 1),
                    ("Not great, had several issues.", 2),
                    ("Average experience, could be better.", 3),
                    ("Good service, but there's room for improvement.", 4),
                    ("Excellent! Highly satisfied.", 5)
            };

            var feedbacks = new List<Feedback>();
            foreach (var book in books)
            {
                for (int i = 0; i < 2; i++)
                {
                    var feedbackChoice = random.Next(feedbackCombination.Length);
                    var feedback = new Feedback()
                    {
                        Id = Guid.NewGuid(),
                        ReviewerName = feedbackNames[random.Next(feedbackNames.Count)],
                        Comment = feedbackCombination[feedbackChoice].Item1,
                        Rating = feedbackCombination[feedbackChoice].Item2,
                        Date = DateTime.UtcNow.AddDays(-random.Next(0, 15)),
                        IsPurchased = true,
                        BookId = book.Id,
                    };

                    feedbacks.Add(feedback);
                }
            }


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