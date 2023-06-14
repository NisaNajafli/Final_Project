using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeEmployeeLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_AspNetUsers_EmployeeId",
                table: "Leaves");

            migrationBuilder.DropIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Leaves");

            migrationBuilder.CreateTable(
                name: "EmployeeLeave",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    LeavesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeave", x => new { x.EmployeesId, x.LeavesId });
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_AspNetUsers_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_Leaves_LeavesId",
                        column: x => x.LeavesId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_LeavesId",
                table: "EmployeeLeave",
                column: "LeavesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeave");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_AspNetUsers_EmployeeId",
                table: "Leaves",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
