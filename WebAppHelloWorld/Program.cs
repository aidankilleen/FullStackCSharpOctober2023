using MemberDao;

string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json", true)
    .AddUserSecrets<Program>();

var configuration = configBuilder.Build();

string testValue = configuration.GetValue<string>("testvalue");

string connectionString = configuration.GetConnectionString("devcon");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add a Member DAO to the items that are available via dependency injection
//builder.Services.AddScoped<IMemberDao, SqlMemberDao>()
// builder.Services.AddSingleton<IMemberDao>(new InMemoryMemberDao());
builder.Services.AddSingleton<IMemberDao>(new SqlMemberDao(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
