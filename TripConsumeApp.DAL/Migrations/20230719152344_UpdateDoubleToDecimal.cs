using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripConsumeApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDoubleToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TankCapacity",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageAutonomy",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageConsume",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Liters",
                table: "Refuelings",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Kilometers",
                table: "Refuelings",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Refuelings",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Refuelings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refuelings_TripId",
                table: "Refuelings",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refuelings_Trips_TripId",
                table: "Refuelings",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refuelings_Trips_TripId",
                table: "Refuelings");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Refuelings_TripId",
                table: "Refuelings");

            migrationBuilder.DropColumn(
                name: "AverageAutonomy",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AverageConsume",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Refuelings");

            migrationBuilder.AlterColumn<double>(
                name: "TankCapacity",
                table: "Vehicles",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Liters",
                table: "Refuelings",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Kilometers",
                table: "Refuelings",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Refuelings",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);
        }
    }
}
