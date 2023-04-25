using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT3047C_FinalProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "F", "Fiction" },
                    { "FA", "Fantasy" },
                    { "H", "Horror" },
                    { "MY", "Mystery" },
                    { "NF", "Non-Fiction" },
                    { "RO", "Romance" },
                    { "SF", "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "GenreId", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", "F", 1960, "To Kill a Mockingbird" },
                    { 2, "Yuval Noah Harari", "NF", 2011, "Sapiens: A Brief History of Humankind" },
                    { 3, "J.D. Salinger", "F", 1951, "The Catcher in the Rye" },
                    { 4, "George Orwell", "F", 1949, "1984" },
                    { 5, "Aldous Huxley", "F", 1932, "Brave New World" },
                    { 6, "Fyodor Dostoevsky", "F", 1866, "Crime and Punishment" },
                    { 7, "F. Scott Fitzgerald", "F", 1925, "The Great Gatsby" },
                    { 8, "Herman Melville", "F", 1851, "Moby-Dick" },
                    { 9, "Jane Austen", "F", 1813, "Pride and Prejudice" },
                    { 10, "Fyodor Dostoevsky", "F", 1880, "The Brothers Karamazov" },
                    { 11, "Charles Dickens", "F", 1859, "A Tale of Two Cities" },
                    { 12, "Cormac McCarthy", "F", 2006, "The Road" },
                    { 13, "Paulo Coelho", "F", 1988, "The Alchemist" },
                    { 14, "Homer", "F", -800, "The Odyssey" },
                    { 15, "Homer", "F", -750, "The Iliad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
