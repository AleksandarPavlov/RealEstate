
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Domain.Services;
using RealEstate.Infrastructure.Persistance;
using RealEstate.Infrastructure.Persistance.Read;
using RealEstate.Infrastructure.Persistance.Write;
using RealEstate.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddHttpClient<ICoordinatesService, CoordinatesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPropertyReadRepository, PropertyReadRepository>();
builder.Services.AddScoped<IPropertyWriteRepository, PropertyWriteRepository>();
builder.Services.AddScoped<ICoordinatesService, CoordinatesService>();
builder.Services.AddScoped<IImageStorageService, ImageStorageService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateApartmentCommandHandler).Assembly));



var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

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
