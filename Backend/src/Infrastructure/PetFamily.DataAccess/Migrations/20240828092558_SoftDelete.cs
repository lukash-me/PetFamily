using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_volunteer_volunteer_id",
                table: "pet");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "volunteer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "pet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "fk_pet_volunteer_volunteer_id",
                table: "pet",
                column: "volunteer_id",
                principalTable: "volunteer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_volunteer_volunteer_id",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "volunteer");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "pet");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_volunteer_volunteer_id",
                table: "pet",
                column: "volunteer_id",
                principalTable: "volunteer",
                principalColumn: "id");
        }
    }
}
