using GoalTrackingAPI.Configuration;
using GoalTrackingAPI.Database;
using GoalTrackingAPI.Database.Models;
using GoalTrackingAPI.Domain.Services;
using GoalTrackingAPI.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddJWTAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerConfiguration();

// Add database;
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<MongoDatabase>();

// Add services
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ObjectiveService>();
builder.Services.AddSingleton<IdentityService>()
    .Configure<JwtTokenConfig>(builder.Configuration.GetSection("JwtTokens"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
