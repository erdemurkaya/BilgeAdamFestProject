using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Countries",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Artists",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 0, 56, 25, 378, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 56, 25, 378, DateTimeKind.Local).AddTicks(1625), "CfDJ8HtxLC5AM4BLvs12g-VlVgbj6uH5RjZnQ2oMSeXIStJ4vtPrtPCQupxmKdARpq7B24GWdIbIGxCaNX_Ubdk1jblyaZPi6s3Vdzpg7xHEYL5FKGc8GzX88YUITFpsSU7D0A" });
        }
    }
}
