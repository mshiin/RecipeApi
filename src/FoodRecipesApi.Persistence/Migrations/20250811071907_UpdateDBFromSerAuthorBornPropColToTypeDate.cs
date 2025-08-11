using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipesApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBFromSerAuthorBornPropColToTypeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalTimeInMinutes",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "PreparationTimeInMinutes",
                table: "Recipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TotalTimeInMinutes",
                table: "Recipes",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "PreparationTimeInMinutes",
                table: "Recipes",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
