using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Urlize_back.Migrations
{
    public partial class migrationjihen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "businessId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    logo = table.Column<string>(type: "longtext", nullable: true),
                    categorie = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    colorPalette = table.Column<int>(type: "int", nullable: false),
                    designPref = table.Column<int>(type: "int", nullable: false),
                    brandDescription = table.Column<int>(type: "int", nullable: false),
                    goal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Product_businessId",
                table: "Product",
                column: "businessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Business_businessId",
                table: "Product",
                column: "businessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Business_businessId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropIndex(
                name: "IX_Product_businessId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "businessId",
                table: "Product");
        }
    }
}
