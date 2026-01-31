using FluentValidation;
using Microsoft.EntityFrameworkCore;
using payFlow.Api.Middlewares;
using payFlow.Application;
using payFlow.Application.Categories.Validators;
using payFlow.Application.Transactions.DTOs.Requests;
using payFlow.Infra.Data.Context;
using payFlow.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// interface para documenta��o da api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.CustomSchemaIds( type => type.FullName);
});


builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddValidatorsFromAssemblyContaining<TransactionCreate>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PayFlowContext>(option => 
    option.UseSqlServer(connection ?? string.Empty));
builder.Services.AddControllers();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
