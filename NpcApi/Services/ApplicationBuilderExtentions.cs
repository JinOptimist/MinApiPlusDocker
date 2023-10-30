using IApplicationLifetime = Microsoft.Extensions.Hosting.IApplicationLifetime;

namespace NpcApi.Services
{
    public static class ApplicationBuilderExtentions
    {
        //the simplest way to store a single long-living object, just for example.
        private static IMessageConsumer? _listener { get; set; }

        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            _listener = app.ApplicationServices.GetService<IMessageConsumer>();

            var lifetime = app.ApplicationServices.GetService<Microsoft.Extensions.Hosting.IApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);

            //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            lifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            _listener.StartListening();
        }

        private static void OnStopping()
        {
            _listener.StopListening();
        }
    }

}
