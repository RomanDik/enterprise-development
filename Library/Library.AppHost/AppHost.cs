var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo").AddDatabase("mongo-db");

builder.AddProject<Projects.Library_Api_Host>("library-api-host")
    .WithReference(db, "Library")
    .WaitFor(db);

builder.Build().Run();