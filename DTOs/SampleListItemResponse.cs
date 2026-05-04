namespace MyApp.DTOs; // ← replace MyApp

public class SampleListItemResponse // ← rename, e.g. CustomerListItemResponse
{
    public int Id { get; set; }             // ← rename + add/remove properties to match exam GET-list JSON
    public string Name { get; set; } = null!; // ← rename/replace
}
