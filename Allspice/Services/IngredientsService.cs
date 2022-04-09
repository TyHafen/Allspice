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

        // internal string Remove(int id, Account userInfo)
        // {
        //     Ingredient ingredient = _ingredientsRepo.GetById(id);
        //     return _ingredientsRepo.Remove(id);
        // }
    }
}
