using AvvikelseApi.Data;
using AvvikelseApi.Repositories;
using AvvikelseApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<AvvikelseRepository>();
builder.Services.AddScoped<UsersRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Avvikelse API running");

app.MapAvvikelseEndpoints();
app.MapLoginEndpoints();

app.Run();
