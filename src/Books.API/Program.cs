using System.Reflection;
using Books.API;
using Books.Core;
using Books.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title= "Books Website API",
        Description = "Lorem ipsum dolor sit amet",
        Contact = new OpenApiContact() { Name = "Vasyl Tyshchuk", Email = "vasyl.tyshchuk@oa.edu.ua" },
        License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
   options.IncludeXmlComments(xmlPath);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(AppAutoMapper).Assembly);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<GenreRepository>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<PublisherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
