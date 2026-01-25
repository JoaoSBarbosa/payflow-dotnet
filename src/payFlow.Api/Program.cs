using FluentValidation;
using payFlow.Application.DTOs.Transactions.Requests;
using payFlow.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfra(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<TransactionCreate>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
