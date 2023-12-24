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
            // Added cors to allow react (default http://localhost:3000) to connect  
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection"));
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            });


            // Add services to the container.
            builder.Services.AddScoped<ITestRepository, TestRepository>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
            CheckDatabaseConnection();
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
            app.MapControllers();
            app.UseCors();
            app.Run();

            // To check db connection - will be removed later
            void CheckDatabaseConnection()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var dbContext = services.GetRequiredService<TestDbContext>();
                        if (dbContext.Database.CanConnect())
                        {
                            Console.WriteLine("Database is connected!");
                        }
                        else
                        {
                            Console.WriteLine("Unable to connect to the database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while checking the database connection: {ex.Message}");
                    }
                }
            }
        }
    }
}