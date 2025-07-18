var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeReview_UsersBFF_Api>("codereview-usersbff-api");

builder.AddProject<Projects.CodeReviewUsersBFF_Api>("codereviewusersbff-api");

builder.Build().Run();
