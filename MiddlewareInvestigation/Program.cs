using MiddlewareInvestigation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseABTesting();

/*
app.Use(async (context, next) =>
{
    string path = context.Request.Path;

    if (path.StartsWith("/Marketing/Index"))
    {
        Random rg = new Random();
        int r = rg.Next(100);
        if (r < 50)
        {
            context.Response.Redirect("/Marketing/Message1");
        } else
        {
            context.Response.Redirect("/Marketing/Message2");
        }
        await next();
    } else
    {
        await next();
    }
});
*/


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
