using Prometheus;

namespace ProyectoDemo3_1.Prometheus
{
    public static class CustomMetrics
    {
        public static readonly Counter ApiRequests = Metrics.CreateCounter("api_requests_total", "Total number of API requests", new[] { "path", "method", "status_code" });
        public static readonly Histogram ApiDuration = Metrics.CreateHistogram("api_duration_seconds", "Histogram of API request durations", new[] { "path", "method" });
    }
}
