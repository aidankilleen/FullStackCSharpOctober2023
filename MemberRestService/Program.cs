using MemberDao;

var builder = WebApplication.CreateBuilder(args);

string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json", true)
    .AddUserSecrets<Program>();

var configuration = configBuilder.Build();


var connectionString = configuration.GetConnectionString("default");

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddSingleton<IMemberDao>(new InMemoryMemberDao());
builder.Services.AddSingleton<IMemberDao>(new SqlMemberDao(connectionString));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
