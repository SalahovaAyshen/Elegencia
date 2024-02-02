using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elegencia.Persistence.Contexts.Migrations
{
    public partial class createdMealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Categories_CategoryId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_MealImages_Meal_MealId",
                table: "MealImages");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTags_Meal_MealId",
                table: "MealTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_Name",
                table: "Meals",
                newName: "IX_Meals_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_CategoryId",
                table: "Meals",
                newName: "IX_Meals_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealImages_Meals_MealId",
                table: "MealImages",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Categories_CategoryId",
                table: "Meals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTags_Meals_MealId",
                table: "MealTags",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealImages_Meals_MealId",
                table: "MealImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Categories_CategoryId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTags_Meals_MealId",
                table: "MealTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_Name",
                table: "Meal",
                newName: "IX_Meal_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_CategoryId",
                table: "Meal",
                newName: "IX_Meal_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Categories_CategoryId",
                table: "Meal",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealImages_Meal_MealId",
                table: "MealImages",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTags_Meal_MealId",
                table: "MealTags",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
