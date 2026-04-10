using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEndTimeToBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingTime",
                table: "Bookings",
                newName: "StartTime");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ClinicId_BookingDate_BookingTime",
                table: "Bookings",
                newName: "IX_Bookings_ClinicId_BookingDate_StartTime");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookings",
                newName: "BookingTime");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ClinicId_BookingDate_StartTime",
                table: "Bookings",
                newName: "IX_Bookings_ClinicId_BookingDate_BookingTime");
        }
    }
}
