using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppBoutique1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemPrice = table.Column<double>(type: "float", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
