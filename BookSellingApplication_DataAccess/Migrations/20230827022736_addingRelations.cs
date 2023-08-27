using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSellingApplication_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Books_BookObjBook_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_BookObjBook_Id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "BookObjBook_Id",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CatObjCategory_Id",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Book_Id",
                table: "Cart",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatObjCategory_Id",
                table: "Books",
                column: "CatObjCategory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Category_CatObjCategory_Id",
                table: "Books",
                column: "CatObjCategory_Id",
                principalTable: "Category",
                principalColumn: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Books_Book_Id",
                table: "Cart",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Category_CatObjCategory_Id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Books_Book_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Book_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Books_CatObjCategory_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CatObjCategory_Id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookObjBook_Id",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BookObjBook_Id",
                table: "Cart",
                column: "BookObjBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Books_BookObjBook_Id",
                table: "Cart",
                column: "BookObjBook_Id",
                principalTable: "Books",
                principalColumn: "Book_Id");
        }
    }
}
