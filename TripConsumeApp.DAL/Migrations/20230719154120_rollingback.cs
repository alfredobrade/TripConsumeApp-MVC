using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripConsumeApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class rollingback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TankCapacity",
                table: "Vehicles",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AverageConsume",
                table: "Vehicles",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AverageAutonomy",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TankCapacity",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageConsume",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageAutonomy",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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
        }
    }
}
