using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MallorcaTeslas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenCarsAndOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cars_CarId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CarId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Offers");
        }
    }
}
