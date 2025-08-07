using Carter;
using CodeReview.Users.Api.RegisterUser;
using CodeReview.Users.Api.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();


builder.Services.Scan(scan => scan
    .FromAssembliesOf(typeof(RegisterUserCommand))
    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
);

builder.Services.AddCarter();

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapCarter();

app.UseHttpsRedirection();

await app.RunAsync().ConfigureAwait(false);



