using System.Collections.Generic;
using Allspice.Repositories;
using Allspice.Models;

namespace Allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepo;
        public RecipesService(RecipesRepository recipesRepo)
        {
            _recipesRepo = recipesRepo;
        }

        internal List<Recipe> GetAll()
        {
            return _recipesRepo.GetAll();
        }

        internal Recipe Create(Recipe recipeData)
        {
            return _recipesRepo.Create(recipeData);
        }
        internal string Delete(int id, Account user)
        {
            Recipe recipe = _recipesRepo.GetById(id);
            if (recipe.CreatorId != user.Id)
            {
                throw new System.Exception("not yours to delete");
            }
            return _recipesRepo.Delete(id);
        }

        internal Recipe GetRecipeById(int id)
        {
            Recipe found = _recipesRepo.GetById(id);
            if (found == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return found;
        }

        internal List<Step> GetSteps(int id)
        {
            return _recipesRepo.Getsteps(id);
        }
    }
}