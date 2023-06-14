using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class LeaveConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenses_Category_CategoryId",
                table: "BudgetExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetRevenues_Category_CategoryId",
                table: "BudgetRevenues");

            migrationBuilder.DropForeignKey(
                name: "FK_Leave_AspNetUsers_EmployeeId",
                table: "Leave");

            migrationBuilder.DropForeignKey(
                name: "FK_Leave_LeaveType_LeaveTypeId",
                table: "Leave");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Team_TeamId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leave",
                table: "Leave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "LeaveType",
                newName: "LeaveTypes");

            migrationBuilder.RenameTable(
                name: "Leave",
                newName: "Leaves");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Leave_LeaveTypeId",
                table: "Leaves",
                newName: "IX_Leaves_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Leave_EmployeeId",
                table: "Leaves",
                newName: "IX_Leaves_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaves",
                table: "Leaves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenses_Categories_CategoryId",
                table: "BudgetExpenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetRevenues_Categories_CategoryId",
                table: "BudgetRevenues",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_AspNetUsers_EmployeeId",
                table: "Leaves",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_LeaveTypes_LeaveTypeId",
                table: "Leaves",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenses_Categories_CategoryId",
                table: "BudgetExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetRevenues_Categories_CategoryId",
                table: "BudgetRevenues");

            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_AspNetUsers_EmployeeId",
                table: "Leaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_LeaveTypes_LeaveTypeId",
                table: "Leaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaves",
                table: "Leaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "LeaveTypes",
                newName: "LeaveType");

            migrationBuilder.RenameTable(
                name: "Leaves",
                newName: "Leave");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Leaves_LeaveTypeId",
                table: "Leave",
                newName: "IX_Leave_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leave",
                newName: "IX_Leave_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leave",
                table: "Leave",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenses_Category_CategoryId",
                table: "BudgetExpenses",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetRevenues_Category_CategoryId",
                table: "BudgetRevenues",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_AspNetUsers_EmployeeId",
                table: "Leave",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_LeaveType_LeaveTypeId",
                table: "Leave",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Team_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
