using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librum.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AlterShoppingCartID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCarts",
                newName: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCarts",
                newName: "Id");
        }
    }
}
