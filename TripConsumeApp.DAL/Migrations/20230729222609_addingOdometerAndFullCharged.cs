using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripConsumeApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingOdometerAndFullCharged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Odometer",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullCharged",
                table: "Refuelings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odometer",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsFullCharged",
                table: "Refuelings");
        }
    }
}
