using System;
using System.Data;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite Create(Favorite favoriteData)
        {
            string sql = @"INSERT INTO favorites
            (recipeId, accountId) VALUES (@RecipeId, @AccountId); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }

        internal Favorite GetById(int id)
        {
            string sql = @"SELECT * FROM favorites WHERE id =@id;";
            return _db.QueryFirstOrDefault<Favorite>(sql, new { id });
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM favorites WHERE id = @id LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("couldnt delete");
        }

    }
}