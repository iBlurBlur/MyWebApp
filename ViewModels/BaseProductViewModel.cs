using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyWebApp.ViewModels;


public class BaseProductViewModel
{
    [Required, MaxLength(100)]
    [MinLength(3, ErrorMessage = "Product name must be more than 3 characters.")]
    public string Name { get; set; } = null!;
    [Required, MaxLength(25)]
    public string ProductNumber { get; set; } = null!;
    [MaxLength(15)]
    public string? Color { get; set; }
    [Required(ErrorMessage = "The value Price is Required")]
    [Range(0, 100_000)]
    public decimal Price { get; set; }
    [MaxLength(5)]
    public string? Size { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
    public decimal? Weight { get; set; }
    [MaxLength(50)]
    public string? ThumbnailPhotoFileName { get; set; }
}
public class ProductViewModel : BaseProductViewModel
{
    [Required]
    public int ProductId { get; set; }
    public byte[]? ThumbNailPhoto { get; set; }
    public ProductCategoryViewModel? ProductCategory { get; set; }
}
public class CreateProductViewModel : BaseProductViewModel
{
    [DataType(DataType.Upload)]
    [Display(Name = "Upload Image")]
    public IFormFile? UploadFile { get; set; }
    [Required]
    [Display(Name = "Category")]
    public int ProductCategoryId { get; set; }
}
public class EditProductViewModel : CreateProductViewModel
{
    [Required]
    [HiddenInput]
    public int ProductId { get; set; }
    [HiddenInput]
    public byte[]? ThumbNailPhoto { get; set; }
}