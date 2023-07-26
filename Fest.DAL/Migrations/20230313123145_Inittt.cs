using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Fests",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Fests");

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 12, 23, 27, 26, 201, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 12, 23, 27, 26, 201, DateTimeKind.Local).AddTicks(6624), "CfDJ8HtxLC5AM4BLvs12g-VlVgY3emryP4K4Byu1t0ZUoWdF0ySdKmIdd36IW6z_7TRip64s9Mj-zLJw7HeO6OINe1GxwgyEc649ekfFm749babENxJh-dUlRb4-5PaLWcLIMA" });
        }
    }
}
