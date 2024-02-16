using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol.Galaxy.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inovoice_Customer_CustomerId",
                schema: "DBO",
                table: "Inovoice");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "DBO",
                table: "Inovoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inovoice_Customer_CustomerId",
                schema: "DBO",
                table: "Inovoice",
                column: "CustomerId",
                principalSchema: "DBO",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inovoice_Customer_CustomerId",
                schema: "DBO",
                table: "Inovoice");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "DBO",
                table: "Inovoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inovoice_Customer_CustomerId",
                schema: "DBO",
                table: "Inovoice",
                column: "CustomerId",
                principalSchema: "DBO",
                principalTable: "Customer",
                principalColumn: "CustomerId");
        }
    }
}
