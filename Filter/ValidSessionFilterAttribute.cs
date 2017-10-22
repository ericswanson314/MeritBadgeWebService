using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MeritBadgeWebService.Filter
{
    public class ValidSessionFilterAttribute : ActionFilterAttribute
    {
        public string ConfigSettingNames { get; set; }
        public string ConfigSettingValues { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.Request;
            IEnumerable<string> headerValues;
            var sessionId = string.Empty;
            if(request.Headers.TryGetValues("session", out headerValues))
            {
                sessionId = headerValues.FirstOrDefault();
            }
            base.OnActionExecuting(actionContext);
        }
    }
}