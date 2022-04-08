using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientRepo;

        public IngredientsService(IngredientsRepository ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        internal List<Ingredient> GetAll()
        {
            return _ingredientRepo.GetAll();
        }
    }
}