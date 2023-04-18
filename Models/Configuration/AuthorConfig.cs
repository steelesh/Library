using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT3047C_FinalProj.Models
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.HasData(
               new Author { AuthorId = 1, FirstName = "Harper", LastName = "Lee" },
               new Author { AuthorId = 2, FirstName = "F.Scott", LastName = "Fitzgerald" },
               new Author { AuthorId = 3, FirstName = "Toni", LastName = "Morrison" },
               new Author { AuthorId = 4, FirstName = "J.D ", LastName = "Salinger" },
               new Author { AuthorId = 5, FirstName = "Aldous", LastName = "Huxley" },
               new Author { AuthorId = 6, FirstName = "Margaret", LastName = "Mitchell" },
               new Author { AuthorId = 7, FirstName = "Ernest", LastName = "Hemimgway" },
               new Author { AuthorId = 8, FirstName = "George", LastName = "Orwell" },
               new Author { AuthorId = 9, FirstName = "William", LastName = "Shakespeare" },
               new Author { AuthorId = 10, FirstName = "Ian", LastName = "McEwan" }



            );
        }
    }

}
