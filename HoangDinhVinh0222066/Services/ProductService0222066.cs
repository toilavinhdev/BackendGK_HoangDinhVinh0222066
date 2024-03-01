using HoangDinhVinh0222066.DbContexts;
using HoangDinhVinh0222066.DTOs;
using HoangDinhVinh0222066.Entities;
using HoangDinhVinh0222066.Exceptions;
using HoangDinhVinh0222066.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HoangDinhVinh0222066.Services;

public interface IProductService0222066
{
    Task<Product0222066> GetProductAsync(int id);
    Task<List<Product0222066>> ListProductAsync(ListProductRequest0222066 request);
    Task AddProductAsync(CreateProductRequest0222066 request);
    Task UpdateProductAsync(UpdateProductRequest0222066 request);
    Task DeleteProductAsync(int id);
}

public class ProductService0222066(ApplicationDbContext0222066 context) : IProductService0222066
{
    public async Task<Product0222066> GetProductAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        UserFriendlyException0222066.ThrowIfNotFound(product);

        return product;
    }

    public async Task<List<Product0222066>> ListProductAsync(ListProductRequest0222066 request)
    {
        var query = context.Products
            .AsQueryable();

        if (request.Search is not null)
        {
            query = query.Where(x => x.Name.Contains(request.Search));
        }

        if (request.FromPrice is not null && request.ToPrice is not null)
        {
            query = query.Where(x => x.Price >= request.FromPrice && x.Price <= request.ToPrice);
        }

        if (request.Sort is not null)
        {
            var asc = request.Sort.StartsWith('+');
            if (request.Sort.Contains("name")) query = query.ToOrderedQuery(x => x.Name, asc);
            if (request.Sort.Contains("price")) query = query.ToOrderedQuery(x => x.Price, asc);
        }

        return await query.ToListAsync();
    }
    
    public async Task AddProductAsync(CreateProductRequest0222066 request)
    {
        if (await context.Products.AnyAsync(x => x.Code == request.Code))
            throw new UserFriendlyException0222066("Duplicate Product Code");
        
        await context.Products.AddAsync(new Product0222066()
        {
            Code = request.Code,
            Name = request.Name,
            Quantity = request.Quantity,
            Price = request.Price
        });
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(UpdateProductRequest0222066 request)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
        
        UserFriendlyException0222066.ThrowIfNotFound(product);

        product.Code = request.Code;
        product.Name = request.Name;
        product.Quantity = request.Quantity;
        product.Price = request.Price;

        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        UserFriendlyException0222066.ThrowIfNotFound(product);

        context.Remove(product);
        await context.SaveChangesAsync();
    }
}