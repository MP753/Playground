using Carter;
using CodeReview.UsersBFF.Api;
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


// Add services to the container.

WebApplication app = builder.Build();

app.MapCarter();


app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

await app.RunAsync().ConfigureAwait(false);

