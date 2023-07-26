using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Inittttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Fests_FestEntityId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FestEntityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FestEntityId",
                table: "Tickets");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestId",
                table: "Tickets",
                column: "FestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Fests_FestId",
                table: "Tickets",
                column: "FestId",
                principalTable: "Fests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Fests_FestId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FestId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "FestEntityId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestEntityId",
                table: "Tickets",
                column: "FestEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Fests_FestEntityId",
                table: "Tickets",
                column: "FestEntityId",
                principalTable: "Fests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
