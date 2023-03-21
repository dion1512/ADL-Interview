using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADL.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeBooked",
                table: "Callout");

            migrationBuilder.RenameColumn(
                name: "DateBooked",
                table: "Callout",
                newName: "DateBookedStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBookedEnd",
                table: "Callout",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentTimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    AppointmentTimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropColumn(
                name: "DateBookedEnd",
                table: "Callout");

            migrationBuilder.RenameColumn(
                name: "DateBookedStart",
                table: "Callout",
                newName: "DateBooked");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeBooked",
                table: "Callout",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
