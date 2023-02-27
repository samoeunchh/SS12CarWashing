using Microsoft.Data.SqlClient;

namespace SS12CarWashing.Models;

public class AdoDB
{
    public SqlConnection connection;
    public static string conString = @"Server=10.10.10.22;Database=SS12CarWashing;User Id=sa;Password=Strong.Pwd-123;TrustServerCertificate=true;";
    public AdoDB()
    {
        connection = new SqlConnection(conString);
    }
    public SqlDataReader Execute(string sql)
    {
        connection.Open();
        var cmd =new SqlCommand(sql, connection);
        return cmd.ExecuteReader();
    }
}
