using Image.Grpc.Service;
using Image.Grpc.Service.Models;
using Image.Grpc.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddMongoDb(builder.Environment.IsDevelopment())
                .AddMongoRepository<FoodImage>("foodImages")
                .AddMongoRepository<RestaurantImage>("restaurantImages")
                .AddMongoRepository<FoodCategoryImage>("foodCategoryImages");

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ImagesService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
