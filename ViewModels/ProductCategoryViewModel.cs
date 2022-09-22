namespace MyWebApp.ViewModels;

public class ProductCategoryViewModel
{
    public int ProductCategoryId { get; set; }
    public string Name { get; set; } = null!;
}
public class ParentProductCategoryViewModel : ProductCategoryViewModel
{
    public string ParentName { get; set; } = null!;
}