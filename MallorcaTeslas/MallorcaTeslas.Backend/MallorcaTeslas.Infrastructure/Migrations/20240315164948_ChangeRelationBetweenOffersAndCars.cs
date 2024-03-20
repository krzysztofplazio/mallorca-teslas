using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MallorcaTeslas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationBetweenOffersAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOffer");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OfferId",
                table: "Cars",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Offers_OfferId",
                table: "Cars",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Offers_OfferId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OfferId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Cars");

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
    }
}
