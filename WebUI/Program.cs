using Infra.IoC;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;

//    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();

//    seedUserRoleInitial.SeedRoles();
//    seedUserRoleInitial.SeedUsers();
//}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
