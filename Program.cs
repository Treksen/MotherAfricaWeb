var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddAuthentication(); // optional
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication(); // optional
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Admin routes
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin", action = "Index" });

app.MapControllerRoute(
    name: "adminRegister",
    pattern: "admin/register",
    defaults: new { controller = "Admin", action = "AdminRegister" });

app.MapControllerRoute(
    name: "manageJobs",
    pattern: "admin/managejobs",
    defaults: new { controller = "Admin", action = "ManageJobs" });

app.MapControllerRoute(
    name: "manageUsers",
    pattern: "admin/manageusers",
    defaults: new { controller = "Admin", action = "ManageUsers" });

app.MapControllerRoute(
    name: "manageApplications",
    pattern: "admin/manageapplications",
    defaults: new { controller = "Admin", action = "ManageApplications" });

// Profile route
app.MapControllerRoute(
    name: "profile2",
    pattern: "profile2/{action=Index}/{id?}",
    defaults: new { controller = "Profile2", action = "Index" });

// Fallback for unknown paths (optional, good for SPA-style)
app.MapFallbackToController("Index", "Home");
// Tell Kestrel to listen on the Render port
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();
