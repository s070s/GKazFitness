using GKazFitness.API.DatabaseClasses;
using GKazFitness.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .AllowAnyOrigin()     // Allows all origins
            .AllowAnyMethod()     // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader());   // Allows all headers
});
#endregion

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database configuration (inject ConnectionService)
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // Apply the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
