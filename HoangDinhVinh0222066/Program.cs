using System.Net;
using HoangDinhVinh0222066.DbContexts;
using HoangDinhVinh0222066.Exceptions;
using HoangDinhVinh0222066.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("SQLServerConfig:ConnectionString");

var services = builder.Services;
services.AddCors();
services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = action =>
    {
        var errors = action.ModelState.Values.Where(x => x.Errors.Count > 0)
            .SelectMany(y => y.Errors)
            .Select(x => x.ErrorMessage)
            .ToArray();
        throw new UserFriendlyException0222066(string.Join(";", errors));
    };
});
services.AddEndpointsApiExplorer().AddSwaggerGen();
services.AddDbContext<ApplicationDbContext0222066>(o => o.UseSqlServer(connectionString));
services.AddScoped<IProductService0222066, ProductService0222066>();

var app = builder.Build();
app.UseExceptionHandler(errApp => errApp.Run(async ctx =>
{
    var feature = ctx.Features.Get<IExceptionHandlerFeature>();
    if (feature is not null)
    {
        var reason = feature.Error.Message;
        var status = feature.Error switch
        {
            UserFriendlyException0222066 => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };
        ctx.Response.StatusCode = status;
        ctx.Response.ContentType = "application/problem+json";
        await ctx.Response.WriteAsJsonAsync<object>(new {Status = status, Error = reason });
    }
}));
app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseSwagger().UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();