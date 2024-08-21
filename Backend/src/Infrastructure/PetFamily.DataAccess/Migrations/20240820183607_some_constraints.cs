using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class some_constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_species_species_id",
                table: "pet");

            migrationBuilder.DropIndex(
                name: "ix_pet_species_id",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "species_id",
                table: "pet");

            migrationBuilder.AlterColumn<string>(
                name: "middlename",
                table: "volunteer",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "volunteer",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "middlename",
                table: "volunteer",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "volunteer",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<Guid>(
                name: "species_id",
                table: "pet",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_pet_species_id",
                table: "pet",
                column: "species_id");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_species_species_id",
                table: "pet",
                column: "species_id",
                principalTable: "species",
                principalColumn: "id");
        }
    }
}
