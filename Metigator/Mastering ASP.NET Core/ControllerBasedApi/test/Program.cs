
using System.Threading.Tasks;
using test.Data;
using test.Responses;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapGet("/api/products", GetProducts);

app.MapGet("/api/products/{id:guid}", GetProduct);

IResult GetProduct(Guid id, ProductRepository repository)
{
    // Handles retrieving a single product by its unique identifier
    var product = repository.GetProductById(id);

    return product is null ? Results.NotFound() : Results.Ok(ProductResponse.FromModel(product));
}

async Task<IResult> GetProducts(ProductRepository repository)
{
    // Handles retrieving a list of products
    await Task.Delay(100);
    return Results.Ok(repository.GetProductsPage());
}
app.Run();
