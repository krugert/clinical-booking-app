using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeUniqueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClinicId_BookingDate_BookingTime",
                table: "Bookings",
                columns: new[] { "ClinicId", "BookingDate", "BookingTime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClinicId_BookingDate_BookingTime",
                table: "Bookings");
        }
    }
}
