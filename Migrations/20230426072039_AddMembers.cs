using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT3047C_FinalProj.Migrations
{
    /// <inheritdoc />
    public partial class AddMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "MemberCurrentlyReadingBooks",
                columns: table => new
                {
                    CurrentlyReadingBookId = table.Column<int>(type: "int", nullable: false),
                    CurrentlyReadingBooksMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCurrentlyReadingBooks", x => new { x.CurrentlyReadingBookId, x.CurrentlyReadingBooksMemberId });
                    table.ForeignKey(
                        name: "FK_MemberCurrentlyReadingBooks_Books_CurrentlyReadingBookId",
                        column: x => x.CurrentlyReadingBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberCurrentlyReadingBooks_Members_CurrentlyReadingBooksMemberId",
                        column: x => x.CurrentlyReadingBooksMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberFavoriteBooks",
                columns: table => new
                {
                    FavoriteBooksMemberId = table.Column<int>(type: "int", nullable: false),
                    FavoritesBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFavoriteBooks", x => new { x.FavoriteBooksMemberId, x.FavoritesBookId });
                    table.ForeignKey(
                        name: "FK_MemberFavoriteBooks_Books_FavoritesBookId",
                        column: x => x.FavoritesBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberFavoriteBooks_Members_FavoriteBooksMemberId",
                        column: x => x.FavoriteBooksMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberWantToReadBooks",
                columns: table => new
                {
                    WantToReadBookId = table.Column<int>(type: "int", nullable: false),
                    WantToReadBooksMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWantToReadBooks", x => new { x.WantToReadBookId, x.WantToReadBooksMemberId });
                    table.ForeignKey(
                        name: "FK_MemberWantToReadBooks_Books_WantToReadBookId",
                        column: x => x.WantToReadBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberWantToReadBooks_Members_WantToReadBooksMemberId",
                        column: x => x.WantToReadBooksMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[,]
                {
                    { 1, "Eric Miller" },
                    { 2, "Miriam Boni" },
                    { 3, "Steele Shreve" },
                    { 4, "Zion Ivery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberCurrentlyReadingBooks_CurrentlyReadingBooksMemberId",
                table: "MemberCurrentlyReadingBooks",
                column: "CurrentlyReadingBooksMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFavoriteBooks_FavoritesBookId",
                table: "MemberFavoriteBooks",
                column: "FavoritesBookId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWantToReadBooks_WantToReadBooksMemberId",
                table: "MemberWantToReadBooks",
                column: "WantToReadBooksMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberCurrentlyReadingBooks");

            migrationBuilder.DropTable(
                name: "MemberFavoriteBooks");

            migrationBuilder.DropTable(
                name: "MemberWantToReadBooks");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
