using FluentValidation;
using Microsoft.EntityFrameworkCore;
using payFlow.Api.Middlewares;
using payFlow.Application.DTOs.Transactions.Requests;
using payFlow.Infra.Data;
using payFlow.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// interface para documenta��o da api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.CustomSchemaIds( type => type.FullName);
});


builder.Services.AddInfra(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<TransactionCreate>();
builder.Services.AddDbContext<PayFlowContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("LinuxConnection")));
builder.Services.AddControllers();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
