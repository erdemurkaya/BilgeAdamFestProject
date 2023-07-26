using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Initttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardExpirationMonth",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "CardExpirationYear",
                table: "Payments",
                newName: "CardExpiration");

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 24, 13, 19, 29, 916, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 24, 13, 19, 29, 916, DateTimeKind.Local).AddTicks(5863), "CfDJ8HtxLC5AM4BLvs12g-VlVgbLEN7p1PY--X8i-tXPn83xeg83aS4VUUO01emSMt3GW6pCVlsc--TEHG5AkbveqYU9r5St7n9WrJCiw4wi1_Oej2E8C05NBqgvgu99cjZOGQ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardExpiration",
                table: "Payments",
                newName: "CardExpirationYear");

            migrationBuilder.AddColumn<string>(
                name: "CardExpirationMonth",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 15, 31, 45, 579, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 13, 15, 31, 45, 579, DateTimeKind.Local).AddTicks(1970), "CfDJ8HtxLC5AM4BLvs12g-VlVgbS2a4c_wulPQaukz1_pLqpWERSWy4sQs9FO7cwEEximwxfgST0juzExgJt4RzxjhPDcOCZALYCLVYGhKohJKVjCZAGCM2oY0m-b2nJR31baA" });
        }
    }
}
