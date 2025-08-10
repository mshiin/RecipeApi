using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipesApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetAuthorBornPropColToTypeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "IngredientQuantity");

            migrationBuilder.RenameColumn(
                name: "TotalTime",
                table: "Recipes",
                newName: "TotalTimeInMinutes");

            migrationBuilder.RenameColumn(
                name: "PreparationTime",
                table: "Recipes",
                newName: "PreparationTimeInMinutes");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                table: "IngredientQuantity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IngredientQuantityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.MeasurementUnitId);
                    table.ForeignKey(
                        name: "FK_MeasurementUnit_IngredientQuantity_IngredientQuantityId",
                        column: x => x.IngredientQuantityId,
                        principalTable: "IngredientQuantity",
                        principalColumn: "IngredientQuantityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnit_IngredientQuantityId",
                table: "MeasurementUnit",
                column: "IngredientQuantityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                table: "IngredientQuantity");

            migrationBuilder.RenameColumn(
                name: "TotalTimeInMinutes",
                table: "Recipes",
                newName: "TotalTime");

            migrationBuilder.RenameColumn(
                name: "PreparationTimeInMinutes",
                table: "Recipes",
                newName: "PreparationTime");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "IngredientQuantity",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
