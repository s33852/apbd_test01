using Test.Repositories; 
using Test.Services;     

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISampleRepository, SampleRepository>(); // ← replace ISampleRepository and SampleRepository with your names
builder.Services.AddScoped<ISampleService, SampleService>();        // ← replace ISampleService and SampleService with your names

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
