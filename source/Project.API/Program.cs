using System.Reflection;
using Project.Infrastructure.Dependencies;

namespace Project.API
{
    /// <summary>
    /// Entry point for application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.RegisterApplication(builder.Configuration);
            builder.Services.AddSwaggerGen(options =>

            {

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);

            });


            var app = builder.Build();

            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
