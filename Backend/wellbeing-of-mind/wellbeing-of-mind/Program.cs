
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using wellbeing_of_mind.Infastructure;

namespace wellbeing_of_mind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalityTestsDb"));
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            });
            // Add services to the container.
            builder.Services.AddScoped<ITestRepository, TestRepository>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
        }
    }
}