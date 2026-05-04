using MyApp.DTOs;         // ← replace MyApp
using MyApp.Repositories; // ← replace MyApp

namespace MyApp.Services; // ← replace MyApp

public class SampleService : ISampleService // ← rename both, e.g. CustomerService : ICustomerService
{
    private readonly ISampleRepository _repository; // ← replace ISampleRepository

    public SampleService(ISampleRepository repository) // ← replace ISampleRepository
    {
        _repository = repository;
    }

    public Task<SampleResponse?> GetDetailsAsync(int id)                        // ← rename method + return type to match interface
        => _repository.GetDetailsAsync(id);                                      // ← rename to match your repository

    public Task<List<SampleListItemResponse>> GetAllAsync(string? filter)        // ← rename + filter param
        => _repository.GetAllAsync(filter);                                      // ← rename to match your repository

    public Task CreateItemAsync(int id, CreateSampleRequest request)             // ← rename method + request type to match interface
        => _repository.CreateItemAsync(id, request);                             // ← rename to match your repository

    public Task<bool> UpdateAsync(int id, UpdateSampleRequest request)           // ← rename + request type
        => _repository.UpdateAsync(id, request);                                 // ← rename to match your repository

    public Task<bool> DeleteAsync(int id)                                        // ← rename
        => _repository.DeleteAsync(id);                                          // ← rename to match your repository
}
