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

app.MapControllerRoute(
    name: "manage",
    pattern: "{area=exists}/{controller=dashboard}/{action=index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");
app.Run();
