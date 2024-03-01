// ReSharper disable All

using System.ComponentModel.DataAnnotations;
using HoangDinhVinh0222066.Entities;

namespace HoangDinhVinh0222066.DTOs;

public class CreateProductRequest0222066
{
    [Required]
    public string Code { get; set; } = default!;
    
    [Required]
    public string Name { get; set; } = default!;
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public double Price { get; set; }
}

public class UpdateProductRequest0222066 : Product0222066;

public class ListProductRequest0222066
{
    public string? Sort { get; set; }
    
    public string? Search { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? FromPrice { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? ToPrice { get; set; }
}
