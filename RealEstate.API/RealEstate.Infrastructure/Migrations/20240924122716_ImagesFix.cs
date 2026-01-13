using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImagesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertyId1",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId1",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "PropertyId1",
                table: "PropertyImage");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.AddColumn<long>(
                name: "PropertyId1",
                table: "PropertyImage",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId1",
                table: "PropertyImage",
                column: "PropertyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertyId1",
                table: "PropertyImage",
                column: "PropertyId1",
                principalTable: "Property",
                principalColumn: "Id");
        }
    }
}
