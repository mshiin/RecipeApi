using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipesApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStepNumberToRecipeSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepNumber",
                table: "RecipeStep",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepNumber",
                table: "RecipeStep");
        }
    }
}
