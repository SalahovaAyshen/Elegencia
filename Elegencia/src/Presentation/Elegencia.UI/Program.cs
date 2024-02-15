using Elegencia.Application.ServiceRegistration;
using Elegencia.Persistence.Contexts;
using Elegencia.Persistence.ServiceRegistration;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    initializer.InitializeDbContext().Wait();
    initializer.CreateRoleAsync().Wait();
    initializer.InitializeAdmin().Wait();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");
app.Run();
