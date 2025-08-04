IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api");

builder.AddProject<Projects.CodeReview_Users_Api>("codereview-users-api");

await builder.Build().RunAsync().ConfigureAwait(false);

