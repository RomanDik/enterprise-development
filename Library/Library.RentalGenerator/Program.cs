using Library.RentalGenerator.Services;
using Library.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapDefaultEndpoints();
app.MapGrpcService<RentalGeneratorService>();

app.MapGet("/", () => "Rental Generator gRPC Service. Use gRPC client to connect.");

app.Run();