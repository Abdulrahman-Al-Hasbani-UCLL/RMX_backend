using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Restaurant_manager_x_backend.Migrations
{
    /// <inheritdoc />
    public partial class userAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreparationTime",
                table: "Dishes",
                newName: "preparationTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dishes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Ingredients",
                table: "Dishes",
                newName: "ingredients");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dishes",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "preparationTime",
                table: "Dishes",
                newName: "PreparationTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Dishes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ingredients",
                table: "Dishes",
                newName: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Dishes",
                newName: "Id");
        }
    }
}
