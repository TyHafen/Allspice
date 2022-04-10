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
            string sql = @"DELETE FROM steps WHERE id = @id LIMIt 1;";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("Cant delete");
        }

    }
}