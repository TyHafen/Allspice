using System;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
    public class StepsService
    {
        private readonly StepsRepository _stepsRepo;
        private readonly RecipesService _recipeService;
        public StepsService(StepsRepository stepsRepo, RecipesService recipeService)
        {
            _stepsRepo = stepsRepo;
            _recipeService = recipeService;
        }

        internal Step Create(Step stepData, Account userInfo)
        {
            Recipe recipe = _recipeService.GetRecipeById(stepData.RecipeId);
            stepData.RecipeId = recipe.Id;
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("Not yours to add a step to");
            }
            return _stepsRepo.Create(stepData);
        }

        internal string Remove(int id, Account userInfo)
        {
            Recipe recipe = _recipeService.GetRecipeById(id);
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new Exception("Not your step to delete");
            }
            return _stepsRepo.Remove(id);
        }
    }
}