using Carter;
using CodeReview.UsersBFF.Api;
using CodeReview.UsersBFF.Services.RegisterUser;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCarter();
builder.Services.AddHttpClient();


builder.Services.AddHttpClient(HttpClientsNames.UsersApi);

builder.Services.AddScoped<IRegisterUserService>(sp =>
{
    HttpClient client = sp.GetRequiredService<IHttpClientFactory>()
                   .CreateClient(HttpClientsNames.UsersApi);
    return new RegisterUserService(client);
});


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

