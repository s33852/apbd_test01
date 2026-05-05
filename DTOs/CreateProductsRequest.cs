using System.ComponentModel.DataAnnotations;

namespace Test.DTOs; 

public class CreateProductRequest 
{
    [Required] public int Id { get; set; }                                                          
    [Required] public String Name { get; set; } + null!;                                                  // ← rename to match exam POST body, e.g. RentalDate
    [Required][MinLength(1)] public List<CreateSampleItemRequest> Items { get; set; } = new();      // ← rename Items + CreateSampleItemRequest to match exam POST body
}