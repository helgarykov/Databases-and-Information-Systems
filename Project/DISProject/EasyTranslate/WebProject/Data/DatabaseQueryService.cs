using System.Data;
using Dapper;
using Npgsql;

namespace BlazorProject.Data;
/*
An instance of a service class
Contains LINQ method (-(() and Dapper methods (:-)) 
 */
public class DatabaseQueryService
{
    public DatabaseQueryService(IDbConnection connection)
    {
        
    }
    
    /* using LINQ */
    public IEnumerable<Translator> GetTranslatorsViaRawSql()
    {
        IDbConnection connection = new NpgsqlConnection("User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;");
        
        connection.Open();

        IDbCommand command = connection.CreateCommand();
        command.CommandText = "SELECT id, title FROM Translator;";
        var reader = command.ExecuteReader();

        List<Translator> results = new();

        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var title = reader.GetString(1);

            var result = new Translator() {Id = id, Title = title};
            
            results.Add(result);
        }
        
        connection.Close();

        return results;
    }

    /* The same as above, but smarter with Dapper. */
    public IEnumerable<Translator> GetTranslatorsViaDapper()
    {
        IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;Host=localhost;Port=5433;Database=Easy_Translate;");
        var translators = connection.Query<Translator>("SELECT id, title FROM Translator;");
        return translators;
        
    }
}


public class Translator: DataQueryServiceInterface
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}
