using System.Collections.Generic;
using System.Data;
using Allspice.Models;
using Dapper;
using System.Linq;

namespace Allspice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;
        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"
           SELECT r.*, a.* FROM recipes r JOIN accounts a WHERE a.id = r.creatorId;";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => { recipe.Creator = account; return recipe; }).ToList();
        }

        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"INSERT INTO recipes 
            (title, subtitle, category, creatorId)
             VALUES 
             (@Title, @Subtitle, @Category, @CreatorId);
              SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }


    }
}
