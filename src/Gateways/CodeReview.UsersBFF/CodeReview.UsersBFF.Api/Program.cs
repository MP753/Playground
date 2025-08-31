using Carter;
using CodeReview.UsersBFF.Api;
using CodeReview.UsersBFF.Api.Middleware;
using CodeReview.UsersBFF.Services.HttpClients;
using CodeReview.UsersBFF.Services.RegisterUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using Refit;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCarter();
builder.Services
    .AddRefitClient<IUserApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://codereview-users-api"));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<IRegisterUserService>()
    .AddClasses(classes => classes.AssignableTo<IRegisterUserService>())
    .AsImplementedInterfaces()
    .WithTransientLifetime());


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

WebApplication app = builder.Build();

app.MapCarter();


app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseExceptionHandler();

await app.RunAsync().ConfigureAwait(false);

