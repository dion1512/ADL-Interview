using ADL.Data.Entities;
using ADL.Repositories;
using ADL.Repositories.Context;
using ADL.Repositories.Implementation;
using ADL.Repositories.Interfaces;
using ADL.Services.Implementations;
using ADL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewOptions(options => { options.HtmlHelperOptions.ClientValidationEnabled = true; }).AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Transient);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICalloutService, CalloutService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmailService, EmailService>();
var emailConfig = builder.Configuration.GetSection("EmailConfig").Get<EmailConfig>();
builder.Services.AddSingleton(emailConfig);

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
