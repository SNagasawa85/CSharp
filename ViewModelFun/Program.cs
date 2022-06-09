var builder = WebApplication.CreateBuilder(args);
// add services to the container here
builder.Services.AddControllersWithViews();

var app = builder.Build();
// check if in development environment
if (!app.Environment.IsDevelopment())
{
    // use execptionhandler to show errors/exceptions rather then hide them (dev vs end user)
    app.UseExceptionHandler("/Home/Error");
}
// use static files...
app.UseStaticFiles();
// use routing (move it out of program.cs)
app.UseRouting();
// use authorization 
app.UseAuthorization();

// the below line comes as the boiler plate, but needs to be changed for MVC usage
// app.MapGet("/", () => "Hello World!");
// instead of app.MapGet() we need to use app.MapControllerRoute()
// this allows us to use controller files to route us

// using pattern will allow us to specify the methods used in our controller files.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();