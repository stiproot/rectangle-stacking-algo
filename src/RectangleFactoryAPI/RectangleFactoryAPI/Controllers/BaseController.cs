using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Algorithms;

namespace RectangleFactoryAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected virtual IHttpActionResult GenerateErrorResponse(Exception ex)
        {
            return Ok(new { opSuccess = false, errorMessage = ex.Message, stacktrace = ex.StackTrace });
        }
    }
}
