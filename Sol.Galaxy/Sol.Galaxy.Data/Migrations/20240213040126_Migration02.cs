using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol.Galaxy.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DBO");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "DBO",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "DBO",
                columns: table => new
                {
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "DBO",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    UserRol = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Inovoice",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inovoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inovoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "DBO",
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inovoice_CustomerId",
                schema: "DBO",
                table: "Inovoice",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inovoice",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "User",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "DBO");
        }
    }
}
