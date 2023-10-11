using System.Diagnostics;
using System.Text;
using API.Service;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => {
    var policy = new AuthorizationPolicyBuilder()
         .RequireAuthenticatedUser() // This tells our middleware that we require users to be authenticated before they can view the records.
         .Build(); // Builds the policy
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Configuration
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer("Data Source=DESKTOP-BQU5IHO;Initial Catalog=StudentManagement;Integrated Security=True;TrustServerCertificate=True;");
});

builder.Services.AddIdentityCore<AppUser>(opt => {
   opt.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<StudentDbContext>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
   opt.TokenValidationParameters = new TokenValidationParameters
   {
        ValidateIssuerSigningKey = true, 
        IssuerSigningKey = key, 
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try 
{
    var context = services.GetRequiredService<StudentDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch(Exception e)
{
    Debug.WriteLine(e);
}

app.Run();
