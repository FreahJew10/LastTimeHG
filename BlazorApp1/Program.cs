using BlazorApp1.Components;
using Microsoft.AspNetCore.ResponseCompression;
using BlazorApp1.Hubs;
using Microsoft.AspNetCore.Components;
using Blazored.Toast;
namespace BlazorApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });

            });
            /////
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            /////
            builder.Services.AddSignalR();

            // Register Blazored.Toast services
            builder.Services.AddBlazoredToast();

            // Register NotificationService using a factory.
         
            // The lambda fetches NavigationManager, constructs the absolute hub URL, and then instantiates the service.

            //builder.Services.AddScoped<NotificationService>(sp =>
            //{
            //    var navigationManager = sp.GetRequiredService<NavigationManager>();
            //    // Construct the absolute URL to your SignalR hub endpoint.
            //    var hubUrl = navigationManager.ToAbsoluteUri("/NotificationHub").ToString();
            //    return new NotificationService(hubUrl);
            //});

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            //app.UseResponseCompression();
            app.MapHub<ChatHub>("/chathub");
            app.MapHub<NotificationHub>("/NotificationHub");
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
           
            app.Run();
        }
    }
}
