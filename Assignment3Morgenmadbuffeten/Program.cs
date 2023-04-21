using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Assignment3Morgenmadbuffeten.Data;
using Assignment3Morgenmadsbuffeten.Hub;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BreakfastBuffetDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BreakfastBuffetDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 0;
});

builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Reception",
        policyBuilder => policyBuilder.RequireClaim("AccessReception")
    );
    options.AddPolicy("Restaurant",
        policyBuilder => policyBuilder.RequireClaim("AccessRestaurant"));

    options.AddPolicy("Kitchen",
        policyBuilder => policyBuilder.RequireClaim("AccessKitchen")
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<KitchenHub>("/KitchenHub");

app.Run();
