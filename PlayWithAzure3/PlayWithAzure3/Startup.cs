using System.Web.Http;
using Owin;
using PlayWithAzure3;

namespace AngularJSWebApiEmpty
{
    public class Startup
    {
        public void Configure(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}