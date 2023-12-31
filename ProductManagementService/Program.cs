using Microsoft.AspNetCore.Diagnostics;
using ProductManagement.Manager;
using ProductManagement.Models;
using ProductManagement.Repository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<IProductManager, ProductManager>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<ICategoryManager, CategoryManager>();
builder.Services.AddSingleton<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddSingleton<ISubCategoryManager, SubCategoryManager>();



var app = builder.Build();
app.UseExceptionHandler(
    options =>
    {
        options.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    await context.Response.WriteAsync(ex.Error.Message);
                }
            });
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
