using Aspire.Hosting;
using Aspire.Hosting.Docker;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);
builder.AddDockerComposeEnvironment("compose");

IResourceBuilder<ProjectResource> usersApi = builder.AddProject<Projects.CodeReview_Users_Api>("codereview-users-api")
                                                    .PublishAsDockerComposeService((resource, service) =>
                                                    {
                                                        service.Name = "codereview-users-api"; 
                                                    });

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api")
       .WithReference(usersApi)
       .PublishAsDockerComposeService((resource, service) =>
       {
           service.Name = "codereview-usersbff-api"; 
       });

await builder.Build().RunAsync().ConfigureAwait(false);

