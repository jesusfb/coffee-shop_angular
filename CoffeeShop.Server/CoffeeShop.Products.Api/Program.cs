using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoffeeShop.Products.Api.Mapping;
using CoffeeShop.Products.Api.Storage;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConnection"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    var assembly = Assembly.GetAssembly(typeof(Program));
    containerBuilder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces();

    containerBuilder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
        "CoffeeShop API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigration(app);
//SeedDatabase(app);

app.Run();

void ApplyMigration(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}

//void SeedDatabase(WebApplication app)
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
//        SeedData.SeedDatabase(dataContext);
//    }
//}