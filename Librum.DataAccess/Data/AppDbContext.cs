using Librum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Librum.DataAccess.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<School> Schools { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Fantasy",DisplayOrder=1},
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Crime", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    Description = "Frankenstein; or, The Modern Prometheus is an 1818 novel written by English author Mary Shelley. Frankenstein tells the story of Victor Frankenstein, a young scientist who creates a sapient creature in an unorthodox scientific experiment. ",
                    ISBN = "FRNK8347",
                    ListPrice = 12.99,
                    Price = 10.99,
                    Price50 = 8.49,
                    CategoryId = 4,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 2,
                    Title = "Castle of Adventure",
                    Author = "Enid Blyton",
                    Description = "What is the secret of the old castle on the hill, and why are the locals so afraid of it? When flashing lights are seen in a distant tower, Philip, Dinah, Lucy-Ann, and Jack decide to investigate—and discover a very sinister plot concealed within its hidden rooms and gloomy underground passages.",
                    ISBN = "ADVN3758",
                    ListPrice = 7.99,
                    Price = 6.99,
                    Price50 = 4.49,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Murder on the Orient Express",
                    Author = "Agatha Christie",
                    Description = "A group of passengers trapped on the Orient Express in a snow storm with a murdered body and a Belgian detective to keep them school: Murder on the Orient Express is one of Agatha Christie’s most famous stories. It's an intricate mystery revolving around a group of characters cut off from the world where Poirot exhibits not only the power of his little grey cells but his concern and compassion for humanity.",
                    ISBN = "MOOE5038",
                    ListPrice = 12.49,
                    Price = 9.99,
                    Price50 = 8.49,
                    CategoryId=3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "The Guns of Navarone",
                    Author = "Alistar MacLean",
                    Description = "An entire navy had tried to silence the guns of Navarone and failed. Full-scale attacks had been driven back. Now they were sending in just five men, each one a specialist in dealing death.",
                    ISBN = "GNVR3892",
                    ListPrice = 5.99,
                    Price = 4.99,
                    Price50 = 3.49,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "The Immortals of Meluha",
                    Author = "Amish Tripathi",
                    Description = "1900 BC. In what modern Indians mistakenly call the Indus Valley Civilisation. The inhabitants of that period called it the land of Meluha : a near perfect empire created many centuries earlier by Lord Ram, one of the greatest monarchs that ever lived. This once proud empire and its Suryavanshi rulers face severe perils. The only hope for the Suryavanshis is an ancient legend: 'When evil reaches epic proportions, when all seems lost, when it appears that your enemies have triumphed, a hero will emerge.'",
                    ISBN = "IMEL2561",
                    ListPrice = 13.99,
                    Price = 11.49,
                    Price50 = 9.99,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "The Palace of Illusions",
                    Author = "Chitra Banerjee Divakaruni",
                    Description = "Taking us back to a time that is half history, half myth and wholly magical, bestselling author Chitra Banerjee Divakaruni gives voice to Panchaali, the fire-born heroine of the Mahabharata, as she weaves a vibrant retelling of an ancient epic saga. Married to five royal husbands who have been cheated out of their father's kingdom, Panchaali aids their quest to reclaim their birthright, remaining at their side through years of exile and a terrible civil war. But she cannot deny her complicated friendship with the enigmatic Krishna--or her secret attraction to the mysterious man who is her husbands' most dangerous enemy--as she is caught up in the ever-manipulating hands of fate.",
                    ISBN = "POIL2947",
                    ListPrice = 15.49,
                    Price = 12.99,
                    Price50 = 10.99,
                    CategoryId=1,
                    ImageUrl = ""
                }
                ) ;

            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id=1,
                    Name= "St. Rufus Boarding School",
                    StreetAddress= "1234 Saints Ave",
                    City= "Philadelphia",
                    State= "PA",
                    PostalCode="38584",
                    PhoneNumber="2617358603",
                },
                new School
                {
                    Id = 2,
                    Name = "Bauxbaton Academy",
                    StreetAddress = "643 Rue de Baguette",
                    City = "Trenton",
                    State = "NJ",
                    PostalCode = "08345",
                    PhoneNumber = "1839459603",
                },
                new School
                {
                    Id = 3,
                    Name = "Monster High",
                    StreetAddress = "34-A Wolfe St",
                    City = "Frederick",
                    State = "MD",
                    PostalCode = "28904",
                    PhoneNumber = "2464367809",
                }
                );
        }
    }
}
