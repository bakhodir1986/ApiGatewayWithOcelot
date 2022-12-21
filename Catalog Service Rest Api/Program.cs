using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Catalog_Service_BLL;
using Catalog_Service_DAL;
using Microsoft.EntityFrameworkCore;
using Catalog_Service_BLL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<CatalogDbContext>();
builder.Services.AddGraphQLServer().AddQueryType<QueryGrQL>().
    AddProjections().AddFiltering().AddSorting();
//builder.Services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
//{
//    var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
//    return new UrlHelper(actionContext);

//});
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var client = new CatalogDbContext())
{
    client.Database.EnsureCreated();
    client.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();
