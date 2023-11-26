
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using wellbeing_of_mind.Infastructure;

namespace wellbeing_of_mind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //string mySqlConnectionStr = builder.Configuration.GetConnectionString("MyDatabaseConnection");

            //builder.Services.AddDbContext<TestDbContext>(options =>
            //{
            //    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
            //    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            //});

            builder.Services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mydatabaseconnection"));
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            });


            // Add services to the container.
            builder.Services.AddScoped<ITestRepository, TestRepository>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddCors(options =>
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
               
            }
                )

            ); ;

            builder.Services.AddControllers(configure =>
            configure.CacheProfiles.Add("Any-60",
                new CacheProfile
                {
                    Location = ResponseCacheLocation.Any,
                    Duration = 60
                }));
           
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddProblemDetails();

            builder.Services.AddResponseCaching();
            builder.Services.AddMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 

            app.UseResponseCaching();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}