using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Concretes;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.Context;
using ShoppingAPI.Repositories.Abstract;
using ShoppingAPI.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShoppingDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
builder.Services.AddScoped<IAccountTransacitonRepository, AccountTransactionRepository>();
builder.Services.AddScoped<UserValidations>();
builder.Services.AddScoped<IUserService, UserMenager>();
builder.Services.AddScoped<ProductValidations>();
builder.Services.AddScoped<IProductService, ProductMenager>();
builder.Services.AddScoped<CategoryValidations>();
builder.Services.AddScoped<ICategoryService, CategoryMenager>();
builder.Services.AddScoped<ProductTransactionValidations>();
builder.Services.AddScoped<IProductTransactionService, ProductTransactionMenager>();
builder.Services.AddScoped<OrderValidations>();
builder.Services.AddScoped<IOrderService, OrderMenager>();
builder.Services.AddScoped<OrderDetailValidations>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailMenager>();
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
