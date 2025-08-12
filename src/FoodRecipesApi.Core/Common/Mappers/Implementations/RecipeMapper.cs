using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipesApi.Core.Common.DTOs;
using FoodRecipesApi.Core.Common.Mappers.Interfaces;
using FoodRecipesApi.Domain.Entities;

namespace FoodRecipesApi.Core.Common.Mappers.Implementations
{
    public class RecipeMapper : IRecipeMapper
    {
        public RecipeDto MapToRecipeDto(Recipe r)
        {
            if (r == null) return null!;

            return new RecipeDto
            {
                RecipeId = r.RecipeId,
                Title = r.Title,
                Description = r.Description,
                Author = r.Author != null
                    ? $"{r.Author.Name} {r.Author.Surname}"
                    : null,
                ImageUrl = r.ImageUrl,
                PreparationTimeInMinutes = r.PreparationTimeInMinutes,
                TotalTimeInMinutes = r.TotalTimeInMinutes,
                RecipeSteps = r.RecipeSteps?
                    .OrderBy(s => s.StepNumber)
                    .Select(s => new RecipeStepDto
                    {
                        RecipeStepId = s.RecipeStepId,
                        StepNumber = s.StepNumber,
                        Instruction = s.Instruction,
                        ImageUrl = s.ImageUrl
                    })
                    .ToList(),
                RecipeIngredients = r.RecipeIngredients?
                    .Select(ri => new IngredientDto
                    {
                        IngredientId = ri.Ingredient.IngredientId,
                        Name = ri.Ingredient.Name,
                        Quantity = new IngredientQuantityDto
                        {
                            Amount = ri.Ingredient.Quantity.Amount,
                            MeasurementUnit = ri.Ingredient.Quantity.MeasurementUnit.Unit
                        }
                    })
                    .ToList()
            };
        }
        public Recipe MapFromCreateDtoToEntity(RecipeCreateDto dto)
        {
            if (dto == null) return null!;

            var entity = new Recipe
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = new Author
                {
                    Name = dto.Author.Name,
                    Surname = dto.Author.Surname,
                    ImageUrl = dto.Author.ImageUrl
                },
                RecipeSteps = dto.RecipeSteps?
                    .Select((s, i) => new RecipeStep
                    {
                        StepNumber = s.StepNumber == 0 ? i + 1 : s.StepNumber,
                        Instruction = s.Instruction,
                        ImageUrl = s.ImageUrl
                    })
                    .ToList(),
                ImageUrl = dto.ImageUrl,
                PreparationTimeInMinutes = dto.PreparationTimeInMinutes,
                RecipeIngredients = dto.RecipeIngredient?
                        .Select(ri => new RecipeIngredient
                        {
                            Ingredient = new Ingredient
                            {
                                Name = ri.Name,
                                Quantity = new IngredientQuantity
                                {
                                    Amount = ri.Quantity.Amount,
                                    MeasurementUnit = new MeasurementUnit
                                    {
                                        Unit = ri.Quantity.MeasurementUnit
                                    }
                                }
                            }
                        })
                        .ToList()
            };
            return entity;
        }
    }
}