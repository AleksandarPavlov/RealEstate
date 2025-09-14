using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdvertiserChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertiser_Property_PropertyId",
                table: "Advertiser");

            migrationBuilder.DropIndex(
                name: "IX_Advertiser_PropertyId",
                table: "Advertiser");

            migrationBuilder.AddColumn<long>(
                name: "AdvertiserId",
                table: "Property",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Advertiser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Advertiser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Property_AdvertiserId",
                table: "Property",
                column: "AdvertiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Advertiser_AdvertiserId",
                table: "Property",
                column: "AdvertiserId",
                principalTable: "Advertiser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Advertiser_AdvertiserId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_AdvertiserId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "AdvertiserId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Advertiser");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Advertiser");

            migrationBuilder.CreateIndex(
                name: "IX_Advertiser_PropertyId",
                table: "Advertiser",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertiser_Property_PropertyId",
                table: "Advertiser",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
