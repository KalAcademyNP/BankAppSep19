using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Migrations
{
    public partial class AccountName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Accounts",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Accounts");
        }
    }
}
