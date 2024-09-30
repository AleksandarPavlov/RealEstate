using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CoordinatesTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Property");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Property",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Property",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Property");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
