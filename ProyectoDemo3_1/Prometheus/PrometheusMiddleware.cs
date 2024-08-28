using Microsoft.AspNetCore.Http;
using Prometheus;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace ProyectoDemo3_1.Prometheus
{
    public class PrometheusMiddleware
    {
        private readonly RequestDelegate _next;

        public PrometheusMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    if (context.Request.Path == "/metrics")
        //    {
        //        var response = context.Response;
        //        response.ContentType = "text/plain; version=0.0.4; charset=utf-8";
        //        await Metrics.DefaultRegistry.CollectAndExportAsTextAsync(response.Body);
        //    }
        //    else
        //    {
        //        await _next(context);
        //    }
        //}
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/metrics")
            {
                var response = context.Response;
                response.ContentType = "text/plain; version=0.0.4; charset=utf-8";
                await Metrics.DefaultRegistry.CollectAndExportAsTextAsync(response.Body);
            }
            else
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    await _next(context);
                }
                finally
                {
                    stopwatch.Stop();
                    // Registra las métricas personalizadas
                    CustomMetrics.ApiRequests.Labels(context.Request.Path, context.Request.Method, context.Response.StatusCode.ToString()).Inc();
                    CustomMetrics.ApiDuration.Labels(context.Request.Path, context.Request.Method).Observe(stopwatch.Elapsed.TotalSeconds);
                }
            }
        }

    }
}
