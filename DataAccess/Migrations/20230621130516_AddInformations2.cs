using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddInformations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informations_AspNetUsers_EmployeeId",
                table: "Informations");

            migrationBuilder.DropIndex(
                name: "IX_Informations_EmployeeId",
                table: "Informations");

            migrationBuilder.AddColumn<int>(
                name: "InformationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InformationId",
                table: "AspNetUsers",
                column: "InformationId",
                unique: true,
                filter: "[InformationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Informations_InformationId",
                table: "AspNetUsers",
                column: "InformationId",
                principalTable: "Informations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Informations_InformationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InformationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InformationId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_EmployeeId",
                table: "Informations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_AspNetUsers_EmployeeId",
                table: "Informations",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
