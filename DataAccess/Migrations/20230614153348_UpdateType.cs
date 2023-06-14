using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_BudgetType_TypeId",
                table: "Budgets");

            migrationBuilder.DropTable(
                name: "BudgetType");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_TypeId",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Budgets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Budgets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BudgetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_TypeId",
                table: "Budgets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_BudgetType_TypeId",
                table: "Budgets",
                column: "TypeId",
                principalTable: "BudgetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
