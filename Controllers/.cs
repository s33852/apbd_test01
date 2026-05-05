using Test.DTOs;       
using Test.Exceptions;  
using Test.Services;    
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers; 

[ApiController]
[Route("api/Products")]
public class SampleController : ControllerBase // ← rename SampleController, e.g. CustomersController
{
    private readonly ISampleService _sampleService; // ← replace ISampleService

    public SampleController(ISampleService sampleService) // ← replace both ISampleService and sampleService
    {
        _sampleService = sampleService;
    }

    [HttpGet] // ← GET /api/samples?filter=abc  — remove [FromQuery] param if the exam has no filter
    public async Task<IActionResult> GetAll([FromQuery] string? filter) // ← rename GetAll
    {
        var results = await _sampleService.GetAllAsync(filter); // ← replace GetAllAsync with your method name
        return Ok(results);
    }

    [HttpGet("{id:int}/details")] // ← replace "details" with the segment from exam URL, e.g. "rentals"
    public async Task<IActionResult> GetDetails(int id) // ← rename GetDetails, e.g. GetCustomerRentals
    {
        var result = await _sampleService.GetDetailsAsync(id); // ← replace GetDetailsAsync with your method name

        if (result is null)
            return NotFound($"Sample with id {id} was not found."); // ← replace "Sample" with your resource name

        return Ok(result);
    }
    [HttpPost("{id:int}/items")] // ← replace "items" with the segment from exam URL, e.g. "rentals"
    public async Task<IActionResult> CreateItem(int id, [FromBody] CreateSampleRequest request) // ← rename CreateItem + CreateSampleRequest
    {
        try
        {
            await _sampleService.CreateItemAsync(id, request); // ← replace CreateItemAsync with your method name
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        return CreatedAtAction(nameof(GetDetails), new { id }, null); // ← replace GetDetails with your GET method name
    }
}
