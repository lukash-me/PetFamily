using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Entities_refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "housed_count",
                table: "volunteer");

            migrationBuilder.DropColumn(
                name: "searching_house_count",
                table: "volunteer");

            migrationBuilder.DropColumn(
                name: "treatment_count",
                table: "volunteer");

            migrationBuilder.RenameColumn(
                name: "Requisites",
                table: "volunteer",
                newName: "requisites");

            migrationBuilder.RenameColumn(
                name: "SocialNetworks",
                table: "volunteer",
                newName: "social_networks");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "species",
                newName: "species");

            migrationBuilder.RenameColumn(
                name: "Requisites",
                table: "pet",
                newName: "requisites");

            migrationBuilder.RenameColumn(
                name: "animal_info_species_id",
                table: "pet",
                newName: "species_id");

            migrationBuilder.RenameColumn(
                name: "animal_info_breed_id",
                table: "pet",
                newName: "breed_id");

            migrationBuilder.RenameColumn(
                name: "PetPhotos",
                table: "pet",
                newName: "pet_photos");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "pet",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "health_info",
                table: "pet",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requisites",
                table: "volunteer",
                newName: "Requisites");

            migrationBuilder.RenameColumn(
                name: "social_networks",
                table: "volunteer",
                newName: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "species",
                table: "species",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "requisites",
                table: "pet",
                newName: "Requisites");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "pet",
                newName: "animal_info_species_id");

            migrationBuilder.RenameColumn(
                name: "breed_id",
                table: "pet",
                newName: "animal_info_breed_id");

            migrationBuilder.RenameColumn(
                name: "pet_photos",
                table: "pet",
                newName: "PetPhotos");

            migrationBuilder.AddColumn<int>(
                name: "housed_count",
                table: "volunteer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "searching_house_count",
                table: "volunteer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "treatment_count",
                table: "volunteer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "pet",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "health_info",
                table: "pet",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);
        }
    }
}
