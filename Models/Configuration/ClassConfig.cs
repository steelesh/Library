using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT3047C_FinalProj.Models
{

internal class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasData(
               new ClassConfig { ClassId = 1, Title = "To Kill a Mockingbird", AuthorId = 1, Page = 1, Date = "03/14/2023" },
               new ClassConfig { ClassId = 2, Title = "The Great Gatsby", AuthorId =2 , Page = 20, Date="03/04/2023"},
               new ClassConfig { ClassId = 3, Title = "Beloved", AuthorId = 3, Page = 14, Date="02/29/2023"},
               new ClassConfig { ClassId = 4, Title = "The Catcher in the Rye", AuthorId = 4, Page = 89, Date="02/17/2023"},
               new ClassConfig { ClassId = 5, Title = "Brave New World ", AuthorId = 5, Page = 70, Date="01/20/2023"},
               new ClassConfig { ClassId = 6, Title = "Gone with the wind", AuthorId = 6, Page = 120, Date="01/15/2023"},
               new ClassConfig { ClassId = 7, Title = "The Sun Also Rises ", AuthorId = 7, Page = 310, Date="12/20/2022"},
               new ClassConfig { ClassId = 8, Title = "Animal Farm", AuthorId = 8 ,Page = 60, Date="12/10/2022" },
               new ClassConfig { ClassId = 9, Title = "Hamelet", AuthorId = 9, Page = 151, Date="11/20/2022"},
               new ClassConfig { ClassId = 10, Title = "Romeo & Juliet", AuthorId = 9, Page = 140, Date="11/01/2022"},
               new ClassConfig { ClassId = 11, Title = "Othello", AuthorId = 9, Page = 200, Date="08/13/2022" },
               new ClassConfig { ClassId = 12, Title = "Atonement ", AuthorId = 10, Page = 365, Date="05/05/2022" }
            );
        }
    }

}

