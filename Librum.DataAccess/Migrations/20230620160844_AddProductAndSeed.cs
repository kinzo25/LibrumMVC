using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Librum.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Mary Shelley", "Frankenstein; or, The Modern Prometheus is an 1818 novel written by English author Mary Shelley. Frankenstein tells the story of Victor Frankenstein, a young scientist who creates a sapient creature in an unorthodox scientific experiment. ", "FRNK8347", 12.99, 10.99, 8.4900000000000002, "Frankenstein" },
                    { 2, "Enid Blyton", "What is the secret of the old castle on the hill, and why are the locals so afraid of it? When flashing lights are seen in a distant tower, Philip, Dinah, Lucy-Ann, and Jack decide to investigate—and discover a very sinister plot concealed within its hidden rooms and gloomy underground passages.", "ADVN3758", 7.9900000000000002, 6.9900000000000002, 4.4900000000000002, "Castle of Adventure" },
                    { 3, "Agatha Christie", "A group of passengers trapped on the Orient Express in a snow storm with a murdered body and a Belgian detective to keep them company: Murder on the Orient Express is one of Agatha Christie’s most famous stories. It's an intricate mystery revolving around a group of characters cut off from the world where Poirot exhibits not only the power of his little grey cells but his concern and compassion for humanity.", "MOOE5038", 12.49, 9.9900000000000002, 8.4900000000000002, "Murder on the Orient Express" },
                    { 4, "Alistar MacLean", "An entire navy had tried to silence the guns of Navarone and failed. Full-scale attacks had been driven back. Now they were sending in just five men, each one a specialist in dealing death.", "GNVR3892", 5.9900000000000002, 4.9900000000000002, 3.4900000000000002, "The Guns of Navarone" },
                    { 5, "Amish Tripathi", "1900 BC. In what modern Indians mistakenly call the Indus Valley Civilisation. The inhabitants of that period called it the land of Meluha : a near perfect empire created many centuries earlier by Lord Ram, one of the greatest monarchs that ever lived. This once proud empire and its Suryavanshi rulers face severe perils. The only hope for the Suryavanshis is an ancient legend: 'When evil reaches epic proportions, when all seems lost, when it appears that your enemies have triumphed, a hero will emerge.'", "IMEL2561", 13.99, 11.49, 9.9900000000000002, "The Immortals of Meluha" },
                    { 6, "Chitra Banerjee Divakaruni", "Taking us back to a time that is half history, half myth and wholly magical, bestselling author Chitra Banerjee Divakaruni gives voice to Panchaali, the fire-born heroine of the Mahabharata, as she weaves a vibrant retelling of an ancient epic saga. Married to five royal husbands who have been cheated out of their father's kingdom, Panchaali aids their quest to reclaim their birthright, remaining at their side through years of exile and a terrible civil war. But she cannot deny her complicated friendship with the enigmatic Krishna--or her secret attraction to the mysterious man who is her husbands' most dangerous enemy--as she is caught up in the ever-manipulating hands of fate.", "POIL2947", 15.49, 12.99, 10.99, "The Palace of Illusions" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
