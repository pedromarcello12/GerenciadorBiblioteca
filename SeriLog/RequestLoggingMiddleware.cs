using System.Diagnostics;
using Serilog;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Tenta capturar o usuário logado (se houver autenticação configurada)
        var userName = context.User?.Identity?.IsAuthenticated == true
            ? context.User.Identity.Name
            : "Anônimo";

        // Captura o IP do cliente
        var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Desconhecido";

        try
        {
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();

            var elapsedMs = stopwatch.ElapsedMilliseconds;
            var request = context.Request;
            var response = context.Response;

            // Enriquecer o log com propriedades adicionais
            Log
                .ForContext("Usuario", userName)
                .ForContext("IP", clientIp)
                .ForContext("Path", request.Path)
                .ForContext("Metodo", request.Method)
                .Information(
                    "HTTP {Method} {Path} responded {StatusCode} in {Elapsed:0.0000} ms by {Usuario} from {IP}",
                    request.Method,
                    request.Path,
                    response.StatusCode,
                    elapsedMs,
                    userName,
                    clientIp
                );
        }
    }
}