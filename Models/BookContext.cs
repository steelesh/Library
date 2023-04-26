using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProj.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "F", Name = "Fiction" },
                new Genre { GenreId = "NF", Name = "Non-Fiction" },
                new Genre { GenreId = "MY", Name = "Mystery" },
                new Genre { GenreId = "SF", Name = "Science Fiction" },
                new Genre { GenreId = "FA", Name = "Fantasy" },
                new Genre { GenreId = "RO", Name = "Romance" },
                new Genre { GenreId = "H", Name = "Horror" }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, GenreId = "F" },
                new Book { BookId = 2, Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", PublicationYear = 2011, GenreId = "NF" },
                new Book { BookId = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationYear = 1951, GenreId = "F" },
                new Book { BookId = 4, Title = "1984", Author = "George Orwell", PublicationYear = 1949, GenreId = "F" },
                new Book { BookId = 5, Title = "Brave New World", Author = "Aldous Huxley", PublicationYear = 1932, GenreId = "F" },
                new Book { BookId = 6, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", PublicationYear = 1866, GenreId = "F" },
                new Book { BookId = 7, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, GenreId = "F" },
                new Book { BookId = 8, Title = "Moby-Dick", Author = "Herman Melville", PublicationYear = 1851, GenreId = "F" },
                new Book { BookId = 9, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationYear = 1813, GenreId = "F" },
                new Book { BookId = 10, Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", PublicationYear = 1880, GenreId = "F" },
                new Book { BookId = 11, Title = "A Tale of Two Cities", Author = "Charles Dickens", PublicationYear = 1859, GenreId = "F" },
                new Book { BookId = 12, Title = "The Road", Author = "Cormac McCarthy", PublicationYear = 2006, GenreId = "F" },
                new Book { BookId = 13, Title = "The Alchemist", Author = "Paulo Coelho", PublicationYear = 1988, GenreId = "F" },
                new Book { BookId = 14, Title = "The Odyssey", Author = "Homer", PublicationYear = -800, GenreId = "F" },
                new Book { BookId = 15, Title = "The Iliad", Author = "Homer", PublicationYear = -750, GenreId = "F" }
                );
        }
    }
}
