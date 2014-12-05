using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Choice.Cenium.WebApi;
using ChoiceCenium;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Choice.Cenium.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration()
                {
                    EnableJSONP = true,
                    EnableDetailedErrors = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.


                map.RunSignalR(hubConfiguration);
            });
        }
    }
}