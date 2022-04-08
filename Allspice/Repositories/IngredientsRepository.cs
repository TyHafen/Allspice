using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
    public class IngredientsRepository
    {

        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Ingredient> GetAll()
        {
            string sql = "SELECT * FROM ingredients";
            return _db.Query<Ingredient>(sql).ToList();
        }
    }
}