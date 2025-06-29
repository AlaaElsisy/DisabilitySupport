using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.Mapping;
using DisabilitySupport.BLL.Services;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using DisabilitySupport.DAL.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DisabilitySupport.DAL.Models.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;



namespace DisabilitySupport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuiration = builder.Configuration;


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDisabledOfferRepository, DisabledOfferRepository>();
            builder.Services.AddScoped<IDisabledOfferService, DisabledOfferService>();
            builder.Services.AddScoped<IDisabledRepository, DisabledRepository>();
            builder.Services.AddScoped<IHelperRepository, HelperRepository>();
            builder.Services.AddScoped<IUserProfileService, UserProfileService>();


            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            #endregion
            #region swagger
            builder.Services.AddEndpointsApiExplorer();
            #region role based authorization configuration
            builder.Services.AddSwaggerGen(
                option =>
                {
                    option.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Disability Support API",
                        Version = "v1",
                        Description = "API for managing disability support services and requests."
                    });
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                }
                );
            #endregion
            #endregion

            #region db
            builder.Services.AddDbContext<ApplicationDbContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
            });
            #endregion

            #region  add repos
            // DAL
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
 
            builder.Services.AddScoped<IHelperRequestRepository, HelperRequestRepository>();
            builder.Services.AddScoped<DAL.Interfaces.IHelperServiceRepository, DAL.Repositories. HelperServiceRepository>();


            builder.Services.AddScoped<IDisabledRequestRepository, DisabledRequestRepository>();
 

            // BLL
            builder.Services.AddScoped<BLL.Interfaces.IHelperServicesService, BLL.Services.HelperServicesService>();
            builder.Services.AddScoped<BLL.Interfaces.IHelperRequestsService, BLL.Services.HelperRequestsService>();

            builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();

            //Unit Of Work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion
            #region identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                       .AddEntityFrameworkStores<ApplicationDbContext>()
                       .AddDefaultTokenProviders();

            #endregion

            builder.Services.Configure<DataProtectionTokenProviderOptions>(opts=>opts.TokenLifespan = TimeSpan.FromHours(10));

            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuiration["JWT:ValidAudience"],
                    ValidIssuer = configuiration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuiration["JWT:Secret"]))


                    };
                }
                );
            #endregion

            #region Email Configuration
            var emailConfig = configuiration
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailService, EmailService>();

            //required email
            builder.Services.Configure<IdentityOptions>(
                opt=>opt.SignIn.RequireConfirmedEmail = true
                );

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                #region swagger
                app.UseSwagger();
                app.UseSwaggerUI();
                #endregion
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
