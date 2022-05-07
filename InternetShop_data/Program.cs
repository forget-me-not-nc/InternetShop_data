using InternetShop_data.Data.Repositories.AuthorRepo;
using InternetShop_data.Data.Repositories.BookRepo;
using InternetShop_data.Data.Repositories.CategoryRepo;
using InternetShop_data.Data.Services.AuthorServices;
using InternetShop_data.Data.Services.AuthorServices.Impls;
using InternetShop_data.Data.Services.BookServices;
using InternetShop_data.Data.Services.BookServices.Impls;
using InternetShop_data.Data.Services.CategoryServices;
using InternetShop_data.Data.Services.CategoryServices.Impls;
using InternetShop_data.Data.Settings;
using InternetShop_data.Data.UnitOfWork;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//config app

DbContext dbContext = new();
builder.Configuration.Bind(nameof(DbContext), dbContext);
AuthorRepository authorRepository = new(dbContext);

//controllers
builder.Services.AddControllers();

//db settings
builder.Services.AddSingleton(dbContext);

//repos
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

//services
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<IAuthorService, AuthorServiceImpl>();
builder.Services.AddScoped<IBookService, BookServiceImpl>();

//unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

//start app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntenetShop_data v1");
    });

}

app.UseRouting();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
