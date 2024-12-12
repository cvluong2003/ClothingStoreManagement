using API.Service;
using API.Model;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using API.Mapping;
using API.MiddleWare;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<StoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddAutoMapper(typeof(MappingProduct));
        builder.Services.AddAutoMapper(typeof(MappingCategory));
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductModel, ProductModel>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // app.UseSwagger();
            // app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseMiddleware<RequestLoggingMiddleware>();

        app.MapControllers();

        app.Run();
    }
}