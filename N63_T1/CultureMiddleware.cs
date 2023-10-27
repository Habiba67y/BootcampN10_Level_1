using System.Globalization;

namespace N63_T1;

public class CultureMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    public CultureMiddleware(RequestDelegate request)
    {
        _requestDelegate = request;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var cultureQuery = context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            var culture = new CultureInfo(cultureQuery);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        var test = CultureInfo.CurrentCulture;

        await _requestDelegate(context);
    }
}
