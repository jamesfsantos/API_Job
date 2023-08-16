using Jobs.Core.Config;
using Jobs.Core.Repositories.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataBase();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.RegisterMappers();
builder.Services.RegisterValidators();
builder.Services.RegisterAssemblers();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.RegisterMiddlerwares();

app.MapControllers();




app.Run();

