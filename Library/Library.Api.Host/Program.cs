using Library.Application;
using Library.Application.Contracts;
using Library.Application.Contracts.Books;
using Library.Application.Contracts.Publishers;
using Library.Application.Contracts.Readers;
using Library.Application.Contracts.Rentals;
using Library.Application.Services;
using Library.Infrastructure;
using Library.Infrastructure.Repositories;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Library.ServiceDefaults;
using Library.Domain.Entities;
using Library.Domain;
using Library.Api.Host;
using Library.Api.Host.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new LibraryProfile());
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("Library"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddTransient<IRepository<Book, Guid>, BookRepository>();
builder.Services.AddTransient<IRepository<Publisher, Guid>, PublisherRepository>();
builder.Services.AddTransient<IRepository<Reader, Guid>, ReaderRepository>();
builder.Services.AddTransient<IRepository<Rental, Guid>, RentalRepository>();

builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IApplicationService<BookDto, BookCreateUpdateDto, Guid>, BookAppService>();
builder.Services.AddScoped<IApplicationService<PublisherDto, PublisherCreateUpdateDto, Guid>, PublisherAppService>();
builder.Services.AddScoped<IApplicationService<ReaderDto, ReaderCreateUpdateDto, Guid>, ReaderAppService>();
builder.Services.AddScoped<IApplicationService<RentalDto, RentalCreateUpdateDto, Guid>, RentalAppService>();

builder.AddMongoDBClient("Library");

builder.Services.AddDbContext<LibraryDbContext>((services, o) =>
{
    var db = services.GetRequiredService<IMongoDatabase>();
    o.UseMongoDB(db.Client, db.DatabaseNamespace.DatabaseName);
});

builder.Services.Configure<RentalStreamingOptions>(builder.Configuration.GetSection("RentalStreaming"));
builder.Services.AddHostedService<RentalStreamingService>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

    if (!dbContext.Books.Any())
    {
        foreach (var family in DataSeeder.Books)
            await dbContext.Books.AddAsync(family);

        foreach (var model in DataSeeder.Publishers)
            await dbContext.Publishers.AddAsync(model);

        foreach (var flight in DataSeeder.Readers)
            await dbContext.Readers.AddAsync(flight);

        foreach (var passenger in DataSeeder.Rentals)
            await dbContext.Rentals.AddAsync(passenger);

        await dbContext.SaveChangesAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
