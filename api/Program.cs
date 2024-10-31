using api.Data; // Assuming this is where your DbContext class is
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add user secrets (if you are using them, make sure this is configured properly)
builder.Configuration.AddUserSecrets<Program>();

// Add DbContext with the correct connection string
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    // Fetch connection string from appsettings.json or appsettings.Development.json
    options.UseSqlServer(builder.Configuration["ConnectionString:KMDListing:SqlDb"]);
});
builder.Services.AddScoped<IDataProcessor30ListingDataRepository, DataProcessor30ListingDataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
