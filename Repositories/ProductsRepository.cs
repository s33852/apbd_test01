using Test.DTOs;        
using Test.Exceptions;  
using Microsoft.Data.SqlClient;

namespace Test.Repositories; 

public class ProductsRepository : IProductsRepository 
{
    private readonly string _connectionString;

    public ProductsRepository(IConfiguration configuration) 
    {
        _connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Missing 'Default' connection string.");
    }

    public async Task<ProductsResponse?> GetDetailsAsync(int id) 
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        string Name; 
        string Description; 

        await using (var cmd = new SqlCommand(
            "SELECT Name, Description FROM Products WHERE Id = @id;", 
            connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null; 

            Name = reader.GetString(0); 
            Description = reader.GetString(1); 
        }

        var VendoorsByCode = new Dictionary<int, VendoorsResponse>(); 

        await using (var cmd = new SqlCommand(@"
            SELECT Code, Name
            FROM    Vendoors v                                  
            JOIN    VendoorProducts s  ON VendorCode = v.Code
            LEFT JOIN g  ON g.VendorCode   = v.Code    
            WHERE   c.Code = @id
            ORDER BY c.;",                                       
            connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            await using var reader = await cmd.ExecuteReaderAsync();
    }
}
