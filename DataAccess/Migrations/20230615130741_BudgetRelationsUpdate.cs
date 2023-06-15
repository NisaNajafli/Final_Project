using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class BudgetRelationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenses_Budgets_BudgetId",
                table: "BudgetExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenses_Categories_CategoryId",
                table: "BudgetExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetRevenues_Budgets_BudgetId",
                table: "BudgetRevenues");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetRevenues_Categories_CategoryId",
                table: "BudgetRevenues");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BudgetRevenues_BudgetId",
                table: "BudgetRevenues");

            migrationBuilder.DropIndex(
                name: "IX_BudgetExpenses_BudgetId",
                table: "BudgetExpenses");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "BudgetRevenues");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "BudgetExpenses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BudgetRevenues",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetRevenues_CategoryId",
                table: "BudgetRevenues",
                newName: "IX_BudgetRevenues_CompanyId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BudgetExpenses",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetExpenses_CategoryId",
                table: "BudgetExpenses",
                newName: "IX_BudgetExpenses_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BudgetRevenues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BudgetExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenses_Companies_CompanyId",
                table: "BudgetExpenses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetRevenues_Companies_CompanyId",
                table: "BudgetRevenues",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenses_Companies_CompanyId",
                table: "BudgetExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetRevenues_Companies_CompanyId",
                table: "BudgetRevenues");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BudgetRevenues");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BudgetExpenses");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "BudgetRevenues",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetRevenues_CompanyId",
                table: "BudgetRevenues",
                newName: "IX_BudgetRevenues_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "BudgetExpenses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetExpenses_CompanyId",
                table: "BudgetExpenses",
                newName: "IX_BudgetExpenses_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "BudgetRevenues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "BudgetExpenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetRevenues_BudgetId",
                table: "BudgetRevenues",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetExpenses_BudgetId",
                table: "BudgetExpenses",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenses_Budgets_BudgetId",
                table: "BudgetExpenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenses_Categories_CategoryId",
                table: "BudgetExpenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetRevenues_Budgets_BudgetId",
                table: "BudgetRevenues",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetRevenues_Categories_CategoryId",
                table: "BudgetRevenues",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
