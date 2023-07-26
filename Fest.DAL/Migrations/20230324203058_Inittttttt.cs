using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fest.DAL.Migrations
{
    public partial class Inittttttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tickets_TicketId1",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_TicketId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TicketId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 24, 23, 30, 58, 70, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 24, 23, 30, 58, 70, DateTimeKind.Local).AddTicks(6997), "CfDJ8HtxLC5AM4BLvs12g-VlVgZTpsk78Gegx0UwFTyRejqs6ULYVw7UFrPSGyhTQ5TigZGiXNpfm9Ju4m6_6KLSvcdoI33a2O8SIC3AqhHt85FUQiU8G4GQPvsJUcDGz3t5Hg" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tickets_TicketId",
                table: "Payments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tickets_TicketId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TicketId1",
                table: "Payments",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tickets_TicketId1",
                table: "Payments",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_TicketId",
                table: "Payments",
                column: "TicketId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
