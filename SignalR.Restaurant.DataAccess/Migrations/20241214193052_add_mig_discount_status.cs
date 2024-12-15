using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Restaurant.DataAccess.Migrations
{
    public partial class add_mig_discount_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DiscountStatus",
                table: "Discounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountStatus",
                table: "Discounts");
        }
    }
}
