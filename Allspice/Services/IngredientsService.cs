using System;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepo;
        private readonly RecipesService _recipesService;

        public IngredientsService(IngredientsRepository ingredientsRepo, RecipesService recipesService)
        {
            _ingredientsRepo = ingredientsRepo;
            _recipesService = recipesService;
        }



        internal Ingredient Create(Ingredient ingredientData, string userId)
        {
            Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);
            if (recipe.CreatorId != userId)
            {
                throw new Exception("This isnt your recipe");
            }
            return _ingredientsRepo.Create(ingredientData);
        }

        internal List<Ingredient> GetAll(int id)
        {
            return _ingredientsRepo.GetAll(id);
        }



        internal string Remove(int id, Account userInfo)
        {
            Ingredient ingredient = _ingredientsRepo.GetById(id);
            Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);

            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("not yours to delete");
            }
            return _ingredientsRepo.Remove(id);
        }

        internal Ingredient Edit(Ingredient updates, Account userInfo)
        {
            Recipe recipe = _recipesService.GetRecipeById(updates.RecipeId);
            updates.RecipeId = recipe.Id;
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("Not your recipe to edit");
            }
            Ingredient original = _ingredientsRepo.GetById(updates.Id);
            original.Name = updates.Name ?? original.Name;
            original.Quantity = updates.Quantity ?? original.Quantity;
            _ingredientsRepo.Edit(original);
            return original;
        }
    }
}
