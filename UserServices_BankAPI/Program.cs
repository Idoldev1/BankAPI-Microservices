using Microsoft.EntityFrameworkCore;
using UserServices_BankAPI;
using UserServices_BankAPI.Repository;
using UserServices_BankAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "User Services for BankAPI",
        Version = "v2",
        Description = "Next generation banking services right here",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Olayinka Idowu",
            Email = "idolayinka98@gmail.com",
            Url = new Uri("https://github.com/Idoldev1")
        }
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    var prefix = string.IsNullOrEmpty(x.RoutePrefix) ? "." : "..";
    x.SwaggerEndpoint($"{prefix}/swagger/v2/swagger.json", "User Services for BankAPI");
});

app.MapControllers();

app.Run();
