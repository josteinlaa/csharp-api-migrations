using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.EndPoints;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<Pizza>, Repository<Pizza>>();
builder.Services.AddScoped<IRepository<Topping>, Repository<Topping>>();
builder.Services.AddScoped<IRepository<OrderToppings>, Repository<OrderToppings>>();


builder.Services.AddAutoMapper(typeof(Program));


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
app.ConfigurePizzaShopApi(); // Ensure this line is present to register the endpoints
app.SeedPizzaShopApi();
app.Run();
