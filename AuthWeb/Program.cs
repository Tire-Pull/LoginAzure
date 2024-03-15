using AuthWeb.Components;
using AuthWeb.Session;

namespace AuthWeb {

    public class Program {

        public static void Main(string[] args) {
            CreateWebApplicationBuilder(args).Run();
        }

        private static WebApplication CreateWebApplicationBuilder(string[] args) {
            return ConfigureApp(ConfigureBuilder(WebApplication.CreateBuilder(args)).Build());
        }

        private static WebApplicationBuilder ConfigureBuilder(WebApplicationBuilder builder) {
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddSingleton<SessionState>(); ;
            return builder;
        }

        private static WebApplication ConfigureApp(WebApplication app) {
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            return app;
        }
    }
}
