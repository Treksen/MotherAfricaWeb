var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

var builder2 = WebApplication.CreateBuilder(args);

var app2 = builder.Build();

// Other configurations...

app.MapControllerRoute(
    name: "profile2",
    pattern: "profile2/{action=Index}/{id?}");

app.Run();

app.MapControllerRoute(
    name: "adminRegister",
    pattern: "admin/register",
    defaults: new { controller = "Admin", action = "AdminRegister" });
app.Run();

var app3 = builder.Build();

// Configure the HTTP request pipeline.
if (!app3.Environment.IsDevelopment())
{
    app3.UseExceptionHandler("/Home/Error");
    app3.UseHsts();
}

app3.UseHttpsRedirection();
app3.UseStaticFiles();
app3.UseRouting();
app3.UseAuthentication(); // If you have authentication
app3.UseAuthorization();

app3.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app3.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin", action = "Index" }
);

app3.MapControllerRoute(
     name: "manageJobs",
     pattern: "Admin/ManageJobs",
     defaults: new { controller = "Admin", action = "ManageJobs" });
app3.MapControllerRoute(
     name: "manageUsers",
     pattern: "Admin/ManageUsers",
     defaults: new { controller = "Admin", action = "ManageUsers" });

app3.MapControllerRoute(
    name: "manageApplications",
    pattern: "Admin/ManageApplications",
    defaults: new { controller = "Admin", action = "ManageApplications" });
app3.Run();
