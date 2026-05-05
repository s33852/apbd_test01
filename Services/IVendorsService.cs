using Test.DTOs; 

namespace Test.Services; 

public interface IVendorsService 
{
    Task<VendorsProductsResponse?> GetDetailsAsync(int id);                            
    Task<List<VendorProductsResponse>> GetAllAsync(string? filter);           
    Task CreateProducts(int id, CreateProductsRequest request);                
     
}
