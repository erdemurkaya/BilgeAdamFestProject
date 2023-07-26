using Fest.Business.Managers;
using Fest.Business.Services;
using Fest.DAL.Abstract;
using Fest.DAL.Concrate;
using Fest.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<ICountryService, CountryManager>();

builder.Services.AddScoped<ICityService, CityManager>();

builder.Services.AddScoped<IMusicTypeService, MusicTypeManager>();

builder.Services.AddScoped<IArtistService, ArtistManager>();

builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<IArtistMusicTypeService, ArtistMusicTypeManager>();

builder.Services.AddScoped<IFestService,FestManager>();

builder.Services.AddScoped<IFestArtistService, FestArtistManager>();

builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<ITicketService, TicketManager>();

builder.Services.AddScoped<IPaymentService, PaymentManager>();



builder.Services.AddDataProtection();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath=new PathString("/");

});


var app = builder.Build();

app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "areas",
    pattern: ("{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"));

app.MapControllerRoute(
    name: "default",
    pattern: ("{Controller=Home}/{Action=Index}/{id?}"));



app.Run();
