using Aspire.Hosting;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ProjectResource> usersApi = builder.AddProject<Projects.CodeReview_Users_Api>("codereview-users-api");

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api")
       .WithReference(usersApi);

await builder.Build().RunAsync().ConfigureAwait(false);

