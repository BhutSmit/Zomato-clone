var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Login

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Login

app.UseSession();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "Restaurant",
    pattern: "{area:exists}/{controller=Restaurant}/{action=RestaurantList}/{id?}");

app.MapControllerRoute(
    name: "FoodType",
    pattern: "{area:exists}/{controller=FoodType}/{action=RestaurentWiseFoodType}/{id?}");

app.MapControllerRoute(
    name: "Food",
    pattern: "{area:exists}/{controller=Food}/{action=FoodTypeWiseFood}/{id?}");

app.MapControllerRoute(
    name: "MST_User",
    pattern: "{area:exists}/{controller=MST_User}/{action=LoginForm}/{id?}");

app.MapControllerRoute(
    name: "LOC_Country",
    pattern: "{area:exists}/{controller=LOC_Country}/{action=CountryList}/{id?}");

app.MapControllerRoute(
    name: "LOC_State",
    pattern: "{area:exists}/{controller=LOC_State}/{action=StateList}/{id?}");

app.MapControllerRoute(
    name: "LOC_City",
    pattern: "{area:exists}/{controller=LOC_City}/{action=CityList}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();