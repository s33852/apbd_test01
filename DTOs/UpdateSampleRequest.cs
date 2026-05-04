using System.ComponentModel.DataAnnotations;

namespace MyApp.DTOs; // ← replace MyApp

public class UpdateSampleRequest // ← rename, e.g. UpdateCustomerRequest
{
    [Required] public string Field1 { get; set; } = null!; // ← rename + add/remove to match exam PUT body
    [Required] public string Field2 { get; set; } = null!; // ← rename/replace
}
