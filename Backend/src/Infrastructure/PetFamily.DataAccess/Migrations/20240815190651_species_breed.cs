using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class species_breed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breed",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "species",
                table: "pet");

            migrationBuilder.AddColumn<Guid>(
                name: "animal_info_breed_id",
                table: "pet",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "animal_info_species_id",
                table: "pet",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "species_id",
                table: "pet",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breed", x => x.id);
                    table.ForeignKey(
                        name: "fk_breed_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_pet_species_id",
                table: "pet",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_breed_species_id",
                table: "breed",
                column: "species_id");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_species_species_id",
                table: "pet",
                column: "species_id",
                principalTable: "species",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_species_species_id",
                table: "pet");

            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropIndex(
                name: "ix_pet_species_id",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "animal_info_breed_id",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "animal_info_species_id",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "species_id",
                table: "pet");

            migrationBuilder.AddColumn<string>(
                name: "breed",
                table: "pet",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "species",
                table: "pet",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
