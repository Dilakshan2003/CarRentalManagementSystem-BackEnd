using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAR_RENTAL.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_BookingId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookingId",
                table: "Rents",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_BookingId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookingId",
                table: "Rents",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
