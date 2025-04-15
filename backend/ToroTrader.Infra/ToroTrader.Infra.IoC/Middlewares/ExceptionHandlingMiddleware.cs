using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ToroTrader.Application.Domain.Exceptions;

namespace ToroTrader.Infra.IoC.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException vex)
            {
                _logger.LogWarning(vex, "Erro de validação.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Erro de validação.",
                    Errors = vex.Errors.Select(msg => new { Error = msg })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Ocorreu um erro inesperado."
                });
            }
        }
    }

}
