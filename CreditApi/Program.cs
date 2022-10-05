using System.Reflection;
using CreditApi.Filters;
using CreditApi.ServicesExtensions;
using CreditApi.ServicesExtensions.Swagger;
using Log4netWebapi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository.Connection;
using Repository.RepositoryImplementation;
using Repository.RepositoryInterface;
using Repository.UnitOfWorks;
using Services;
using Swashbuckle.AspNetCore.Swagger;



var builder = WebApplication.CreateBuilder(args);


//log4net
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddLog4Net("log4net.config");
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);


//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

//CallerId authorization
builder.Services.AddScoped<CallerIdAuthorization>();
builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
// builder.Services.AddSwaggerGen(option =>
// {
//     option.SwaggerDoc("v1", new OpenApiInfo {Title = "CreditService", Version = "v1"});
// });


builder.Services.AddDbContext<CreditContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCustomApiVersioning();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

// app.UseSwagger();
// app.UseSwaggerUI(options =>
// {
//     options.SwaggerEndpoint("/swagger/v1/swagger.json" , "Doc-v1");
// });
app.UseSwaggerAndUI();


var lf = app.Services.GetRequiredService<ILoggerFactory>();
app.ConfigureBuildInExceptionHandler(lf);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();