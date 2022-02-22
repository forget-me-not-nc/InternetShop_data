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

//start app
var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.Run();
