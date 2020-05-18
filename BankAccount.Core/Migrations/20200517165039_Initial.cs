using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAccount.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    OpenedDate = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");


            InsertCurrencies(migrationBuilder);
            InsertTestUser(migrationBuilder);
        }

        private void InsertTestUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Email", "Created" },
                values: new object[] { 0, "Smith", "test@Smith.com", DateTime.UtcNow });
        }

        private void InsertCurrencies(MigrationBuilder migrationBuilder)
        {
            var currencies = Currencies();
            for (int i = 0; i < currencies.Count; i++)
            {
                migrationBuilder.InsertData(
                    table: "Currencies",
                    columns: new[] { "Id", "Code", "Created" },
                    values: new object[] { i, currencies[i], DateTime.UtcNow });
            }
        }

        private List<string> Currencies()
        {
            return new List<string>()
            {
                "USD",
                "JPY",
                "BGN",
                "CZK",
                "DKK",
                "GBP",
                "HUF",
                "PLN",
                "RON",
                "SEK",
                "CHF",
                "ISK",
                "NOK",
                "HRK",
                "RUB",
                "TRY",
                "AUD",
                "BRL",
                "CAD",
                "CNY",
                "HKD",
                "IDR",
                "ILS",
                "INR",
                "KRW",
                "MXN",
                "MYR",
                "NZD",
                "PHP",
                "SGD",
                "THB",
                "ZAR",
            };
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
