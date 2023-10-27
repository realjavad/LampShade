using ShopManagment.Configuration;

namespace ServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            ConfigurationManager configuration = builder.Configuration;
            ShopManagmentBootstraper.Configure(builder.Services,configuration.GetConnectionString("LampshadeDb"));

            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}