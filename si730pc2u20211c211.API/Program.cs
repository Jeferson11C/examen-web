using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730pc2u20211c211.API.Hr.Application.Internal.CommandServices;
using si730pc2u20211c211.API.Hr.Application.Internal.QueryServices;
using si730pc2u20211c211.API.Hr.Domain.Repositories;
using si730pc2u20211c211.API.Hr.Domain.Services;
using si730pc2u20211c211.API.Hr.Infrastructure.Persistence.EFC.Repositories;
using si730pc2u20211c211.API.Shared.Domain.Repositories;
using si730pc2u20211c211.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u20211c211.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si730pc2u20211c211.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "si730pc2u20211c211.API",
                Version = "v1",
                Description = "si730pc2u20211c211.API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),

                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJoinRequestCommandService, JoinRequestCommadService>();
builder.Services.AddScoped<IJoinRequestQueryService, JoinRequestQueryService>();
builder.Services.AddScoped<IJoinRequestRepository, JoinRequestRepository>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();