using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librum.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHoppingCarts_Products_ProductId",
                table: "SHoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHoppingCarts",
                table: "SHoppingCarts");

            migrationBuilder.RenameTable(
                name: "SHoppingCarts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_SHoppingCarts_ProductId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "SHoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "SHoppingCarts",
                newName: "IX_SHoppingCarts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHoppingCarts",
                table: "SHoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SHoppingCarts_Products_ProductId",
                table: "SHoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
