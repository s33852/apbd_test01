using Test.DTOs;

namespace Test.Repositories; 

public interface IVendorsRepository 
{
    Task<VendorsProductsResponse?> GetDetailsAsync(int id);
    Task<List<VendorProductsResponse>> GetAllAsync(string? filter);
    Task CreateProducts(int id, CreateProductsRequest request);

}
