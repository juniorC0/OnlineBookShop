using OnlineBookShop.Domain;

namespace OnlineBookShop.Infrastructure.Persistance.DataSeed
{
    public class BooksSeed
    {
        public static async Task Seed(OnlineBookShopDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                var books = new[]
                {
                    new Book
                    {
                        Name = "The Great Gatsby",
                        PublicationDate = new DateTime(1925, 4, 10),
                        Description = "A novel by F. Scott Fitzgerald",
                        NumberOfPages = 218
                    },
                    new Book
                    {
                        Name = "To Kill a Mockingbird",
                        PublicationDate = new DateTime(1960, 7, 11),
                        Description = "A novel by Harper Lee",
                        NumberOfPages = 281
                    },
                    new Book
                    {
                        Name = "1984",
                        PublicationDate = new DateTime(1949, 6, 8),
                        Description = "A dystopian social science fiction novel by English novelist George Orwell",
                        NumberOfPages = 328
                    },
                    new Book
                    {
                        Name = "Pride and Prejudice",
                        PublicationDate = new DateTime(1813, 1, 28),
                        Description = "A romantic novel of manners written by Jane Austen",
                        NumberOfPages = 279
                    },
                    new Book
                    {
                        Name = "The Catcher in the Rye",
                        PublicationDate = new DateTime(1951, 7, 16),
                        Description = "A novel by J. D. Salinger",
                        NumberOfPages = 234
                    },
                    new Book
                    {
                        Name = "The Hobbit",
                        PublicationDate = new DateTime(1937, 9, 21),
                        Description = "A children's fantasy novel by J. R. R. Tolkien",
                        NumberOfPages = 310
                    },
                    new Book
                    {
                        Name = "The Lord of the Rings",
                        PublicationDate = new DateTime(1954, 7, 29),
                        Description = "An epic high fantasy novel by J. R. R. Tolkien",
                        NumberOfPages = 1178
                    },
                    new Book
                    {
                        Name = "The Chronicles of Narnia",
                        PublicationDate = new DateTime(1950, 10, 16),
                        Description = "A series of seven high fantasy novels by C. S. Lewis",
                        NumberOfPages = 764
                    },
                    new Book
                    {
                        Name = "Animal Farm",
                        PublicationDate = new DateTime(1945, 8, 17),
                        Description = "An allegorical novella by George Orwell",
                        NumberOfPages = 112
                    },
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        PublicationDate = new DateTime(1979, 10, 12),
                        Description = "A comedic science fiction series created by Douglas Adams",
                        NumberOfPages = 193
                    }
                };

                await dbContext.Books.AddRangeAsync(books);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
