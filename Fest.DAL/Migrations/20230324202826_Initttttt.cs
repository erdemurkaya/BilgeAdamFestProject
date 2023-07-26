using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Initttttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 24, 23, 28, 26, 693, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 24, 23, 28, 26, 693, DateTimeKind.Local).AddTicks(6477), "CfDJ8HtxLC5AM4BLvs12g-VlVgb-LuoMYrOEjOcmiLjMnSvjIw2OWeFhars74tP-Ks5hTENKdiHHVM5zBYrl6rEpfuOg-TCEtZg_EfUsZ3bjDLf0IBecSdtZYa8tw5sEdSkzvw" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 24, 22, 42, 15, 701, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 24, 22, 42, 15, 701, DateTimeKind.Local).AddTicks(3716), "CfDJ8HtxLC5AM4BLvs12g-VlVgahV12Q_7WxBGw1SZ62Qo0SaqCTzU8Wkkk56Q3zaf8CE474K2iHodV8WIU4NW2hGAbiqJ-011dCZdnna2lOb5dgouUQmGlLNFYir_BUJMEY8Q" });
        }
    }
}
