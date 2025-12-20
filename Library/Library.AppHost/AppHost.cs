var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo").AddDatabase("mongo-db");

var rentalGenerator = builder.AddProject<Projects.Library_RentalGenerator>("rental-generator");

builder.AddProject<Projects.Library_Api_Host>("library-api-host")
    .WithReference(db, "Library")
    .WithReference(rentalGenerator)
    .WaitFor(db)
    .WaitFor(rentalGenerator);

builder.Build().Run();