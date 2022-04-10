using System;
using System.Data;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;
        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Step Create(Step stepData)
        {
            string sql = @"INSERT INTO steps
          (position, body, recipeId) 
          VALUE (@Position, @Body, @RecipeId);
           SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, stepData);
            return stepData;
        }

        internal string Remove(int id)
        {
            string sql = @"DELETE FROM steps WHERE id = @id LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("Cant delete");
        }
        internal Step GetById(int id)
        {
            string sql = "SELECT * FROM steps WHERE id = @id;";
            return _db.QueryFirstOrDefault<Step>(sql, new { id });
        }

        internal void Edit(Step original)
        {
            string sql = @"UPDATE steps SET 
         position = @Position, 
         body = @Body,
         recipeId = @recipeId
         WHERE id = @id;";
            _db.Execute(sql, original);
        }
    }
}