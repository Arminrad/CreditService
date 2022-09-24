using CreditApi.Filters;
using CreditService.Repository.RepositoryImplementation;
using Log4netWebapi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Repository.Connection;
using Repository.RepositoryImplementation;
using Repository.RepositoryInterface;
using Repository.UnitOfWorks;
using Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//nlog
// var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
// builder.Logging.ClearProviders();
// builder.Host.UseNLog();
//log4net
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddLog4Net("log4net.config");
//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CallerIdAuthorization>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CreditContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddApiVersioning(cfg =>
{
    cfg.DefaultApiVersion = new ApiVersion(1, 1);
    cfg.AssumeDefaultVersionWhenUnspecified = true;
    cfg.ReportApiVersions = true;
    cfg.ApiVersionReader = ApiVersionReader.Combine(
        new HeaderApiVersionReader(""),
        new QueryStringApiVersionReader(""));
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var lf = app.Services.GetRequiredService<ILoggerFactory>();
app.ConfigureBuildInExceptionHandler(lf);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();