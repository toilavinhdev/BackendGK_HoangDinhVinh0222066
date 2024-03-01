using System.ComponentModel.DataAnnotations;

namespace HoangDinhVinh0222066.Entities;

public class Product0222066 : BaseEntity0222066
{
    [Required]
    public string Code { get; set; } = default!;
    
    [Required]
    public string Name { get; set; } = default!;
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public double Price { get; set; }
}