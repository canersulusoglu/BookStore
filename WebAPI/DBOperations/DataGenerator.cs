namespace WebAPI.DBOperations;

public class DataGenerator{ 
    public static void Initialize(IServiceProvider serviceProvider){
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if(!context.Books!.Any()){
                context.Books!.AddRange(
                    new Book {
                        Title = "Lean Startup", 
                        GenreId = GenreEnum.PersonalGrowth, // Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 6, 12)
                    },
                    new Book {
                        Title = "Herland", 
                        GenreId = GenreEnum.ScienceFiction, // Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 5, 23)
                    },
                    new Book {
                        Title = "Dune", 
                        GenreId = GenreEnum.ScienceFiction, // Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 12, 21)
                    }
                );
                context.SaveChanges();
            }
            return;
        }
    }
}