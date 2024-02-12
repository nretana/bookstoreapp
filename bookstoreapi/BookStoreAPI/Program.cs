using BookStore.API.Configuration;
using BookStore.API.DbContexts;
using BookStore.API.Entities.Account;
using BookStore.API.Services.Implementations;
using BookStore.API.Services.Interfaces;
using BookStore.API.TokenProviders;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(configure =>
{
    configure.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BookStoreDbConnectionString"]);
    });

builder.Services.AddOptions<JwtSettings>().BindConfiguration("JwtSettings")
                                          .ValidateDataAnnotations()
                                          .ValidateOnStart();

builder.Services.AddOptions<EmailConfiguration>().BindConfiguration("EmailConfiguration")
                                          .ValidateDataAnnotations()
                                          .ValidateOnStart();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<User, Role>(options =>
{
                        options.Password.RequiredLength = 7;
                        options.Password.RequireDigit = true;
                        options.Password.RequireNonAlphanumeric = true;
                        options.Password.RequireUppercase = true;

                        options.User.RequireUniqueEmail = true;

                        options.SignIn.RequireConfirmedEmail = true;

                        options.Tokens.EmailConfirmationTokenProvider = "EmailConfirmation";
                        options.Tokens.PasswordResetTokenProvider = "ResetPassword";

                        options.Lockout.AllowedForNewUsers = true;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(3);
                        options.Lockout.MaxFailedAccessAttempts = 3;
                    })
                    .AddEntityFrameworkStores<BookStoreContext>()
                    .AddDefaultTokenProviders()
                    .AddTokenProvider<EmailConfirmationTokenProvider<User>>("EmailConfirmation")
                    .AddTokenProvider<ResetPasswordTokenProvider<User>>("ResetPassword");

//set a lifespan for the generated token
//reset password
//two step verification
builder.Services.Configure<DataProtectionTokenProviderOptions>(options => {
    options.TokenLifespan = TimeSpan.FromMinutes(30);
});

//email token provider
builder.Services.Configure<EmailConfirmationTokenProviderOptions>(options =>
                    {
                        options.TokenLifespan = TimeSpan.FromMinutes(30);
                    });

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings?.ValidIssuer,
        ValidAudience = jwtSettings?.ValidAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.SecurityKey))
    };
});

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IFormatService, FormatService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(action =>
{
    action.AddSecurityDefinition("BookStoreApiAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme= "Bearer",
        Description = "Input a valid token to access this API"
    });

    action.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BookStoreApiAuth"
                }
            }, new List<string>()
        }
    });
});

var app = builder.Build();


app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithExposedHeaders("X-Pagination",
                                      "Location"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
