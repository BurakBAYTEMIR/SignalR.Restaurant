using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Restaurant.DataAccess.Migrations
{
    public partial class add_mig_contact_new_coulmns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactFooterTitle",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenDays",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenDaysDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactFooterTitle",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactOpenDays",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactOpenDaysDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactOpenHours",
                table: "Contacts");
        }
    }
}
