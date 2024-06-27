using HotelManage.Repositery;
using HotelManage.Serivice;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<databasesetings>(
builder.Configuration.GetSection("Mydb")
   );
builder.Services.AddSingleton<IdatabseconnetinSetings>(sp => sp.GetRequiredService<IOptions<databasesetings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("Mydb:ConnectionString")));
//builder.Services.AddTransient<ICategoryserives, CategoryServices>();
builder.Services.AddScoped<IHotelseriveRepositer, HotelseriveRepositer>();
builder.Services.AddScoped<Ijodassingcs, JodAssingRepositery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Options =>

Options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()

);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
