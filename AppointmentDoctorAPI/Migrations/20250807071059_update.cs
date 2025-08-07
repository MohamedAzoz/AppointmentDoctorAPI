using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AvailableSlots_AvailableSlotId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AvailableSlotId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AvailableSlotId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SlotId",
                table: "Appointments",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AvailableSlots_SlotId",
                table: "Appointments",
                column: "SlotId",
                principalTable: "AvailableSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AvailableSlots_SlotId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SlotId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSlotId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AvailableSlotId",
                table: "Appointments",
                column: "AvailableSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AvailableSlots_AvailableSlotId",
                table: "Appointments",
                column: "AvailableSlotId",
                principalTable: "AvailableSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
