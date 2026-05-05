namespace Test.DTOs; 

public class ProductsResponse 
{
    public int Id { get; set; }                                            
    public String Name { get; set; } = null!;
    public String Description { get; set; } = null!;                                   
    public decimal StickerPrice { get; set; }                             
    public int ProductTypeId { get; set; }                             
    public int MarkerId { get; set; }                             
    public List<SampleProductsResponse> Items { get; set; } = new();          
}
