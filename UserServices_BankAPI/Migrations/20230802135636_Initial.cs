using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserServices_BankAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentAccountBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountNumberGenerated = table.Column<string>(type: "TEXT", nullable: false),
                    PinHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PinSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    DateCreatred = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
