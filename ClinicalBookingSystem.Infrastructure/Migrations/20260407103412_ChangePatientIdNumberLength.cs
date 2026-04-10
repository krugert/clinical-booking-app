using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePatientIdNumberLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IdNumber",
                table: "Patients",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
