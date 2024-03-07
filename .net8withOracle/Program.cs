using Microsoft.EntityFrameworkCore;
using vlife.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEntityFrameworkOracle()
    .AddDbContext<Context>(options => options.UseOracle(connectionString));

builder.Services.AddScoped<VideoRepository>();

builder.Services.AddLogging(config =>
{
    config.AddConsole(); 
    config.AddDebug(); 
});

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
