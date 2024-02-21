using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elegencia.Persistence.Contexts.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Reservations",
                newName: "ArrivalDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArrivalDateTime",
                table: "Reservations",
                newName: "ArrivalTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
