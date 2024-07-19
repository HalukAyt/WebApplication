using WebApp.Core.Settings;
using WebApp.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure MongoDB settings
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoConnection"));

// Register MongoDbContext as a service
builder.Services.AddSingleton<MongoDbContext>();

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
