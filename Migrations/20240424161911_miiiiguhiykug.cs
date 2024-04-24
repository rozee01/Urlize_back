using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Urlize_back.Migrations
{
    public partial class miiiiguhiykug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Business_businessId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_businessId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "businessId1",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Business",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.DropIndex(
                name: "IX_Product_businessId",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "businessId1",
                table: "Product",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Business",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Product_businessId1",
                table: "Product",
                column: "businessId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Business_businessId1",
                table: "Product",
                column: "businessId1",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
