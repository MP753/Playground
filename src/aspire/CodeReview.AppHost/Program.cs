using Aspire.Hosting;
using Aspire.Hosting.Docker;
using Microsoft.Extensions.Configuration;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);
builder.AddDockerComposeEnvironment("compose");


string? keycloakAdmin = builder.Configuration.GetValue<string>("Keycloak:Admin");
string? keycloakPassword = builder.Configuration.GetValue<string>("Keycloak:Password");
ArgumentNullException.ThrowIfNullOrEmpty(keycloakAdmin);
ArgumentNullException.ThrowIfNullOrEmpty(keycloakPassword);

IResourceBuilder<KeycloakResource> keycloak = builder.AddKeycloak("keycloak", 8080)
                                                     .WithContainerName("keycloak")
                                                     .WithEnvironment("KEYCLOAK_ADMIN", keycloakAdmin)
                                                     .WithEnvironment("KEYCLOAK_ADMIN_PASSWORD", keycloakPassword)
                                                     .WithDataVolume();


IResourceBuilder<ProjectResource> usersApi = builder.AddProject<Projects.CodeReview_Users_Api>("codereview-users-api")
                                                    .WithReference(keycloak)    
                                                    .WaitFor(keycloak)
                                                    .PublishAsDockerComposeService((resource, service) =>
                                                    {
                                                        service.Name = "codereview-users-api"; 
                                                    });

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api")
       .WithReference(usersApi)
       .WithReference(keycloak)
       .WaitFor(keycloak)
       .PublishAsDockerComposeService((resource, service) =>
       {
           service.Name = "codereview-usersbff-api"; 
       });

await builder.Build().RunAsync().ConfigureAwait(false);

