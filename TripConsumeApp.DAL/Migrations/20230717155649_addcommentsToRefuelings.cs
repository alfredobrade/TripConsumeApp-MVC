using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripConsumeApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addcommentsToRefuelings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Refuelings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Refuelings");
        }
    }
}
