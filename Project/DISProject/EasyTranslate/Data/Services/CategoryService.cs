using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class CategoryService : ICategoryService
{
    public IEnumerable<Category> DetCategoryViaDapper()
    {
        using (IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                               "Host=localhost;Port=5433;" +
                                                               "Database=Easy_Translate;"))
        {
            var sql = "SELECT * FROM Category WHERE CategoryName = 'category1'";

            var category = connection.Query<Category>(sql);

            return category;
        }
    }
}