
using enterprise_ecommerce.Infrastructure.Persistence;
using enterprise_ecommerce.Infrastructure.Repositories;
using enterpriseecommerce.Application.Features.Products.Commands.CreateProduct;
using enterpriseecommerce.Application.Features.Products.Queries.GetAllProducts;
using enterpriseecommerce.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IProductRepository , ProductRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));
            //builder.Services.AddScoped<CreateProductHandler>();
            //builder.Services.AddScoped<GetAllProductsHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
