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

        internal Step Edit(Step updates, Account userInfo)
        {
            Recipe recipe = _recipeService.GetRecipeById(updates.Id);
            updates.RecipeId = recipe.Id;
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("not yours to edit");
            }
            Step original = _stepsRepo.GetById(updates.Id);
            original.Position = updates.Position;
            original.Body = updates.Body ?? original.Body;
            _stepsRepo.Edit(original);
            return original;
        }
    }
}