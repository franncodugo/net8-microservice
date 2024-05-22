using SShoping.Frontend.Web.Controllers;
using SShoping.Frontend.Web.Services;
using SShoping.Frontend.Web.Services.Coupon;
using SShoping.Frontend.Web.Util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

#region HttpClient
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
StaticDetails.CouponAPIBaseUrl = builder.Configuration["ServiceUrls:CouponAPI"];
#endregion

#region Service Registration 
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
