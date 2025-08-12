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
        if (r is null) throw new ArgumentNullException(nameof(r));

        return new RecipeDto
        {
            RecipeId = r.RecipeId,
            Title = r.Title,
            Description = r.Description,
            Author = r.Author != null ? $"{r.Author.Name} {r.Author.Surname}" : null,
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
        if (dto is null) throw new ArgumentNullException(nameof(dto));
        if (dto.Author is null) throw new ArgumentException("Author is required.", nameof(dto));

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
            ImageUrl = dto.ImageUrl,
            PreparationTimeInMinutes = dto.PreparationTimeInMinutes,
            TotalTimeInMinutes = dto.TotalTimeInMinutes,
            RecipeIngredients = (dto.RecipeIngredient ?? Enumerable.Empty<IngredientCreateDto>())
                .Select(ri => new RecipeIngredient
                {
                    Ingredient = new Ingredient
                    {
                        Name = ri.Name,
                        Quantity = new IngredientQuantity
                        {
                            Amount = ri.Quantity.Amount,
                            MeasurementUnit = new MeasurementUnit { Unit = ri.Quantity.MeasurementUnit }
                        }
                    }
                })
                .ToList()
        };

        // Mutate the existing collection (private setter friendly)
        entity.RecipeSteps.Clear();
        var steps = dto.RecipeSteps ?? Enumerable.Empty<RecipeStepCreateDto>();
        int i = 0;
        foreach (var s in steps)
        {
            i++;
            entity.RecipeSteps.Add(new RecipeStep
            {
                StepNumber = s.StepNumber == 0 ? i : s.StepNumber,
                Instruction = s.Instruction,
                ImageUrl = s.ImageUrl
            });
        }

        return entity;
    }
}

}