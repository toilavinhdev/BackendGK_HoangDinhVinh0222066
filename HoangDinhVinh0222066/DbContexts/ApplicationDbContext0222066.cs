using HoangDinhVinh0222066.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoangDinhVinh0222066.DbContexts;

public class ApplicationDbContext0222066(DbContextOptions<ApplicationDbContext0222066> options) : DbContext(options)
{
    public DbSet<Product0222066> Products { get; set; } = default!;
}