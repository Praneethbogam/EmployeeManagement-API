
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using TestEmployeeManagement.Data;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins(allowedOrigins)
        .AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// OPTIONAL – comment during training
//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//    .AddNegotiate();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<ISalaryService, SalaryService>();

builder.Services.AddDbContext<ApplicationDBcontext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

