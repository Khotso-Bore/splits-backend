using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitsAPI.Domian.Migrations
{
    /// <inheritdoc />
    public partial class FKOnCategoryAndTransactionState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_TransactionCategoryId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionsState_StateId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StateId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionCategoryId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionCategoryId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Category",
                table: "Transactions",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionState",
                table: "Transactions",
                column: "TransactionState",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_Category",
                table: "Transactions",
                column: "Category",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionsState_TransactionState",
                table: "Transactions",
                column: "TransactionState",
                principalTable: "TransactionsState",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_Category",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionsState_TransactionState",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Category",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionState",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionCategoryId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StateId",
                table: "Transactions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionCategoryId",
                table: "Transactions",
                column: "TransactionCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_TransactionCategoryId",
                table: "Transactions",
                column: "TransactionCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionsState_StateId",
                table: "Transactions",
                column: "StateId",
                principalTable: "TransactionsState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
