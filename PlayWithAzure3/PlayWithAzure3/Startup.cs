using System.Web.Http;
using Microsoft.Owin;
using Owin;
using PlayWithAzure3;

[assembly: OwinStartup(typeof(AngularJSWebApiEmpty.Startup))]

namespace AngularJSWebApiEmpty
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}