using Wangkanai.Detection.Services;

namespace PB09.Middlewares
{
    public class BrowserMiddleware : IMiddleware
    {
       private readonly IDetectionService _detection;

        public BrowserMiddleware(IDetectionService detection)
        {
            _detection = detection; 
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var forbiddenBrowsers = new[] 
            {
                Wangkanai.Detection.Models.Browser.InternetExplorer,
                Wangkanai.Detection.Models.Browser.Edge
            };

            if (forbiddenBrowsers.Contains(_detection.Browser.Name))
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }

            await next(context);
        }
    }
}
