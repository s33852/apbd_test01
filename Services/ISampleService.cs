using MyApp.DTOs; // ← replace MyApp

namespace MyApp.Services; // ← replace MyApp

public interface ISampleService // ← rename, e.g. ICustomerService
{
    Task<SampleResponse?> GetDetailsAsync(int id);                            // ← rename method + return type to match your DTO
    Task<List<SampleListItemResponse>> GetAllAsync(string? filter);           // ← rename + adjust filter param to match exam query params (remove if not needed)
    Task CreateItemAsync(int id, CreateSampleRequest request);                // ← rename method + request type to match your DTO
    Task<bool> UpdateAsync(int id, UpdateSampleRequest request);              // ← rename + request type; returns false → 404
    Task<bool> DeleteAsync(int id);                                           // ← rename; returns false → 404
}
