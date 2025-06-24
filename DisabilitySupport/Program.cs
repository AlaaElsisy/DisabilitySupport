
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.Mapping;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
 

namespace DisabilitySupport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            #endregion
            #region swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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

            // BLL
            builder.Services.AddScoped<BLL.Interfaces.IHelperService, BLL.Services.HelperService>();


            #endregion
            #region identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                       .AddEntityFrameworkStores<ApplicationDbContext>()
                       .AddDefaultTokenProviders();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
