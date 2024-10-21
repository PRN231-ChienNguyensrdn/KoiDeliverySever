using Microsoft.EntityFrameworkCore;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.Implementations;
using KoiDeliv.Service.Interface;
using Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext with dependency injection
builder.Services.AddDbContext<KoiDeliveryDBContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services and repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin() // or specify allowed origins, e.g., .WithOrigins("https://example.com")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && roleClaim.Value == "Admin")
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Staff", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Staff"))
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Student", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Student"))
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Lecture", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Lecture"))
            {
                return true;
            }
            return false;
        });
    });
});

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c2VydmVwZXJmZWN0bHljaGVlc2VxdWlja2NvYWNoY29sbGVjdHNsb3Bld2lzZWNhbWU=")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
