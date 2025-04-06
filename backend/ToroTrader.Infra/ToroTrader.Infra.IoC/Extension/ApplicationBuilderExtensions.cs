using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToroTrader.Infra.Messaging;

namespace ToroTrader.Infra.IoC.Extension
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            var serviceProvider = app.ApplicationServices;

            IServiceScope scope = null;

            lifetime.ApplicationStarted.Register(() =>
            {
                scope = serviceProvider.CreateScope();
                var consumerSubscriptions = scope.ServiceProvider.GetRequiredService<IConsumerSubscriptions>();
                consumerSubscriptions.Subscribe();
            });

            lifetime.ApplicationStopping.Register(() =>
            {
                if (scope != null)
                {
                    var consumerSubscriptions = scope.ServiceProvider.GetRequiredService<IConsumerSubscriptions>();
                    consumerSubscriptions.Unsubscribe();
                    scope.Dispose(); // Libera o escopo apenas no shutdown
                }
            });

            return app;
        }
    }
}
