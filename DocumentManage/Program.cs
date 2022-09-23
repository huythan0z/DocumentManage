
//Scaffold-DbContext "Server=TAKA\SQLEXPRESS;Database=DocumentManage;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
using DocumentManage.IServices;
using DocumentManage.Models;
using DocumentManage.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to db
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Ignore self reference loop
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<DocumentManageContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ITypeServices, TypeServices>();
builder.Services.AddScoped<IUrgencyServices, UrgencyServices>();
builder.Services.AddScoped<IStatusServices, StatusServices>();
builder.Services.AddScoped<IPositionServices, PositionServices>();
builder.Services.AddScoped<IDocumentServices, DocumentServices>();
builder.Services.AddScoped<IProfileServices, ProfileServices>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
  .AllowAnyMethod()
  .AllowAnyHeader()
  .SetIsOriginAllowed(origin => true) // allow any origin
  .AllowCredentials()); // allow credentials


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
