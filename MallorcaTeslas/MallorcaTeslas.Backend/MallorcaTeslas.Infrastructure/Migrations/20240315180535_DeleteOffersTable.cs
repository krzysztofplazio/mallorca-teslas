using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MallorcaTeslas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteOffersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Offers_OfferId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Offers_OfferId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_OfferId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OfferId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "Cars",
                newName: "RentDays");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Cars",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerMonth",
                table: "Cars",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RangeLimit",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PricePerMonth",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RangeLimit",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "RentDays",
                table: "Cars",
                newName: "OfferId");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Rentals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PricePerDay = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false),
                    RangeLimit = table.Column<int>(type: "integer", nullable: false),
                    RentDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_OfferId",
                table: "Rentals",
                column: "OfferId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Offers_OfferId",
                table: "Rentals",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
