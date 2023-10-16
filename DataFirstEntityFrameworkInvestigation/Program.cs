// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

Console.WriteLine("Data First");

var configBuilder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

var configuration = configBuilder.Build();

string? connectionString = configuration.GetConnectionString("default");

