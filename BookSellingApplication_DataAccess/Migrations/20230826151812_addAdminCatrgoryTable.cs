using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSellingApplication_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAdminCatrgoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Category_Id", "Category_Name" },
                values: new object[,]
                {
                    { 1, "Historic" },
                    { 2, "Thriller" },
                    { 3, "Mystery" },
                    { 4, "Fiction" },
                    { 5, "Action" },
                    { 6, "Action & Adventure" },
                    { 7, "Comics" },
                    { 8, "Fantasy" },
                    { 9, "Horror" },
                    { 10, "Romantic" },
                    { 11, "Biography" },
                    { 12, "Science" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
