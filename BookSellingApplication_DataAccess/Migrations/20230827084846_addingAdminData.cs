using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSellingApplication_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Admin_Id", "Password", "UserName" },
                values: new object[] { 1, "Cheppanu", "Anvesh" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Admin_Id",
                keyValue: 1);
        }
    }
}
