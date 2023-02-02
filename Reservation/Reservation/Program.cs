using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Reservation.Data;
using Reservation.Data.DataAccess;
using Reservation.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ReservationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ReservationContext") ?? throw new InvalidOperationException("Connection string 'ReservationContext' not found.")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        // scoped service 
        builder.Services.AddScoped<AppointmentDataAccess>();
        builder.Services.AddScoped<PaientDataAccess>();
        builder.Services.AddScoped<UserDataAccess>();
        builder.Services.AddScoped<Validate>();

        
        //add identity 
        builder.Services.AddIdentity<Reservation.Data.Tables.User, IdentityRole>()
            .AddEntityFrameworkStores<ReservationContext>().AddDefaultTokenProviders();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/auth/login");
                    options.AccessDeniedPath = new PathString("/auth/denied");
                });
        builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Auth/login");

        builder.Services.Configure<IdentityOptions>(options => {
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;

            //options.Lockout.MaxFailedAccessAttempts = 5;
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        });

        //builder.Services.AddIdentity<Reservation.Data.Tables.User, IdentityRole>(options =>
        //{
        //    options.User.RequireUniqueEmail = false;
        //});//.AddEntityFrameworkStores<ReservationContext>();
        //.AddDefaultTokenProviders();

        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MainProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
    }
}