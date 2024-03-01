using HoangDinhVinh0222066.DTOs;
using HoangDinhVinh0222066.Entities;
using HoangDinhVinh0222066.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoangDinhVinh0222066.Controllers;

[ApiController]
[Route("api/v1/product")]
public class ProductController0222066(IProductService0222066 productService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<Product0222066> Get(int id)
    {
        return await productService.GetProductAsync(id);
    }
    
    [HttpGet("list")]
    public async Task<List<Product0222066>> List([FromQuery] ListProductRequest0222066 request)
    {
        return await productService.ListProductAsync(request);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest0222066 request)
    {
        await productService.AddProductAsync(request);
        return Ok("Tạo sản phẩm thành công");
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest0222066 request)
    {
        await productService.UpdateProductAsync(request);
        return Ok("Cập nhật sản phẩm thành công");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await productService.DeleteProductAsync(id);
        return Ok("Xóa sản phẩm thành công");
    }
}