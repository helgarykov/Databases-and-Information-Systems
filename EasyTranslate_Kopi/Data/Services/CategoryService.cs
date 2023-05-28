using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class CategoryService : ICategoryService
{
    public IDbConnection Connection { get; }

    public CategoryService(IDbConnection connection)
    {
        Connection = connection;
    }
    public IEnumerable<Category> DetCategoryViaDapper()
    {
        {
            var sql = "SELECT * FROM Category WHERE CategoryName = 'category1'";

            var category = Connection.Query<Category>(sql);

            return category;
        }
    }
}