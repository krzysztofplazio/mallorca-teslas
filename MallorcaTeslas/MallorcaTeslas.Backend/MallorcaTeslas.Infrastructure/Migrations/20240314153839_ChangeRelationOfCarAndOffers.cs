using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MallorcaTeslas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationOfCarAndOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Offers",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleOdometer",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    OfferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOffer_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOffer_CarId",
                table: "CarOffer",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOffer_OfferId",
                table: "CarOffer",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOffer");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "VehicleOdometer",
                table: "Cars");

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
    }
}
