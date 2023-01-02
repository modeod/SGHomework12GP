using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    public partial class remove_manufacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufactures_ManufacterId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacterId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacterId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufactures_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacterId",
                table: "Products",
                column: "ManufacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_AddressId",
                table: "Manufactures",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufactures_ManufacterId",
                table: "Products",
                column: "ManufacterId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
