IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api");

await builder.Build().RunAsync().ConfigureAwait(false);

