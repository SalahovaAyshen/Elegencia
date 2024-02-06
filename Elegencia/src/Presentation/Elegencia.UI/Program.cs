using Elegencia.Persistence.ServiceRegistration;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

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
