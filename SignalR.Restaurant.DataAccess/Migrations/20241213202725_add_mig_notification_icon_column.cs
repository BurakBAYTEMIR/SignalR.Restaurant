using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Restaurant.DataAccess.Migrations
{
    public partial class add_mig_notification_icon_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationIcon",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationIcon",
                table: "Notifications");
        }
    }
}
