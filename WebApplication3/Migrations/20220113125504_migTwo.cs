using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class migTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yolcu_Otobus_OtobusID",
                table: "Yolcu");

            migrationBuilder.DropIndex(
                name: "IX_Yolcu_OtobusID",
                table: "Yolcu");

            migrationBuilder.DropColumn(
                name: "OtobusID",
                table: "Yolcu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OtobusID",
                table: "Yolcu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yolcu_OtobusID",
                table: "Yolcu",
                column: "OtobusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yolcu_Otobus_OtobusID",
                table: "Yolcu",
                column: "OtobusID",
                principalTable: "Otobus",
                principalColumn: "OtobusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
