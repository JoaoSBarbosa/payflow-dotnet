using FluentValidation;
using payFlow.Api.Middlewares;
using payFlow.Application.DTOs.Transactions.Requests;
using payFlow.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfra(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<TransactionCreate>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();
