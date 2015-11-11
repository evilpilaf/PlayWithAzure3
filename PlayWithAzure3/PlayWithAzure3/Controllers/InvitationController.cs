using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSWebApiEmpty.Controllers
{
    public class InvitationController : ApiController
    {
        [HttpPost]
        [Route("api/subscribe")]
        public IHttpActionResult TrySubscribeToNewsletter()
        {
            return Ok();
        }
    }
}
