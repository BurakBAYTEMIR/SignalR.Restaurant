using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Restaurant.DataAccess.Migrations
{
    public partial class mig_add_booking_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingDescription",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDescription",
                table: "Bookings");
        }
    }
}
