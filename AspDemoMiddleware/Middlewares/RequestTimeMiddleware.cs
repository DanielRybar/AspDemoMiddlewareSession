namespace AspDemoMiddleware.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next; // odkaz na dalsi middleware v sekvenci
        private readonly ILogger<RequestTimeMiddleware> _logger; // logger

        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // zaznamenani casu pred zpracovanim pozadavku
            DateTime start = DateTime.Now;
            // predani pozadavku dalsimu middleware v pipeline
            await _next(context).ConfigureAwait(false);
            // zaznamenani casu po zpracovani pozadavku
            DateTime end = DateTime.Now;
            // doba trvani
            TimeSpan duration = end - start;
            // vypis do konzole
            Console.WriteLine($"Pozadavek {context.Request.Path} trval {duration.TotalMilliseconds} ms.");

            // vypis do logu
            _logger.LogInformation($"Pozadavek {context.Request.Path} trval {duration.TotalMilliseconds} ms.");
        }
    }

    // vytvoreni extension metody pro pouziti middleware
    public static class RequestTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeMiddleware>();
        }
    }
}