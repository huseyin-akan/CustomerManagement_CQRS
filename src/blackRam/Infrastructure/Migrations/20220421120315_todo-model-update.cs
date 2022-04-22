using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class todomodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtCases_Court_CourtId",
                table: "CourtCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_CourtCases_CourtCaseId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_CourtCases_CourtCaseId",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Court",
                table: "Court");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Todos");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "Court",
                newName: "Courts");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_CourtCaseId",
                table: "Todos",
                newName: "IX_Todos_CourtCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CourtCaseId",
                table: "Expenses",
                newName: "IX_Expenses_CourtCaseId");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Todos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courts",
                table: "Courts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtCases_Courts_CourtId",
                table: "CourtCases",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CourtCases_CourtCaseId",
                table: "Expenses",
                column: "CourtCaseId",
                principalTable: "CourtCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_CourtCases_CourtCaseId",
                table: "Todos",
                column: "CourtCaseId",
                principalTable: "CourtCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtCases_Courts_CourtId",
                table: "CourtCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CourtCases_CourtCaseId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_CourtCases_CourtCaseId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courts",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Todo");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "Courts",
                newName: "Court");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_CourtCaseId",
                table: "Todo",
                newName: "IX_Todo_CourtCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CourtCaseId",
                table: "Expense",
                newName: "IX_Expense_CourtCaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Court",
                table: "Court",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtCases_Court_CourtId",
                table: "CourtCases",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_CourtCases_CourtCaseId",
                table: "Expense",
                column: "CourtCaseId",
                principalTable: "CourtCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_CourtCases_CourtCaseId",
                table: "Todo",
                column: "CourtCaseId",
                principalTable: "CourtCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
