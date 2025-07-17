var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api");

builder.Build().Run();
