using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedPropertyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FloorNumber",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFurnished",
                table: "Property",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListingType",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SizeInMmSquared",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "IsFurnished",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ListingType",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "SizeInMmSquared",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Property");
        }
    }
}
