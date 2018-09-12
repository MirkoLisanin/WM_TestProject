namespace WM_TestProject.Models
{
    public interface IProduct
    {
        string Category { get; set; }
        string Manufacturer { get; set; }
        decimal Price { get; set; }
        string ProductDescription { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
        string Supplier { get; set; }
    }
}